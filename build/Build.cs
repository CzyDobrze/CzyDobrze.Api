using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Docker;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.EntityFramework;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.EntityFramework.EntityFrameworkTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("Tag for docker image")] readonly string Tag;
    
    [Parameter("DbContext name")] readonly string DbContext;
    [Parameter("Migration reason")] readonly string MigrationReason;

    [Solution] readonly Solution Solution;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath OutputDirectory => RootDirectory / "output";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(OutputDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target BuildDockerImage => _ => _
        .Executes(() =>
        {
            DockerTasks.DockerBuild(s => s
                .SetTag(Tag)
                .SetPath(Solution.Directory)
            );
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoBuild()
                .EnableNoRestore()
            );
        });
    
        Target DbUpdate => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            var output = EntityFrameworkDbContextList(settings =>
                settings
                    .SetStartupProject(Solution.GetProject("CzyDobrze.Api")?.Directory)
                    .SetProject(Solution.GetProject("CzyDobrze.Infrastructure")?.Directory)
                    .DisableProcessLogOutput()
                    .SetProcessArgumentConfigurator(x => x.Add("--no-build")));
            var failure = output.Any(x => x.Type != OutputType.Std);
            if (failure)
            {
                Logger.Warn(output.Select(x => x.Text).Aggregate((s1, s2) => s1 + "\n" + s2));
            }
            else
            {
                var dbContexts = output.Select(x => x.Text);
                foreach (var dbContext in dbContexts)
                {
                    EntityFrameworkDatabaseUpdate(settings =>
                        settings
                            .SetStartupProject(Solution.GetProject("CzyDobrze.Api")?.Directory)
                            .SetProject(Solution.GetProject("CzyDobrze.Infrastructure")?.Directory)
                            .SetContext(dbContext)
                            .DisableProcessLogOutput()
                            .SetProcessArgumentConfigurator(x => x.Add("--no-build")));
                }
            }
        });
        
    Target AddMigration => _ => _
        .Requires(()=>DbContext)
        .Requires(()=>MigrationReason)
        .DependsOn(Compile)
        .Executes(() =>
        {
            EntityFrameworkMigrationsAdd(s => s
                .SetStartupProject(Solution.GetProject("CzyDobrze.Api")?.Directory)
                .SetContext(DbContext)
                .SetName(MigrationReason)
                .SetProcessArgumentConfigurator(x => x
                    .Add("--no-build")
                    .Add("--project "+Solution.GetProject("CzyDobrze.Infrastructure")?.Directory)));
        });


}

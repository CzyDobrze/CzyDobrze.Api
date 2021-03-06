using CzyDobrze.Domain.Users.Contributor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CzyDobrze.Infrastructure.Persistence.TypeConfigurations.Users
{
    public class ContributorTypeConfiguration : IEntityTypeConfiguration<Contributor>
    {
        public void Configure(EntityTypeBuilder<Contributor> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.ToSqlQuery("SELECT Id, Created, Updated, DisplayName, Points FROM Users WHERE IsContributor = 1");
            builder.ToView("Contributors");

            builder.Property(x => x.Created);
            builder.Property(x => x.DisplayName);
        }
    }
}
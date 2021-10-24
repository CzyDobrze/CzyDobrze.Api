using CzyDobrze.Domain.Users.Moderator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CzyDobrze.Infrastructure.Persistence.TypeConfigurations.Users
{
    public class ModeratorTypeConfiguration : IEntityTypeConfiguration<Moderator>
    {
        public void Configure(EntityTypeBuilder<Moderator> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToSqlQuery("Select Id, Created, Updated FROM Users Where IsModerator = 1");
            builder.ToView("Moderator");
        }
    }
}
using CzyDobrze.Domain.Content.Answer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CzyDobrze.Infrastructure.Persistence.TypeConfigurations.Content
{
    public class AnswerTypeConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder
                .HasOne(x => x.Author)
                .WithMany()
                .IsRequired();
                
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Created)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            
            builder.Property(x => x.Updated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
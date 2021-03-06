using CzyDobrze.Domain.Content.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CzyDobrze.Infrastructure.Persistence.TypeConfigurations.Content.Comments
{
    public class ExerciseCommentTypeConfiguration : IEntityTypeConfiguration<ExerciseComment>
    {
        public void Configure(EntityTypeBuilder<ExerciseComment> builder)
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
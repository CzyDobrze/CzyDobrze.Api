using CzyDobrze.Domain.Content.Vote;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CzyDobrze.Infrastructure.Persistence.TypeConfigurations.Content.Votes
{
    public class ExerciseCommentVoteTypeConfiguration : IEntityTypeConfiguration<ExerciseCommentVote>
    {
        public void Configure(EntityTypeBuilder<ExerciseCommentVote> builder)
        {
            builder
                .HasOne(x => x.Voter)
                .WithMany()
                .IsRequired();
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Created)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.Updated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.Value)
                .HasColumnType("int");
        }
    }
}
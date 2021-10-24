﻿// <auto-generated />
using System;
using CzyDobrze.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CzyDobrze.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211024143213_AddDbUser")]
    partial class AddDbUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("CzyDobrze.Domain.Content.Answer.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Accepted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid?>("ExerciseId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Comment.AnswerComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AnswerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.ToTable("AnswerComments");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Comment.ExerciseComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid?>("ExerciseId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseComments");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Exercise.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("InBookId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Section.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TextbookId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("TextbookId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Textbook.Textbook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClassYear")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Publisher")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("Textbooks");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Vote.AnswerCommentVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.ToTable("AnswerCommentVote");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Vote.AnswerVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AnswerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.ToTable("AnswerVote");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Vote.ExerciseCommentVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.ToTable("ExerciseCommentVote");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Users.Contributor.Contributor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b
                        .HasAnnotation("Relational:SqlQuery", "Select Id, Created, Updated, DisplayName, Points FROM Users WHERE IsContributor = 1");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Users.Moderator.Moderator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b
                        .HasAnnotation("Relational:SqlQuery", "Select Id, Created, Updated FROM Users Where IsModerator = 1");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Users.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b
                        .HasAnnotation("Relational:SqlQuery", "SELECT Id, Created, Updated, DisplayName FROM Users");
                });

            modelBuilder.Entity("CzyDobrze.Infrastructure.Persistence.Identity.DbUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Auth0Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsContributor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsModerator")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Answer.Answer", b =>
                {
                    b.HasOne("CzyDobrze.Domain.Content.Exercise.Exercise", "Exercise")
                        .WithMany("Answers")
                        .HasForeignKey("ExerciseId");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Comment.AnswerComment", b =>
                {
                    b.HasOne("CzyDobrze.Domain.Content.Answer.Answer", "Answer")
                        .WithMany("AnswerComments")
                        .HasForeignKey("AnswerId");

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Comment.ExerciseComment", b =>
                {
                    b.HasOne("CzyDobrze.Domain.Content.Exercise.Exercise", "Exercise")
                        .WithMany("Comments")
                        .HasForeignKey("ExerciseId");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Exercise.Exercise", b =>
                {
                    b.HasOne("CzyDobrze.Domain.Content.Section.Section", "Section")
                        .WithMany("Exercises")
                        .HasForeignKey("SectionId");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Section.Section", b =>
                {
                    b.HasOne("CzyDobrze.Domain.Content.Textbook.Textbook", "Textbook")
                        .WithMany("Sections")
                        .HasForeignKey("TextbookId");

                    b.Navigation("Textbook");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Vote.AnswerCommentVote", b =>
                {
                    b.HasOne("CzyDobrze.Domain.Content.Comment.AnswerComment", "Comment")
                        .WithMany("Votes")
                        .HasForeignKey("CommentId");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Vote.AnswerVote", b =>
                {
                    b.HasOne("CzyDobrze.Domain.Content.Answer.Answer", "Answer")
                        .WithMany("Votes")
                        .HasForeignKey("AnswerId");

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Vote.ExerciseCommentVote", b =>
                {
                    b.HasOne("CzyDobrze.Domain.Content.Comment.ExerciseComment", "Comment")
                        .WithMany("Votes")
                        .HasForeignKey("CommentId");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Answer.Answer", b =>
                {
                    b.Navigation("AnswerComments");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Comment.AnswerComment", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Comment.ExerciseComment", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Exercise.Exercise", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Section.Section", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("CzyDobrze.Domain.Content.Textbook.Textbook", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}

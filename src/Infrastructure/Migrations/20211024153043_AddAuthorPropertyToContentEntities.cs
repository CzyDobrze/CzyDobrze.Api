using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CzyDobrze.Infrastructure.Migrations
{
    public partial class AddAuthorPropertyToContentEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VoterId",
                table: "ExerciseCommentVote",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "ExerciseComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VoterId",
                table: "AnswerVote",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Answers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VoterId",
                table: "AnswerCommentVote",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "AnswerComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCommentVote_VoterId",
                table: "ExerciseCommentVote",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseComments_AuthorId",
                table: "ExerciseComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerVote_VoterId",
                table: "AnswerVote",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AuthorId",
                table: "Answers",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerCommentVote_VoterId",
                table: "AnswerCommentVote",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerComments_AuthorId",
                table: "AnswerComments",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExerciseCommentVote_VoterId",
                table: "ExerciseCommentVote");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseComments_AuthorId",
                table: "ExerciseComments");

            migrationBuilder.DropIndex(
                name: "IX_AnswerVote_VoterId",
                table: "AnswerVote");

            migrationBuilder.DropIndex(
                name: "IX_Answers_AuthorId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_AnswerCommentVote_VoterId",
                table: "AnswerCommentVote");

            migrationBuilder.DropIndex(
                name: "IX_AnswerComments_AuthorId",
                table: "AnswerComments");

            migrationBuilder.DropColumn(
                name: "VoterId",
                table: "ExerciseCommentVote");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ExerciseComments");

            migrationBuilder.DropColumn(
                name: "VoterId",
                table: "AnswerVote");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "VoterId",
                table: "AnswerCommentVote");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AnswerComments");
        }
    }
}

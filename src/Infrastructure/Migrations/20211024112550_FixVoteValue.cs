using Microsoft.EntityFrameworkCore.Migrations;

namespace CzyDobrze.Infrastructure.Migrations
{
    public partial class FixVoteValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "ExerciseCommentVote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "AnswerVote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "AnswerCommentVote",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ExerciseCommentVote");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "AnswerVote");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "AnswerCommentVote");
        }
    }
}

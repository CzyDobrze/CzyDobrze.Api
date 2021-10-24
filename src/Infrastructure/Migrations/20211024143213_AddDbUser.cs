using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CzyDobrze.Infrastructure.Migrations
{
    public partial class AddDbUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Points = table.Column<uint>(type: "INTEGER", nullable: false),
                    Auth0Id = table.Column<string>(type: "TEXT", nullable: true),
                    IsContributor = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsModerator = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatGPTModeration.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommnetId = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommnetId);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommnetId", "Approved", "Comment" },
                values: new object[] { new Guid("5530d53a-5c47-4448-ab8b-08a3aebba9a0"), true, "How are you?" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}

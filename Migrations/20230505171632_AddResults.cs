using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatGPTModeration.Migrations
{
    public partial class AddResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommnetId",
                keyValue: new Guid("5530d53a-5c47-4448-ab8b-08a3aebba9a0"));

            migrationBuilder.AddColumn<string>(
                name: "ChatGPTResults",
                table: "Comments",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommnetId", "Approved", "ChatGPTResults", "Comment" },
                values: new object[] { new Guid("0a5e8e69-c241-441b-b72d-59839a0d588c"), true, null, "How are you?" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommnetId",
                keyValue: new Guid("0a5e8e69-c241-441b-b72d-59839a0d588c"));

            migrationBuilder.DropColumn(
                name: "ChatGPTResults",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommnetId", "Approved", "Comment" },
                values: new object[] { new Guid("5530d53a-5c47-4448-ab8b-08a3aebba9a0"), true, "How are you?" });
        }
    }
}

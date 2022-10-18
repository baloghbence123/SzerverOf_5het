using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzerverOf_5het.Data.Migrations
{
    public partial class hirdetes_mod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Hirdetesek",
                newName: "Pos");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hirdetesek",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Oraber",
                table: "Hirdetesek",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hirdetesek");

            migrationBuilder.DropColumn(
                name: "Oraber",
                table: "Hirdetesek");

            migrationBuilder.RenameColumn(
                name: "Pos",
                table: "Hirdetesek",
                newName: "Title");
        }
    }
}

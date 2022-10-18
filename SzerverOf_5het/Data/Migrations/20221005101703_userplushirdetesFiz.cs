using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzerverOf_5het.Data.Migrations
{
    public partial class userplushirdetesFiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Oraber",
                table: "Hirdetesek",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MinSal",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinSal",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Oraber",
                table: "Hirdetesek",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

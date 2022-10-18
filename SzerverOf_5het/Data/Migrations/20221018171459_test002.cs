using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzerverOf_5het.Data.Migrations
{
    public partial class test002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HirdetesUid",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HirdetesUid",
                table: "AspNetUsers",
                column: "HirdetesUid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hirdetesek_HirdetesUid",
                table: "AspNetUsers",
                column: "HirdetesUid",
                principalTable: "Hirdetesek",
                principalColumn: "Uid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hirdetesek_HirdetesUid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HirdetesUid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HirdetesUid",
                table: "AspNetUsers");
        }
    }
}

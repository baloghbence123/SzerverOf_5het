using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzerverOf_5het.Data.Migrations
{
    public partial class lazy_loading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Hirdetesek",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Hirdetesek_OwnerId",
                table: "Hirdetesek",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hirdetesek_AspNetUsers_OwnerId",
                table: "Hirdetesek",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hirdetesek_AspNetUsers_OwnerId",
                table: "Hirdetesek");

            migrationBuilder.DropIndex(
                name: "IX_Hirdetesek_OwnerId",
                table: "Hirdetesek");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Hirdetesek",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

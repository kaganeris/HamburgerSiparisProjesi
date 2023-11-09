using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.DAL.Migrations
{
    public partial class asdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sepettekiler_AspNetUsers_AppUserId",
                table: "Sepettekiler");

            migrationBuilder.DropIndex(
                name: "IX_Sepettekiler_AppUserId",
                table: "Sepettekiler");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Sepettekiler");

            migrationBuilder.DropColumn(
                name: "MenuAdi",
                table: "Sepettekiler");

            migrationBuilder.RenameColumn(
                name: "MenuNumarasi",
                table: "Sepettekiler",
                newName: "MenuID");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Sepettekiler",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_MenuID",
                table: "Sepettekiler",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_UserId",
                table: "Sepettekiler",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sepettekiler_AspNetUsers_UserId",
                table: "Sepettekiler",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sepettekiler_Menuler_MenuID",
                table: "Sepettekiler",
                column: "MenuID",
                principalTable: "Menuler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sepettekiler_AspNetUsers_UserId",
                table: "Sepettekiler");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepettekiler_Menuler_MenuID",
                table: "Sepettekiler");

            migrationBuilder.DropIndex(
                name: "IX_Sepettekiler_MenuID",
                table: "Sepettekiler");

            migrationBuilder.DropIndex(
                name: "IX_Sepettekiler_UserId",
                table: "Sepettekiler");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sepettekiler");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "Sepettekiler",
                newName: "MenuNumarasi");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Sepettekiler",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuAdi",
                table: "Sepettekiler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_AppUserId",
                table: "Sepettekiler",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sepettekiler_AspNetUsers_AppUserId",
                table: "Sepettekiler",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.DAL.Migrations
{
    public partial class asdas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sepettekiler_Menuler_MenuID",
                table: "Sepettekiler");

            migrationBuilder.AlterColumn<int>(
                name: "MenuID",
                table: "Sepettekiler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ExtraMalzemeID",
                table: "Sepettekiler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_ExtraMalzemeID",
                table: "Sepettekiler",
                column: "ExtraMalzemeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sepettekiler_ExtraMalzemeler_ExtraMalzemeID",
                table: "Sepettekiler",
                column: "ExtraMalzemeID",
                principalTable: "ExtraMalzemeler",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sepettekiler_Menuler_MenuID",
                table: "Sepettekiler",
                column: "MenuID",
                principalTable: "Menuler",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sepettekiler_ExtraMalzemeler_ExtraMalzemeID",
                table: "Sepettekiler");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepettekiler_Menuler_MenuID",
                table: "Sepettekiler");

            migrationBuilder.DropIndex(
                name: "IX_Sepettekiler_ExtraMalzemeID",
                table: "Sepettekiler");

            migrationBuilder.DropColumn(
                name: "ExtraMalzemeID",
                table: "Sepettekiler");

            migrationBuilder.AlterColumn<int>(
                name: "MenuID",
                table: "Sepettekiler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sepettekiler_Menuler_MenuID",
                table: "Sepettekiler",
                column: "MenuID",
                principalTable: "Menuler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

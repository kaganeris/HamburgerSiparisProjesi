using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Boyut",
                table: "Menuler");

            migrationBuilder.AddColumn<int>(
                name: "Boyut",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Boyut",
                table: "Siparisler");

            migrationBuilder.AddColumn<int>(
                name: "Boyut",
                table: "Menuler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

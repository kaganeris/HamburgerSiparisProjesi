using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.DAL.Migrations
{
    public partial class asdas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "SiparislerMenuler");

            migrationBuilder.DropColumn(
                name: "GuncellemeZamani",
                table: "SiparislerMenuler");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "SiparislerMenuler");

            migrationBuilder.DropColumn(
                name: "OlusturmaZamani",
                table: "SiparislerMenuler");

            migrationBuilder.DropColumn(
                name: "SilinmeZamani",
                table: "SiparislerMenuler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "SiparislerMenuler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeZamani",
                table: "SiparislerMenuler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "SiparislerMenuler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturmaZamani",
                table: "SiparislerMenuler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeZamani",
                table: "SiparislerMenuler",
                type: "datetime2",
                nullable: true);
        }
    }
}

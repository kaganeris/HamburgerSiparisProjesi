using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.DAL.Migrations
{
    public partial class siparisMenulerIdEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SiparislerMenuler",
                table: "SiparislerMenuler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtraMalzemelerSiparisler",
                table: "ExtraMalzemelerSiparisler");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "SiparislerMenuler",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ExtraMalzemelerSiparisler",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiparislerMenuler",
                table: "SiparislerMenuler",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtraMalzemelerSiparisler",
                table: "ExtraMalzemelerSiparisler",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparislerMenuler_SiparisID",
                table: "SiparislerMenuler",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMalzemelerSiparisler_ExtraMalzemeID",
                table: "ExtraMalzemelerSiparisler",
                column: "ExtraMalzemeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SiparislerMenuler",
                table: "SiparislerMenuler");

            migrationBuilder.DropIndex(
                name: "IX_SiparislerMenuler_SiparisID",
                table: "SiparislerMenuler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtraMalzemelerSiparisler",
                table: "ExtraMalzemelerSiparisler");

            migrationBuilder.DropIndex(
                name: "IX_ExtraMalzemelerSiparisler_ExtraMalzemeID",
                table: "ExtraMalzemelerSiparisler");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "SiparislerMenuler");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ExtraMalzemelerSiparisler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiparislerMenuler",
                table: "SiparislerMenuler",
                columns: new[] { "SiparisID", "MenuID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtraMalzemelerSiparisler",
                table: "ExtraMalzemelerSiparisler",
                columns: new[] { "ExtraMalzemeID", "SiparisID" });
        }
    }
}

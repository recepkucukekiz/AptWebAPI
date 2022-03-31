using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AptWebAPI.Migrations
{
    public partial class InitialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartmans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartmans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kiracis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoyAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiraciMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiracis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yoneticis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoyAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoneticis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yoneticis_Apartmans_ApartmanId",
                        column: x => x.ApartmanId,
                        principalTable: "Apartmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Daires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kat = table.Column<short>(type: "smallint", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    ApartmanId = table.Column<int>(type: "int", nullable: false),
                    KiraciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Daires_Apartmans_ApartmanId",
                        column: x => x.ApartmanId,
                        principalTable: "Apartmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Daires_Kiracis_KiraciId",
                        column: x => x.KiraciId,
                        principalTable: "Kiracis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aidats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tutar = table.Column<double>(type: "float", nullable: false),
                    OdendiMi = table.Column<bool>(type: "bit", nullable: false),
                    Donem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aidats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aidats_Daires_DaireId",
                        column: x => x.DaireId,
                        principalTable: "Daires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aidats_DaireId",
                table: "Aidats",
                column: "DaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Daires_ApartmanId",
                table: "Daires",
                column: "ApartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Daires_KiraciId",
                table: "Daires",
                column: "KiraciId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yoneticis_ApartmanId",
                table: "Yoneticis",
                column: "ApartmanId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aidats");

            migrationBuilder.DropTable(
                name: "Yoneticis");

            migrationBuilder.DropTable(
                name: "Daires");

            migrationBuilder.DropTable(
                name: "Apartmans");

            migrationBuilder.DropTable(
                name: "Kiracis");
        }
    }
}

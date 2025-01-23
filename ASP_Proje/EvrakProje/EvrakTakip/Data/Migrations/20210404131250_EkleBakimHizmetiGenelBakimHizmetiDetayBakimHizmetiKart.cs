using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvrakTakip.Data.Migrations
{
    public partial class EkleBakimHizmetiGenelBakimHizmetiDetayBakimHizmetiKart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakimHizmetiGenel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvrakSayacSaat = table.Column<double>(nullable: false),
                    ToplamFiyat = table.Column<double>(nullable: false),
                    Detaylar = table.Column<string>(nullable: true),
                    EklendigiTarih = table.Column<DateTime>(nullable: false),
                    EvrakId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimHizmetiGenel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BakimHizmetiGenel_Evrak_EvrakId",
                        column: x => x.EvrakId,
                        principalTable: "Evrak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BakimHizmetKart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvrakId = table.Column<int>(nullable: false),
                    EvrakTipiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimHizmetKart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BakimHizmetKart_Evrak_EvrakId",
                        column: x => x.EvrakId,
                        principalTable: "Evrak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakimHizmetKart_EvrakTipi_EvrakTipiId",
                        column: x => x.EvrakTipiId,
                        principalTable: "EvrakTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BakimHizmetiDetay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BakimHizmetiGenelId = table.Column<int>(nullable: false),
                    EvrakTipiId = table.Column<int>(nullable: false),
                    EvrakFiyati = table.Column<double>(nullable: false),
                    EvrakAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimHizmetiDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BakimHizmetiDetay_BakimHizmetiGenel_BakimHizmetiGenelId",
                        column: x => x.BakimHizmetiGenelId,
                        principalTable: "BakimHizmetiGenel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakimHizmetiDetay_EvrakTipi_EvrakTipiId",
                        column: x => x.EvrakTipiId,
                        principalTable: "EvrakTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetiDetay_BakimHizmetiGenelId",
                table: "BakimHizmetiDetay",
                column: "BakimHizmetiGenelId");

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetiDetay_EvrakTipiId",
                table: "BakimHizmetiDetay",
                column: "EvrakTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetiGenel_EvrakId",
                table: "BakimHizmetiGenel",
                column: "EvrakId");

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetKart_EvrakId",
                table: "BakimHizmetKart",
                column: "EvrakId");

            migrationBuilder.CreateIndex(
                name: "IX_BakimHizmetKart_EvrakTipiId",
                table: "BakimHizmetKart",
                column: "EvrakTipiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakimHizmetiDetay");

            migrationBuilder.DropTable(
                name: "BakimHizmetKart");

            migrationBuilder.DropTable(
                name: "BakimHizmetiGenel");
        }
    }
}

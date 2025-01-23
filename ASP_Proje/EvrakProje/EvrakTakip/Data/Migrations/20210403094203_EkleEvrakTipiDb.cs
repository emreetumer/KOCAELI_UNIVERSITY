using Microsoft.EntityFrameworkCore.Migrations;

namespace EvrakTakip.Data.Migrations
{
    public partial class EkleEvrakTipiDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvrakTipi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvrakAdi = table.Column<string>(nullable: false),
                    EvrakFiyati = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvrakTipi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvrakTipi");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuveszetiGaleriaApi.Migrations
{
    /// <inheritdoc />
    public partial class innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kiallitasok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomName = table.Column<string>(type: "TEXT", nullable: false),
                    Felelos = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiallitasok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muveszek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muveszek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mualkotasok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MuveszId = table.Column<int>(type: "INTEGER", nullable: false),
                    KiallitasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mualkotasok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mualkotasok_Kiallitasok_KiallitasId",
                        column: x => x.KiallitasId,
                        principalTable: "Kiallitasok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mualkotasok_Muveszek_MuveszId",
                        column: x => x.MuveszId,
                        principalTable: "Muveszek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mualkotasok_KiallitasId",
                table: "Mualkotasok",
                column: "KiallitasId");

            migrationBuilder.CreateIndex(
                name: "IX_Mualkotasok_MuveszId",
                table: "Mualkotasok",
                column: "MuveszId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mualkotasok");

            migrationBuilder.DropTable(
                name: "Kiallitasok");

            migrationBuilder.DropTable(
                name: "Muveszek");
        }
    }
}

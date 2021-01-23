using Microsoft.EntityFrameworkCore.Migrations;

namespace SerwisSamochodowy.Migrations
{
    public partial class migracja1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mechaniks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechaniks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Samochods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rejestracja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samochods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samochods_Klients_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zlecenies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisUsterki = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktywne = table.Column<bool>(type: "bit", nullable: false),
                    IdSamochodu = table.Column<int>(type: "int", nullable: false),
                    IdMechanika = table.Column<int>(type: "int", nullable: false),
                    SamochodId = table.Column<int>(type: "int", nullable: true),
                    MechanikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zlecenies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zlecenies_Mechaniks_MechanikId",
                        column: x => x.MechanikId,
                        principalTable: "Mechaniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zlecenies_Samochods_SamochodId",
                        column: x => x.SamochodId,
                        principalTable: "Samochods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samochods_KlientId",
                table: "Samochods",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenies_MechanikId",
                table: "Zlecenies",
                column: "MechanikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenies_SamochodId",
                table: "Zlecenies",
                column: "SamochodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zlecenies");

            migrationBuilder.DropTable(
                name: "Mechaniks");

            migrationBuilder.DropTable(
                name: "Samochods");

            migrationBuilder.DropTable(
                name: "Klients");
        }
    }
}

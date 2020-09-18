using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRPUA.Server.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulica = table.Column<string>(nullable: true),
                    Broj = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    PosBroj = table.Column<string>(nullable: true),
                    Drzava = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrimalacUslugas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    KontaktTel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AdresaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimalacUslugas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrimalacUslugas_Adresas_AdresaID",
                        column: x => x.AdresaID,
                        principalTable: "Adresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Drzava", "Grad", "PosBroj", "Ulica" },
                values: new object[] { 1, "13", "Srbija", "Novi Pazar", "36300", "Mehmeda Alibašića" });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Drzava", "Grad", "PosBroj", "Ulica" },
                values: new object[] { 2, "BB", "Srbija", "Novi Pazar", "36300", "Kragujevačka" });

            migrationBuilder.CreateIndex(
                name: "IX_PrimalacUslugas_AdresaID",
                table: "PrimalacUslugas",
                column: "AdresaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrimalacUslugas");

            migrationBuilder.DropTable(
                name: "Adresas");
        }
    }
}

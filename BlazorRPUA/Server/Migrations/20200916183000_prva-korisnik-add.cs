using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRPUA.Server.Migrations
{
    public partial class prvakorisnikadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PrimalacUslugas",
                columns: new[] { "ID", "AdresaID", "Email", "Ime", "KontaktTel", "Prezime" },
                values: new object[] { 1, null, "esad@dr.com", "Esad", "063614616", "Međedović" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PrimalacUslugas",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRPUA.Server.Migrations
{
    public partial class unikatEmailKontaktTel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KontaktTel",
                table: "PrimalacUslugas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "PrimalacUslugas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrimalacUslugas_Email",
                table: "PrimalacUslugas",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PrimalacUslugas_KontaktTel",
                table: "PrimalacUslugas",
                column: "KontaktTel",
                unique: true,
                filter: "[KontaktTel] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PrimalacUslugas_Email",
                table: "PrimalacUslugas");

            migrationBuilder.DropIndex(
                name: "IX_PrimalacUslugas_KontaktTel",
                table: "PrimalacUslugas");

            migrationBuilder.AlterColumn<string>(
                name: "KontaktTel",
                table: "PrimalacUslugas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "PrimalacUslugas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

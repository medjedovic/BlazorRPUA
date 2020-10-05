using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRPUA.Server.Migrations.EFDBIDMigrations
{
    public partial class dodanManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3cb8705-77b8-4295-8061-a6dd66716945");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e750594e-b2fb-4316-ab48-7491a18951db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32a1f8bb-4ab9-4838-8b5b-5a22ebec7391", "a53fa882-e0e2-4184-8b66-ebd4c6dfc32a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "786858a2-ba38-4ad1-a853-a8b3cbbd9d1d", "b255a1b9-2e78-43e3-98d3-d83bb516f168", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5255f775-cc84-4a2d-98d2-2b5fab721672", "9f933c51-b129-42f8-907f-f4bea5630be2", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32a1f8bb-4ab9-4838-8b5b-5a22ebec7391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5255f775-cc84-4a2d-98d2-2b5fab721672");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "786858a2-ba38-4ad1-a853-a8b3cbbd9d1d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e750594e-b2fb-4316-ab48-7491a18951db", "fcd7f3fa-22fe-42f8-bd49-992dc24d2eb9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3cb8705-77b8-4295-8061-a6dd66716945", "59e39d9e-8f14-4ab6-8a5b-09a02464f1da", "User", "USER" });
        }
    }
}

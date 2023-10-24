using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dc11c36-e6e5-4c31-bd04-ffe9599d9028");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9b6ee43-521c-4f76-abaa-ef08baf4e265");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30435c22-33fd-41d0-be47-be944a8202ed", "270dcc60-e861-47a9-8005-17838155edbe", "User", "USER" },
                    { "9c01cff9-0553-4eb1-9f61-fda64f236f3a", "331b809b-019a-4eab-9920-f52f46395e92", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30435c22-33fd-41d0-be47-be944a8202ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c01cff9-0553-4eb1-9f61-fda64f236f3a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8dc11c36-e6e5-4c31-bd04-ffe9599d9028", "e236fb3c-87ab-4514-8666-7384786b14b0", "User", "USER" },
                    { "b9b6ee43-521c-4f76-abaa-ef08baf4e265", "218b0ea6-e602-4e2b-9d45-cddd920577ac", "Admin", "ADMIN" }
                });
        }
    }
}

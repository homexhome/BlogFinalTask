using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
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
                    { "254be243-e827-4366-b9b5-6253dd18af76", "4ab3900c-339f-4c51-8d7a-811f0c0580c7", "User", "USER" },
                    { "64b080e9-b5e5-4886-acf3-ced71d25b9ec", "92494064-6592-4140-a584-0a45971e3059", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "254be243-e827-4366-b9b5-6253dd18af76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b080e9-b5e5-4886-acf3-ced71d25b9ec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30435c22-33fd-41d0-be47-be944a8202ed", "270dcc60-e861-47a9-8005-17838155edbe", "User", "USER" },
                    { "9c01cff9-0553-4eb1-9f61-fda64f236f3a", "331b809b-019a-4eab-9920-f52f46395e92", "Admin", "ADMIN" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b9cefb0c-ba21-4249-93e1-a4a9a46325c2", "1313578e-0aa1-4c7d-b7d9-466d34837536", "User", "USER" },
                    { "e2754ea5-aa96-4ccf-9bbe-3ec50f539066", "8b593be2-8199-4781-9170-8712fb403186", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9cefb0c-ba21-4249-93e1-a4a9a46325c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2754ea5-aa96-4ccf-9bbe-3ec50f539066");
        }
    }
}

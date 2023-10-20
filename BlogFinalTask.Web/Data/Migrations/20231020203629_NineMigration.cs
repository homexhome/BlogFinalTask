using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NineMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75f51818-2b3c-4d00-b398-832a4f89e9f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83c1fa38-1ba0-40b1-924d-9891dbcd1847");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d3a70d70-267c-4b16-94ab-b589f28cb7d2", "f7365515-dd99-4761-82d3-bae52d04d5e2", "User", "USER" },
                    { "fd66ec81-a587-4ec9-9b16-4a4a8df44076", "28346e5f-0716-4c9b-9eba-9628996e33c0", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3a70d70-267c-4b16-94ab-b589f28cb7d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd66ec81-a587-4ec9-9b16-4a4a8df44076");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75f51818-2b3c-4d00-b398-832a4f89e9f0", "521a8f39-dae5-4529-8d46-7326f2e215b8", "Admin", "ADMIN" },
                    { "83c1fa38-1ba0-40b1-924d-9891dbcd1847", "1abdbd8e-66d6-4b12-a27a-d9bbed32ae40", "User", "USER" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModeratorRoleAddMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "3c1ac8e2-c90b-423a-a6b4-2998dbe87be2", "b8f4d6af-ce9b-49f0-8487-2d97cd3e3473", "Moderator", "MODERATOR" },
                    { "9fe29154-c8ec-4f1f-bde0-3f9e84b535e5", "e32f8bb6-b7a2-4df6-925a-6e7493a64776", "User", "USER" },
                    { "c3f27360-caa4-42fd-8d01-30d678956937", "f739befe-5a52-438e-a439-534a89b4fad5", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c1ac8e2-c90b-423a-a6b4-2998dbe87be2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fe29154-c8ec-4f1f-bde0-3f9e84b535e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3f27360-caa4-42fd-8d01-30d678956937");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d3a70d70-267c-4b16-94ab-b589f28cb7d2", "f7365515-dd99-4761-82d3-bae52d04d5e2", "User", "USER" },
                    { "fd66ec81-a587-4ec9-9b16-4a4a8df44076", "28346e5f-0716-4c9b-9eba-9628996e33c0", "Admin", "ADMIN" }
                });
        }
    }
}

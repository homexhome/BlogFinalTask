using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9cefb0c-ba21-4249-93e1-a4a9a46325c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2754ea5-aa96-4ccf-9bbe-3ec50f539066");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6692c59b-7718-4848-bfec-d396a204be85", "7dd8e11c-2c00-486c-9b46-0f0c053a2610", "CustomRole", "Admin", "ADMIN" },
                    { "ea24dbf9-153d-4022-9ee6-da25ea2bc1bf", "7e2c88b5-604d-499b-badf-cc39b3b5ba1c", "CustomRole", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6692c59b-7718-4848-bfec-d396a204be85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea24dbf9-153d-4022-9ee6-da25ea2bc1bf");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b9cefb0c-ba21-4249-93e1-a4a9a46325c2", "1313578e-0aa1-4c7d-b7d9-466d34837536", "User", "USER" },
                    { "e2754ea5-aa96-4ccf-9bbe-3ec50f539066", "8b593be2-8199-4781-9170-8712fb403186", "Admin", "ADMIN" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClaimsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0ff2ded5-e487-4747-b53b-15547d6e5ae7", "47723cda-8804-4e69-83dc-eecfed101582", "Moderator", "MODERATOR" },
                    { "b019c75d-a8d1-47f7-a20e-41c13af6fc89", "94c66790-b16d-48d5-a1b5-abeb1d2eb4e1", "Admin", "ADMIN" },
                    { "cf83783b-00e6-4ec1-8a68-9426f95e6ed9", "bfc98d44-7204-4a1f-a68b-2ddf3da605bf", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -3, "Role", "User", "cf83783b-00e6-4ec1-8a68-9426f95e6ed9" },
                    { -2, "Role", "Moderator", "0ff2ded5-e487-4747-b53b-15547d6e5ae7" },
                    { -1, "Role", "Admin", "b019c75d-a8d1-47f7-a20e-41c13af6fc89" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ff2ded5-e487-4747-b53b-15547d6e5ae7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b019c75d-a8d1-47f7-a20e-41c13af6fc89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf83783b-00e6-4ec1-8a68-9426f95e6ed9");

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
    }
}

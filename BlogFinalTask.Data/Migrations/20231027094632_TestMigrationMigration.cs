using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestMigrationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "06f84a75-945d-4d92-9ccb-a731f412ca60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6881ee96-1f5e-4fad-adf3-1d5fdca68095");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86f275ec-d37e-4db0-a140-22ea708078cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "926dd13c-f220-49cf-b093-7102fbfcba85", "45084f1a-a437-41a3-9b23-f541eee1439a", "Basic Moderator Role", "Moderator", "MODERATOR" },
                    { "b734f2b2-c4a7-4881-a2a8-2a395cc388f0", "d9d51d39-62f9-43d5-9e02-4da5e2e8cd68", "Basic Admin Role", "Admin", "ADMIN" },
                    { "e505a21f-7b80-43e9-83eb-c56130a1165a", "2de4ddd9-2feb-4d02-b4e4-b3caab3cb70e", "Basic User Role", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Role", "Admin", "b734f2b2-c4a7-4881-a2a8-2a395cc388f0" },
                    { 2, "Role", "Moderator", "926dd13c-f220-49cf-b093-7102fbfcba85" },
                    { 3, "Role", "User", "e505a21f-7b80-43e9-83eb-c56130a1165a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "926dd13c-f220-49cf-b093-7102fbfcba85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b734f2b2-c4a7-4881-a2a8-2a395cc388f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e505a21f-7b80-43e9-83eb-c56130a1165a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06f84a75-945d-4d92-9ccb-a731f412ca60", "e9a49ee1-a2a4-4df4-9298-9c2ebf60e7d3", "Basic Moderator Role", "Moderator", "MODERATOR" },
                    { "6881ee96-1f5e-4fad-adf3-1d5fdca68095", "61c652d0-ed0c-4620-a319-0cf6a3bc917e", "Basic Admin Role", "Admin", "ADMIN" },
                    { "86f275ec-d37e-4db0-a140-22ea708078cd", "658a7186-e47e-496a-a293-a9778d6ff32c", "Basic User Role", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -3, "Role", "User", "86f275ec-d37e-4db0-a140-22ea708078cd" },
                    { -2, "Role", "Moderator", "06f84a75-945d-4d92-9ccb-a731f412ca60" },
                    { -1, "Role", "Admin", "6881ee96-1f5e-4fad-adf3-1d5fdca68095" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestClaimsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4011e10f-e826-4ff1-9bcc-eecbdf996fbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afbad608-b3c8-4223-9d15-0d22ca4c85eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c70cf8cf-1e2e-4e08-9c83-214d2b18a37d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06f84a75-945d-4d92-9ccb-a731f412ca60", "e9a49ee1-a2a4-4df4-9298-9c2ebf60e7d3", "Basic Moderator Role", "Moderator", "MODERATOR" },
                    { "6881ee96-1f5e-4fad-adf3-1d5fdca68095", "61c652d0-ed0c-4620-a319-0cf6a3bc917e", "Basic Admin Role", "Admin", "ADMIN" },
                    { "86f275ec-d37e-4db0-a140-22ea708078cd", "658a7186-e47e-496a-a293-a9778d6ff32c", "Basic User Role", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -3,
                column: "RoleId",
                value: "86f275ec-d37e-4db0-a140-22ea708078cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2,
                column: "RoleId",
                value: "06f84a75-945d-4d92-9ccb-a731f412ca60");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1,
                column: "RoleId",
                value: "6881ee96-1f5e-4fad-adf3-1d5fdca68095");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -3,
                column: "RoleId",
                value: "afbad608-b3c8-4223-9d15-0d22ca4c85eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2,
                column: "RoleId",
                value: "4011e10f-e826-4ff1-9bcc-eecbdf996fbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1,
                column: "RoleId",
                value: "c70cf8cf-1e2e-4e08-9c83-214d2b18a37d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4011e10f-e826-4ff1-9bcc-eecbdf996fbf", "43ca184e-c415-431a-aec4-600ba925cacc", "Basic Moderator Role", "Moderator", "MODERATOR" },
                    { "afbad608-b3c8-4223-9d15-0d22ca4c85eb", "db4faae5-634b-4a01-8a39-e2a70809e5b1", "Basic User Role", "User", "USER" },
                    { "c70cf8cf-1e2e-4e08-9c83-214d2b18a37d", "07fc5074-353f-42fc-9c97-ec9f1678a744", "Basic Admin Role", "Admin", "ADMIN" }
                });
        }
    }
}

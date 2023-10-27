using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -3,
                column: "RoleId",
                value: "2b1897c6-d094-4b83-b18e-b2afe3bd48ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2,
                column: "RoleId",
                value: "7db1a8d3-aabc-43cb-a0da-10cbc2b3bd8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1,
                column: "RoleId",
                value: "3c2099f4-3aae-4c19-ad25-ff21ce6b77cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b1897c6-d094-4b83-b18e-b2afe3bd48ef", "b0c36452-2f9b-4659-a2f4-806daf2d30b8", "User", "USER" },
                    { "3c2099f4-3aae-4c19-ad25-ff21ce6b77cd", "978b395c-0933-4663-a34e-fabf4d376908", "Admin", "ADMIN" },
                    { "7db1a8d3-aabc-43cb-a0da-10cbc2b3bd8b", "7527502d-d19a-40f9-8735-c52ee0af1111", "Moderator", "MODERATOR" }
                });
        }
    }
}

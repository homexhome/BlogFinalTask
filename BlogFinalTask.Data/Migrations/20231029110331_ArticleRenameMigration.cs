using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArticleRenameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "ArcticleId",
                table: "ArticleTags");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleId",
                table: "ArticleTags",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "7e9e1940-d9ff-4515-ad09-a1040d612b85");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "3992efda-9e1d-4f5a-9aa1-50d836c2468e");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "6b85412f-8b98-4bbb-9377-b724f9069a9b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3992efda-9e1d-4f5a-9aa1-50d836c2468e", "6d46c352-33cd-48a1-ada8-aeea61e003c4", "Basic Moderator Role", "Moderator", "MODERATOR" },
                    { "6b85412f-8b98-4bbb-9377-b724f9069a9b", "fb6bf3d1-e65a-455b-bfd3-a0889257eec3", "Basic User Role", "User", "USER" },
                    { "7e9e1940-d9ff-4515-ad09-a1040d612b85", "22f82825-80f1-41bb-876b-be8aa516d798", "Basic Admin Role", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3992efda-9e1d-4f5a-9aa1-50d836c2468e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b85412f-8b98-4bbb-9377-b724f9069a9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e9e1940-d9ff-4515-ad09-a1040d612b85");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleId",
                table: "ArticleTags",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ArcticleId",
                table: "ArticleTags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "b734f2b2-c4a7-4881-a2a8-2a395cc388f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "926dd13c-f220-49cf-b093-7102fbfcba85");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "e505a21f-7b80-43e9-83eb-c56130a1165a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "926dd13c-f220-49cf-b093-7102fbfcba85", "45084f1a-a437-41a3-9b23-f541eee1439a", "Basic Moderator Role", "Moderator", "MODERATOR" },
                    { "b734f2b2-c4a7-4881-a2a8-2a395cc388f0", "d9d51d39-62f9-43d5-9e02-4da5e2e8cd68", "Basic Admin Role", "Admin", "ADMIN" },
                    { "e505a21f-7b80-43e9-83eb-c56130a1165a", "2de4ddd9-2feb-4d02-b4e4-b3caab3cb70e", "Basic User Role", "User", "USER" }
                });
        }
    }
}

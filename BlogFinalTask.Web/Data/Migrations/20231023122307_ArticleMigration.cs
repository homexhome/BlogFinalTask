using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArticleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29f35053-4149-4c78-b6b9-90ed654b5226");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c214477-8329-4064-8501-babbec349dcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "595988b3-a810-4c26-9c14-7db899033338");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -3,
                column: "RoleId",
                value: "cf83783b-00e6-4ec1-8a68-9426f95e6ed9");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2,
                column: "RoleId",
                value: "0ff2ded5-e487-4747-b53b-15547d6e5ae7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1,
                column: "RoleId",
                value: "b019c75d-a8d1-47f7-a20e-41c13af6fc89");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ff2ded5-e487-4747-b53b-15547d6e5ae7", "47723cda-8804-4e69-83dc-eecfed101582", "Moderator", "MODERATOR" },
                    { "b019c75d-a8d1-47f7-a20e-41c13af6fc89", "94c66790-b16d-48d5-a1b5-abeb1d2eb4e1", "Admin", "ADMIN" },
                    { "cf83783b-00e6-4ec1-8a68-9426f95e6ed9", "bfc98d44-7204-4a1f-a68b-2ddf3da605bf", "User", "USER" }
                });
        }
    }
}

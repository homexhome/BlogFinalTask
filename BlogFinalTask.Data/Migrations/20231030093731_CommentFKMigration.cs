using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommentFKMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20dd0f53-83b9-478d-8bf7-d8a423d09f7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5475f090-62f8-4839-b0e1-caae3ddcd473");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d70df32-32dd-4b35-be7f-137081578ec3");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "06073925-7a48-44d1-b370-ec0d82442126");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "bb747792-efc6-4e2f-ba87-bd83bfa4599c");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "935e8d5d-acfc-46d7-a376-2e33c7ce3138");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06073925-7a48-44d1-b370-ec0d82442126", "c3ff8511-842e-4a86-a4b8-93d05b144c06", "Basic Admin Role", "Admin", "ADMIN" },
                    { "935e8d5d-acfc-46d7-a376-2e33c7ce3138", "30d10323-5a61-4959-9863-eb4709218430", "Basic User Role", "User", "USER" },
                    { "bb747792-efc6-4e2f-ba87-bd83bfa4599c", "3dc77cd1-8fb7-49e6-bb77-b8c8080148f2", "Basic Moderator Role", "Moderator", "MODERATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06073925-7a48-44d1-b370-ec0d82442126");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "935e8d5d-acfc-46d7-a376-2e33c7ce3138");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb747792-efc6-4e2f-ba87-bd83bfa4599c");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "20dd0f53-83b9-478d-8bf7-d8a423d09f7e");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "6d70df32-32dd-4b35-be7f-137081578ec3");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "5475f090-62f8-4839-b0e1-caae3ddcd473");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20dd0f53-83b9-478d-8bf7-d8a423d09f7e", "bfcc924d-0737-4d6d-aded-88c02d7e749a", "Basic Admin Role", "Admin", "ADMIN" },
                    { "5475f090-62f8-4839-b0e1-caae3ddcd473", "110a23e5-5a00-458f-86f3-5afa8507f9b9", "Basic User Role", "User", "USER" },
                    { "6d70df32-32dd-4b35-be7f-137081578ec3", "edb6fc2b-4d81-4bc4-a878-f49dd8edb207", "Basic Moderator Role", "Moderator", "MODERATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogFinalTask.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class NavigatonFixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTags_Articles_ArticleId",
                table: "ArticleTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags");

            migrationBuilder.DropIndex(
                name: "IX_ArticleTags_ArticleId",
                table: "ArticleTags");

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
                name: "Id",
                table: "ArticleTags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId" });

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
                name: "FK_ArticleTags_Articles_ArticleId",
                table: "ArticleTags",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTags_Articles_ArticleId",
                table: "ArticleTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags");

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

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ArticleTags",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_ArticleId",
                table: "ArticleTags",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTags_Articles_ArticleId",
                table: "ArticleTags",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}

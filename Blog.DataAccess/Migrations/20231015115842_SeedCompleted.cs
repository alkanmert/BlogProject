using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"), new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(913), "Dünya", null },
                    { new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"), new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(909), "ASP.Net Core", null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "FileName", "FileType", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"), new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(1201), "Deneme", "jpg", null },
                    { new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"), new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(1205), "Deneme2", "png", null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "CreatedDate", "ImageId", "Title", "UpdatedDate", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("51e431e0-c056-442b-b98c-dfa504910e95"), "Mertcan Alkan", new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"), "LoremLoremloremmmmmmmmmm", new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(580), new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"), "Deneme2", null, 1 },
                    { new Guid("eb6a7c59-cfa6-4334-ae0d-31d99a0c6c8a"), "Mertcan Alkan", new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"), "Merhababaaaababababababa", new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(543), new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"), "Deneme", null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("51e431e0-c056-442b-b98c-dfa504910e95"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("eb6a7c59-cfa6-4334-ae0d-31d99a0c6c8a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

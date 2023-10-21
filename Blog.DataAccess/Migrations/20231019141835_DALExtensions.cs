using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DALExtensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("51e431e0-c056-442b-b98c-dfa504910e95"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("eb6a7c59-cfa6-4334-ae0d-31d99a0c6c8a"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "CreatedDate", "ImageId", "Title", "UpdatedDate", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("5f5347f8-910f-4d83-a6f5-dc6984fe4e79"), "Mertcan Alkan", new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"), "Merhababaaaababababababa", new DateTime(2023, 10, 19, 17, 18, 34, 869, DateTimeKind.Local).AddTicks(8818), new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"), "Deneme", null, 1 },
                    { new Guid("bf804af6-19de-4a3d-a2d8-04c9655ab856"), "Mertcan Alkan", new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"), "LoremLoremloremmmmmmmmmm", new DateTime(2023, 10, 19, 17, 18, 34, 869, DateTimeKind.Local).AddTicks(8854), new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"), "Deneme2", null, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 17, 18, 34, 869, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 17, 18, 34, 869, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 17, 18, 34, 869, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 17, 18, 34, 869, DateTimeKind.Local).AddTicks(9367));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5f5347f8-910f-4d83-a6f5-dc6984fe4e79"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bf804af6-19de-4a3d-a2d8-04c9655ab856"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "CreatedDate", "ImageId", "Title", "UpdatedDate", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("51e431e0-c056-442b-b98c-dfa504910e95"), "Mertcan Alkan", new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"), "LoremLoremloremmmmmmmmmm", new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(580), new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"), "Deneme2", null, 1 },
                    { new Guid("eb6a7c59-cfa6-4334-ae0d-31d99a0c6c8a"), "Mertcan Alkan", new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"), "Merhababaaaababababababa", new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(543), new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"), "Deneme", null, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 58, 42, 64, DateTimeKind.Local).AddTicks(1205));
        }
    }
}

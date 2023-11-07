using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("12e5a7a5-6180-4aa9-aaf0-dd840fef54ee"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("db990faa-b935-47d7-9563-e0ae897c083a"));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Articles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "Title", "UpdatedDate", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("67406233-adeb-4c6a-934a-6a5162e52737"), "Mertcan Alkan", new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"), "Merhababaaaababababababa", new DateTime(2023, 10, 30, 17, 13, 3, 297, DateTimeKind.Local).AddTicks(9115), null, null, new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"), false, null, "Deneme", null, new Guid("5746464f-c6d1-4f4c-91f8-a106e489e20e"), 1 },
                    { new Guid("cf271ae3-682a-4b7f-8a83-0e86969894f2"), "Mertcan Alkan", new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"), "LoremLoremloremmmmmmmmmm", new DateTime(2023, 10, 30, 17, 13, 3, 297, DateTimeKind.Local).AddTicks(9152), null, null, new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"), false, null, "Deneme2", null, new Guid("a5c8d88a-6a51-4b46-b192-867138c8654f"), 1 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66dcaabe-5427-4703-a557-48431fce10e5"),
                column: "ConcurrencyStamp",
                value: "5439e7eb-cdaf-4626-80b9-fb2f88c8fac2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7750a061-fd25-462d-a4ee-cd8929525408"),
                column: "ConcurrencyStamp",
                value: "0b710bc3-e5b1-4582-bc0f-4df796de96a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c4d933c2-411e-4485-bc06-006604ec11fa"),
                column: "ConcurrencyStamp",
                value: "0983edad-733a-4907-b0d2-fbfc97b3010b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5746464f-c6d1-4f4c-91f8-a106e489e20e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38e4d8dc-65db-48fb-80bb-0b16046978b6", "AQAAAAEAACcQAAAAEPnZrhnv0rP9KVZ2Kwjc8i1ICYrUTeIwNVwy0d3S/dztsse0z9ctt/412m1bD/oZBA==", "9c049c52-2998-4926-8504-b340f4a8ff8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5c8d88a-6a51-4b46-b192-867138c8654f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fbc9b11-9828-4665-81cd-1e998d015aa8", "AQAAAAEAACcQAAAAEMJt82NWxmoy9QQCTXB9bwwqVSHOLAa8HFGTq/aDQIvlnpiXmyKkc/eJpkABhpfFkQ==", "5689833f-0064-464b-976c-7d2ce821d89d" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"),
                columns: new[] { "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy" },
                values: new object[] { new DateTime(2023, 10, 30, 17, 13, 3, 297, DateTimeKind.Local).AddTicks(9506), null, null, false, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"),
                columns: new[] { "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy" },
                values: new object[] { new DateTime(2023, 10, 30, 17, 13, 3, 297, DateTimeKind.Local).AddTicks(9502), null, null, false, null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"),
                columns: new[] { "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy" },
                values: new object[] { new DateTime(2023, 10, 30, 17, 13, 3, 297, DateTimeKind.Local).AddTicks(9751), null, null, false, null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"),
                columns: new[] { "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy" },
                values: new object[] { new DateTime(2023, 10, 30, 17, 13, 3, 297, DateTimeKind.Local).AddTicks(9756), null, null, false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("67406233-adeb-4c6a-934a-6a5162e52737"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("cf271ae3-682a-4b7f-8a83-0e86969894f2"));

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "CreatedDate", "ImageId", "Title", "UpdatedDate", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("12e5a7a5-6180-4aa9-aaf0-dd840fef54ee"), "Mertcan Alkan", new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"), "Merhababaaaababababababa", new DateTime(2023, 10, 24, 13, 36, 28, 819, DateTimeKind.Local).AddTicks(8506), new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"), "Deneme", null, new Guid("5746464f-c6d1-4f4c-91f8-a106e489e20e"), 1 },
                    { new Guid("db990faa-b935-47d7-9563-e0ae897c083a"), "Mertcan Alkan", new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"), "LoremLoremloremmmmmmmmmm", new DateTime(2023, 10, 24, 13, 36, 28, 819, DateTimeKind.Local).AddTicks(8539), new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"), "Deneme2", null, new Guid("a5c8d88a-6a51-4b46-b192-867138c8654f"), 1 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66dcaabe-5427-4703-a557-48431fce10e5"),
                column: "ConcurrencyStamp",
                value: "a4f9cad2-62fa-4a65-b640-3c4eb600ca02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7750a061-fd25-462d-a4ee-cd8929525408"),
                column: "ConcurrencyStamp",
                value: "e5815ae0-85e8-497b-aa2b-24739e5cbfce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c4d933c2-411e-4485-bc06-006604ec11fa"),
                column: "ConcurrencyStamp",
                value: "77aa29bb-6494-4b8b-ac8f-73de84090d0a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5746464f-c6d1-4f4c-91f8-a106e489e20e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a9c9287-ee39-4d78-9dbd-40b485849d0b", "AQAAAAEAACcQAAAAEFMw/bTOZmTRGczy/5KkgdGlEbjPauuGJ1aghrrCyr7fxJKB+8LcSvvK+MQCXWkNfg==", "51b0b687-39a0-4311-9fb1-39519d67286d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5c8d88a-6a51-4b46-b192-867138c8654f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aceb8ecd-2e2c-496d-b319-9ef75ff6eb8e", "AQAAAAEAACcQAAAAEMoLxlwIbuciIZMV8Fm6Fonv9/G7K+gs1raQR8SkxrnWoaWdopQUfrIjIztHbxQhRQ==", "99932b9c-f42b-4d42-afd5-06d2638072e4" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 24, 13, 36, 28, 819, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 24, 13, 36, 28, 819, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 24, 13, 36, 28, 819, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 24, 13, 36, 28, 819, DateTimeKind.Local).AddTicks(9114));
        }
    }
}

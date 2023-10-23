using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5f5347f8-910f-4d83-a6f5-dc6984fe4e79"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bf804af6-19de-4a3d-a2d8-04c9655ab856"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "CreatedDate", "ImageId", "Title", "UpdatedDate", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1328e604-55c0-40fc-98ec-182d19dad42f"), "Mertcan Alkan", new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"), "Merhababaaaababababababa", new DateTime(2023, 10, 23, 21, 7, 49, 572, DateTimeKind.Local).AddTicks(5331), new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"), "Deneme", null, 1 },
                    { new Guid("eae84b6b-c78e-4f25-87e8-705dcf246dfe"), "Mertcan Alkan", new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"), "LoremLoremloremmmmmmmmmm", new DateTime(2023, 10, 23, 21, 7, 49, 572, DateTimeKind.Local).AddTicks(5365), new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"), "Deneme2", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("66dcaabe-5427-4703-a557-48431fce10e5"), "ec1f5160-36a8-4da9-aec7-0cf1eba30592", "User", "USER" },
                    { new Guid("7750a061-fd25-462d-a4ee-cd8929525408"), "a207c31f-f497-4811-ae6d-c13dddaa6796", "Admin", "ADMIN" },
                    { new Guid("c4d933c2-411e-4485-bc06-006604ec11fa"), "c3a390e5-fe7d-4f2a-a8cf-50392c30f7fa", "Superadmin", "SUPERADMİN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5746464f-c6d1-4f4c-91f8-a106e489e20e"), 0, "492e8459-5012-4b00-bcbc-679dc9e25d62", "superadmin@gmail.com", true, "Mert", "Alkan", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPdB2P1HuirbR+ARnqomO6PqcPQ4e01T52en9Kn/8U303pFlDglbiy+w9ulmMovIeA==", "+905435554545", true, "b5de52ce-de1c-4207-8ae1-0e9db6f40f81", false, "superadmin@gmail.com" },
                    { new Guid("a5c8d88a-6a51-4b46-b192-867138c8654f"), 0, "33d26779-4ce8-4bb0-9ddc-761aa3f6ddae", "admin@gmail.com", false, "Admin", "Alkan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELWlYEXxq/vXjQI0oD/pA/PixqVvmts+fO1Z/MjdPrOGg8D3edplQWTQjAyvDLnQFQ==", "+905435558888", false, "39baff8f-9e69-4de1-8a80-d9a1d8f6b2e7", false, "admin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("31e1cb79-1160-47e3-ace7-33afcacb763e"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 23, 21, 7, 49, 572, DateTimeKind.Local).AddTicks(5722));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b78b5ef8-714b-4c4d-93aa-f7c09863cf9b"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 23, 21, 7, 49, 572, DateTimeKind.Local).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5a6b603d-c15a-4508-ae7c-49f82ea5e8b0"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 23, 21, 7, 49, 572, DateTimeKind.Local).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8a7b7e4b-956b-4907-9945-b6864f6b3ccb"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 23, 21, 7, 49, 572, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c4d933c2-411e-4485-bc06-006604ec11fa"), new Guid("5746464f-c6d1-4f4c-91f8-a106e489e20e") },
                    { new Guid("7750a061-fd25-462d-a4ee-cd8929525408"), new Guid("a5c8d88a-6a51-4b46-b192-867138c8654f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1328e604-55c0-40fc-98ec-182d19dad42f"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("eae84b6b-c78e-4f25-87e8-705dcf246dfe"));

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
    }
}

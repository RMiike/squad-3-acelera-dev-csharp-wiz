using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1833434-73ef-40c3-aa8f-dd9b535e240f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7f8a163a-1c1f-4991-99d8-52cb0d846979", 0, "f56f1dc3-ecf9-430b-9c98-748856c4e03c", new DateTime(2020, 6, 24, 21, 18, 57, 353, DateTimeKind.Local).AddTicks(1521), "rmiike@gmail.com", false, false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 24, 21, 18, 57, 348, DateTimeKind.Local).AddTicks(6836));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f8a163a-1c1f-4991-99d8-52cb0d846979");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c1833434-73ef-40c3-aa8f-dd9b535e240f", 0, "81d5a884-d73b-447c-9d86-bf117c9342d5", new DateTime(2020, 6, 24, 21, 17, 53, 872, DateTimeKind.Local).AddTicks(3252), "rmiike@gmail.com", false, false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 24, 21, 17, 53, 866, DateTimeKind.Local).AddTicks(8202));
        }
    }
}

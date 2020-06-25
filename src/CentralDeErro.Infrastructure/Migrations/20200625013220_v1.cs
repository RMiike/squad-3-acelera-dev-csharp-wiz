using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f8a163a-1c1f-4991-99d8-52cb0d846979");

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Error",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Error",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "42c6fd48-ea94-4a5c-b76d-93c51b21963a", 0, "37f7c90e-2d58-45e5-8f12-7229606eba28", new DateTime(2020, 6, 24, 22, 32, 18, 834, DateTimeKind.Local).AddTicks(4269), "rmiike@gmail.com", false, false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Event" },
                values: new object[] { new DateTime(2020, 6, 24, 22, 32, 18, 829, DateTimeKind.Local).AddTicks(6140), 10010 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c6fd48-ea94-4a5c-b76d-93c51b21963a");

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Error");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Error");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7f8a163a-1c1f-4991-99d8-52cb0d846979", 0, "f56f1dc3-ecf9-430b-9c98-748856c4e03c", new DateTime(2020, 6, 24, 21, 18, 57, 353, DateTimeKind.Local).AddTicks(1521), "rmiike@gmail.com", false, false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Event" },
                values: new object[] { new DateTime(2020, 6, 24, 21, 18, 57, 348, DateTimeKind.Local).AddTicks(6836), 1000 });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4eea9ccd-e24b-454f-9f54-9aac788bd31a");

            migrationBuilder.AlterColumn<string>(
                name: "Environment",
                table: "Source",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Error",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e9843b9e-ac02-48cc-aaf3-a77e8459c6d4", 0, "a264f427-b9c6-477b-ae7e-c74fea5186c6", new DateTime(2020, 7, 9, 0, 15, 38, 449, DateTimeKind.Utc).AddTicks(1749), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 9, 0, 15, 38, 442, DateTimeKind.Utc).AddTicks(2172));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9843b9e-ac02-48cc-aaf3-a77e8459c6d4");

            migrationBuilder.AlterColumn<string>(
                name: "Environment",
                table: "Source",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Error",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4eea9ccd-e24b-454f-9f54-9aac788bd31a", 0, "97afee1f-0ed7-46be-a2c4-72e46dc5c981", new DateTime(2020, 7, 8, 23, 54, 59, 801, DateTimeKind.Utc).AddTicks(4100), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 8, 23, 54, 59, 795, DateTimeKind.Utc).AddTicks(2555));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70d7ee27-c466-4201-9ec2-c609e4dc6b4f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "21f97e26-de91-4938-8069-6b535fcc67ee", 0, "1c727c55-7411-41b6-a1da-92c1339aa953", new DateTime(2020, 6, 24, 7, 24, 28, 212, DateTimeKind.Local).AddTicks(2610), "rmiike@gmail.com", false, false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 24, 7, 24, 28, 207, DateTimeKind.Local).AddTicks(7948));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21f97e26-de91-4938-8069-6b535fcc67ee");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "70d7ee27-c466-4201-9ec2-c609e4dc6b4f", 0, "45fea23e-401c-4a53-a61a-e61989624a82", new DateTime(2020, 6, 23, 22, 19, 46, 895, DateTimeKind.Local).AddTicks(6135), "rmiike@gmail.com", false, false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 23, 22, 19, 46, 890, DateTimeKind.Local).AddTicks(9122));
        }
    }
}

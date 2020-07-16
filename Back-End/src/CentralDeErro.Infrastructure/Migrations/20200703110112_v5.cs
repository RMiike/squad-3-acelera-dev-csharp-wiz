using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d4387fd-0a2c-4a6c-a78a-4287a3022ced");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e785db32-da5d-4933-9c16-277aca224f9f", 0, "89385f1c-5ad3-45b9-b45d-200506c59b2d", new DateTime(2020, 7, 3, 8, 1, 11, 889, DateTimeKind.Local).AddTicks(8122), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 3, 11, 1, 11, 887, DateTimeKind.Utc).AddTicks(5638));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e785db32-da5d-4933-9c16-277aca224f9f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d4387fd-0a2c-4a6c-a78a-4287a3022ced", 0, "06491377-8533-412e-bd4f-7ec7c7859907", new DateTime(2020, 7, 3, 7, 56, 52, 333, DateTimeKind.Local).AddTicks(5842), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 3, 10, 56, 52, 331, DateTimeKind.Utc).AddTicks(4807));
        }
    }
}

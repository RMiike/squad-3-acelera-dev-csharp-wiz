using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0490f446-1522-4307-84bb-c45129875751");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "55b3f0bd-221d-44bc-b02b-ddcc744f9d59", 0, "f78d15f8-94a1-4600-a968-d929146f81f6", new DateTime(2020, 6, 26, 16, 35, 2, 915, DateTimeKind.Local).AddTicks(2960), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 16, 35, 2, 908, DateTimeKind.Local).AddTicks(3095));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55b3f0bd-221d-44bc-b02b-ddcc744f9d59");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0490f446-1522-4307-84bb-c45129875751", 0, "9cda0424-0921-4902-96a6-d9f1f30525b3", new DateTime(2020, 6, 26, 16, 26, 51, 751, DateTimeKind.Local).AddTicks(2468), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 16, 26, 51, 745, DateTimeKind.Local).AddTicks(4041));
        }
    }
}

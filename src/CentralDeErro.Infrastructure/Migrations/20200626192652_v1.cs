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
                keyValue: "26b12401-5c7d-47ec-ad7d-417f5c9a3130");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0490f446-1522-4307-84bb-c45129875751");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "26b12401-5c7d-47ec-ad7d-417f5c9a3130", 0, "adb30490-39c2-4044-90d7-81fff966e4ff", new DateTime(2020, 6, 26, 15, 59, 11, 678, DateTimeKind.Local).AddTicks(5785), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 15, 59, 11, 672, DateTimeKind.Local).AddTicks(9313));
        }
    }
}

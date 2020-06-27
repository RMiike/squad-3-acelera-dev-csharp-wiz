using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11807a60-1035-4819-92ab-2cf060b2cf98");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1af5198-579a-4f37-9386-d25f5875f946", 0, "838c80cd-6f33-463c-86b9-af5c53121fc8", new DateTime(2020, 6, 26, 17, 20, 5, 592, DateTimeKind.Local).AddTicks(2042), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 17, 20, 5, 587, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Environment" },
                values: new object[] { "Front-End", 1 });

            migrationBuilder.InsertData(
                table: "Source",
                columns: new[] { "Id", "Address", "Environment" },
                values: new object[,]
                {
                    { 3, "Front-End", 0 },
                    { 4, "Back-End", 2 },
                    { 5, "Back-End", 1 },
                    { 6, "Back-End", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1af5198-579a-4f37-9386-d25f5875f946");

            migrationBuilder.DeleteData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11807a60-1035-4819-92ab-2cf060b2cf98", 0, "e85ac8f3-2cc9-4b88-8efe-ca5ccb06df5f", new DateTime(2020, 6, 26, 17, 15, 33, 444, DateTimeKind.Local).AddTicks(5301), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 17, 15, 33, 439, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Environment" },
                values: new object[] { "Back-End", 0 });
        }
    }
}

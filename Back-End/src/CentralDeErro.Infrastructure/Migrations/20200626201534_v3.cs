using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55b3f0bd-221d-44bc-b02b-ddcc744f9d59");

            migrationBuilder.DropColumn(
                name: "Event",
                table: "Error");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11807a60-1035-4819-92ab-2cf060b2cf98");

            migrationBuilder.AddColumn<int>(
                name: "Event",
                table: "Error",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "55b3f0bd-221d-44bc-b02b-ddcc744f9d59", 0, "f78d15f8-94a1-4600-a968-d929146f81f6", new DateTime(2020, 6, 26, 16, 35, 2, 915, DateTimeKind.Local).AddTicks(2960), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Event" },
                values: new object[] { new DateTime(2020, 6, 26, 16, 35, 2, 908, DateTimeKind.Local).AddTicks(3095), 1 });
        }
    }
}

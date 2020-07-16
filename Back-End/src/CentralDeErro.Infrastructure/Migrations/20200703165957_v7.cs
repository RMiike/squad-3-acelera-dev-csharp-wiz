using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32ca41ba-6a17-44f3-b6d3-04d1249d8b86");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Source",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c8d91df2-5039-42f6-8e25-e54017eb3e4e", 0, "980379e7-86d0-4d14-b5f5-1f72498d22d2", new DateTime(2020, 7, 3, 16, 59, 56, 612, DateTimeKind.Utc).AddTicks(8592), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 3, 16, 59, 56, 608, DateTimeKind.Utc).AddTicks(7348));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8d91df2-5039-42f6-8e25-e54017eb3e4e");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Source");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32ca41ba-6a17-44f3-b6d3-04d1249d8b86", 0, "c97da9ca-1c03-45b6-ad41-a79bd8423a1f", new DateTime(2020, 7, 3, 11, 21, 16, 246, DateTimeKind.Utc).AddTicks(484), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 3, 11, 21, 16, 241, DateTimeKind.Utc).AddTicks(2839));
        }
    }
}

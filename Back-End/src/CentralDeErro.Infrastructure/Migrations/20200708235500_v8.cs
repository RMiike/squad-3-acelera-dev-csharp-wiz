using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErro.Infrastructure.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8d91df2-5039-42f6-8e25-e54017eb3e4e");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Source");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Error");

            migrationBuilder.AlterColumn<string>(
                name: "Environment",
                table: "Source",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Source",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Error",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Error",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4eea9ccd-e24b-454f-9f54-9aac788bd31a", 0, "97afee1f-0ed7-46be-a2c4-72e46dc5c981", new DateTime(2020, 7, 8, 23, 54, 59, 801, DateTimeKind.Utc).AddTicks(4100), "rmiike@gmail.com", false, "Renato Miike", false, null, null, null, null, null, false, null, false, "rmiike@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Error",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Level" },
                values: new object[] { new DateTime(2020, 7, 8, 23, 54, 59, 795, DateTimeKind.Utc).AddTicks(2555), "Debug" });

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 1,
                column: "Environment",
                value: "Development");

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 2,
                column: "Environment",
                value: "Homologation");

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 3,
                column: "Environment",
                value: "Production");

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 4,
                column: "Environment",
                value: "Development");

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 5,
                column: "Environment",
                value: "Homologation");

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 6,
                column: "Environment",
                value: "Production");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4eea9ccd-e24b-454f-9f54-9aac788bd31a");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Source");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Error");

            migrationBuilder.AlterColumn<int>(
                name: "Environment",
                table: "Source",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Source",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Error",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Error",
                type: "bit",
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
                columns: new[] { "CreatedAt", "Level" },
                values: new object[] { new DateTime(2020, 7, 3, 16, 59, 56, 608, DateTimeKind.Utc).AddTicks(7348), 2 });

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 1,
                column: "Environment",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 2,
                column: "Environment",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 3,
                column: "Environment",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 4,
                column: "Environment",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 5,
                column: "Environment",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Source",
                keyColumn: "Id",
                keyValue: 6,
                column: "Environment",
                value: 0);
        }
    }
}

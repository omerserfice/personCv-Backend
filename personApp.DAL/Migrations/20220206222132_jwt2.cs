using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace personApp.DAL.Migrations
{
    public partial class jwt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityNo",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "TCNo",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_TCNo",
                table: "Users",
                column: "TCNo");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2022, 2, 7, 1, 21, 31, 747, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2022, 2, 7, 1, 21, 31, 749, DateTimeKind.Local).AddTicks(1467));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_TCNo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TCNo",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "IdentityNo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2022, 2, 6, 22, 13, 47, 964, DateTimeKind.Local).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2022, 2, 6, 22, 13, 47, 968, DateTimeKind.Local).AddTicks(7165));
        }
    }
}

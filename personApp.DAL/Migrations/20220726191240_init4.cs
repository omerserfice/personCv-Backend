using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace personApp.DAL.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2022, 7, 26, 22, 12, 40, 193, DateTimeKind.Local).AddTicks(5244));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2022, 7, 26, 22, 12, 40, 196, DateTimeKind.Local).AddTicks(944));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2022, 4, 2, 22, 37, 13, 646, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2022, 4, 2, 22, 37, 13, 649, DateTimeKind.Local).AddTicks(953));
        }
    }
}

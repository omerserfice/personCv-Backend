using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace personApp.DAL.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CDate",
                value: new DateTime(2022, 7, 26, 22, 23, 17, 564, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CDate",
                value: new DateTime(2022, 7, 26, 22, 23, 17, 566, DateTimeKind.Local).AddTicks(4011));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace personApp.DAL.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AbilityPoint = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CUserId = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MUserId = table.Column<int>(type: "int", nullable: true),
                    MDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_PersonId",
                table: "Abilities",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");
        }
    }
}

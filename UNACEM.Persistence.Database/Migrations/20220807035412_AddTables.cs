using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OvensOvenId",
                table: "Tyres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Headquarters",
                columns: table => new
                {
                    HeadquarterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headquarters", x => x.HeadquarterId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Ovens",
                columns: table => new
                {
                    OvenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadquarterId = table.Column<int>(type: "int", nullable: false),
                    HeadquartersHeadquarterId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Large = table.Column<int>(type: "int", nullable: false),
                    Diameter = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ovens", x => x.OvenId);
                    table.ForeignKey(
                        name: "FK_Ovens_Headquarters_HeadquartersHeadquarterId",
                        column: x => x.HeadquartersHeadquarterId,
                        principalTable: "Headquarters",
                        principalColumn: "HeadquarterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tyres_OvensOvenId",
                table: "Tyres",
                column: "OvensOvenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ovens_HeadquartersHeadquarterId",
                table: "Ovens",
                column: "HeadquartersHeadquarterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Ovens_OvensOvenId",
                table: "Tyres",
                column: "OvensOvenId",
                principalTable: "Ovens",
                principalColumn: "OvenId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Ovens_OvensOvenId",
                table: "Tyres");

            migrationBuilder.DropTable(
                name: "Ovens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Headquarters");

            migrationBuilder.DropIndex(
                name: "IX_Tyres_OvensOvenId",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "OvensOvenId",
                table: "Tyres");
        }
    }
}

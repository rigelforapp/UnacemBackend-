using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    VersionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OvenId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date_Ini = table.Column<DateTime>(type: "Date", nullable: false),
                    Date_End = table.Column<DateTime>(type: "Date", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.VersionId);
                    table.ForeignKey(
                        name: "FK_Versions_Ovens_OvenId",
                        column: x => x.OvenId,
                        principalTable: "Ovens",
                        principalColumn: "OvenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Versions_OvenId",
                table: "Versions",
                column: "OvenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Versions");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProviderConcretes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderImportationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RecommendedZone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Composition = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    MaterialNeeded = table.Column<double>(type: "float", nullable: false),
                    WaterMix = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    ThermalConductivity300 = table.Column<double>(type: "float", nullable: false),
                    ThermalConductivity700 = table.Column<double>(type: "float", nullable: false),
                    ThermalConductivity100 = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderConcretes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderConcretes_ProviderImportations_ProviderImportationId",
                        column: x => x.ProviderImportationId,
                        principalTable: "ProviderImportations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderInsulatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderImportationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RecommendedZone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Composition = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    MaterialNeeded = table.Column<double>(type: "float", nullable: false),
                    WaterMix = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    ThermalConductivity300 = table.Column<double>(type: "float", nullable: false),
                    ThermalConductivity700 = table.Column<double>(type: "float", nullable: false),
                    ThermalConductivity100 = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderInsulatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderInsulatings_ProviderImportations_ProviderImportationId",
                        column: x => x.ProviderImportationId,
                        principalTable: "ProviderImportations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProviderConcretes_ProviderImportationId",
                table: "ProviderConcretes",
                column: "ProviderImportationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderInsulatings_ProviderImportationId",
                table: "ProviderInsulatings",
                column: "ProviderImportationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderConcretes");

            migrationBuilder.DropTable(
                name: "ProviderInsulatings");
        }
    }
}

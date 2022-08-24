using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportationId",
                table: "ProviderBricks");

            migrationBuilder.RenameColumn(
                name: "ProviderImportationId",
                table: "ProviderBricks",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderBricks_ProviderImportationId",
                table: "ProviderBricks",
                newName: "IX_ProviderBricks_ProviderId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Thermal_Conductivity_700",
                table: "ProviderBricks",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Thermal_Conductivity_300",
                table: "ProviderBricks",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Thermal_Conductivity_100",
                table: "ProviderBricks",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderBricks_Providers_ProviderId",
                table: "ProviderBricks",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderBricks_Providers_ProviderId",
                table: "ProviderBricks");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "ProviderBricks",
                newName: "ProviderImportationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderBricks_ProviderId",
                table: "ProviderBricks",
                newName: "IX_ProviderBricks_ProviderImportationId");

            migrationBuilder.AlterColumn<double>(
                name: "Thermal_Conductivity_700",
                table: "ProviderBricks",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Thermal_Conductivity_300",
                table: "ProviderBricks",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Thermal_Conductivity_100",
                table: "ProviderBricks",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportationId",
                table: "ProviderBricks",
                column: "ProviderImportationId",
                principalTable: "ProviderImportations",
                principalColumn: "ProviderImportationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

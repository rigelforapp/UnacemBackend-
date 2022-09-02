using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VersionId",
                table: "Versions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TyreId",
                table: "Tyres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StretchId",
                table: "Stretchs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Providers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderImportationId",
                table: "ProviderImportations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderBrickId",
                table: "ProviderBricks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OvenId",
                table: "Ovens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HeadquarterId",
                table: "Headquarters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GalleryId",
                table: "Gallery",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Color",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BudgetStretchId",
                table: "BudgetStretch",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "Budgets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BudgetCurrencyId",
                table: "BudgetCurrency",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BrickFormatId",
                table: "BrickFormats",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Versions",
                newName: "VersionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tyres",
                newName: "TyreId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stretchs",
                newName: "StretchId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Providers",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProviderImportations",
                newName: "ProviderImportationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProviderBricks",
                newName: "ProviderBrickId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ovens",
                newName: "OvenId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Headquarters",
                newName: "HeadquarterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Gallery",
                newName: "GalleryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Color",
                newName: "ColorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BudgetStretch",
                newName: "BudgetStretchId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Budgets",
                newName: "BudgetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BudgetCurrency",
                newName: "BudgetCurrencyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BrickFormats",
                newName: "BrickFormatId");
        }
    }
}

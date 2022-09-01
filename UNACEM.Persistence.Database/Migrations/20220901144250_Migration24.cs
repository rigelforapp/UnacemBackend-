using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration24 : Migration
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
                name: "BudgetCurrencyID",
                table: "BudgetCurrency",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BrickFormatId",
                table: "BrickFormats",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ovens",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Large",
                table: "Ovens",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
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
                newName: "BudgetCurrencyID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BrickFormats",
                newName: "BrickFormatId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ovens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Large",
                table: "Ovens",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }
    }
}

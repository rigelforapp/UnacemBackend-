using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Versions",
                newName: "Version_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tyres",
                newName: "Tyre_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stretchs",
                newName: "Stretch_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Providers",
                newName: "Provider_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProviderImportations",
                newName: "ProviderImportation_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProviderBricks",
                newName: "ProviderBrick_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ovens",
                newName: "Oven_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Headquarters",
                newName: "Headquarter_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Gallery",
                newName: "Gallery_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Color",
                newName: "Color_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BudgetStretch",
                newName: "BudgetStretch_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Budgets",
                newName: "Budget_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BudgetCurrency",
                newName: "BudgetCurrency_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BrickFormats",
                newName: "BrickFormat_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Version_Id",
                table: "Versions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Tyre_Id",
                table: "Tyres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Stretch_Id",
                table: "Stretchs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Provider_Id",
                table: "Providers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderImportation_Id",
                table: "ProviderImportations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderBrick_Id",
                table: "ProviderBricks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Oven_Id",
                table: "Ovens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Headquarter_Id",
                table: "Headquarters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Gallery_Id",
                table: "Gallery",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Color_Id",
                table: "Color",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BudgetStretch_Id",
                table: "BudgetStretch",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Budget_Id",
                table: "Budgets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BudgetCurrency_Id",
                table: "BudgetCurrency",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BrickFormat_Id",
                table: "BrickFormats",
                newName: "Id");
        }
    }
}

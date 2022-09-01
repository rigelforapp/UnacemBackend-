using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCurrency_Budgets_Budget_Id",
                table: "BudgetCurrency");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Versions_Version_Id",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetStretch_BrickFormats_BrickFormat_Id",
                table: "BudgetStretch");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetStretch_Budgets_Budget_Id",
                table: "BudgetStretch");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetStretch_Stretchs_Stretch_Id",
                table: "BudgetStretch");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Versions_Version_Id",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Ovens_Headquarters_Headquarter_Id",
                table: "Ovens");

            migrationBuilder.DropForeignKey(
                name: "FK_Ovens_Users_User_Id",
                table: "Ovens");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportation_Id",
                table: "ProviderBricks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderImportations_Providers_Provider_Id",
                table: "ProviderImportations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stretchs_BrickFormats_BrickFormat_Id",
                table: "Stretchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stretchs_ProviderBricks_ProviderBrick_Id",
                table: "Stretchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stretchs_Versions_Version_Id",
                table: "Stretchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Color_Color_Id",
                table: "Tyres");

            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Ovens_Oven_Id",
                table: "Tyres");

            migrationBuilder.DropForeignKey(
                name: "FK_Versions_Ovens_Oven_Id",
                table: "Versions");

            migrationBuilder.RenameColumn(
                name: "Oven_Id",
                table: "Versions",
                newName: "OvenId");

            migrationBuilder.RenameColumn(
                name: "Version_Id",
                table: "Versions",
                newName: "VersionId");

            migrationBuilder.RenameIndex(
                name: "IX_Versions_Oven_Id",
                table: "Versions",
                newName: "IX_Versions_OvenId");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Oven_Id",
                table: "Tyres",
                newName: "OvenId");

            migrationBuilder.RenameColumn(
                name: "Color_Id",
                table: "Tyres",
                newName: "ColorId");

            migrationBuilder.RenameColumn(
                name: "Tyre_Id",
                table: "Tyres",
                newName: "TyreId");

            migrationBuilder.RenameIndex(
                name: "IX_Tyres_Oven_Id",
                table: "Tyres",
                newName: "IX_Tyres_OvenId");

            migrationBuilder.RenameIndex(
                name: "IX_Tyres_Color_Id",
                table: "Tyres",
                newName: "IX_Tyres_ColorId");

            migrationBuilder.RenameColumn(
                name: "Version_Id",
                table: "Stretchs",
                newName: "VersionId");

            migrationBuilder.RenameColumn(
                name: "ProviderBrick_Id",
                table: "Stretchs",
                newName: "ProviderBrickId");

            migrationBuilder.RenameColumn(
                name: "BrickFormat_Id",
                table: "Stretchs",
                newName: "BrickFormatId");

            migrationBuilder.RenameColumn(
                name: "Stretch_Id",
                table: "Stretchs",
                newName: "StretchId");

            migrationBuilder.RenameIndex(
                name: "IX_Stretchs_Version_Id",
                table: "Stretchs",
                newName: "IX_Stretchs_VersionId");

            migrationBuilder.RenameIndex(
                name: "IX_Stretchs_ProviderBrick_Id",
                table: "Stretchs",
                newName: "IX_Stretchs_ProviderBrickId");

            migrationBuilder.RenameIndex(
                name: "IX_Stretchs_BrickFormat_Id",
                table: "Stretchs",
                newName: "IX_Stretchs_BrickFormatId");

            migrationBuilder.RenameColumn(
                name: "Provider_Id",
                table: "Providers",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "Provider_Id",
                table: "ProviderImportations",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "ProviderImportation_Id",
                table: "ProviderImportations",
                newName: "ProviderImportationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderImportations_Provider_Id",
                table: "ProviderImportations",
                newName: "IX_ProviderImportations_ProviderId");

            migrationBuilder.RenameColumn(
                name: "ProviderImportation_Id",
                table: "ProviderBricks",
                newName: "ProviderImportationId");

            migrationBuilder.RenameColumn(
                name: "ProviderBrick_Id",
                table: "ProviderBricks",
                newName: "ProviderBrickId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderBricks_ProviderImportation_Id",
                table: "ProviderBricks",
                newName: "IX_ProviderBricks_ProviderImportationId");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Ovens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Headquarter_Id",
                table: "Ovens",
                newName: "HeadquarterId");

            migrationBuilder.RenameColumn(
                name: "Oven_Id",
                table: "Ovens",
                newName: "OvenId");

            migrationBuilder.RenameIndex(
                name: "IX_Ovens_User_Id",
                table: "Ovens",
                newName: "IX_Ovens_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ovens_Headquarter_Id",
                table: "Ovens",
                newName: "IX_Ovens_HeadquarterId");

            migrationBuilder.RenameColumn(
                name: "Headquarter_Id",
                table: "Headquarters",
                newName: "HeadquarterId");

            migrationBuilder.RenameColumn(
                name: "Version_Id",
                table: "Gallery",
                newName: "VersionId");

            migrationBuilder.RenameColumn(
                name: "Gallery_Id",
                table: "Gallery",
                newName: "GalleryId");

            migrationBuilder.RenameIndex(
                name: "IX_Gallery_Version_Id",
                table: "Gallery",
                newName: "IX_Gallery_VersionId");

            migrationBuilder.RenameColumn(
                name: "Color_Id",
                table: "Color",
                newName: "ColorId");

            migrationBuilder.RenameColumn(
                name: "Stretch_Id",
                table: "BudgetStretch",
                newName: "StretchId");

            migrationBuilder.RenameColumn(
                name: "Budget_Id",
                table: "BudgetStretch",
                newName: "BudgetId");

            migrationBuilder.RenameColumn(
                name: "BrickFormat_Id",
                table: "BudgetStretch",
                newName: "BrickFormatId");

            migrationBuilder.RenameColumn(
                name: "BudgetStretch_Id",
                table: "BudgetStretch",
                newName: "BudgetStretchId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetStretch_Stretch_Id",
                table: "BudgetStretch",
                newName: "IX_BudgetStretch_StretchId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetStretch_Budget_Id",
                table: "BudgetStretch",
                newName: "IX_BudgetStretch_BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetStretch_BrickFormat_Id",
                table: "BudgetStretch",
                newName: "IX_BudgetStretch_BrickFormatId");

            migrationBuilder.RenameColumn(
                name: "Version_Id",
                table: "Budgets",
                newName: "VersionId");

            migrationBuilder.RenameColumn(
                name: "Budget_Id",
                table: "Budgets",
                newName: "BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_Version_Id",
                table: "Budgets",
                newName: "IX_Budgets_VersionId");

            migrationBuilder.RenameColumn(
                name: "Budget_Id",
                table: "BudgetCurrency",
                newName: "BudgetId");

            migrationBuilder.RenameColumn(
                name: "BudgetCurrency_Id",
                table: "BudgetCurrency",
                newName: "BudgetCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCurrency_Budget_Id",
                table: "BudgetCurrency",
                newName: "IX_BudgetCurrency_BudgetId");

            migrationBuilder.RenameColumn(
                name: "BrickFormat_Id",
                table: "BrickFormats",
                newName: "BrickFormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCurrency_Budgets_BudgetId",
                table: "BudgetCurrency",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "BudgetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Versions_VersionId",
                table: "Budgets",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "VersionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_BrickFormats_BrickFormatId",
                table: "BudgetStretch",
                column: "BrickFormatId",
                principalTable: "BrickFormats",
                principalColumn: "BrickFormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Budgets_BudgetId",
                table: "BudgetStretch",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "BudgetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Stretchs_StretchId",
                table: "BudgetStretch",
                column: "StretchId",
                principalTable: "Stretchs",
                principalColumn: "StretchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Versions_VersionId",
                table: "Gallery",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "VersionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Headquarters_HeadquarterId",
                table: "Ovens",
                column: "HeadquarterId",
                principalTable: "Headquarters",
                principalColumn: "HeadquarterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Users_UserId",
                table: "Ovens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportationId",
                table: "ProviderBricks",
                column: "ProviderImportationId",
                principalTable: "ProviderImportations",
                principalColumn: "ProviderImportationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderImportations_Providers_ProviderId",
                table: "ProviderImportations",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_BrickFormats_BrickFormatId",
                table: "Stretchs",
                column: "BrickFormatId",
                principalTable: "BrickFormats",
                principalColumn: "BrickFormatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_ProviderBricks_ProviderBrickId",
                table: "Stretchs",
                column: "ProviderBrickId",
                principalTable: "ProviderBricks",
                principalColumn: "ProviderBrickId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_Versions_VersionId",
                table: "Stretchs",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "VersionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Ovens_OvenId",
                table: "Tyres",
                column: "OvenId",
                principalTable: "Ovens",
                principalColumn: "OvenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Versions_Ovens_OvenId",
                table: "Versions",
                column: "OvenId",
                principalTable: "Ovens",
                principalColumn: "OvenId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCurrency_Budgets_BudgetId",
                table: "BudgetCurrency");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Versions_VersionId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetStretch_BrickFormats_BrickFormatId",
                table: "BudgetStretch");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetStretch_Budgets_BudgetId",
                table: "BudgetStretch");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetStretch_Stretchs_StretchId",
                table: "BudgetStretch");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Versions_VersionId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Ovens_Headquarters_HeadquarterId",
                table: "Ovens");

            migrationBuilder.DropForeignKey(
                name: "FK_Ovens_Users_UserId",
                table: "Ovens");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportationId",
                table: "ProviderBricks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderImportations_Providers_ProviderId",
                table: "ProviderImportations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stretchs_BrickFormats_BrickFormatId",
                table: "Stretchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stretchs_ProviderBricks_ProviderBrickId",
                table: "Stretchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stretchs_Versions_VersionId",
                table: "Stretchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres");

            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Ovens_OvenId",
                table: "Tyres");

            migrationBuilder.DropForeignKey(
                name: "FK_Versions_Ovens_OvenId",
                table: "Versions");

            migrationBuilder.RenameColumn(
                name: "OvenId",
                table: "Versions",
                newName: "Oven_Id");

            migrationBuilder.RenameColumn(
                name: "VersionId",
                table: "Versions",
                newName: "Version_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Versions_OvenId",
                table: "Versions",
                newName: "IX_Versions_Oven_Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "OvenId",
                table: "Tyres",
                newName: "Oven_Id");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Tyres",
                newName: "Color_Id");

            migrationBuilder.RenameColumn(
                name: "TyreId",
                table: "Tyres",
                newName: "Tyre_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tyres_OvenId",
                table: "Tyres",
                newName: "IX_Tyres_Oven_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tyres_ColorId",
                table: "Tyres",
                newName: "IX_Tyres_Color_Id");

            migrationBuilder.RenameColumn(
                name: "VersionId",
                table: "Stretchs",
                newName: "Version_Id");

            migrationBuilder.RenameColumn(
                name: "ProviderBrickId",
                table: "Stretchs",
                newName: "ProviderBrick_Id");

            migrationBuilder.RenameColumn(
                name: "BrickFormatId",
                table: "Stretchs",
                newName: "BrickFormat_Id");

            migrationBuilder.RenameColumn(
                name: "StretchId",
                table: "Stretchs",
                newName: "Stretch_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Stretchs_VersionId",
                table: "Stretchs",
                newName: "IX_Stretchs_Version_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Stretchs_ProviderBrickId",
                table: "Stretchs",
                newName: "IX_Stretchs_ProviderBrick_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Stretchs_BrickFormatId",
                table: "Stretchs",
                newName: "IX_Stretchs_BrickFormat_Id");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Providers",
                newName: "Provider_Id");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "ProviderImportations",
                newName: "Provider_Id");

            migrationBuilder.RenameColumn(
                name: "ProviderImportationId",
                table: "ProviderImportations",
                newName: "ProviderImportation_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderImportations_ProviderId",
                table: "ProviderImportations",
                newName: "IX_ProviderImportations_Provider_Id");

            migrationBuilder.RenameColumn(
                name: "ProviderImportationId",
                table: "ProviderBricks",
                newName: "ProviderImportation_Id");

            migrationBuilder.RenameColumn(
                name: "ProviderBrickId",
                table: "ProviderBricks",
                newName: "ProviderBrick_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderBricks_ProviderImportationId",
                table: "ProviderBricks",
                newName: "IX_ProviderBricks_ProviderImportation_Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ovens",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "HeadquarterId",
                table: "Ovens",
                newName: "Headquarter_Id");

            migrationBuilder.RenameColumn(
                name: "OvenId",
                table: "Ovens",
                newName: "Oven_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ovens_UserId",
                table: "Ovens",
                newName: "IX_Ovens_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ovens_HeadquarterId",
                table: "Ovens",
                newName: "IX_Ovens_Headquarter_Id");

            migrationBuilder.RenameColumn(
                name: "HeadquarterId",
                table: "Headquarters",
                newName: "Headquarter_Id");

            migrationBuilder.RenameColumn(
                name: "VersionId",
                table: "Gallery",
                newName: "Version_Id");

            migrationBuilder.RenameColumn(
                name: "GalleryId",
                table: "Gallery",
                newName: "Gallery_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Gallery_VersionId",
                table: "Gallery",
                newName: "IX_Gallery_Version_Id");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Color",
                newName: "Color_Id");

            migrationBuilder.RenameColumn(
                name: "StretchId",
                table: "BudgetStretch",
                newName: "Stretch_Id");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "BudgetStretch",
                newName: "Budget_Id");

            migrationBuilder.RenameColumn(
                name: "BrickFormatId",
                table: "BudgetStretch",
                newName: "BrickFormat_Id");

            migrationBuilder.RenameColumn(
                name: "BudgetStretchId",
                table: "BudgetStretch",
                newName: "BudgetStretch_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetStretch_StretchId",
                table: "BudgetStretch",
                newName: "IX_BudgetStretch_Stretch_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetStretch_BudgetId",
                table: "BudgetStretch",
                newName: "IX_BudgetStretch_Budget_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetStretch_BrickFormatId",
                table: "BudgetStretch",
                newName: "IX_BudgetStretch_BrickFormat_Id");

            migrationBuilder.RenameColumn(
                name: "VersionId",
                table: "Budgets",
                newName: "Version_Id");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "Budgets",
                newName: "Budget_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_VersionId",
                table: "Budgets",
                newName: "IX_Budgets_Version_Id");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "BudgetCurrency",
                newName: "Budget_Id");

            migrationBuilder.RenameColumn(
                name: "BudgetCurrencyId",
                table: "BudgetCurrency",
                newName: "BudgetCurrency_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCurrency_BudgetId",
                table: "BudgetCurrency",
                newName: "IX_BudgetCurrency_Budget_Id");

            migrationBuilder.RenameColumn(
                name: "BrickFormatId",
                table: "BrickFormats",
                newName: "BrickFormat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCurrency_Budgets_Budget_Id",
                table: "BudgetCurrency",
                column: "Budget_Id",
                principalTable: "Budgets",
                principalColumn: "Budget_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Versions_Version_Id",
                table: "Budgets",
                column: "Version_Id",
                principalTable: "Versions",
                principalColumn: "Version_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_BrickFormats_BrickFormat_Id",
                table: "BudgetStretch",
                column: "BrickFormat_Id",
                principalTable: "BrickFormats",
                principalColumn: "BrickFormat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Budgets_Budget_Id",
                table: "BudgetStretch",
                column: "Budget_Id",
                principalTable: "Budgets",
                principalColumn: "Budget_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Stretchs_Stretch_Id",
                table: "BudgetStretch",
                column: "Stretch_Id",
                principalTable: "Stretchs",
                principalColumn: "Stretch_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Versions_Version_Id",
                table: "Gallery",
                column: "Version_Id",
                principalTable: "Versions",
                principalColumn: "Version_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Headquarters_Headquarter_Id",
                table: "Ovens",
                column: "Headquarter_Id",
                principalTable: "Headquarters",
                principalColumn: "Headquarter_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Users_User_Id",
                table: "Ovens",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportation_Id",
                table: "ProviderBricks",
                column: "ProviderImportation_Id",
                principalTable: "ProviderImportations",
                principalColumn: "ProviderImportation_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderImportations_Providers_Provider_Id",
                table: "ProviderImportations",
                column: "Provider_Id",
                principalTable: "Providers",
                principalColumn: "Provider_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_BrickFormats_BrickFormat_Id",
                table: "Stretchs",
                column: "BrickFormat_Id",
                principalTable: "BrickFormats",
                principalColumn: "BrickFormat_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_ProviderBricks_ProviderBrick_Id",
                table: "Stretchs",
                column: "ProviderBrick_Id",
                principalTable: "ProviderBricks",
                principalColumn: "ProviderBrick_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_Versions_Version_Id",
                table: "Stretchs",
                column: "Version_Id",
                principalTable: "Versions",
                principalColumn: "Version_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Color_Color_Id",
                table: "Tyres",
                column: "Color_Id",
                principalTable: "Color",
                principalColumn: "Color_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Ovens_Oven_Id",
                table: "Tyres",
                column: "Oven_Id",
                principalTable: "Ovens",
                principalColumn: "Oven_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Versions_Ovens_Oven_Id",
                table: "Versions",
                column: "Oven_Id",
                principalTable: "Ovens",
                principalColumn: "Oven_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

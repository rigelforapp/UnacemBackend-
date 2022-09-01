using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Stretchs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ProviderImportations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ProviderBricks");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Ovens");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Headquarters");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BudgetCurrency");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BrickFormats");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Versions",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "OvenId",
                table: "Versions",
                newName: "Oven_Id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Versions",
                newName: "Created_At");

            migrationBuilder.RenameIndex(
                name: "IX_Versions_OvenId",
                table: "Versions",
                newName: "IX_Versions_Oven_Id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Tyres",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "TextureId",
                table: "Tyres",
                newName: "Texture_Id");

            migrationBuilder.RenameColumn(
                name: "OvenId",
                table: "Tyres",
                newName: "Oven_Id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Tyres",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Tyres",
                newName: "Color_Id");

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
                name: "UpdatedAt",
                table: "Stretchs",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "ProviderBrickId",
                table: "Stretchs",
                newName: "ProviderBrick_Id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Stretchs",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "BrickFormatId",
                table: "Stretchs",
                newName: "BrickFormat_Id");

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
                name: "UpdatedBy",
                table: "Providers",
                newName: "Updated_By");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Providers",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Providers",
                newName: "Deleted_By");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Providers",
                newName: "Created_By");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Providers",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ProviderImportations",
                newName: "Updated_By");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ProviderImportations",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "ProviderImportations",
                newName: "Provider_Id");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProviderImportations",
                newName: "Deleted_By");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ProviderImportations",
                newName: "Created_By");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ProviderImportations",
                newName: "Created_At");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderImportations_ProviderId",
                table: "ProviderImportations",
                newName: "IX_ProviderImportations_Provider_Id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ProviderBricks",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "ProviderImportationId",
                table: "ProviderBricks",
                newName: "ProviderImportation_Id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ProviderBricks",
                newName: "Deleted_At");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderBricks_ProviderImportationId",
                table: "ProviderBricks",
                newName: "IX_ProviderBricks_ProviderImportation_Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ovens",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Ovens",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "HeadquarterId",
                table: "Ovens",
                newName: "Headquarter_Id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Ovens",
                newName: "Created_At");

            migrationBuilder.RenameIndex(
                name: "IX_Ovens_UserId",
                table: "Ovens",
                newName: "IX_Ovens_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ovens_HeadquarterId",
                table: "Ovens",
                newName: "IX_Ovens_Headquarter_Id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Headquarters",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Headquarters",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "VersionId",
                table: "Gallery",
                newName: "Version_Id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Gallery",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Gallery",
                newName: "Deleted_At");

            migrationBuilder.RenameIndex(
                name: "IX_Gallery_VersionId",
                table: "Gallery",
                newName: "IX_Gallery_Version_Id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BudgetStretch",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "StretchId",
                table: "BudgetStretch",
                newName: "Stretch_Id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BudgetStretch",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "BudgetStretch",
                newName: "Budget_Id");

            migrationBuilder.RenameColumn(
                name: "BrickFormatId",
                table: "BudgetStretch",
                newName: "BrickFormat_Id");

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
                name: "UpdatedAt",
                table: "Budgets",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Budgets",
                newName: "Created_At");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_VersionId",
                table: "Budgets",
                newName: "IX_Budgets_Version_Id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BudgetCurrency",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BudgetCurrency",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "BudgetCurrency",
                newName: "Budget_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCurrency_BudgetId",
                table: "BudgetCurrency",
                newName: "IX_BudgetCurrency_Budget_Id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BrickFormats",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BrickFormats",
                newName: "Created_At");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Versions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Position",
                table: "Tyres",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Tyres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Stretchs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Providers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "ProviderImportations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "ProviderBricks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Ovens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Headquarters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Gallery",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "BudgetStretch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Budgets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "BudgetCurrency",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "BrickFormats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCurrency_Budgets_Budget_Id",
                table: "BudgetCurrency",
                column: "Budget_Id",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Versions_Version_Id",
                table: "Budgets",
                column: "Version_Id",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_BrickFormats_BrickFormat_Id",
                table: "BudgetStretch",
                column: "BrickFormat_Id",
                principalTable: "BrickFormats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Budgets_Budget_Id",
                table: "BudgetStretch",
                column: "Budget_Id",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Stretchs_Stretch_Id",
                table: "BudgetStretch",
                column: "Stretch_Id",
                principalTable: "Stretchs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Versions_Version_Id",
                table: "Gallery",
                column: "Version_Id",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Headquarters_Headquarter_Id",
                table: "Ovens",
                column: "Headquarter_Id",
                principalTable: "Headquarters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Users_User_Id",
                table: "Ovens",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportation_Id",
                table: "ProviderBricks",
                column: "ProviderImportation_Id",
                principalTable: "ProviderImportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderImportations_Providers_Provider_Id",
                table: "ProviderImportations",
                column: "Provider_Id",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_BrickFormats_BrickFormat_Id",
                table: "Stretchs",
                column: "BrickFormat_Id",
                principalTable: "BrickFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_ProviderBricks_ProviderBrick_Id",
                table: "Stretchs",
                column: "ProviderBrick_Id",
                principalTable: "ProviderBricks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_Versions_Version_Id",
                table: "Stretchs",
                column: "Version_Id",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Color_Color_Id",
                table: "Tyres",
                column: "Color_Id",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Ovens_Oven_Id",
                table: "Tyres",
                column: "Oven_Id",
                principalTable: "Ovens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Versions_Ovens_Oven_Id",
                table: "Versions",
                column: "Oven_Id",
                principalTable: "Ovens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Stretchs");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "ProviderImportations");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "ProviderBricks");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Ovens");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Headquarters");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "BudgetCurrency");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "BrickFormats");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Versions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Oven_Id",
                table: "Versions",
                newName: "OvenId");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Versions",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Versions_Oven_Id",
                table: "Versions",
                newName: "IX_Versions_OvenId");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Tyres",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Texture_Id",
                table: "Tyres",
                newName: "TextureId");

            migrationBuilder.RenameColumn(
                name: "Oven_Id",
                table: "Tyres",
                newName: "OvenId");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Tyres",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Color_Id",
                table: "Tyres",
                newName: "ColorId");

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
                name: "Updated_At",
                table: "Stretchs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ProviderBrick_Id",
                table: "Stretchs",
                newName: "ProviderBrickId");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Stretchs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "BrickFormat_Id",
                table: "Stretchs",
                newName: "BrickFormatId");

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
                name: "Updated_By",
                table: "Providers",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Providers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_By",
                table: "Providers",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Created_By",
                table: "Providers",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Providers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_By",
                table: "ProviderImportations",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "ProviderImportations",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Provider_Id",
                table: "ProviderImportations",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "Deleted_By",
                table: "ProviderImportations",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Created_By",
                table: "ProviderImportations",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "ProviderImportations",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderImportations_Provider_Id",
                table: "ProviderImportations",
                newName: "IX_ProviderImportations_ProviderId");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "ProviderBricks",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ProviderImportation_Id",
                table: "ProviderBricks",
                newName: "ProviderImportationId");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "ProviderBricks",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderBricks_ProviderImportation_Id",
                table: "ProviderBricks",
                newName: "IX_ProviderBricks_ProviderImportationId");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Ovens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Ovens",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Headquarter_Id",
                table: "Ovens",
                newName: "HeadquarterId");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Ovens",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Ovens_User_Id",
                table: "Ovens",
                newName: "IX_Ovens_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ovens_Headquarter_Id",
                table: "Ovens",
                newName: "IX_Ovens_HeadquarterId");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Headquarters",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Headquarters",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Version_Id",
                table: "Gallery",
                newName: "VersionId");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Gallery",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Gallery",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Gallery_Version_Id",
                table: "Gallery",
                newName: "IX_Gallery_VersionId");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "BudgetStretch",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Stretch_Id",
                table: "BudgetStretch",
                newName: "StretchId");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "BudgetStretch",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Budget_Id",
                table: "BudgetStretch",
                newName: "BudgetId");

            migrationBuilder.RenameColumn(
                name: "BrickFormat_Id",
                table: "BudgetStretch",
                newName: "BrickFormatId");

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
                name: "Updated_At",
                table: "Budgets",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Budgets",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_Version_Id",
                table: "Budgets",
                newName: "IX_Budgets_VersionId");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "BudgetCurrency",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "BudgetCurrency",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Budget_Id",
                table: "BudgetCurrency",
                newName: "BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCurrency_Budget_Id",
                table: "BudgetCurrency",
                newName: "IX_BudgetCurrency_BudgetId");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "BrickFormats",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "BrickFormats",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Versions",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "Tyres",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tyres",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Stretchs",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Providers",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ProviderImportations",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ProviderBricks",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Ovens",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Headquarters",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Gallery",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BudgetStretch",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Budgets",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BudgetCurrency",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BrickFormats",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCurrency_Budgets_BudgetId",
                table: "BudgetCurrency",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Versions_VersionId",
                table: "Budgets",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_BrickFormats_BrickFormatId",
                table: "BudgetStretch",
                column: "BrickFormatId",
                principalTable: "BrickFormats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Budgets_BudgetId",
                table: "BudgetStretch",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Stretchs_StretchId",
                table: "BudgetStretch",
                column: "StretchId",
                principalTable: "Stretchs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Versions_VersionId",
                table: "Gallery",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Headquarters_HeadquarterId",
                table: "Ovens",
                column: "HeadquarterId",
                principalTable: "Headquarters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Users_UserId",
                table: "Ovens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportationId",
                table: "ProviderBricks",
                column: "ProviderImportationId",
                principalTable: "ProviderImportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderImportations_Providers_ProviderId",
                table: "ProviderImportations",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_BrickFormats_BrickFormatId",
                table: "Stretchs",
                column: "BrickFormatId",
                principalTable: "BrickFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_ProviderBricks_ProviderBrickId",
                table: "Stretchs",
                column: "ProviderBrickId",
                principalTable: "ProviderBricks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stretchs_Versions_VersionId",
                table: "Stretchs",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Ovens_OvenId",
                table: "Tyres",
                column: "OvenId",
                principalTable: "Ovens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Versions_Ovens_OvenId",
                table: "Versions",
                column: "OvenId",
                principalTable: "Ovens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

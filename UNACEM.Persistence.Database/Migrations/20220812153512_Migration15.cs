using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderBricks_Providers_ProviderId",
                table: "ProviderBricks");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Versions",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Versions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Versions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Users",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Tyres",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Tyres",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Tyres",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Stretchs",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Stretchs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Stretchs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Providers",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Providers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Providers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ProviderImportations",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "ProviderImportations",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "ProviderImportations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "ProviderBricks",
                newName: "ProviderImportationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderBricks_ProviderId",
                table: "ProviderBricks",
                newName: "IX_ProviderBricks_ProviderImportationId");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Ovens",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Ovens",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Ovens",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Headquarters",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Headquarters",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Headquarters",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Color",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Color",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Color",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "BudgetStretch",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "BudgetStretch",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "BudgetStretch",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Budgets",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Budgets",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Budgets",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "BudgetCurrency",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "BudgetCurrency",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "BudgetCurrency",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "BrickFormats",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "BrickFormats",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "BrickFormats",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Versions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Versions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tyres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Tyres",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Stretchs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Stretchs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Providers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Providers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ProviderImportations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ProviderImportations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Ovens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Ovens",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Headquarters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Headquarters",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Color",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Color",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BudgetStretch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "BudgetStretch",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Budgets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Budgets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BudgetCurrency",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "BudgetCurrency",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BrickFormats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "BrickFormats",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportationId",
                table: "ProviderBricks",
                column: "ProviderImportationId",
                principalTable: "ProviderImportations",
                principalColumn: "ProviderImportationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderBricks_ProviderImportations_ProviderImportationId",
                table: "ProviderBricks");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Stretchs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Stretchs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ProviderImportations");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ProviderImportations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Ovens");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Ovens");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Headquarters");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Headquarters");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BudgetCurrency");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "BudgetCurrency");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BrickFormats");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "BrickFormats");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Versions",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Versions",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Versions",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Users",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Tyres",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Tyres",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Tyres",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Stretchs",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Stretchs",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Stretchs",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Providers",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Providers",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Providers",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ProviderImportations",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ProviderImportations",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ProviderImportations",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "ProviderImportationId",
                table: "ProviderBricks",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderBricks_ProviderImportationId",
                table: "ProviderBricks",
                newName: "IX_ProviderBricks_ProviderId");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Ovens",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Ovens",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Ovens",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Headquarters",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Headquarters",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Headquarters",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Color",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Color",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Color",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "BudgetStretch",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BudgetStretch",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BudgetStretch",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Budgets",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Budgets",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Budgets",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "BudgetCurrency",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BudgetCurrency",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BudgetCurrency",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "BrickFormats",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BrickFormats",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BrickFormats",
                newName: "CreationDate");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderBricks_Providers_ProviderId",
                table: "ProviderBricks",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Stretchs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Stretchs");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Stretchs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ovens");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Ovens");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Ovens");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Headquarters");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Headquarters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Headquarters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BudgetCurrency");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "BudgetCurrency");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BudgetCurrency");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BrickFormats");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "BrickFormats");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BrickFormats");

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ProviderImportations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Versions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Versions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Versions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tyres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Tyres",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Tyres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Stretchs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Stretchs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Stretchs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Providers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ProviderImportations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Ovens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Ovens",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Ovens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Headquarters",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Headquarters",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Headquarters",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Gallery",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Color",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Color",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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
                name: "UpdatedAt",
                table: "Color",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Color",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BudgetStretch",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "BudgetStretch",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BudgetStretch",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Budgets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Budgets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Budgets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BudgetCurrency",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "BudgetCurrency",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BudgetCurrency",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BrickFormats",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "BrickFormats",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BrickFormats",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}

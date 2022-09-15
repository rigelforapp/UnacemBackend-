using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "BudgetsCi",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "BudgetsCi",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BudgetsCi",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "BudgetsCi",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "BudgetsCi",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BudgetsCi",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);
        }
    }
}

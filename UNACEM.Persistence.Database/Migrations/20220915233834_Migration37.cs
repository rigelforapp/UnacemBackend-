using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "BudgetsCi",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "BudgetsCi",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Budgets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Budgets",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Budgets",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Budgets",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "Budgets",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProviderBricks");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProviderBricks");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProviderBricks");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ProviderBricks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProviderBricks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProviderBricks",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProviderBricks",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ProviderBricks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}

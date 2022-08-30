using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class ActualizarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BrickFormats",
                newName: "BrickFormatsId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity_b",
                table: "BrickFormats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity_a",
                table: "BrickFormats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "BrickFormats",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Diameter",
                table: "BrickFormats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brick_b",
                table: "BrickFormats",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brick_a",
                table: "BrickFormats",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BrickFormats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "BrickFormats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "BrickFormats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "BrickFormats",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BrickFormats");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "BrickFormats");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "BrickFormats");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BrickFormats");

            migrationBuilder.RenameColumn(
                name: "BrickFormatsId",
                table: "BrickFormats",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Quantity_b",
                table: "BrickFormats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Quantity_a",
                table: "BrickFormats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "BrickFormats",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diameter",
                table: "BrickFormats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Brick_b",
                table: "BrickFormats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brick_a",
                table: "BrickFormats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}

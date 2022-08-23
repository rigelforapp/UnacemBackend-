using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class AddTables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "OvenId",
                table: "Tyres");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Tyres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Tyres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OvenId",
                table: "Tyres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class AddTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres");

            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Ovens_OvensOvenId",
                table: "Tyres");

            migrationBuilder.DropIndex(
                name: "IX_Tyres_ColorId",
                table: "Tyres");

            migrationBuilder.DropIndex(
                name: "IX_Tyres_OvensOvenId",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "OvensOvenId",
                table: "Tyres");

            migrationBuilder.AddColumn<int>(
                name: "TyreId",
                table: "Color",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Color_TyreId",
                table: "Color",
                column: "TyreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Tyres_TyreId",
                table: "Color",
                column: "TyreId",
                principalTable: "Tyres",
                principalColumn: "TyreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Tyres_TyreId",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_TyreId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "TyreId",
                table: "Color");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Tyres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OvensOvenId",
                table: "Tyres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tyres_ColorId",
                table: "Tyres",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tyres_OvensOvenId",
                table: "Tyres",
                column: "OvensOvenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Ovens_OvensOvenId",
                table: "Tyres",
                column: "OvensOvenId",
                principalTable: "Ovens",
                principalColumn: "OvenId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

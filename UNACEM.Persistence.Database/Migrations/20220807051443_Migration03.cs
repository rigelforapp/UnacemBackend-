using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Tyres_TyresTyreId",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_TyresTyreId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "TyreId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "TyresTyreId",
                table: "Color");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Tyres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tyres_ColorId",
                table: "Tyres",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Color_ColorId",
                table: "Tyres");

            migrationBuilder.DropIndex(
                name: "IX_Tyres_ColorId",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Tyres");

            migrationBuilder.AddColumn<int>(
                name: "TyreId",
                table: "Color",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TyresTyreId",
                table: "Color",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_TyresTyreId",
                table: "Color",
                column: "TyresTyreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Tyres_TyresTyreId",
                table: "Color",
                column: "TyresTyreId",
                principalTable: "Tyres",
                principalColumn: "TyreId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

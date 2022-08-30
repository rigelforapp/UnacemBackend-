using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Tyres_TyreId",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_TyreId",
                table: "Color");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Tyres_TyresTyreId",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_TyresTyreId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "TyresTyreId",
                table: "Color");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OvenId",
                table: "Tyres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OvensOvenId",
                table: "Tyres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tyres_OvensOvenId",
                table: "Tyres",
                column: "OvensOvenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Ovens_OvensOvenId",
                table: "Tyres",
                column: "OvensOvenId",
                principalTable: "Ovens",
                principalColumn: "OvenId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Ovens_OvensOvenId",
                table: "Tyres");

            migrationBuilder.DropIndex(
                name: "IX_Tyres_OvensOvenId",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "OvenId",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "OvensOvenId",
                table: "Tyres");
        }
    }
}

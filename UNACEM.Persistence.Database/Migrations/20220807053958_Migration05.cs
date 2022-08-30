using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ovens_Headquarters_HeadquartersHeadquarterId",
                table: "Ovens");

            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Ovens_OvensOvenId",
                table: "Tyres");

            migrationBuilder.DropIndex(
                name: "IX_Tyres_OvensOvenId",
                table: "Tyres");

            migrationBuilder.DropIndex(
                name: "IX_Ovens_HeadquartersHeadquarterId",
                table: "Ovens");

            migrationBuilder.DropColumn(
                name: "OvensOvenId",
                table: "Tyres");

            migrationBuilder.DropColumn(
                name: "HeadquartersHeadquarterId",
                table: "Ovens");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ovens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tyres_OvenId",
                table: "Tyres",
                column: "OvenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ovens_HeadquarterId",
                table: "Ovens",
                column: "HeadquarterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ovens_UserId",
                table: "Ovens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Headquarters_HeadquarterId",
                table: "Ovens",
                column: "HeadquarterId",
                principalTable: "Headquarters",
                principalColumn: "HeadquarterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Users_UserId",
                table: "Ovens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tyres_Ovens_OvenId",
                table: "Tyres",
                column: "OvenId",
                principalTable: "Ovens",
                principalColumn: "OvenId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ovens_Headquarters_HeadquarterId",
                table: "Ovens");

            migrationBuilder.DropForeignKey(
                name: "FK_Ovens_Users_UserId",
                table: "Ovens");

            migrationBuilder.DropForeignKey(
                name: "FK_Tyres_Ovens_OvenId",
                table: "Tyres");

            migrationBuilder.DropIndex(
                name: "IX_Tyres_OvenId",
                table: "Tyres");

            migrationBuilder.DropIndex(
                name: "IX_Ovens_HeadquarterId",
                table: "Ovens");

            migrationBuilder.DropIndex(
                name: "IX_Ovens_UserId",
                table: "Ovens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ovens");

            migrationBuilder.AddColumn<int>(
                name: "OvensOvenId",
                table: "Tyres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeadquartersHeadquarterId",
                table: "Ovens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tyres_OvensOvenId",
                table: "Tyres",
                column: "OvensOvenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ovens_HeadquartersHeadquarterId",
                table: "Ovens",
                column: "HeadquartersHeadquarterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ovens_Headquarters_HeadquartersHeadquarterId",
                table: "Ovens",
                column: "HeadquartersHeadquarterId",
                principalTable: "Headquarters",
                principalColumn: "HeadquarterId",
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

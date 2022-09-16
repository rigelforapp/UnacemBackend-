using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Versions_Ovens_OvenId",
                table: "Versions");

            migrationBuilder.AlterColumn<int>(
                name: "OvenId",
                table: "Versions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Versions_Ovens_OvenId",
                table: "Versions",
                column: "OvenId",
                principalTable: "Ovens",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Versions_Ovens_OvenId",
                table: "Versions");

            migrationBuilder.AlterColumn<int>(
                name: "OvenId",
                table: "Versions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Versions_Ovens_OvenId",
                table: "Versions",
                column: "OvenId",
                principalTable: "Ovens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

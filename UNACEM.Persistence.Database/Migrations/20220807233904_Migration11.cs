using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrickFormatId",
                table: "BudgetStretch",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetStretch_BrickFormatId",
                table: "BudgetStretch",
                column: "BrickFormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_BrickFormats_BrickFormatId",
                table: "BudgetStretch",
                column: "BrickFormatId",
                principalTable: "BrickFormats",
                principalColumn: "BrickFormatId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetStretch_BrickFormats_BrickFormatId",
                table: "BudgetStretch");

            migrationBuilder.DropIndex(
                name: "IX_BudgetStretch_BrickFormatId",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "BrickFormatId",
                table: "BudgetStretch");
        }
    }
}

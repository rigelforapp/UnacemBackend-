using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StretchId",
                table: "BudgetStretch",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetStretch_StretchId",
                table: "BudgetStretch",
                column: "StretchId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Stretchs_StretchId",
                table: "BudgetStretch",
                column: "StretchId",
                principalTable: "Stretchs",
                principalColumn: "StretchId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetStretch_Stretchs_StretchId",
                table: "BudgetStretch");

            migrationBuilder.DropIndex(
                name: "IX_BudgetStretch_StretchId",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "StretchId",
                table: "BudgetStretch");
        }
    }
}

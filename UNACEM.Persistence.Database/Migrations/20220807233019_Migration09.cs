using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "BudgetStretch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetStretch_BudgetId",
                table: "BudgetStretch",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetStretch_Budgets_BudgetId",
                table: "BudgetStretch",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "BudgetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetStretch_Budgets_BudgetId",
                table: "BudgetStretch");

            migrationBuilder.DropIndex(
                name: "IX_BudgetStretch_BudgetId",
                table: "BudgetStretch");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "BudgetStretch");
        }
    }
}

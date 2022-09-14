using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderInsulatingId",
                table: "BudgetCiRows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCiRows_ProviderInsulatingId",
                table: "BudgetCiRows",
                column: "ProviderInsulatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCiRows_ProviderInsulatings_ProviderInsulatingId",
                table: "BudgetCiRows",
                column: "ProviderInsulatingId",
                principalTable: "ProviderInsulatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCiRows_ProviderInsulatings_ProviderInsulatingId",
                table: "BudgetCiRows");

            migrationBuilder.DropIndex(
                name: "IX_BudgetCiRows_ProviderInsulatingId",
                table: "BudgetCiRows");

            migrationBuilder.DropColumn(
                name: "ProviderInsulatingId",
                table: "BudgetCiRows");
        }
    }
}

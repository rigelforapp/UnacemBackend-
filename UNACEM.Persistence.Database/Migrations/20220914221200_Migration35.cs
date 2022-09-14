using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCiRows_ProviderInsulatings_ProviderInsulatingId",
                table: "BudgetCiRows");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderInsulatingId",
                table: "BudgetCiRows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProviderConcretesId",
                table: "BudgetCiRows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCiRows_ProviderConcretesId",
                table: "BudgetCiRows",
                column: "ProviderConcretesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCiRows_ProviderConcretes_ProviderConcretesId",
                table: "BudgetCiRows",
                column: "ProviderConcretesId",
                principalTable: "ProviderConcretes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCiRows_ProviderInsulatings_ProviderInsulatingId",
                table: "BudgetCiRows",
                column: "ProviderInsulatingId",
                principalTable: "ProviderInsulatings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCiRows_ProviderConcretes_ProviderConcretesId",
                table: "BudgetCiRows");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCiRows_ProviderInsulatings_ProviderInsulatingId",
                table: "BudgetCiRows");

            migrationBuilder.DropIndex(
                name: "IX_BudgetCiRows_ProviderConcretesId",
                table: "BudgetCiRows");

            migrationBuilder.DropColumn(
                name: "ProviderConcretesId",
                table: "BudgetCiRows");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderInsulatingId",
                table: "BudgetCiRows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCiRows_ProviderInsulatings_ProviderInsulatingId",
                table: "BudgetCiRows",
                column: "ProviderInsulatingId",
                principalTable: "ProviderInsulatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

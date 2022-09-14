using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class Migration29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Versions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Versions",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Date_Ini",
                table: "Versions",
                newName: "DateIni");

            migrationBuilder.RenameColumn(
                name: "Date_End",
                table: "Versions",
                newName: "DateEnd");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Versions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Users",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Tyres",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Texture_Id",
                table: "Tyres",
                newName: "TextureId");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Tyres",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Tyres",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Stretchs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Texture_Id",
                table: "Stretchs",
                newName: "TextureId");

            migrationBuilder.RenameColumn(
                name: "Position_Ini",
                table: "Stretchs",
                newName: "PositionIni");

            migrationBuilder.RenameColumn(
                name: "Position_End",
                table: "Stretchs",
                newName: "PositionEnd");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Stretchs",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Stretchs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Color_Id",
                table: "Stretchs",
                newName: "ColorId");

            migrationBuilder.RenameColumn(
                name: "Updated_By",
                table: "Providers",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Providers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_By",
                table: "Providers",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Providers",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_By",
                table: "Providers",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Providers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_By",
                table: "ProviderImportations",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "ProviderImportations",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_By",
                table: "ProviderImportations",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "ProviderImportations",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_By",
                table: "ProviderImportations",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "ProviderImportations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "ProviderBricks",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Thermal_Conductivity_700",
                table: "ProviderBricks",
                newName: "ThermalConductivity700");

            migrationBuilder.RenameColumn(
                name: "Thermal_Conductivity_300",
                table: "ProviderBricks",
                newName: "ThermalConductivity300");

            migrationBuilder.RenameColumn(
                name: "Thermal_Conductivity_100",
                table: "ProviderBricks",
                newName: "ThermalConductivity100");

            migrationBuilder.RenameColumn(
                name: "Recommended_Zone",
                table: "ProviderBricks",
                newName: "RecommendedZone");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "ProviderBricks",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "ProviderBricks",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Ovens",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Ovens",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Ovens",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Headquarters",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Headquarters",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Headquarters",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Gallery",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Gallery",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Gallery",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Wedge_b_Quantity",
                table: "BudgetStretch",
                newName: "WedgeBQuantity");

            migrationBuilder.RenameColumn(
                name: "Wedge_b_Cost",
                table: "BudgetStretch",
                newName: "WedgeBCost");

            migrationBuilder.RenameColumn(
                name: "Wedge_a_Quantity",
                table: "BudgetStretch",
                newName: "WedgeAQuantity");

            migrationBuilder.RenameColumn(
                name: "Wedge_a_Cost",
                table: "BudgetStretch",
                newName: "WedgeACost");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "BudgetStretch",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Total_Amount",
                table: "BudgetStretch",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "BudgetStretch",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "BudgetStretch",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Brick_b_Cost",
                table: "BudgetStretch",
                newName: "BrickBCost");

            migrationBuilder.RenameColumn(
                name: "Brick_a_Cost",
                table: "BudgetStretch",
                newName: "BrickACost");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Budgets",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Total_Amount",
                table: "Budgets",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "Budgets",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Budgets",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "BudgetCurrency",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "BudgetCurrency",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "BudgetCurrency",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "BrickFormats",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Quantity_b",
                table: "BrickFormats",
                newName: "QuantityB");

            migrationBuilder.RenameColumn(
                name: "Quantity_a",
                table: "BrickFormats",
                newName: "QuantityA");

            migrationBuilder.RenameColumn(
                name: "Deleted_At",
                table: "BrickFormats",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "BrickFormats",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Brick_b",
                table: "BrickFormats",
                newName: "BrickB");

            migrationBuilder.RenameColumn(
                name: "Brick_a",
                table: "BrickFormats",
                newName: "BrickA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Versions",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Versions",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "DateIni",
                table: "Versions",
                newName: "Date_Ini");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "Versions",
                newName: "Date_End");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Versions",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Users",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Tyres",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "TextureId",
                table: "Tyres",
                newName: "Texture_Id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Tyres",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Tyres",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Stretchs",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "TextureId",
                table: "Stretchs",
                newName: "Texture_Id");

            migrationBuilder.RenameColumn(
                name: "PositionIni",
                table: "Stretchs",
                newName: "Position_Ini");

            migrationBuilder.RenameColumn(
                name: "PositionEnd",
                table: "Stretchs",
                newName: "Position_End");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Stretchs",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Stretchs",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Stretchs",
                newName: "Color_Id");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Providers",
                newName: "Updated_By");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Providers",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Providers",
                newName: "Deleted_By");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Providers",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Providers",
                newName: "Created_By");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Providers",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ProviderImportations",
                newName: "Updated_By");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ProviderImportations",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProviderImportations",
                newName: "Deleted_By");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ProviderImportations",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ProviderImportations",
                newName: "Created_By");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ProviderImportations",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ProviderBricks",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "ThermalConductivity700",
                table: "ProviderBricks",
                newName: "Thermal_Conductivity_700");

            migrationBuilder.RenameColumn(
                name: "ThermalConductivity300",
                table: "ProviderBricks",
                newName: "Thermal_Conductivity_300");

            migrationBuilder.RenameColumn(
                name: "ThermalConductivity100",
                table: "ProviderBricks",
                newName: "Thermal_Conductivity_100");

            migrationBuilder.RenameColumn(
                name: "RecommendedZone",
                table: "ProviderBricks",
                newName: "Recommended_Zone");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ProviderBricks",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ProviderBricks",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Ovens",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Ovens",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Ovens",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Headquarters",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Headquarters",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Headquarters",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Gallery",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Gallery",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Gallery",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "WedgeBQuantity",
                table: "BudgetStretch",
                newName: "Wedge_b_Quantity");

            migrationBuilder.RenameColumn(
                name: "WedgeBCost",
                table: "BudgetStretch",
                newName: "Wedge_b_Cost");

            migrationBuilder.RenameColumn(
                name: "WedgeAQuantity",
                table: "BudgetStretch",
                newName: "Wedge_a_Quantity");

            migrationBuilder.RenameColumn(
                name: "WedgeACost",
                table: "BudgetStretch",
                newName: "Wedge_a_Cost");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BudgetStretch",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "BudgetStretch",
                newName: "Total_Amount");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "BudgetStretch",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BudgetStretch",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "BrickBCost",
                table: "BudgetStretch",
                newName: "Brick_b_Cost");

            migrationBuilder.RenameColumn(
                name: "BrickACost",
                table: "BudgetStretch",
                newName: "Brick_a_Cost");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Budgets",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Budgets",
                newName: "Total_Amount");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Budgets",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Budgets",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BudgetCurrency",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "BudgetCurrency",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BudgetCurrency",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BrickFormats",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "QuantityB",
                table: "BrickFormats",
                newName: "Quantity_b");

            migrationBuilder.RenameColumn(
                name: "QuantityA",
                table: "BrickFormats",
                newName: "Quantity_a");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "BrickFormats",
                newName: "Deleted_At");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BrickFormats",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "BrickB",
                table: "BrickFormats",
                newName: "Brick_b");

            migrationBuilder.RenameColumn(
                name: "BrickA",
                table: "BrickFormats",
                newName: "Brick_a");
        }
    }
}

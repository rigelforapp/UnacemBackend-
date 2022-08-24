using Microsoft.EntityFrameworkCore.Migrations;

namespace UNACEM.Persistence.Database.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrickFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Brick_a = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brick_b = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity_a = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity_b = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diameter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrickFormats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrickFormats");
        }
    }
}

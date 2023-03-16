using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcFoodRecipe.Migrations
{
    public partial class changeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Director",
                table: "FoodItem",
                newName: "FoodPhoto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodPhoto",
                table: "FoodItem",
                newName: "Director");
        }
    }
}

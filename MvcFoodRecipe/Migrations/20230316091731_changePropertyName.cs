using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcFoodRecipe.Migrations
{
    public partial class changePropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieImage",
                table: "FoodItem",
                newName: "RecipeImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeImage",
                table: "FoodItem",
                newName: "MovieImage");
        }
    }
}

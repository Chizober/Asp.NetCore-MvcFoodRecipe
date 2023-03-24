using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcFoodRecipe.Migrations
{
    public partial class addedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "FoodItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DietLabel",
                table: "FoodItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthLabel",
                table: "FoodItem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "FoodItem");

            migrationBuilder.DropColumn(
                name: "DietLabel",
                table: "FoodItem");

            migrationBuilder.DropColumn(
                name: "HealthLabel",
                table: "FoodItem");
        }
    }
}

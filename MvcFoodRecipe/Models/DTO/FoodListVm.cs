using MvcFoodRecipe.Models.Domain;

namespace MvcFoodRecipe.Models.DTO
{
    public class FoodListVm
    {
        public IQueryable<FoodItem> FoodList { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}

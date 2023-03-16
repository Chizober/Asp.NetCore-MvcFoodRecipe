using MvcFoodRecipe.Models.Domain;
using MvcFoodRecipe.Models.DTO;

namespace MvcFoodRecipe.Repositories.Abstract
{
    public interface IFoodService
    {
        bool Add(FoodItem model);
        bool Update(FoodItem model);
        
        FoodItem GetById(int id);
        bool Delete(int id);
       
        FoodListVm List(string term = "", bool paging = false, int currentPage = 0);
    
    }
}
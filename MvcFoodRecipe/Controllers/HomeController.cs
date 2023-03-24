using Microsoft.AspNetCore.Mvc;
using MvcFoodRecipe.Models;
using MvcFoodRecipe.Models.Domain;
using MvcFoodRecipe.Models.DTO;
using MvcFoodRecipe.Repositories.Interface;
using System.Diagnostics;

namespace MvcFoodRecipe.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IFoodService _foodService;
        public HomeController(ILogger<HomeController> logger, IFoodService FoodService)
        {
            _foodService = FoodService;
            
        }

        public IActionResult Index()
        {
            FoodListVm fmmodel = new FoodListVm();
            fmmodel.FoodList = _foodService.List();
            return View(fmmodel);
        }

        public IActionResult FoodDetail(int foodId)
        {
            var food = _foodService.GetById(foodId);
            return View(food);
        }
    }
}
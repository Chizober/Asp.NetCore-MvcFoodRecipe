using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcFoodRecipe.Models.Domain;
using MvcFoodRecipe.Repositories.Abstract;

namespace MvcFoodRecipe.Controllers
{
    /*[Authorize]*/
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly IFileService _fileService;
        public FoodController(IFoodService FoodService, IFileService fileService)
        {
            _foodService = FoodService;
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new FoodItem();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(FoodItem model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.RecipeImage = imageName;
            }
            var result = _foodService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            var model = _foodService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(FoodItem model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.RecipeImage = imageName;
            }
            var result = _foodService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(FoodList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult FoodList()
        {
            var data = this._foodService.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _foodService.Delete(id);
            return RedirectToAction(nameof(FoodList));
        }



    }
}

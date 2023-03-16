using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcFoodRecipe.Models.Domain
{


    public class FoodItem
    {

        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? FoodPhoto { get; set; }

        public string? RecipeImage { get; set; }  // stores movie image name with extension (eg, image0001.jpg)
        
        [Required]
        public string? Ingredients { get; set; }
        public string? Steps { get; set; }
        [Required]

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        



    }
}

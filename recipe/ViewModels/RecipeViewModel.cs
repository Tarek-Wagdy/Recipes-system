using recipe.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace recipe.ViewModels
{
    public class RecipeViewModel
    {
        [Required]
        public string Name { get; set; }
        public int RecipeId { get; set; }
        [Required]
        public List<string> Ingredients { get; set; }
        [DisplayName("Steps")]
        [Required]
        public List<string> Methods { get; set; }
        [Required]
        public IFormFile? File { get; set; }
        public RecipeViewModel()
        {

        }
        public RecipeViewModel(Recipe recipe)
        {
            Ingredients = new List<string>();
            Methods = new List<string>();
            this.Name=recipe.Name;
            this.RecipeId = recipe.Id;
            foreach(Ingredient item in recipe.ingredients)
            {
                Ingredients.Add(item.FoodIngredient);
            }
            foreach (Method item in recipe.Methods)
            {
                Methods.Add(item.Step);
            }
        }
    }
}

using recipe.Models;

namespace recipe.ViewModels
{
    public class AllDataForRecipeViewModel
    {
        public List<Ingredient> ingredients { get; set; }
        public List<Method> methods { get; set; }
        public string Name { get; set; }
        public string Image { get; set; } 
  
    }
}

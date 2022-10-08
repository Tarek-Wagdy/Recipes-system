using recipe.Models;

namespace recipe.ViewModels
{
    public class IndexViewModel
    {
        public string Filter { get; set; }
        public List<Recipe> Recipes { get; set; }

    }
}

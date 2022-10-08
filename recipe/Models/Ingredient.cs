using System.ComponentModel.DataAnnotations.Schema;

namespace recipe.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string FoodIngredient { get; set; }
        [ForeignKey("recipe")]
        public int RecipeId { get; set; }
        public virtual Recipe? recipe { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace recipe.Models
{
    public class Method
    {
        public int Id { get; set; }
        public string Step { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }
    }
}

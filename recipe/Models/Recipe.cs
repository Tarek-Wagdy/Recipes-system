using System.ComponentModel.DataAnnotations.Schema;

namespace recipe.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string image { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual List<Ingredient>? ingredients { get; set; }
        public virtual List<Method>? Methods { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public Recipe()
        {
            CreatedDate= DateTime.Now;
        }

    }
}

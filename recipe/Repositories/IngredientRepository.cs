using Microsoft.EntityFrameworkCore;
using recipe.Models;

namespace recipe.Repositories
{
    public class IngredientRepository : IingredientRepository
    {

        Entity context;
        public IngredientRepository(Entity context)
        {
            this.context = context;
        }

        public List<Ingredient> GetAll(int id)
        {
            List<Ingredient> ingredients = context.ingredients.
                Where(e=>e.RecipeId==id).Include(e =>e.recipe).ToList();
            return ingredients;
        }
        public Ingredient GetById(int id)
        {
            Ingredient ingredient = context.ingredients.Where(e => e.Id == id).Include(e => e.recipe).FirstOrDefault();
            return ingredient;
        }

        public void Insert(Ingredient ingredient)
        {

            context.ingredients.Add(ingredient);
            context.SaveChanges();
        }

        public void Update(int id, Ingredient ingredient)
        {
            
        }
        public void Delete(int id)
        {
            Ingredient ingredient = GetById(id);
            context.ingredients.Remove(ingredient);
            context.SaveChanges();
        }
    }
}

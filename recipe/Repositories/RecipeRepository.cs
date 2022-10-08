using Microsoft.EntityFrameworkCore;
using recipe.Models;
using recipe.ViewModels;

namespace recipe.Repositories
{
    public class RecipeRepository :IrecipeRepository
    {
        Entity context;
        public RecipeRepository(Entity context)
        {
            this.context = context;
        }

        public List<Recipe> GetAll()
        {
            List<Recipe> recipes =context.recipes.Include(e => e.ingredients)
                .Include(e => e.Methods).Include(e => e.User).ToList();
            return recipes;
        }
        public IndexViewModel GetAllSorted(IndexViewModel indexViewModel)
        {
            List<Recipe> recipes =GetAll();
            IndexViewModel indexViewModel1 = new IndexViewModel();
            indexViewModel1.Recipes = recipes;
            indexViewModel1.Filter = indexViewModel.Filter;
            if (indexViewModel.Filter == "newest")
            {
                indexViewModel1.Recipes = recipes.OrderByDescending(e => e.CreatedDate).ToList();
            }
            return indexViewModel1;

        }
        public List<Recipe> GetAllForUser(int id)
        {
            List<Recipe> recipes = context.recipes.Where(e => e.UserId == id).Include(e => e.ingredients)
                .Include(e => e.Methods).Include(e => e.User).ToList();
            return recipes;
        }
        public Recipe GetById(int id)
        {
            Recipe recipe=context.recipes.Include(e=>e.ingredients).Include(e=>e.Methods).FirstOrDefault(x =>x.Id == id);
            return recipe;
        }

        public void Insert(Recipe recipe)
        {

            context.recipes.Add(recipe);
            context.SaveChanges();
        }

        public void Update(RecipeViewModel recipe)
        {
            Recipe OldRecipe = GetById(recipe.RecipeId);
            OldRecipe.Name = recipe.Name;
            
            List<Ingredient> ingredients = context.ingredients.Where(e => e.RecipeId == recipe.RecipeId).ToList();
            List<Method> methods = context.methods.Where(e => e.RecipeId == recipe.RecipeId).ToList();
            foreach(Ingredient item in ingredients)
            {
                context.ingredients.Remove(item);
            }
            foreach (Method item in methods)
            {
                context.methods.Remove(item);
            }
            foreach(string item in recipe.Ingredients)
            {
                Ingredient newingredient = new Ingredient();
                newingredient.FoodIngredient = item;
                newingredient.RecipeId=recipe.RecipeId;
                context.ingredients.Add(newingredient);
            }
            foreach (string item in recipe.Methods)
            {
                Method newMethod = new Method();
                newMethod.Step = item;
                newMethod.RecipeId = recipe.RecipeId;
                context.methods.Add(newMethod);
            }
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Recipe recipe = GetById(id);
           context.recipes.Remove(recipe);
            context.SaveChanges();
        }

        
    }
}

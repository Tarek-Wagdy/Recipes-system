using recipe.Models;
using recipe.ViewModels;

namespace recipe.Repositories
{
    public interface IrecipeRepository
    {
        List<Recipe> GetAll();
        IndexViewModel GetAllSorted(IndexViewModel sort);
        List<Recipe> GetAllForUser(int id);
        Recipe GetById(int id);
        void Insert(Recipe recipe);
        void Update(RecipeViewModel recipe);
        void Delete(int id);
    }
}

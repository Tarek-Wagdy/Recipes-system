using recipe.Models;

namespace recipe.Repositories
{
    public interface IingredientRepository
    {
        List<Ingredient> GetAll(int id);
        Ingredient GetById(int id);
        void Insert(Ingredient recipe);
        void Update(int id, Ingredient recipe);
        void Delete(int id);
    }
}

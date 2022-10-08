using recipe.Models;
namespace recipe.Repositories
{
    public interface ImethodRepository
    {
        List<Method> GetAll(int id);
        Method GetById(int id);
        void Insert(Method method);
        void Update(int id, Method method);
        void Delete(int id);
    }
}

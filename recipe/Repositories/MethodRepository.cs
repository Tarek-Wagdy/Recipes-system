using Microsoft.EntityFrameworkCore;
using recipe.Models;

namespace recipe.Repositories
{
    public class MethodRepository : ImethodRepository
    {
        Entity context;
        public MethodRepository(Entity context)
        {
            this.context = context;
        }

        public List<Method> GetAll(int id)
        {
            List<Method> ingredients = context.methods.Where(e=>e.RecipeId==id).
                Include(e => e.Recipe).ToList();
            return ingredients;
        }
        public Method GetById(int id)
        {
            Method method = context.methods.FirstOrDefault(x => x.Id == id);
            return method;
        }

        public void Insert(Method method)
        {

            context.methods.Add(method);
            context.SaveChanges();
        }

        public void Update(int id, Method method)
        {
            
        }
        public void Delete(int id)
        {
            Method method = GetById(id);
            context.methods.Remove(method);
            context.SaveChanges();
        }
    }
}

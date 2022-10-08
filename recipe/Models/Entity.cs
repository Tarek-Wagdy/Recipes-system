
using recipe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace recipe.Models
{
    public class Entity : IdentityDbContext<ApplicationUser,Role,int>
    {
        public Entity() { }
        public Entity(DbContextOptions<Entity> options) : base(options) { }

        public DbSet<Recipe> recipes { get; set; }
        public DbSet<Method> methods { get; set; }
        public DbSet<Ingredient> ingredients { get; set; }
    }
}

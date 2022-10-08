using recipe.Models;
using Microsoft.EntityFrameworkCore;
using recipe.Repositories;

namespace recipe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connetionString = builder.Configuration.GetConnectionString("Cs");
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IrecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<ImethodRepository, MethodRepository>();
            builder.Services.AddScoped<IingredientRepository, IngredientRepository>();
            builder.Services.AddDbContext<Entity>(optionsbuilder =>
            {
                optionsbuilder.UseSqlServer(connetionString);
            });
            builder.Services.AddIdentity<ApplicationUser, Role>(options =>
            {
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<Entity>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=recipe}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
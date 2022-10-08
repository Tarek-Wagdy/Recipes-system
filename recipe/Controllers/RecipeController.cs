using Microsoft.AspNetCore.Mvc;
using recipe.Models;
using recipe.Repositories;
using recipe.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace recipe.Controllers
{

    public class RecipeController : Controller
    {
      
        private readonly IHostingEnvironment hosting;
        private readonly ImethodRepository methodRepository;
        private readonly IingredientRepository ingredientRepository;
        private readonly IrecipeRepository recipeRepository;
        private readonly Entity context;

        public RecipeController(IHostingEnvironment Hosting,
            ImethodRepository methodRepository,IingredientRepository ingredientRepository,
            IrecipeRepository recipeRepository,Entity context)
        {
            hosting = Hosting;
            this.methodRepository = methodRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeRepository = recipeRepository;
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index(IndexViewModel indexViewModel)
        {
           IndexViewModel NewIndexViewModel= recipeRepository.GetAllSorted(indexViewModel);
            return View(NewIndexViewModel) ;
        }
        
        public IActionResult GetAllForUser()
        {
            var userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<Recipe> recipes = recipeRepository.GetAllForUser(userid);
            return View(recipes);
        }
        public IActionResult GetById(int id)
        {
            Recipe recipe = recipeRepository.GetById(id);
            AllDataForRecipeViewModel data = new AllDataForRecipeViewModel();
            List<Method> methods=methodRepository.GetAll(id);
            List<Ingredient> ingredients = ingredientRepository.GetAll(id);
            data.methods = methods;
            data.Name = recipe.Name;
            data.Image = recipe.image;
            data.ingredients = ingredients;
            return View("RecipeDetails",data);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(RecipeViewModel recipe)
        {
            if(ModelState.IsValid)
            {
                Recipe recipe1 = new Recipe();

                var userid =Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                recipe1.UserId=userid;
                recipe1.Name=recipe.Name;
                string fileName = string.Empty;
                if (recipe.File != null)
                {
                    string images = Path.Combine(hosting.WebRootPath, "images");
                    fileName = recipe.File.FileName;
                    string fullPath = Path.Combine(images, fileName);
                    recipe.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                recipe1.image = fileName;



                recipeRepository.Insert(recipe1);

                foreach (string foodIngredient in recipe.Ingredients)
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.FoodIngredient=foodIngredient;
                    ingredient.RecipeId = recipe1.Id;
                    context.ingredients.Add(ingredient);
                    context.SaveChanges();
                }
                foreach (string cookingStep in recipe.Methods)
                {
                    Method method = new Method();
                    method.Step = cookingStep;
                    method.RecipeId = recipe1.Id;
                    context.methods.Add(method);
                    context.SaveChanges();
                }

                
            }
            return RedirectToAction("Index","recipe");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Recipe recipe = recipeRepository.GetById(id);
            RecipeViewModel recipeViewModel = new RecipeViewModel(recipe);
           
            return View(recipeViewModel);

        }
        [HttpPost]
        public IActionResult Update(RecipeViewModel recipe)
        {
            recipeRepository.Update(recipe);
            return RedirectToAction("GetAllForUser", "Recipe");
        }

        public IActionResult Delete(int id)
        {
            recipeRepository.Delete(id);
            return RedirectToAction("GetAllForUser", "Recipe");
        }
    }
}

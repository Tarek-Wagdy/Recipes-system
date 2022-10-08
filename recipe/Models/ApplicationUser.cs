using Microsoft.AspNetCore.Identity;
using recipe.Models;
using System.ComponentModel.DataAnnotations;

namespace recipe.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        [Required]
        public virtual List<Recipe>? recipes { get; set; }
    }
}

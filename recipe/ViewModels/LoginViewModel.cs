using System.ComponentModel.DataAnnotations;

namespace recipe.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

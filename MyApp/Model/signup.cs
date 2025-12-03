using System.ComponentModel.DataAnnotations;

namespace MyApp.Model
{
    public class signup
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }

    }
}

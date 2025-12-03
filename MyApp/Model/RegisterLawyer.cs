using System.ComponentModel.DataAnnotations;

namespace MyApp.Model
{
    public class LawyerRegistration
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a Specialist")]
        public string Specialist { get; set; }

        [Required(ErrorMessage = "Experiance is required")]
        public int Experiance { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
    }
}

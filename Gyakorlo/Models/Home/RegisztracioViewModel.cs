using System.ComponentModel.DataAnnotations;

namespace Gyakorlo.Models.Home
{
    public class RegisztracioViewModel
    {
        [Required(ErrorMessage = "A név megadása kötelező")]
        public string Nev { get; set; }

        [Required(ErrorMessage = "Email megadása kötelező")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Jelszó megadása kötelező")]
        [DataType(DataType.Password)]
        public string Jelszo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Jelszo", ErrorMessage = "A jelszavak nem egyeznek")]
        public string JelszoUjra { get; set; }



        [Required(ErrorMessage = "Választása kötelező")]
        public string Tipus { get; set; }
    }
}

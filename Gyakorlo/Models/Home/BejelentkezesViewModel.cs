using System.ComponentModel.DataAnnotations;

namespace Gyakorlo.Models.Home
{
    public class BejelentkezesViewModel
    {
        [Required(ErrorMessage = "Email megadása kötelező")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Jelszó megadása kötelező")]
        [DataType(DataType.Password)]
        public string Jelszo { get; set; }
    }
}

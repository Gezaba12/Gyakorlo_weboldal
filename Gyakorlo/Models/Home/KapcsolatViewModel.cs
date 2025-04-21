using System.ComponentModel.DataAnnotations;

namespace Gyakorlo.Models.Home
{
    public class KapcsolatViewModel
    {
        [Required(ErrorMessage = "Email megadása kötelező")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Név megadása kötelező")]
        public string Nev { get; set; }

        [Required(ErrorMessage = "Üzenet megadása kötelező")]
        public string Uzenet { get; set; }

        public string Visszajelzes { get; set; } = "";
    }
}

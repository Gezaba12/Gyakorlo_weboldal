using Gyakorlo.Data;
using Microsoft.AspNetCore.Identity;

namespace Gyakorlo.Models.Home
{
    public class HomeModel : IHomeModel
    {
        public HomeModel(UserManager<Felhasznalo> userManager, SignInManager<Felhasznalo> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<Felhasznalo> UserManager { get; set; }

        public SignInManager<Felhasznalo> SignInManager { get; set; }

        public Task<IEnumerable<Csoport>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}

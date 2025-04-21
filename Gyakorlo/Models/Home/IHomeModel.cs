using Gyakorlo.Data;
using Microsoft.AspNetCore.Identity;

namespace Gyakorlo.Models.Home
{
    public interface IHomeModel
    {
        Task<IEnumerable<Csoport>> GetAllProducts();

        UserManager<Felhasznalo> UserManager { get; }
        SignInManager<Felhasznalo> SignInManager { get; }
        IAppRepo Repo { get; set; }

    }
}

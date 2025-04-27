using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gyakorlo.Models;
using Gyakorlo.Data;
using Gyakorlo.Models.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Gyakorlo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    IHomeModel _homeModel;

    public HomeController(IHomeModel homeModel, ILogger<HomeController> logger)
    {
        _homeModel = homeModel;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Rolunk()
    { 
        return View();
    }

    [Route("Hasznalati-Utmutato")]
    public IActionResult HasznalatiUtmutato()
    {
        return View();
    }

    public IActionResult Kapcsolat()
    {
        return View(new KapcsolatViewModel());
    }

    [HttpPost]
    public IActionResult Kapcsolat(KapcsolatViewModel model)
    {
        if (ModelState.IsValid)
        {
            _homeModel.Repo.UzenetFelvesz(new Uzenetek { Email= model.Email, Nev= model.Nev, Uzenet= model.Uzenet});
            model.Visszajelzes = "Üzenetet Fogadtuk, Köszönjük a megkeresést!";
        }
        return View(model);
    }

    public IActionResult Bejelentkezes()
    {
        //await _homeModel.SignInManager.SignOutAsync();
        BejelentkezesViewModel felhasznalo = new BejelentkezesViewModel();
        return View(felhasznalo);
    }

    [HttpPost]
    public async Task<IActionResult> Bejelentkezes(BejelentkezesViewModel felhasznalo)
    {
        if (ModelState.IsValid)
        {
            var result = await _homeModel.SignInManager.PasswordSignInAsync(
                felhasznalo.Email,
                felhasznalo.Jelszo,
                false,
                false
            );

            if (result.Succeeded)
            {
                return Redirect("/");
            }
        }
        ModelState.AddModelError("", "Hibás felhasználónév vagy jelszó.");
        return View(felhasznalo);
    }

    public async Task<IActionResult> Kijelentkezes()
    {
        await _homeModel.SignInManager.SignOutAsync();
        return RedirectToAction("/");
    }
    public IActionResult Regisztracio()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisztracioAsync(RegisztracioViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new Felhasznalo
            {
                UserName = model.Email,
                Email = model.Email,
                Nev = model.Nev
            };

            var result = await _homeModel.UserManager.CreateAsync(user, model.Jelszo);

            if (result.Succeeded)
            {
                await _homeModel.UserManager.AddToRoleAsync(user, model.Tipus);
                
                await _homeModel.SignInManager.PasswordSignInAsync(
                model.Email,
                model.Jelszo,
                false,
                false
            );
                return RedirectToAction("/");
            }
        }
        return View(model);
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        //teszt viktor
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

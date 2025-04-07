using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gyakorlo.Models;
using Gyakorlo.Data;
using Gyakorlo.Models.Home;
using Microsoft.AspNetCore.Identity;

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
        return View();
    }

    public IActionResult Bejelentkezes(bool? sikeres)
    {
        return View(sikeres);
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
                return RedirectToAction("Bejelentkezes", new {sikeres = true});
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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gyakorlo.Models;

namespace Gyakorlo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
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

    public IActionResult Utmutato()
    {
        return View();
    }

    public IActionResult Kapcsolat()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        //teszt viktor
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

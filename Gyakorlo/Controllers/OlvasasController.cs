using Gyakorlo.Data;
using Gyakorlo.Models.Home;
using Gyakorlo.Models.Matematika;
using Gyakorlo.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;

namespace Gyakorlo.Controllers
{
    [Authorize(Roles = "diak,tanar")]
    public class OlvasasController : Controller
    {
        IHomeModel _homeModel;
        public OlvasasController()
        {
        }
        public IActionResult Gyakorlas(int osztaly)
        {
            return View();
        }

        public IActionResult FeladatKeszites(int osztaly)
        {
            return View();
        }

    }
}

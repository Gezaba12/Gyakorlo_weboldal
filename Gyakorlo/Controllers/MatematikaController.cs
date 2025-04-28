using Gyakorlo.Data;
using Gyakorlo.Models;
using Gyakorlo.Models.Home;
using Gyakorlo.Models.Matematika;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System.Reflection;

namespace Gyakorlo.Controllers
{
    [Authorize(Roles = "diak,tanar")]
    public class MatematikaController : Controller
    {
        IHomeModel _homeModel;
        public MatematikaController(IHomeModel homeModel)
        {
            _homeModel = homeModel;
        }
        public IActionResult Gyakorlas(int osztaly)
        {
            IMatematika generator;
            Feladatlap model;
            switch (osztaly)
            {
                case 1:
                    generator = new MatematikaElso(10);
                    model = new Feladatlap() { Feladatok=generator.Feladatok, Evfolyam=osztaly, Tipus="Gyakorlas"};
                    break;
                case 2:
                    generator = new MatematikaMasodik(10);
                    model = new Feladatlap() { Feladatok = generator.Feladatok, Evfolyam = osztaly, Tipus = "Gyakorlas" };
                    break;
                case 3:
                    generator = new MatematikaHarmadik(10);
                    model = new Feladatlap() { Feladatok = generator.Feladatok, Evfolyam = osztaly, Tipus = "Gyakorlas" };
                    break;
                case 4:
                    generator = new MatematikaNegyedik(10);
                    model = new Feladatlap() { Feladatok = generator.Feladatok, Evfolyam = osztaly, Tipus = "Gyakorlas" };
                    break;
                default:
                    model = null;
                    break;
            }
            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GyakorlasAsync(Feladatlap model)
        {
            int helyes = 0;

            foreach (var feladat in model.Feladatok)
            {
                if (int.TryParse(feladat.Valasz, out int valasz))
                {
                    if (valasz == feladat.Eredmeny)
                        helyes++;
                }
            }

            ViewBag.HelyesDb = helyes;
            ViewBag.Osszes = model.Feladatok.Count;

            int szazalek = (int)((double)helyes / model.Feladatok.Count * 100);

            string uzenet = "";
            switch (szazalek)
            {
                case <20:
                    uzenet = "Ne csüggedj, gyakorlással egyre jobb leszel!";
                    break;
                case < 40:
                    uzenet = "Alakul, de érdemes lenne még néhány feladatsort megcsinálni!";
                    break;
                case < 60:
                    uzenet = "Egész jó, még egy kis gyakorlás és a legjobbak között lehetsz.";
                    break;
                case < 80:
                    uzenet = "Nagyszerű eredmény!";
                    break;
                default:
                    uzenet = "Nem semmi, de ne feledd, a szinten tartáshoz sem árt a gyakorlás!";
                    break;
            }

            var felhasznalo = await _homeModel.UserManager.GetUserAsync(User);

            if (felhasznalo != null)
            {
                felhasznalo.Pontok += helyes;

                var result = await _homeModel.UserManager.UpdateAsync(felhasznalo);

                if (result.Succeeded)
                {
                    // Ha a claim is tartalmazza a Pontokat, frissíteni kell:
                    await _homeModel.SignInManager.RefreshSignInAsync(felhasznalo);
                }
            }

            ViewBag.Uzenet = uzenet;
            ViewBag.Szazalek = szazalek;

            return View("~/Views/Eredmeny.cshtml", model);
        }

        public IActionResult FeladatKeszites(int osztaly)
        {
            var model = new FeladatlapGeneralasViewModel();
            var tipus = typeof(MatematikaElso);
            switch (osztaly)
            {
                case 1:
                    tipus = typeof(MatematikaElso);
                    break;
                case 2:
                    tipus = typeof(MatematikaMasodik);
                    break;
                case 3:
                    tipus = typeof(MatematikaHarmadik);
                    break;
                case 4:
                    tipus = typeof(MatematikaNegyedik);
                    break;
                default:
                    return NotFound();
            }
            var tipusok = tipus
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(m => m.GetCustomAttribute<FeladatTipusAttribute>())
                .Where(attr => attr != null)
                .Select(attr => new Tipus() { TipusNev = attr.Tipus, TipusLeiras = attr.FeladatLeiras })
                .Distinct()
                .ToList();

            model.Tipusok = tipusok;
            model.Osztaly = osztaly;
            ViewBag.Osztaly = osztaly;
            return View(model);
        }

        [HttpPost]
        public IActionResult FeladatlapGeneralas(FeladatlapGeneralasViewModel model)
        {

            List<Dictionary<string, List<Feladat>>> feladatModel;
            IMatematika generator;
            switch (model.Osztaly)
            {
                case 1:
                    generator = new MatematikaElso(model);
                    feladatModel = generator.Temazarok;
                    break;
                case 2:
                    generator = new MatematikaMasodik(model);
                    feladatModel = generator.Temazarok; 
                    break;
                case 3:
                    generator = new MatematikaHarmadik(model);
                    feladatModel = generator.Temazarok;
                    break;
                case 4:
                    generator = new MatematikaNegyedik(model);
                    feladatModel = generator.Temazarok;
                    break;
                default:
                    feladatModel = null;
                    break;
            }
            

            return new ViewAsPdf("TemazaroPdf", feladatModel)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }
    }
}

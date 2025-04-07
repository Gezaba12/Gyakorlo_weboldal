using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gyakorlo.Data
{
    public class Felhasznalo : IdentityUser
    {
        public string Nev { get; set; }
        public int CsoportId { get; set; }
        public int Pontok { get; set; }
    }
}

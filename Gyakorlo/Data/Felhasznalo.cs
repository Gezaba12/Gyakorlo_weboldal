using Microsoft.AspNetCore.Identity;

namespace Gyakorlo.Data
{
    public class Felhasznalo : IdentityUser
    {
        public int CsoportId { get; set; }
    }

    public class Diak : Felhasznalo
    {
        public int Pontok { get; set; } 
    }
}

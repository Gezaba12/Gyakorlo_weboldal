namespace Gyakorlo.Models
{
    public class LayoutModel
    {
        public class Menupont
        {
            public string Nev { get; set; }
            public string Url { get; set; }
            public string Action { get; set; }
            public string Title { get; set; }
            public bool Bejelentkezve { get; set; }
        }
        public List<Menupont> Menupontok { get; set; }
        public List<Menupont> OktatasiAnyagok { get; set; }

        public LayoutModel()
        {
            Menupontok = new List<Menupont>();
            Menupontok.Add(new Menupont() { Nev = "Főoldal", Url = "", Action = "Index", Title = "Kezdőlap", Bejelentkezve = false });
            Menupontok.Add(new Menupont() { Nev = "Rólunk", Url = "Rolunk", Action = "Rolunk", Title = "Rólunk", Bejelentkezve = false });
            Menupontok.Add(new Menupont() { Nev = "Használati útmutató", Url = "Hasznalati-Utmutato", Action = "HasznalatiUtmutato", Title = "Segítség", Bejelentkezve = false });
            Menupontok.Add(new Menupont() { Nev = "Kapcsolat", Url = "Kapcsolat", Action = "Kapcsolat", Title = "Elérhetőségek", Bejelentkezve = false });
            Menupontok.Add(new Menupont() { Nev = "Bejelentkezés", Url = "Bejelentkezes", Action = "Bejelentkezes", Title = "Bejelentkezés", Bejelentkezve = true });
            Menupontok.Add(new Menupont() { Nev = "Regisztráció", Url = "Regisztracio", Action = "Regisztracio", Title = "Regisztráció", Bejelentkezve = true });

            OktatasiAnyagok = new List<Menupont>();
            OktatasiAnyagok.Add(new Menupont() { Nev = "Matematika", Url = "Matematika", Action = "Index", Title = "Matematika Feladatok" });
            OktatasiAnyagok.Add(new Menupont() { Nev = "Olvasás", Url = "Olvasas", Action = "Index", Title = "Olvasás Feladatok" });
        }
    }
}

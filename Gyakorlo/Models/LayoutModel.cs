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
        }
        public List<Menupont> Menupontok { get; set; }
        public List<Menupont> OktatasiAnyagok { get; set; }

        public LayoutModel()
        {
            Menupontok = new List<Menupont>();
            Menupontok.Add(new Menupont() { Nev = "Főoldal", Url = "", Action = "Index", Title = "Kezdőlap" });
            Menupontok.Add(new Menupont() { Nev = "Rólunk", Url = "Rolunk", Action = "Rolunk", Title = "Rólunk" });
            Menupontok.Add(new Menupont() { Nev = "Használati útmutató", Url = "Hasznalati-Utmutato", Action = "Hasznalati-Utmutato", Title = "Segítség" });
            Menupontok.Add(new Menupont() { Nev = "Kapcsolat", Url = "Kapcsolat", Action = "Kapcsolat", Title = "Elérhetőségek" });
            Menupontok.Add(new Menupont() { Nev = "Bejelentkezés", Url = "Bejelentkezes", Action = "Bejelentkezes", Title = "Bejelentkezés" });

            OktatasiAnyagok = new List<Menupont>();
            OktatasiAnyagok.Add(new Menupont() { Nev = "Matematika", Url = "/MatematikaFeladatok", Action = "Index", Title = "Matematika Feladatok" });
            OktatasiAnyagok.Add(new Menupont() { Nev = "Olvasás", Url = "/OlvasasFeladatok", Action = "Index", Title = "Olvasás Feladatok" });
        }
    }
}

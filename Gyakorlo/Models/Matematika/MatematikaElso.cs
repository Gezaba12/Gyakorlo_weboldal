using Gyakorlo.Data;
using System.Reflection;

namespace Gyakorlo.Models.Matematika
{
    public class MatematikaElso
    {
        Random rnd = new Random();
        public List<Feladat> Feladatok { get; set; } = new();
        public List<Dictionary<string, List<Feladat>>> Temazarok { get; set; } = new();

        private readonly List<MethodInfo> _aktivTipusok;
        public MatematikaElso(FeladatlapGeneralasViewModel feladatlap)
        {
            List<string> engedelyezettTipusok = new List<string>();
            feladatlap.Tipusok = feladatlap.Tipusok.Where(x => x.TipusNev != null).Select(x => x).ToList();
            for (int i = 0; i < feladatlap.Tipusok.Count; i++)
            {
                MethodInfo methode = GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                                    .FirstOrDefault(m =>m.GetCustomAttribute<FeladatTipusAttribute>()?
                                    .Tipus == feladatlap.Tipusok[i].TipusNev);

                Temazarok.Add(new Dictionary<string, List<Feladat>>());
                for (int j = 0; j <= feladatlap.Tipusok[i].TipusDB; j++)
                {
                    Feladat feladat = (Feladat)methode.Invoke(this, null);
                    if (!Temazarok[i].ContainsKey(feladatlap.Tipusok[i].TipusLeiras))
                    {
                        Temazarok[i].Add(feladatlap.Tipusok[i].TipusLeiras,new List<Feladat>());
                    }
                    else
                    {
                        Temazarok[i][feladatlap.Tipusok[i].TipusLeiras].Add(feladat);
                    }   
                }
            }            
        }
        public MatematikaElso(int db)
        { 
            for (int i = 0; i < db; i++)
            {

                Feladat feladat;
                if (rnd.Next(0,5) <= 2)
                {
                    feladat = Osszeadas();
                }
                else
                {
                    feladat = Kivonas();
                }
                Feladatok.Add(feladat);
            }
        }

        [FeladatTipus("Összeadás", "Írd be a hiányzó számokat.", "Osszeadas")]
        Feladat Osszeadas()
        {
            int szam1 = rnd.Next(0, 6);
            int szam2 = rnd.Next(0, 6 - szam1);
            int helyesValasz;
            string keplet = "";
            int valasztas = rnd.Next(0, 10);
            if (valasztas <= 2)
            {
                keplet = szam1 + "+%%=" + (szam1 + szam2);
                helyesValasz = szam2;
            }
            else if(valasztas <= 6)
            {
                keplet = "%%+" + szam2 + "=" + (szam1 + szam2);
                helyesValasz = szam1;
            }
            else
            {
                keplet = szam1 + "+" + szam2 + "=%%";
                helyesValasz = (szam1 + szam2);
            }

            Feladat feladat = new Feladat() { Keplet= keplet, Eredmeny= helyesValasz  };

            return feladat;
        }

        [FeladatTipus("Kivonás", "Írd be a hiányzó számokat.", "Kivonas")]
        Feladat Kivonas()
        {
            int szam1 = rnd.Next(0, 6);
            int szam2 = rnd.Next(0, 6 - szam1);
            int helyesValasz;
            string keplet = "";

            if (szam1 < szam2)
                (szam1, szam2) = (szam2, szam1);

            int valasztas = rnd.Next(0, 10);

            if (valasztas <= 2)
            {
                keplet = szam1 + "-%%=" + (szam1 - szam2);
                helyesValasz = szam2;
            }
            else if (valasztas <= 6)
            {
                keplet = "%%-" + szam2 + "=" + (szam1 - szam2);
                helyesValasz = szam1;
            }
            else
            {
                keplet = szam1 + "-" + szam2 + "=%%";
                helyesValasz = (szam1 - szam2);
            }

            Feladat feladat = new Feladat() { Keplet = keplet, Eredmeny = helyesValasz };

            return feladat;
        }
    }
}

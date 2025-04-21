namespace Gyakorlo.Data
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FeladatTipusAttribute : Attribute
    {
        public string Tipus { get; }
        public string Nev { get; }
        public string FeladatLeiras { get; }


        public FeladatTipusAttribute(string tipus, string feladatLeiras, string nev)
        {
            Tipus = tipus;
            FeladatLeiras = feladatLeiras;
            Nev = nev;
        }
    }
}

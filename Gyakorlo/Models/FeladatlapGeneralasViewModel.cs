namespace Gyakorlo.Models
{
    public class Tipus
    {
        public string TipusNev { get; set; }
        public string TipusLeiras { get; set; }
        public int TipusDB { get; set; }
    }
    public class FeladatlapGeneralasViewModel
    {
        public List<Tipus> Tipusok { get; set; }
        public List<int> Db { get; set; }
        public int Osztaly { get; set; }
    }
}

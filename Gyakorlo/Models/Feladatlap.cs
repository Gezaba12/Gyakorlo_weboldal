namespace Gyakorlo.Models
{
    public class Feladatlap
    {
        public List<Feladat> Feladatok { get; set; } = new();

        public int Evfolyam { get; set; }

        public string Tipus { get; set; }
    }
}

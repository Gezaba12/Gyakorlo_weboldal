namespace Gyakorlo.Models.Matematika
{
    public interface IMatematika
    {
        List<Feladat> Feladatok { get; set; }
        List<Dictionary<string, List<Feladat>>> Temazarok { get; set; }
    }
}

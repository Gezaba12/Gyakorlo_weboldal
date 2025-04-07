namespace Gyakorlo.Data
{
    public interface IAppRepo
    {
        Task<IEnumerable<Csoport>> GetAllProductsAsync();
        void Add(string s);
        string Get();
    }
}

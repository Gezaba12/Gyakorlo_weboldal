namespace Gyakorlo.Data
{
    public interface IAppRepo
    {
        Task<IEnumerable<Csoport>> GetAllProductsAsync();
        void UzenetFelvesz(Uzenetek uzenet);
    }
}

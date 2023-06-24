namespace webapi.Models.Repository.Interface
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetBrands();
    }
}

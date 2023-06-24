namespace webapi.Models.Repository.Interface
{
    public interface IBikeTypeRepository
    {
        Task<List<BikeType>> GetBikeTypes();
    }
}

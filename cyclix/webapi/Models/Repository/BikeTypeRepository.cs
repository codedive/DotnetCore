using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using webapi.Models.Repository.Interface;

namespace webapi.Models.Repository
{
    public class BikeTypeRepository: IBikeTypeRepository
    {
        CyclixContext db;
        public BikeTypeRepository(CyclixContext _db)
        {
            db = _db;
        }

        public async Task<List<BikeType>> GetBikeTypes()
        {
            List<BikeType> bikeTypes = new List<BikeType>();
            if (db != null)
            {
                bikeTypes = await db.BikeTypes.ToListAsync();
            }
            return bikeTypes;
        }
    }
}

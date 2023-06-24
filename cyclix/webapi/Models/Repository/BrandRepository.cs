using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using webapi.Models.Repository.Interface;

namespace webapi.Models.Repository
{
    public class BrandRepository : IBrandRepository
    {
        CyclixContext db;
        public BrandRepository(CyclixContext _db)
        {
            db = _db;
        }

        public async Task<List<Brand>> GetBrands()
        {
            List<Brand> brands = new List<Brand>();
            if (db != null)
            {
                brands = await db.Brands.ToListAsync();
            }
            return brands;
        }
    }
}

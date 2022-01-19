using InventoryApi.Business.Interfaces;
using InventoryApi.Business.Models;
using InventoryApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace InventoryApi.Data.Repository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(InventoryDbContext context) : base(context)
        {
        }

        public async Task<Location> GetLocation(Guid id)
        {
            return await Db.Locations.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Location> GetLocationProducts(Guid id)
        {
            return await Db.Locations.AsNoTracking()
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
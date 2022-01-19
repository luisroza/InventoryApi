using InventoryApi.Business.Interfaces;
using InventoryApi.Business.Models;
using InventoryApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(InventoryDbContext context) : base(context) { }

        public async Task<Product> GetProduct(Guid id)
        {
            return await Db.Products.AsNoTracking().Include(f => f.Location)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsLocations()
        {
            return await Db.Products.AsNoTracking().Include(f => f.Location).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByLocation(Guid supplierId)
        {
            return await Db.Products.AsNoTracking().Where(p => p.LocationId == supplierId).ToListAsync();
        }
    }
}
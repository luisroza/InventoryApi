using InventoryApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryApi.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByLocation(Guid supplierId);
        Task<IEnumerable<Product>> GetProductsLocations();
        Task<Product> GetProduct(Guid id);
    }
}
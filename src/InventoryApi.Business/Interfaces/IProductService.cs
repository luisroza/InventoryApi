using InventoryApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryApi.Business.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Guid id);
        Task<Product> GetProduct(Guid id);
        Task<IEnumerable<Product>> GetProductsLocations();
        Task<IEnumerable<Product>> GetProductsByLocation(Guid supplierId);
    }
}
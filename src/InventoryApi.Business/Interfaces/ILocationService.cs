using InventoryApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryApi.Business.Interfaces
{
    public interface ILocationService : IDisposable
    {
        Task<bool> Add(Location v);
        Task<bool> Update(Location supplier);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Location>> GetAll();
        Task<Location> GetLocation(Guid id);
        Task<Location> GetLocationProducts(Guid id);
    }
}
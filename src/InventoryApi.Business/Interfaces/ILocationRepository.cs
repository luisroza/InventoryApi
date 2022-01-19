using InventoryApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace InventoryApi.Business.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<Location> GetLocation(Guid id);
        Task<Location> GetLocationProducts(Guid id);
    }
}
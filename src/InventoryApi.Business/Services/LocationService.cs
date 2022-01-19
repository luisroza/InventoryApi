using InventoryApi.Business.Interfaces;
using InventoryApi.Business.Models;
using InventoryApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Business.Services
{
    public class LocationService : BaseService, ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository, INotifier notifier) : base(notifier)
        {
            _locationRepository = locationRepository;
        }

        public async Task<bool> Add(Location location)
        {
            if (!Validate(new LocationValidation(), location)) return false;

            var loc = await _locationRepository.GetLocation(location.Id);

            if (loc != null)
            {
                Notify("There is a existing location with the informed CODE");
                return false;
            }

            await _locationRepository.Add(location);
            return true;
        }

        public async Task<bool> Update(Location location)
        {
            if (!Validate(new LocationValidation(), location)) return false;

            var loc = await _locationRepository.GetLocation(location.Id);

            if (loc != null)
            {
                Notify("There is a existing location with the informed CODE");
                return false;
            }

            await _locationRepository.Update(location);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (_locationRepository.GetLocationProducts(id).Result.Products.Any())
            {
                Notify("Location has products registered");
                return false;
            }

            await _locationRepository.Delete(id);
            return true;
        }

        public void Dispose()
        {
            _locationRepository?.Dispose();
        }
    }
}
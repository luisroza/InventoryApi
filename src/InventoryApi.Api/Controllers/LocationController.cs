using AutoMapper;
using InventoryApi.Business.Interfaces;
using InventoryApi.Business.Models;
using InventoryApi.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryApi.WebApp.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController : BaseController
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationRepository supplierRepository,
                                    ILocationService supplierService,
                                    IMapper mapper,
                                    INotifier notifier) : base(notifier)
        {
            _locationRepository = supplierRepository;
            _locationService = supplierService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<LocationViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<LocationViewModel>>(await _locationRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LocationViewModel>> GetById(Guid id)
        {
            var location = await GetSupplierProducts(id);

            if (location == null) return NotFound();

            return location;
        }
        
        [HttpPost]
        public async Task<ActionResult<LocationViewModel>> Add(LocationViewModel locationViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _locationService.Add(_mapper.Map<Location>(locationViewModel));

            return CustomResponse(locationViewModel);
        }
        
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LocationViewModel>> Update(Guid id, LocationViewModel locationViewModel)
        {
            if (id != locationViewModel.Id)
            {
                NotifyError("Id do not match with the one used in the query");
                return CustomResponse(locationViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _locationService.Update(_mapper.Map<Location>(locationViewModel));

            return CustomResponse(locationViewModel);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LocationViewModel>> Delete(Guid id)
        {
            var locationViewModel = await GetSupplierProducts(id);

            if (locationViewModel == null) return NotFound();

            await _locationService.Delete(id);

            return CustomResponse(locationViewModel);
        }

        private async Task<LocationViewModel> GetSupplierProducts(Guid id)
        {
            return _mapper.Map<LocationViewModel>(await _locationRepository.GetLocationProducts(id));
        }
    }
}
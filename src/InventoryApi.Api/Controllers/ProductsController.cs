using AutoMapper;
using InventoryApi.Business.Interfaces;
using InventoryApi.Business.Models;
using InventoryApi.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryApi.WebApp.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, INotifier notifier,
                                    IMapper mapper) : base(notifier)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetProductsLocations());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null) return NotFound();

            return productViewModel;
        }
        
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.Add(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                NotifyError("Ids do not match");
                return CustomResponse();
            }

            var productUpdate = await GetProduct(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            productUpdate.LocationId = productViewModel.LocationId;
            productUpdate.Name = productViewModel.Name;
            productUpdate.Description = productViewModel.Description;
            productUpdate.Price = productViewModel.Price;

            await _productService.Update(_mapper.Map<Product>(productUpdate));

            return CustomResponse(productViewModel);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null) return NotFound();

            await _productService.Delete(id);

            return CustomResponse(product);
        }

        private async Task<ProductViewModel> GetProduct(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productService.GetProduct(id));
        }
    }
}
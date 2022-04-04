using InventoryApi.Business.Interfaces;
using InventoryApi.Business.Models;
using InventoryApi.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryApi.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!Validate(new ProductValidation(), product)) return;

            await _productRepository.Add(product);
        }

        public async Task Update(Product product)
        {
            if (!Validate(new ProductValidation(), product)) return;

            await _productRepository.Update(product);
        }

        public async Task Delete(Guid id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _productRepository.GetProduct(id);
;        }

        public async Task<IEnumerable<Product>> GetProductsLocations()
        {
            return await _productRepository.GetProductsLocations();
        }

        public async Task<IEnumerable<Product>> GetProductsByLocation(Guid supplierId)
        {
            return await _productRepository.GetProductsByLocation(supplierId);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
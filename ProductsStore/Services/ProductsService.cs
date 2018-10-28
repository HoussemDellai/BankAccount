using Microsoft.EntityFrameworkCore;
using ProductsStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.Services
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _repository;

        /// <summary>
        /// Should introduce IProductsRepository
        /// instead of using ProductsContext.
        /// </summary>
        /// <param name="context"></param>
        public ProductsService(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }

        public async Task<Product> GetById(int id)
        {
            if (id < 0) return null;

            return await _repository.GetById(id);
        }
        
        public async Task<Product> Add(Product product)
        {
            if (string.IsNullOrEmpty(product.Name)) return null;

            return await _repository.Add(product);
        }

        public async Task<Product> Update(int id, Product product)
        {
            if (id != product.Id) return null;

            return await _repository.Update(id, product);
        }

        public async Task<Product> Remove(int id)
        {
            if (id < 0) return null;

            return await _repository.Remove(id);
        }
    }
}

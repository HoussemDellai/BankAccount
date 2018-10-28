using ProductsStore.Models;
using ProductsStore.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.UnitTests
{
    public class FakeProductsRepository : IProductsRepository
    {
        private readonly List<Product> _products;

        public FakeProductsRepository(List<Product> products)
        {
            _products = products;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return _products;
        }

        public async Task<Product> GetById(int id)
        {
            return _products.Find(p => p.Id == id);
        }

        public async Task<Product> Add(Product product)
        {
            _products.Add(product);
            return product;
        }

        public async Task<Product> Update(int id, Product product)
        {
            var prdct = _products.Find(p => p.Id == id);
            prdct.Name = product.Name;
            return prdct;
        }

        public async Task<Product> Remove(int id)
        {
            var product = _products.Find(p => p.Id == id);
            _products.Remove(product);
            return product;
        }
    }
}

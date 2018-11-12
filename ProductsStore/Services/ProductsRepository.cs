using Microsoft.EntityFrameworkCore;
using ProductsStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.Services
{
    public class ProductsRepository : IProductsRepository
    {
        private ProductsContext _context;

        /// <summary>
        /// Should introduce IProductsRepository
        /// instead of using ProductsContext.
        /// </summary>
        /// <param name="context"></param>
        public ProductsRepository(ProductsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        
        public async Task<Product> Add(Product product)
        {
            var entry = _context.Add(product);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Product> Update(int id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Remove(int id)
        {
            var product = await GetById(id);
            _context.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}

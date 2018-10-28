using ProductsStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.Services
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetById(int id);

        Task<Product> Add(Product newItem);

        Task<Product> Update(int id, Product product);

        Task<Product> Remove(int id);
    }
}

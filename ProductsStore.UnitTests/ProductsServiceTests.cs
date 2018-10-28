using ProductsStore.Models;
using ProductsStore.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProductsStore.UnitTests
{
    public class ProductsServiceTests
    {
        private readonly IProductsRepository _fakeProductsRepository;

        public ProductsServiceTests()
        {
            // TODO: generate sample products using Bogus

            var product = new Product
            {
                Id = 1,
                Name = "Laptop"
            };
            var products = new List<Product>();
            products.Add(product);
            _fakeProductsRepository = new FakeProductsRepository(products);
        }

        [Fact]
        [Trait("ProductsStore", "GetAllProducts")]
        public async Task GetAllProducts_ReturnsAvailableProducts()
        {
            // Arrange
            var sut = new ProductsService(_fakeProductsRepository);

            // Act
            var actual = await sut.GetAllProducts();

            // Assert
            Assert.True(actual.ToList().Count > 0);
        }

        [Fact]
        [Trait("ProductsStore", "GetById")]
        public async Task GetById_ValidId_ReturnsProduct()
        {
            // Arrange
            var sut = new ProductsService(_fakeProductsRepository);

            // Act
            var actual = await sut.GetById(1);

            // Assert
            Assert.NotNull(actual);
        }

        [Fact]
        [Trait("ProductsStore", "Add")]
        public async Task Add_ValidId_ReturnsProduct()
        {
            // Arrange
            var sut = new ProductsService(_fakeProductsRepository);

            // Act
            var actual = await sut.Add(new Product
            {
                Id = 2,
                Name = "Smartphone"
            });

            // Assert
            Assert.True(actual.Id == 2);
            Assert.True(actual.Name == "Smartphone");
        }
    }
}

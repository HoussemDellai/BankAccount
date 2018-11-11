using Bogus;
using Moq;
using ProductsStore.Models;
using ProductsStore.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProductsStore.UnitTests
{
    public class ProductsServiceTestsWithMock
    {
        private readonly Mock<IProductsRepository> _mockProductsRepository;
        private Product _product;
        private IEnumerable<Product> _products;

        public ProductsServiceTestsWithMock()
        {
            // TODO: generate sample products using Bogus

            _product = new Product
            {
                Id = 1,
                Name = "Laptop"
            };
            _products = new List<Product> { _product };

            _mockProductsRepository = new Mock<IProductsRepository>();
        }

        [Fact]
        [Trait("ProductsStore", "GetAllProducts")]
        public async Task GetAllProducts_ReturnsAvailableProducts()
        {
            // Arrange
            _mockProductsRepository.Setup(x => x.GetAllProducts()).Returns(Task.FromResult(_products));
            
            var sut = new ProductsService(_mockProductsRepository.Object);

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
            _mockProductsRepository.Setup(x => x.GetById(1)).Returns(Task.FromResult(_product));

            var sut = new ProductsService(_mockProductsRepository.Object);

            // Act
            var actual = await sut.GetById(1);

            // Assert
            Assert.NotNull(actual);
        }

        [Fact]
        [Trait("ProductsStore", "GetById")]
        public async Task GetById_NegativeId_ReturnsNull()
        {
            // Arrange
            _mockProductsRepository.Setup(x => x.GetById(-1)).Returns(Task.FromResult<Product>(null));

            var sut = new ProductsService(_mockProductsRepository.Object);

            // Act
            var actual = await sut.GetById(-1);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        [Trait("ProductsStore", "Add")]
        public async Task Add_ValidProduct_ReturnsProduct()
        {
            // Arrange
            _mockProductsRepository.Setup(x => x.Add(_product)).Returns(Task.FromResult(_product));

            var sut = new ProductsService(_mockProductsRepository.Object);

            // Act
            var actual = await sut.Add(_product);

            // Assert
            Assert.True(actual.Id == 1);
            Assert.True(actual.Name == "Laptop");
        }

        [Fact]
        [Trait("ProductsStore", "Add")]
        public async Task Add_EmptyName_ReturnsNull()
        {
            // Arrange
            _mockProductsRepository.Setup(x => x.Add(_product)).Returns(Task.FromResult(_product));

            var sut = new ProductsService(_mockProductsRepository.Object);

            // Act
            var actual = await sut.Add(_product);

            // Assert
            Assert.True(actual.Id == 1);
            Assert.True(actual.Name == "Laptop");
        }

        [Fact]
        [Trait("ProductsStore", "GetAllProducts")]
        public async Task GetAllProducts_ReturnsAvailableProducts_UsingBogus()
        {
            // Arrange
            var id = 1;
            var names = new[] { "laptop", "xbox", "TV", "smartphone", "tablet" };
            var faker = new Faker<Product>()
                              .RuleFor(p => p.Id, f => id++)
                              .RuleFor(p => p.Name, f => f.PickRandom(names));

            IEnumerable<Product> products = faker.Generate(100);

            //var faker2 = new Faker<Product>()
            //                   .RuleFor(p => p.Id, f => f.Random.Int())
            //                   .RuleFor(p => p.Name, f => f.Random.String());

            _mockProductsRepository.Setup(x => x.GetAllProducts()).Returns(Task.FromResult(products));

            var sut = new ProductsService(_mockProductsRepository.Object);

            // Act
            var actual = await sut.GetAllProducts();

            // Assert
            Assert.True(actual.ToList().Count > 0);
        }
    }
}

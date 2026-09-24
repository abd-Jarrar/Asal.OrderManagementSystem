using Asal.OrderManagementSystem.Api.Interfaces;
using Asal.OrderManagementSystem.Api.Models;

namespace Asal.OrderManagementSystem.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Laptop",
                SKU = "LAP-001",
                Price = 1200.00m,
                stockQuantity = 10,
                IsActive = true
            },
            new Product
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Wireless Mouse",
                SKU = "MOU-001",
                Price = 25.50m,
                stockQuantity = 50,
                IsActive = true
            },
            new Product
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Mechanical Keyboard",
                SKU = "KEY-001",
                Price = 85.00m,
                stockQuantity = 20,
                IsActive = true
            },
            new Product
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Name = "USB-C Cable",
                SKU = "USB-001",
                Price = 12.99m,
                stockQuantity = 100,
                IsActive = true
            },
            new Product
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Name = "Old Monitor",
                SKU = "MON-001",
                Price = 150.00m,
                stockQuantity = 0,
                IsActive = false
            }
        };
        public Guid? CreateProduct(string productName, string? SKU, decimal productPrice, int? stockQuantity)
        {
            if (string.IsNullOrEmpty(productName))
                throw new ArgumentException("Product name cannot be empty.",nameof(productName));
            if (productPrice<=0)
                throw new ArgumentException("Product price must be greater than zero.",nameof(productPrice));

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = productName,
                SKU = SKU ?? "Unspecified",
                Price = productPrice,
                stockQuantity = stockQuantity ?? 0
            };
            _products.Add(product);
            return product.Id;

        }

        public bool DeleteProductById(Guid productId)
        {
            var product=GetProductById(productId);
            if (product is null)
                return false;
            else
            {
                _products.Remove(product);
                return true;
            }
        }

        public List<Product> GetAllProducts()
        {
            return _products.ToList();
        }

        public Product? GetProductById(Guid productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        public bool UpdateProduct(Guid productId,string? productName, string? SKU, decimal? price, int? stockQuantity, bool? isActive)
        {
            var product= GetProductById(productId);
            if (product is null)
                return false;
            if (productName is not null)
                product.Name = productName;
            if(SKU is not null)
                product.SKU = SKU;
            if (price is not null && price>0)
                product.Price = (decimal)price;
            if (stockQuantity is not null&&stockQuantity>0)
                product.stockQuantity = (int)stockQuantity;
            if (isActive is not null)
                product.IsActive = (bool)isActive;

            return true;
        }
    }
}

using Asal.OrderManagementSystem.Api.Models;
using System.Net.NetworkInformation;

namespace Asal.OrderManagementSystem.Api.Respnoses
{
    public class ProductRespnose
    {
        public string Name { get; set; } = null!;

        public string SKU { get; set; } = null!;

        public decimal Price { get; set; }

        public int stockQuantity { get; set; }
        private ProductRespnose()
        {
             
        }
        public static ProductRespnose FromModel(Product product)
        {
            if(product is null)
                throw new ArgumentNullException(nameof(product),"cannot create a response from null product");
            var response=new ProductRespnose()
            {
              Name= product.Name,
              SKU= product.SKU,
              Price= product.Price,
              stockQuantity= product.stockQuantity
            };
            return response;
        }
        public static List<ProductRespnose> FromModels(IEnumerable<Product> products)
        {
            return products.Select(p => ProductRespnose.FromModel(p)).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartWithDiscounts.Data
{
    public class ProductPricingRepository
    {
        private readonly List<ProductPricing> _products;  // Database
        private readonly Dictionary<string, ProductPricing> _productList;  // Index

        private static ProductPricingRepository _instance = null;

        public static ProductPricingRepository Instance
        {
            get
            {
                return _instance ??= new ProductPricingRepository();
            }
        }

        // Normally i would put this in a database but to simplify I'll put this into a singleton constructor instead
        private ProductPricingRepository()
        {
            _products = new List<ProductPricing>
            {
                new ProductPricing { Id = "A", UnitPrice = (decimal) 2.00, DiscountVolume = 4, DiscountVolumePrice = (decimal) 7.00 },
                new ProductPricing { Id = "B", UnitPrice = (decimal) 12.00 },
                new ProductPricing { Id = "C", UnitPrice = (decimal) 1.25, DiscountVolume = 6, DiscountVolumePrice = (decimal) 6.00 },
                new ProductPricing { Id = "D", UnitPrice = (decimal) 0.15 }
            };

            // simulating index by putting in dictionary
            _productList = new Dictionary<string, ProductPricing>();
            foreach (var product in _products)
            {
                _productList.Add(product.Id, product);
            }
        }

        public List<ProductPricing> GetProductPricing()
        {
            return _products;
        }

        public ProductPricing GetProductPricingById(string id)
        {
            return _productList.ContainsKey(id) ? _productList[id] : null;
        }
    }
}

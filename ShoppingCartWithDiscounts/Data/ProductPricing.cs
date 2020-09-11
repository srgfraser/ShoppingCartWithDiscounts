using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartWithDiscounts.Data
{
    public class ProductPricing
    {
        public string Id { get; set; }

        public decimal UnitPrice { get; set; }

        public int? DiscountVolume { get; set; }
        public decimal? DiscountVolumePrice { get; set; }
    }
}

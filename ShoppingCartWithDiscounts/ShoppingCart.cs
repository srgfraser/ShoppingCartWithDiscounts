using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCartWithDiscounts.Data;
using ShoppingCartWithDiscounts.Exceptions;
using ShoppingCartWithDiscounts.Interfaces;

namespace ShoppingCartWithDiscounts
{
    public class ShoppingCart : ITerminal
    {
        private readonly ProductPricingRepository _repo = ProductPricingRepository.Instance;

        private readonly Dictionary<string, int> _itemList;

        public ShoppingCart()
        {
            _itemList = new Dictionary<string, int>();
        }

        public int CountForItem(string item)
        {
            return _itemList.ContainsKey(item) ? _itemList[item] : 0;
        }

        public void Scan(string item)
        {
            if (_itemList.ContainsKey(item))
            {
                _itemList[item]++;
            }
            else
            {
                _itemList.Add(item, 1);
            }
        }

        public void ScanMultipleItems(IEnumerable<string> listItems)
        {
            foreach (var item in listItems)
            {
                Scan(item);
            }
        }

        public decimal Total()
        {
            return _itemList.Sum(item => CalcTotalForItem(item.Key, item.Value));
        }

        private decimal CalcTotalForItem(string item, int count)
        {
            var itemPricing = _repo.GetProductPricingById(item);

            if (itemPricing == null)
                throw new PriceCheckException(item);

            if (itemPricing.DiscountVolume == null)
            {
                return count * itemPricing.UnitPrice;
            }

            var discPrice = (decimal) 0.0;
            var remainingCount = count;

            while (remainingCount >= itemPricing.DiscountVolume)
            {
                discPrice += itemPricing.DiscountVolumePrice??0;
                remainingCount -= itemPricing.DiscountVolume??0;
            }

            return discPrice + (remainingCount * itemPricing.UnitPrice);
        }
    }
}

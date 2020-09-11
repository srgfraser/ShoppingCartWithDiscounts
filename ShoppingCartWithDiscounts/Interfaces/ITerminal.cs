using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartWithDiscounts.Interfaces
{
    public interface ITerminal
    {
        void ScanMultipleItems(IEnumerable<string> listItems);
        void Scan(string item);

        decimal Total();
    }
}

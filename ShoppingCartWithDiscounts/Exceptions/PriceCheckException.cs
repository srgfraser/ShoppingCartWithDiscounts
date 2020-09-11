using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartWithDiscounts.Exceptions
{
    public class PriceCheckException : Exception
    {
        public string Item { get; set; }

        public PriceCheckException() : base()
        {
            Item = "Unknown Item";
        }

        public PriceCheckException(string item) : base()
        {
            Item = item;
        }

        public PriceCheckException(string item, string message) : base(message)
        {
            Item = item;
        }

        public PriceCheckException(string message, Exception innerException) : base(message, innerException)
        {
            Item = "Unknown Item";
        }

        public PriceCheckException(string item, string message, Exception innerException) : base(message, innerException)
        {
            Item = item;
        }
    }
}

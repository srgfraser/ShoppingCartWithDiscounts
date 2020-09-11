using System.Collections.Generic;
using NUnit.Framework;
using ShoppingCartWithDiscounts.Exceptions;

namespace ShoppingCartWithDiscounts.Tests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void Scan_MultipleItems_CorrectCountForEachItem()
        {
            var cart = new ShoppingCart();

            cart.Scan("A");
            cart.Scan("B");
            cart.Scan("C");
            cart.Scan("A");
            cart.Scan("A");
            cart.Scan("B");

            Assert.That(cart.CountForItem("A") == 3);
            Assert.That(cart.CountForItem("B") == 2);
            Assert.That(cart.CountForItem("C") == 1);
            Assert.That(cart.CountForItem("D") == 0);
        }

        [Test]
        public void ScanMultipleItems_MultipleItems_CorrectCountForEachItem()
        {
            var cart = new ShoppingCart();

            cart.ScanMultipleItems(new string[] {"A", "B", "C", "A", "A", "B"});

            Assert.That(cart.CountForItem("A") == 3);
            Assert.That(cart.CountForItem("B") == 2);
            Assert.That(cart.CountForItem("C") == 1);
            Assert.That(cart.CountForItem("D") == 0);
        }

        [Test]
        [TestCase(new string[] {}, 0)]
        [TestCase(new string[] {"A", "B", "C", "D", "A", "B", "A", "A"}, 32.40)]
        [TestCase(new string[] {"C", "C", "C", "C", "C", "C", "C"}, 7.25)]
        [TestCase(new string[] {"A", "B", "C", "D"}, 15.40)]
        public void Total_MultipleItems_CorrectTotal(IEnumerable<string> itemList, decimal expectedResult)
        {
            var cart = new ShoppingCart();

            cart.ScanMultipleItems(itemList);

            var result = cart.Total();

            Assert.That(result == expectedResult);
        }

        [Test]
        public void Total_InvalidItem_ThrowPriceCheckException()
        {
            var cart = new ShoppingCart();

            cart.ScanMultipleItems(new string[] {"A", "E", "B"});

            Assert.That(() => cart.Total(), Throws.Exception.TypeOf<PriceCheckException>());
        }

    }
}
/*
 * If we have sufficient time, we can try Checkout Pricing Kata:
 * Implement the code for a supermarket checkout that calculates the total price of a number of items. 
 * In a normal supermarket, things are identified using Stock Keeping Units, or SKUs.
 * In our store, we’ll use individual letters of the alphabet (A, B, C, and so on). Our goods are priced individually.
 * In addition, some items are multipriced: buy n of them, and they’ll cost you y cents. 
 * For example, item ‘A’ might cost 50 cents individually, but this week we have a special offer: buy three ‘A’s and they’ll cost you $1.30. 
 * In fact this week’s prices are:
  
   Item   Unit      Special
          Price     Price
  --------------------------
    A     50       3 for 130
    B     30       2 for 45
    C     20
    D     15
 * 
 * Our checkout accepts items in any order, so that if we scan a B, an A, and another B, we’ll recognize the two B’s and price them at 45 (for a total price so far of 95). Because the pricing changes frequently, we need to be able to pass in a set of pricing rules each time we start handling a checkout transaction.
*/

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CheckoutTest
{
    [TestFixture]
    public class CheckoutKata
    {
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        public void AddSingleItem(string item, int expected)
        {
            Checkout c = new Checkout();
            c.Add(item);
            Assert.AreEqual(expected, c.GetTotalPrice());
        }

        [Test]
        public void AddMultipleDifferentItem()
        {
            Checkout c = new Checkout();
            c.Add("A");
            c.Add("B");
            Assert.AreEqual(80, c.GetTotalPrice());
        }

        [Test]
        public void AddItemWithDiscount()
        {
            Checkout c = new Checkout();
            c.Add("A");
            c.Add("A");
            c.Add("A");
            Assert.AreEqual(130, c.GetTotalPrice());
        }

        [Test]
        public void AddMultipleItemsWithDiscount()
        {
            Checkout c = new Checkout();
            c.Add("A");
            c.Add("A");
            c.Add("B");
            c.Add("A");
            Assert.AreEqual(160, c.GetTotalPrice());
        }

        [Test]
        public void AddMultipleItemsWithMultipleDiscount()
        {
            Checkout c = new Checkout();
            c.Add("A");
            c.Add("B");
            c.Add("A");
            c.Add("B");
            c.Add("A");
            Assert.AreEqual(175, c.GetTotalPrice());
        }

        [Test]
        public void AddMultipleItemsWithNonDiscount()
        {
            Checkout c = new Checkout();
            c.Add("A");
            c.Add("C");
            c.Add("A");
            c.Add("B");
            c.Add("A");
            Assert.AreEqual(180, c.GetTotalPrice());
        }
    }

    public class Checkout
    {
        private int total = 0;
        public Dictionary<string, int> Price = new Dictionary<string, int>()
        {
            {"A", 50},
            {"B", 30},
            {"C", 20},
        };
        public Dictionary<string, int> DiscountItem = new Dictionary<string, int>()
        {
            {"A", 3},
            {"B", 2}
        };
        public Dictionary<string, int> DiscountedPrice = new Dictionary<string, int>()
        {
            {"A", 130},
            {"B", 45}
        };
        public void Add(string s)
        {
            if (!ItemCount.ContainsKey(s)) ItemCount[s] = 0;
            ItemCount[s]++;
        }

        public Dictionary<string, int> ItemCount = new Dictionary<string, int>();

        public int GetTotalPrice()
        {
            return ItemCount.AsEnumerable().Sum(item => GetDiscountedItemsPrice(item) + GetNormalItemsPrice(item));
        }

        private int GetDiscountedItemsPrice(KeyValuePair<string, int> item)
        {
            return DiscountItem.ContainsKey(item.Key) ? item.Value/DiscountItem[item.Key] * DiscountedPrice[item.Key] : 0;
        }

        private int GetNormalItemsPrice(KeyValuePair<string, int> item)
        {
            return Price[item.Key] * (DiscountItem.ContainsKey(item.Key) ? item.Value % DiscountItem[item.Key] : item.Value);
        }
    }
}

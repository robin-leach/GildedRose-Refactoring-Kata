using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void IfPastSellByDate_QualityDegradesTwiceAsFast()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "test_item_1", SellIn = 10, Quality = 10 },
                new Item { Name = "test_item_2", SellIn = 0, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, Items[1].Quality+1);
        }

        [Test]
        public void QualityNeverNegative()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "test_item", SellIn = 10, Quality = 0 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality,0);
        }

        [Test]
        public void AgedBrieGainsQuality()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality,11);
            Assert.AreEqual(Items[1].Quality, 12);
        }

        [Test]
        public void QualityNeverMoreThanFifty()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 50);
        }

        [Test]
        public void SulfurasNeverChangesQuality()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 80);
            Assert.AreEqual(Items[1].Quality, 80);
        }

        [Test]
        public void BackStagePassesIncreaseInQualityBeforeSellIn()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -5, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 11);
            Assert.AreEqual(Items[1].Quality, 12);
            Assert.AreEqual(Items[2].Quality, 13);
            Assert.AreEqual(Items[3].Quality, 0);
        }

        [Test]
        public void ConjuredItemsDegradeInQualityTwiceAsFast()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Conjured bracelet", SellIn = 10, Quality = 20 },
                new Item { Name = "Conjured apple", SellIn = 10, Quality = 20 },
                new Item { Name = "Regular bracelet", SellIn = 10, Quality = 20 },
                new Item { Name = "Regular apple", SellIn = 10, Quality = 20 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 18);
            Assert.AreEqual(Items[1].Quality, 18);
            Assert.AreEqual(Items[2].Quality, 19);
            Assert.AreEqual(Items[3].Quality, 19);
        }
    }
}

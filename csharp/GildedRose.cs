using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public bool IsNameOfConjuredItem(string itemName)
        {
            return (itemName.Length >= 8 && itemName.Substring(0, 8) == "Conjured");
        }

        public Item UpdateAgedBrieQuality(Item agedBrie)
        {
            agedBrie.Quality++;
            if (agedBrie.SellIn <= 0) agedBrie.Quality++;
            return agedBrie;
        }

        public Item UpdateBackstagePassQuality(Item backstagePass)
        {
            if (backstagePass.SellIn > 10) backstagePass.Quality += 1;
            else if (backstagePass.SellIn > 5) backstagePass.Quality += 2;
            else if (backstagePass.SellIn > 0) backstagePass.Quality += 3;
            else backstagePass.Quality = 0;
            return backstagePass;
        }

        public Item UpdateOtherItemsQuality(Item otherItem)
        {
            int conjuredMultiplier = 1;
            if (IsNameOfConjuredItem(otherItem.Name)) conjuredMultiplier = 2;
            if (otherItem.SellIn > 1) otherItem.Quality -= 1 * conjuredMultiplier;
            else otherItem.Quality -= 2 * conjuredMultiplier;
            return otherItem;
        }

        public Item keepQualityBetweenMinAndMax(Item item)
        {
            item.Quality = Math.Min(50, item.Quality);
            item.Quality = Math.Max(0, item.Quality);
            return item;
        }

        public void UpdateQuality()
        {
            foreach(Item item in Items)
            {
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Aged Brie":
                        UpdateAgedBrieQuality(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePassQuality(item);
                        break;
                    default:
                        UpdateOtherItemsQuality(item);
                        break;
                }
                keepQualityBetweenMinAndMax(item);
                item.SellIn--;
            }
        }
    }
}

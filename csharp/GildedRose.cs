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
            if (itemName.Length < 8)
                return false;
            string firstEightLetters = itemName.Substring(0,8);
            if (firstEightLetters == "Conjured")
                return true;
            else return false;
        }

        public Item UpdateAgedBrieQuality(Item agedBrie)
        {
            if (agedBrie.Quality < 50)
            {
                agedBrie.Quality++;
                if (agedBrie.SellIn <= 0) agedBrie.Quality++;
            }
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

        public Item UpdateNonSpecialItemsQuality(Item nonSpecialItem)
        {
            int conjuredMultiplier = 1;
            if (IsNameOfConjuredItem(nonSpecialItem.Name)) conjuredMultiplier = 2;
            if (nonSpecialItem.Quality > 0)
            {
                if (nonSpecialItem.SellIn > 1) nonSpecialItem.Quality -= 1 * conjuredMultiplier;
                else nonSpecialItem.Quality -= 2 * conjuredMultiplier;
            }
            return nonSpecialItem;
        }

        public Item keepQualityBetweenZeroAndFifty(Item item)
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
                        UpdateNonSpecialItemsQuality(item);
                        break;
                }

                keepQualityBetweenZeroAndFifty(item);
                item.SellIn--;

            }
        }
    }
}

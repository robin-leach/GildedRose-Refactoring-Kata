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

        public void UpdateQuality()
        {
            foreach(Item item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                    continue;
                switch (item.Name)
                {
                    case "Aged Brie":
                        if (item.Quality < 50) item.Quality++;
                        if (item.Quality < 50 && item.SellIn <= 0) item.Quality++;
                        item.SellIn--;
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (item.SellIn > 10) item.Quality += 1;
                        else if (item.SellIn > 5) item.Quality += 2;
                        else if (item.SellIn > 0) item.Quality += 3;
                        else item.Quality = 0;
                        item.SellIn--;
                        break;
                    default:
                        int conjuredMultiplier = 1;
                        if (IsNameOfConjuredItem(item.Name))
                            conjuredMultiplier = 2;
                        if (item.Quality > 0)
                        {
                            if (item.SellIn > 1) item.Quality -= 1*conjuredMultiplier;
                            else item.Quality -= 2*conjuredMultiplier;
                        }
                        item.SellIn--;
                        break;
                }
                item.Quality = Math.Min(50, item.Quality);
                item.Quality = Math.Max(0, item.Quality);
            }
        }
    }
}

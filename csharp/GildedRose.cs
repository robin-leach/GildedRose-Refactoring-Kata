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

        public void UpdateQuality()
        {
           foreach(Item item in Items)
                {
                    switch (item.Name)
                    {
                        case "Sulfuras, Hand of Ragnaros":
                            break;
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
                            if (item.Quality > 0)
                            {
                                if (item.SellIn > 1) item.Quality -= 1;
                                else item.Quality -= 2;
                            }
                        item.SellIn--;
                            break;
                    }
                }
        }
    }
}

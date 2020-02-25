using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackStagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";


        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name != AgedBrie && item.Name != BackStagePass)
                {
                    if (IsQualityAboveMinimumValue(item))
                    {
                        if (item.Name != Sulfuras)
                        {
                            DecreaseQuality(item);
                        }
                    }
                }
                else
                {
                    if (IsQualityBelowMaximumAllowedValue(item))
                    {
                        IncreaseQuality(item);

                        if (item.Name == BackStagePass)
                        {
                            if (item.SellIn < 11)
                            {
                                if (IsQualityBelowMaximumAllowedValue(item))
                                {
                                    IncreaseQuality(item);
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (IsQualityBelowMaximumAllowedValue(item))
                                {
                                    IncreaseQuality(item);
                                }
                            }
                        }
                    }
                }

                if (item.Name != Sulfuras)
                {
                    DecreaseRemainingSellDays(item);
                }

                if (IsItemExpired(item))
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != BackStagePass)
                        {
                            if (IsQualityAboveMinimumValue(item))
                            {
                                if (item.Name != Sulfuras)
                                {
                                    DecreaseQuality(item);
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (IsQualityBelowMaximumAllowedValue(item))
                        {
                            IncreaseQuality(item);
                        }
                    }
                }
            }
        }

        private static void DecreaseRemainingSellDays(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private static bool IsQualityAboveMinimumValue(Item item)
        {
            return item.Quality > 0;
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }

        private static void IncreaseQuality(Item item)
        {
            item.Quality += 1;
        }

        private static bool IsQualityBelowMaximumAllowedValue(Item item)
        {
            return item.Quality < 50;
        }

        private static bool IsItemExpired(Item item)
        {
            return item.SellIn < 0;
        }
    }
}

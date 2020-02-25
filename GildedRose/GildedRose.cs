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
                //Quality Handeling

                
                
                if(item.Name == AgedBrie || item.Name == BackStagePass)
                {
                    if (IsQualityBelowMaximumAllowedValue(item))
                    {
                        IncreaseQuality(item);
                    }
                }

                if (item.Name == BackStagePass)
                {
                    if (IsQualityBelowMaximumAllowedValue(item))
                    {
                        if (item.SellIn < 11)
                        {

                            IncreaseQuality(item);
                        }

                        if (item.SellIn < 6)
                        {
                            IncreaseQuality(item);
                        }
                    }
                }

                //SellIn Handeling
                if (item.Name != Sulfuras)
                {
                    DecreaseRemainingSellDays(item);
                }

                //Default Case
                if (item.Name != AgedBrie && item.Name != BackStagePass && item.Name != Sulfuras)
                {
                    if (IsItemExpired(item))
                    {
                        if (IsQualityAboveMinimumValue(item))
                        {
                            DecreaseQuality(item);
                        }
                    }

                    if (IsQualityAboveMinimumValue(item))
                    {
                        DecreaseQuality(item);
                    }
                }



                if (item.Name == BackStagePass)
                {
                    if (IsItemExpired(item))
                    {
                        SetQualityTo0(item);
                    }
                }

                if (item.Name == AgedBrie)
                {
                    if (IsItemExpired(item))
                    {
                        if (IsQualityBelowMaximumAllowedValue(item))
                        {
                            IncreaseQuality(item);
                        }
                    }
                }
            }
        }

        private static void SetQualityTo0(Item item)
        {
            item.Quality = 0;
        }

        private static void DecreaseRemainingSellDays(Item item)
        {
            item.SellIn -=  1;
        }

        private static bool IsQualityAboveMinimumValue(Item item)
        {
            return item.Quality > 0;
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality -= 1;
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

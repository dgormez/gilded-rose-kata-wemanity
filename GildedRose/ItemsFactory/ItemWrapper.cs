using GildedRose.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{

    public class ItemWrapper : Item, IAgeable
    {
        private const string AgedBrie = "Aged Brie";

        private const string BackStagePass = "Backstage passes to a TAFKAL80ETC concert";

        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        public void Age()
        {
            if (Name == BackStagePass)
            {
                //BackStage passes Increase in quality when approching sell day
                IncreaseQualityIfBelowMaximum();

                if (IsQualityBelowMaximumAllowedValue())
                {
                    if (SellIn < 11)
                    {
                        IncreaseQuality();
                    }

                    if (SellIn < 6)
                    {
                        IncreaseQuality();
                    }
                }

                DecreaseRemainingSellDays();

                if (IsItemExpired())
                {
                    SetQualityTo0();
                }
            }
                       
            if (Name == AgedBrie)
            {
                DecreaseRemainingSellDays();

                //Aged Brie increase in quality instead of decreasing
                IncreaseQualityIfBelowMaximum();

                //Double quality increase rate for AgedBrie when expired
                if (IsItemExpired())
                {
                    IncreaseQualityIfBelowMaximum();
                }
            }
                       
            //Default Case
            if (Name != AgedBrie && Name != BackStagePass && Name != Sulfuras)
            {
                DecreaseRemainingSellDays();

                //Decrease quality of item
                DecreaseQualityIfAboveMinimum();

                //Doubble decrease Rate when expired
                if (IsItemExpired())
                {
                    DecreaseQualityIfAboveMinimum();
                }
            }
        }

        private void DecreaseQualityIfAboveMinimum()
        {
            if (IsQualityAboveMinimumValue())
            {
                DecreaseQuality();
            }
        }

        private void IncreaseQualityIfBelowMaximum()
        {
            if (IsQualityBelowMaximumAllowedValue())
            {
                IncreaseQuality();
            }
        }

        private void SetQualityTo0()
        {
            Quality = 0;
        }

        private void DecreaseRemainingSellDays()
        {
            SellIn -= 1;
        }

        private bool IsQualityAboveMinimumValue()
        {
            return Quality > 0;
        }

        private void DecreaseQuality()
        {
            Quality -= 1;
        }

        private void IncreaseQuality()
        {
            Quality += 1;
        }

        private bool IsQualityBelowMaximumAllowedValue()
        {
            return Quality < 50;
        }

        private bool IsItemExpired()
        {
            return SellIn < 0;
        }
    }

}
using GildedRose.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.ItemsFactory
{

    public class ItemWrapper : Item, IAgeable
    {
        private const string AgedBrie = "Aged Brie";

        private const string BackStagePass = "Backstage passes to a TAFKAL80ETC concert";

        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        public ItemWrapper (string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public virtual void Age()
        {
            //Default Case
            DecreaseRemainingSellDays();

            //Decrease quality of item
            DecreaseQualityIfAboveMinimum();

            //Doubble decrease Rate when expired
            if (IsItemExpired())
            {
                DecreaseQualityIfAboveMinimum();
            }
        }

        protected void DecreaseQualityIfAboveMinimum()
        {
            if (IsQualityAboveMinimumValue())
            {
                DecreaseQuality();
            }
        }

        protected void IncreaseQualityIfBelowMaximum()
        {
            if (IsQualityBelowMaximumAllowedValue())
            {
                IncreaseQuality();
            }
        }

        protected void SetQualityTo0()
        {
            Quality = 0;
        }

        protected void DecreaseRemainingSellDays()
        {
            SellIn -= 1;
        }

        protected bool IsQualityAboveMinimumValue()
        {
            return Quality > 0;
        }

        protected void DecreaseQuality()
        {
            Quality -= 1;
        }

        protected void IncreaseQuality()
        {
            Quality += 1;
        }

        protected bool IsQualityBelowMaximumAllowedValue()
        {
            return Quality < 50;
        }

        protected bool IsItemExpired()
        {
            return SellIn < 0;
        }
    }

}
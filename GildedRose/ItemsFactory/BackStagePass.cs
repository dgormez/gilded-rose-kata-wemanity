﻿using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class BackStagePass : ItemWrapper
    {

        public BackStagePass(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }

        public override void Age()
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
    }

}
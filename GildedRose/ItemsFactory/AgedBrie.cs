using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class AgedBrie : ItemWrapper
    {

        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }

        public override void Age()
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{

    public static class ItemWrapperFactory
    {
        public static ItemWrapper GetCorrectItemTypeByName(string name, int quality, int sellIn)
        {
            switch (name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(name, quality, sellIn);
                case "Aged Brie":
                    return new AgedBrie(name, quality, sellIn);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackStagePass(name, quality, sellIn);
                default:
                    return new ItemWrapper(name, quality, sellIn);
            }
        }
    }
}
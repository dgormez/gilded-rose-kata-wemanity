using GildedRose.ItemsFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.ItemsFactory
{

    public static class ItemWrapperFactory
    {
        public static ItemWrapper GetCorrectItemTypeByName(string name, int sellIn, int quality )
        {
            switch (name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(name, sellIn, quality);
                case "Aged Brie":
                    return new AgedBrie(name, sellIn, quality);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackStagePass(name, sellIn, quality);
                case "Conjured Mana Cake":
                    return new Conjured(name, sellIn, quality);
                default:
                    return new ItemWrapper(name, sellIn, quality);
            }
        }
    }
}
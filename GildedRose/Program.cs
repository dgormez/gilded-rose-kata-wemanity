using GildedRose.ItemsFactory;
using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<ItemWrapper> Items = new List<ItemWrapper>{
                ItemWrapperFactory.GetCorrectItemTypeByName("+5 Dexterity Vest",10,20),
                ItemWrapperFactory.GetCorrectItemTypeByName("Aged Brie", 2,  0),
                ItemWrapperFactory.GetCorrectItemTypeByName("Elixir of the Mongoose", 5,  7),
                ItemWrapperFactory.GetCorrectItemTypeByName("Sulfuras, Hand of Ragnaros", 0,  80),
                ItemWrapperFactory.GetCorrectItemTypeByName("Sulfuras, Hand of Ragnaros", -1,  80),
                ItemWrapperFactory.GetCorrectItemTypeByName("Backstage passes to a TAFKAL80ETC concert",15,20),
                ItemWrapperFactory.GetCorrectItemTypeByName("Backstage passes to a TAFKAL80ETC concert",10,49),
                ItemWrapperFactory.GetCorrectItemTypeByName("Backstage passes to a TAFKAL80ETC concert",5,49),
				// this conjured item does not work properly yet
				ItemWrapperFactory.GetCorrectItemTypeByName("Conjured Mana Cake", 3,  25)
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}

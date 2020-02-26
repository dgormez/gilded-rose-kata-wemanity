using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.ItemsFactory
{
    public class Conjured : ItemWrapper
    {
        public Conjured(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }

        public override void Age()
        { }
    }
}

using System;

using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class Sulfuras : ItemWrapper
    {

        public Sulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }

        public override void Age()
        {
            //Do nothing - sulfuras do not age
        }
    }
}
using System.Collections.Generic;



namespace GildedRose

{

    public class GildedRose
    {
        IList<ItemWrapper> Items;

        public GildedRose(IList<ItemWrapper> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.Age();
            }
        }
    }

}
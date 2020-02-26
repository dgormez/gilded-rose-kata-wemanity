using FluentAssertions;

using NUnit.Framework;

using System.Collections.Generic;



namespace GildedRose

{

    [TestFixture]

    public class ItemWrapperTests

    {

        private const string AgedBrie = "Aged Brie";

        private const string BackStagePass = "Backstage passes to a TAFKAL80ETC concert";

        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        private const string DefaultName = "Default Item";



        /// <summary>

        /// [REQ 1] For default item : At the end of each day our system lowers both values for every item

        /// </summary>

        [Test]

        public void AgeItemTest_DefaultItem_AboveSellInDate_QualityShouldDecreaseByOneAndSellInByOne()

        {

            ItemWrapper item = new ItemWrapper() { Name = DefaultName, Quality = 10, SellIn = 10 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = DefaultName, Quality = 9, SellIn = 9 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        /// [REQ 2] Once the sell by date has passed, Quality degrades twice as fast

        /// </summary>

        [Test]

        public void AgeItemTest_DefaultItem_BelowSellInDate_QualityShouldDecreaseByOneAndSellInByOne()

        {

            ItemWrapper item = new ItemWrapper() { Name = DefaultName, Quality = 10, SellIn = -1 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = DefaultName, Quality = 8, SellIn = -2 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        ///  [REQ 3] The Quality of an item is never negative - Default Item

        /// </summary>

        [Test]

        public void AgeItemTest_DefaultItem_QualityShouldNeverBeNegative_DefaultItem()

        {

            ItemWrapper item = new ItemWrapper() { Name = DefaultName, Quality = 10, SellIn = -1 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = DefaultName, Quality = 8, SellIn = -2 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        /// [REQ 3] The Quality of an item is never negative - BackStage Pass

        /// </summary>

        [Test]

        public void AgeItemTest_DefaultItem_QualityShouldNeverBeNegative_BackStagePass()

        {

            ItemWrapper item = new ItemWrapper() { Name = BackStagePass, Quality = 0, SellIn = -1 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = BackStagePass, Quality = 0, SellIn = -2 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        /// [REQ 4] : "Aged Brie" actually increases in Quality the older it gets

        /// </summary>

        [Test]

        public void AgeItemTest_AgedBrie_AboveSellInDate_QualityShouldIncreaseByOneAndSellInDecreaseByOne()

        {

            ItemWrapper item = new ItemWrapper() { Name = AgedBrie, Quality = 10, SellIn = 10 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = AgedBrie, Quality = 11, SellIn = 9 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        /// [REQ 5] : The Quality of an item is never more than 50

        /// </summary>

        [Test]

        public void AgeItemTest_AgedBrie_QualityShouldNeverBeAbove50()

        {

            ItemWrapper item = new ItemWrapper() { Name = AgedBrie, Quality = 50, SellIn = 10 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = AgedBrie, Quality = 50, SellIn = 9 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        /// [REQ 5] : The Quality of an item is never more than 50

        /// </summary>

        [Test]

        public void AgeItemTest_BackStagePass_QualityShouldNeverBeAbove50()

        {

            ItemWrapper item = new ItemWrapper() { Name = BackStagePass, Quality = 50, SellIn = 10 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = BackStagePass, Quality = 50, SellIn = 9 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        /// [REQ 6] : "Sulfuras", being a legendary item, never has to be sold or decreases in Quality

        /// </summary>

        [Test]

        public void AgeItemTest_Sulfuras_QualityNeverDecreases()

        {

            ItemWrapper item = new ItemWrapper() { Name = Sulfuras, Quality = 80, SellIn = 10 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = Sulfuras, Quality = 80, SellIn = 10 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        ///  [REQ 7] "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;

        /// </summary>

        [Test]

        public void AgeItemTest_BackStagePass_QualityIncreaseAsSellInDateApproaches()

        {

            ItemWrapper item = new ItemWrapper() { Name = BackStagePass, Quality = 25, SellIn = 12 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = BackStagePass, Quality = 26, SellIn = 11 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        /// [REQ 8] uality increases by 2 when there are 10 days or less

        /// </summary>

        [Test]

        public void AgeItemTest_BackStagePass_QualityIncreasesByTwoWhenThereAreLessThan10DaysLeft()

        {

            ItemWrapper item = new ItemWrapper() { Name = BackStagePass, Quality = 25, SellIn = 9 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = BackStagePass, Quality = 27, SellIn = 8 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        /// [REQ 8] Quality increases by 3 when there are 5 days or less

        /// </summary>

        [Test]

        public void AgeItemTest_BackStagePass_QualityIncreasesByThreeWhenThereAreLessThan5DaysLeft()

        {

            ItemWrapper item = new ItemWrapper() { Name = BackStagePass, Quality = 25, SellIn = 4 };

            ItemWrapper item_aged_expected = new ItemWrapper() { Name = BackStagePass, Quality = 28, SellIn = 3 };



            item.Age();



            item.Should().BeEquivalentTo(item_aged_expected);

        }



        /// <summary>

        /// [REQ 9] Quality increases by 3 when there are 5 days or less

        /// </summary>

        [Test]

        public void AgeItemTest_BackStagePass_QualityDropsToZeroAfterConcert()
        {
            ItemWrapper item = new ItemWrapper() { Name = BackStagePass, Quality = 25, SellIn = 0 };
            ItemWrapper item_aged_expected = new ItemWrapper() { Name = BackStagePass, Quality = 0, SellIn = -1 };

            item.Age();
            item.Should().BeEquivalentTo(item_aged_expected);
        }

    }

}


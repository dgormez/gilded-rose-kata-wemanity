using FluentAssertions;
using GildedRose.ItemsFactory;
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
        private const string Conjured = "Conjured";

        /// <summary>
        /// [REQ 1] For default item : At the end of each day our system lowers both values for every item
        /// </summary>
        [Test]
        public void AgeItemTest_DefaultItem_AboveSellInDate_QualityShouldDecreaseByOneAndSellInByOne()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(DefaultName, 10, 10);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(DefaultName, 9, 9);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        /// [REQ 2] Once the sell by date has passed, Quality degrades twice as fast
        /// </summary>
        [Test]
        public void AgeItemTest_DefaultItem_BelowSellInDate_QualityShouldDecreaseByOneAndSellInByOne()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(DefaultName, -1, 10);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(DefaultName, -2, 8);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        ///  [REQ 3] The Quality of an item is never negative - Default Item
        /// </summary>
        [Test]
        public void AgeItemTest_DefaultItem_QualityShouldNeverBeNegative_DefaultItem()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(DefaultName, -1, 10);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(DefaultName, -2, 8);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        /// [REQ 3] The Quality of an item is never negative - BackStage Pass
        /// </summary>
        [Test]
        public void AgeItemTest_DefaultItem_QualityShouldNeverBeNegative_BackStagePass()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, -1, 0);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, -2, 0);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        /// [REQ 4] : "Aged Brie" actually increases in Quality the older it gets
        /// </summary>
        [Test]
        public void AgeItemTest_AgedBrie_AboveSellInDate_QualityShouldIncreaseByOneAndSellInDecreaseByOne()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(AgedBrie, 10, 10);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(AgedBrie, 9, 11);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        /// [REQ 5] : The Quality of an item is never more than 50
        /// </summary>
        [Test]
        public void AgeItemTest_AgedBrie_QualityShouldNeverBeAbove50()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(AgedBrie, 10, 50);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(AgedBrie, 9, 50);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        /// [REQ 5] : The Quality of an item is never more than 50
        /// </summary>
        [Test]
        public void AgeItemTest_BackStagePass_QualityShouldNeverBeAbove50()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, 10, 50);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, 9, 50);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }



        /// <summary>
        /// [REQ 6] : "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        /// </summary>
        [Test]
        public void AgeItemTest_Sulfuras_QualityNeverDecreases()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(Sulfuras, 10, 80);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(Sulfuras, 10, 80);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }



        /// <summary>
        ///  [REQ 7] "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
        /// </summary>
        [Test]
        public void AgeItemTest_BackStagePass_QualityIncreaseAsSellInDateApproaches()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, 12, 25);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, 11, 26);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        /// [REQ 8] uality increases by 2 when there are 10 days or less
        /// </summary>
        [Test]
        public void AgeItemTest_BackStagePass_QualityIncreasesByTwoWhenThereAreLessThan10DaysLeft()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, 9, 25);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, 8, 27);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        /// [REQ 8] Quality increases by 3 when there are 5 days or less
        /// </summary>
        [Test]
        public void AgeItemTest_BackStagePass_QualityIncreasesByThreeWhenThereAreLessThan5DaysLeft()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, 4, 25);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, 3, 28);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        /// [REQ 9] Quality increases by 3 when there are 5 days or less
        /// </summary>
        [Test]
        public void AgeItemTest_BackStagePass_QualityDropsToZeroAfterConcert()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, 0, 25);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(BackStagePass, -1, 0);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }

        /// <summary>
        /// [REQ 10] Quality increases by 3 when there are 5 days or less
        /// </summary>
        [Test]
        public void AgeItemTest_Conjured_QualityDecreasesTwiceAsFast()
        {
            ItemWrapper item = ItemWrapperFactory.GetCorrectItemTypeByName(Conjured, -1, 25);
            ItemWrapper item_aged_expected = ItemWrapperFactory.GetCorrectItemTypeByName(Conjured, -2, 21);

            item.Age();

            item.Should().BeEquivalentTo(item_aged_expected);
        }
    }
}


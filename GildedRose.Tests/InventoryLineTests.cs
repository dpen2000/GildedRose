using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class InventoryLineTests
    {
        [Fact]
        public void QualityDegratesByOneEveryDay()
        {
            var inventoryLine = new InventoryLine() { Quality = 1, SellIn = 1 };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(0);
        }

        [Fact]
        public void QualityOfItemNeverNegative()
        {
            var inventoryLine = new InventoryLine() { Quality = 0 };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(0);
        }

        [Fact]
        public void SellInDecreasesEveryDay()
        {
            var inventoryLine = new InventoryLine() { SellIn = 1 };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.SellIn.ShouldBe(0);
        }

        [Fact]
        public void OnceSellInDateHasPassedQualityDegratesTwiceAsFast()
        {
            var inventoryLine = new InventoryLine() { SellIn = 0, Quality = 50 };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(48);
        }

        [Fact]
        public void AgedBrieIncreasesInQualityAsItGetsOlder()
        {
            var inventoryLine = new InventoryLine() { SellIn = 0, Quality = 0, ItemName = "Aged Brie" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(1);
        }

        [Fact]
        public void QualityOfItemCannotExceed50()
        {
            var inventoryLine = new InventoryLine() { SellIn = 0, Quality = 50, ItemName = "Aged Brie" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(50);
        }

        [Fact]
        public void SulfurasDoesNotAgeOrDecreaseQuality()
        {
            var inventoryLine = new InventoryLine() { SellIn = 2, Quality = 2, ItemName = "Sulfuras" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(2);
            inventoryLine.SellIn.ShouldBe(2);
        }

        [Fact]
        public void BackstagePasses_QualityIncreasesBy2_When10DaysInSellInValue()
        {
            var inventoryLine = new InventoryLine() { SellIn = 10, Quality = 2, ItemName = "Backstage Passes" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(4);
        }

        [Fact]
        public void BackstagePasses_QualityIncreasesBy2_When9DaysInSellInValue()
        {
            var inventoryLine = new InventoryLine() { SellIn = 9, Quality = 2, ItemName = "Backstage Passes" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(4);
        }

        [Fact]
        public void BackstagePasses_QualityIncreasesBy3_When5DaysInSellInValue()
        {
            var inventoryLine = new InventoryLine() { SellIn = 5, Quality = 2, ItemName = "Backstage Passes" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(5);
        }

        [Fact]
        public void BackstagePasses_QualityIncreasesBy2_When4DaysInSellInValue()
        {
            var inventoryLine = new InventoryLine() { SellIn = 4, Quality = 2, ItemName = "Backstage Passes" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(5);
        }

        [Fact]
        public void QualityDropsToZeroAfterConcertForBackstagePasses()
        {
            var inventoryLine = new InventoryLine() { SellIn = -1, Quality = 2, ItemName = "Backstage Passes" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(0);
        }

        [Fact]
        public void ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems_BeforeSellIn()
        {
            var inventoryLine = new InventoryLine() { SellIn = 2, Quality = 2, ItemName = "Conjured" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(0);
        }

        [Fact]
        public void ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems_AfterSellIn()
        {
            var inventoryLine = new InventoryLine() { SellIn = -1, Quality = 5, ItemName = "Conjured" };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(1);
        }
    }
}

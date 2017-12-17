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
        private readonly InventoryLineManager _inventoryLineManager;
        public InventoryLineTests()
        {
            _inventoryLineManager = InventoryLineManagerFactory.GetWithUpdatersConfigured();
        }
        [Fact]
        public void QualityDegratesByOneEveryDay()
        {
            var inventoryLine = new InventoryLine() { Quality = 1, SellIn = 1, ItemName = "Normal Item" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(0);
        }

        [Theory]
        [InlineData("Normal Item")]
        [InlineData("Conjured")]
        [InlineData("Sulfuras")]
        [InlineData("Aged Brie")]
        public void QualityOfItemNeverNegative(string itemName)
        {
            var inventoryLine = new InventoryLine() { Quality = -10, ItemName = itemName };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(0);
        }

        [Theory]
        [InlineData("Normal Item")]
        [InlineData("Aged Brie")]
        [InlineData("Backstage passes")]
        [InlineData("Conjured")]
        public void SellInDecreasesEveryDay(string itemName)
        {
            var inventoryLine = new InventoryLine() { SellIn = 1, ItemName = itemName };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.SellIn.ShouldBe(0);
        }

        [Fact]
        public void OnceSellInDateHasPassedQualityDegratesTwiceAsFast()
        {
            var inventoryLine = new InventoryLine() { SellIn = 0, Quality = 50, ItemName = "Normal Item" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(48);
        }

        [Fact]
        public void AgedBrieIncreasesInQualityAsItGetsOlder()
        {
            var inventoryLine = new InventoryLine() { SellIn = 0, Quality = 0, ItemName = "Aged Brie" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(1);
        }

        [Theory]
        [InlineData("Aged Brie")]
        [InlineData("Normal Item")]
        [InlineData("Backstage passes")]
        [InlineData("Conjured")]
        [InlineData("Sulfuras")]
        public void QualityOfItemCannotExceed50(string itemName)
        {
            var inventoryLine = new InventoryLine() { SellIn = 0, Quality = 55, ItemName = itemName };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(50);
        }

        [Fact]
        public void SulfurasDoesNotAgeOrDecreaseQuality()
        {
            var inventoryLine = new InventoryLine() { SellIn = 2, Quality = 2, ItemName = "Sulfuras" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(2);
            inventoryLine.SellIn.ShouldBe(2);
        }

        [Fact]
        public void BackstagePasses_QualityIncreasesBy2_When10DaysInSellInValue()
        {
            var inventoryLine = new InventoryLine() { SellIn = 10, Quality = 2, ItemName = "Backstage passes" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(4);
        }

        [Fact]
        public void BackstagePasses_QualityIncreasesBy2_When9DaysInSellInValue()
        {
            var inventoryLine = new InventoryLine() { SellIn = 9, Quality = 2, ItemName = "Backstage passes" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(4);
        }

        [Fact]
        public void BackstagePasses_QualityIncreasesBy3_When5DaysInSellInValue()
        {
            var inventoryLine = new InventoryLine() { SellIn = 5, Quality = 2, ItemName = "Backstage passes" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(5);
        }

        [Fact]
        public void BackstagePasses_QualityIncreasesBy2_When4DaysInSellInValue()
        {
            var inventoryLine = new InventoryLine() { SellIn = 4, Quality = 2, ItemName = "Backstage passes" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(5);
        }

        [Fact]
        public void QualityDropsToZeroAfterConcertForBackstagePasses()
        {
            var inventoryLine = new InventoryLine() { SellIn = -1, Quality = 2, ItemName = "Backstage passes" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(0);
        }

        [Fact]
        public void ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems_BeforeSellIn()
        {
            var inventoryLine = new InventoryLine() { SellIn = 2, Quality = 2, ItemName = "Conjured" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(0);
        }

        [Fact]
        public void ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems_AfterSellIn()
        {
            var inventoryLine = new InventoryLine() { SellIn = -1, Quality = 5, ItemName = "Conjured" };
            _inventoryLineManager.PerformDailyUpdate(inventoryLine);
            inventoryLine.Quality.ShouldBe(1);
        }
    }
}

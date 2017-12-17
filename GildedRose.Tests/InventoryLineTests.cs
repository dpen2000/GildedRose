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
    }
}

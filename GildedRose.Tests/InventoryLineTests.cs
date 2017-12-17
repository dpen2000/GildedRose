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

        public class InventoryLine
        {
            public int Quality { get; set; }
            public int SellIn { get; set; }
            public string ItemName { get; set; }

            internal void PerformDailyUpdate()
            {
                var previousQuality = Quality;
                if (ItemName == "Aged Brie")
                {
                    Quality++;
                }
                else if (SellIn <= 0)
                {
                    Quality = Quality - 2;
                }
                else
                {
                    Quality--;
                }

                if (Quality < 0)
                {
                    Quality = previousQuality;
                }

                SellIn--;
            }
        }
    }
}

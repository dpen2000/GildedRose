using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class InventoryManagerTests
    {
        [Fact]
        public void QualityDegratesByOneEveryDay()
        {
            var inventoryLine = new InventoryLine() { Quality = 1 };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(0);
        }

        public class InventoryLine
        {
            public int Quality { get; set; }

            internal void PerformDailyUpdate()
            {
                Quality--;
            }
        }
    }
}

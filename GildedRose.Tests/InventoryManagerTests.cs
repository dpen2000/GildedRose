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
        [Theory]
        [InlineData("Aged Brie 1 1", "Aged Brie 0 2")]
        public void UpdateItemTests(string input, string output)
        {
            UpdateItem(input).ShouldBe(output);
        }

        [Fact]
        public void QualityDegratesEveryDay()
        {
            var inventoryLine = new InventoryLine() { Quality = 1 };
            inventoryLine.PerformDailyUpdate();
            inventoryLine.Quality.ShouldBe(0);
        }

        private string UpdateItem(string input)
        {
            var inventoryLine = ParseInventoryLine(input);
            inventoryLine.Quality++;
            inventoryLine.SellIn--;
            return $"{inventoryLine.ProductName} {inventoryLine.SellIn} {inventoryLine.Quality}";
        }

        private InventoryLine ParseInventoryLine(string input)
        {
            var inventoryLine = new InventoryLine();
            var inputSplitReversed = input.Split(' ').Reverse();
            inventoryLine.ProductName = string.Join(" ", inputSplitReversed.Skip(2).Reverse().ToArray());
            inventoryLine.SellIn = int.Parse(inputSplitReversed.ElementAt(1));
            inventoryLine.Quality = int.Parse(inputSplitReversed.ElementAt(0));
            return inventoryLine;
        }

        public class InventoryLine
        {
            public string ProductName { get; set; }
            public int SellIn { get; set; }
            public int Quality { get; set; }

            internal void PerformDailyUpdate()
            {
                Quality--;
            }
        }

    }
}

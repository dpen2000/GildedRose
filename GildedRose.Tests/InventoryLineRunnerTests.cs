using GildedRose.Console;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class InventoryLineRunnerTests
    {
        [Fact]
        public void CanHandleListOfInventoryLines_AndProduceCorrectOutput()
        {
            var inventoryLineRunner = new InventoryLineRunner();
            var testInput = @"Aged Brie 1 1
Backstage passes -1 2
Backstage passes 9 2
Sulfuras 2 2
Normal Item -1 55
Normal Item 2 2
INVALID ITEM 2 2
Conjured 2 2
Conjured -1 5";
            var output = inventoryLineRunner.UpdateAllLines(testInput);
            output.ShouldBe(@"Aged Brie 0 2
Backstage passes -2 0
Backstage passes 8 4
Sulfuras 2 2
Normal Item -2 50
Normal Item 1 1
NO SUCH ITEM
Conjured 1 0
Conjured -2 1");
        }
    }
}

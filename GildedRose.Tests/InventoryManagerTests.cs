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

        private string UpdateItem(string input)
        {
            throw new NotImplementedException();
        }
    }
}

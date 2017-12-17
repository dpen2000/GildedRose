using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests
{
    public class InventoryLineManager
    {
        public void PerformDailyUpdate(InventoryLine inventoryLine)
        {
            if (inventoryLine.ItemName == "Sulfuras") return;

            var previousQuality = inventoryLine.Quality;
            if (inventoryLine.ItemName == "Aged Brie")
            {
                inventoryLine.Quality++;
            }
            else if (inventoryLine.ItemName == "Backstage passes")
            {
                if (inventoryLine.SellIn < 0)
                {
                    inventoryLine.Quality = 0;
                }
                else if (inventoryLine.SellIn <= 5)
                {
                    inventoryLine.Quality = inventoryLine.Quality + 3;
                }
                else if (inventoryLine.SellIn <= 10)
                {
                    inventoryLine.Quality = inventoryLine.Quality + 2;
                }
            }
            else if (inventoryLine.SellIn <= 0)
            {
                if (inventoryLine.ItemName == "Conjured")
                {
                    inventoryLine.Quality = inventoryLine.Quality - 4;
                }
                else
                {
                    inventoryLine.Quality = inventoryLine.Quality - 2;
                }
            }
            else
            {
                if (inventoryLine.ItemName == "Conjured")
                {
                    inventoryLine.Quality = inventoryLine.Quality - 2;
                }
                else
                {
                    inventoryLine.Quality--;
                }
            }

            if (inventoryLine.Quality < 0)
            {
                inventoryLine.Quality = previousQuality;
            }

            if (inventoryLine.Quality > 50)
            {
                inventoryLine.Quality = 50;
            }

            inventoryLine.SellIn--;
        }
    }
}

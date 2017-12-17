using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.InventoryLineUpdaters
{
    public class BackstagePassInventoryLineUpdater : IInventoryLineUpdater
    {
        public void UpdateInventoryLine(InventoryLine inventoryLine)
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

            inventoryLine.SellIn--;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests
{
    public class GenericInventoryLineUpdater : IInventoryLineUpdater
    {
        public void UpdateInventoryLine(InventoryLine inventoryLine)
        {
            if (inventoryLine.SellIn <= 0)
            {
                inventoryLine.Quality = inventoryLine.Quality - 2;
            }
            else
            {
                inventoryLine.Quality--;
            }
            inventoryLine.SellIn--;
        }
    }
}

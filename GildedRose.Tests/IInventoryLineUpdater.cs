using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests
{
    public interface IInventoryLineUpdater
    {
        void UpdateInventoryLine(InventoryLine inventoryLine);
    }
}

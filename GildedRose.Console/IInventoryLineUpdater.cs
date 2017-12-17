using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public interface IInventoryLineUpdater
    {
        void UpdateInventoryLine(InventoryLine inventoryLine);
    }
}

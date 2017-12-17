using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests
{
    public class InventoryLineManager
    {
        private Dictionary<string, IInventoryLineUpdater> _itemNameToUpdatorDictionary;
        public InventoryLineManager(Dictionary<string, IInventoryLineUpdater> itemNameToUpdatorDictionary)
        {
            _itemNameToUpdatorDictionary = itemNameToUpdatorDictionary;
        }

        public void PerformDailyUpdate(InventoryLine inventoryLine)
        {
            if (_itemNameToUpdatorDictionary.ContainsKey(inventoryLine.ItemName))
            {
                _itemNameToUpdatorDictionary[inventoryLine.ItemName].UpdateInventoryLine(inventoryLine);
                EnsureQualityLimits(inventoryLine);
                return;
            }
        }

        private static void EnsureQualityLimits(InventoryLine inventoryLine)
        {
            if (inventoryLine.Quality < 0)
            {
                inventoryLine.Quality = 0;
            }

            if (inventoryLine.Quality > 50)
            {
                inventoryLine.Quality = 50;
            }
        }
    }
}

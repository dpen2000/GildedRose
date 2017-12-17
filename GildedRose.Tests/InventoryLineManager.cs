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
            if (inventoryLine.ItemName != "Sulfuras")
            {
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
                }
                else
                {
                    if (inventoryLine.ItemName == "Conjured")
                    {
                        inventoryLine.Quality = inventoryLine.Quality - 2;
                    }
                }

                inventoryLine.SellIn--;
            }

            EnsureQualityLimits(inventoryLine);
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

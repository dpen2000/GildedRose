using GildedRose.Console.InventoryLineUpdaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class InventoryLineManagerFactory
    {
        public static InventoryLineManager GetWithUpdatersConfigured()
        {
            return new InventoryLineManager(new Dictionary<string, IInventoryLineUpdater>
            {
                {"Normal Item", new GenericInventoryLineUpdater(sellInAdjustment:-1,
                beforeSellInQualityAdjustment: -1,
                afterSellInQualityAdjustment: -2) },
                {"Aged Brie", new GenericInventoryLineUpdater(sellInAdjustment:-1,
                beforeSellInQualityAdjustment: 1,
                afterSellInQualityAdjustment: 1) },
                {"Conjured", new GenericInventoryLineUpdater(sellInAdjustment:-1,
                beforeSellInQualityAdjustment: -2,
                afterSellInQualityAdjustment: -4) },
                {"Sulfuras", new GenericInventoryLineUpdater(sellInAdjustment:0,
                beforeSellInQualityAdjustment: 0,
                afterSellInQualityAdjustment: 0) },
                {"Backstage passes", new BackstagePassInventoryLineUpdater() }
            });
        }
    }
}

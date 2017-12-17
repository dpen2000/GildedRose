using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.InventoryLineUpdaters
{
    public class GenericInventoryLineUpdater : IInventoryLineUpdater
    {
        private readonly int _sellInAdjustment;
        private readonly int _beforeSellInQualityAdjustment;
        private readonly int _afterSellInQualityAdjustment;

        public GenericInventoryLineUpdater(int sellInAdjustment,
            int beforeSellInQualityAdjustment,
            int afterSellInQualityAdjustment)
        {
            _sellInAdjustment = sellInAdjustment;
            _beforeSellInQualityAdjustment = beforeSellInQualityAdjustment;
            _afterSellInQualityAdjustment = afterSellInQualityAdjustment;
        }
        public void UpdateInventoryLine(InventoryLine inventoryLine)
        {
            if (inventoryLine.SellIn <= 0)
            {
                inventoryLine.Quality = inventoryLine.Quality + _afterSellInQualityAdjustment;
            }
            else
            {
                inventoryLine.Quality = inventoryLine.Quality + _beforeSellInQualityAdjustment;
            }
            inventoryLine.SellIn = inventoryLine.SellIn + _sellInAdjustment;
        }
    }
}

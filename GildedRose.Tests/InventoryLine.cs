namespace GildedRose.Tests
{
    public class InventoryLine
    {
        public int Quality { get; set; }
        public int SellIn { get; set; }
        public string ItemName { get; set; }

        internal void PerformDailyUpdate()
        {
            if (ItemName == "Sulfuras") return;

            var previousQuality = Quality;
            if (ItemName == "Aged Brie")
            {
                Quality++;
            }
            else if (ItemName == "Backstage Passes")
            {
                if (SellIn < 0)
                {
                    Quality = 0;
                }
                else if (SellIn <= 5)
                {
                    Quality = Quality + 3;
                }
                else if (SellIn <= 10)
                {
                    Quality = Quality + 2;
                }
            }
            else if (SellIn <= 0)
            {
                if (ItemName == "Conjured")
                {
                    Quality = Quality - 4;
                }
                else
                {
                    Quality = Quality - 2;
                }
            }
            else
            {
                if (ItemName == "Conjured")
                {
                    Quality = Quality - 2;
                }
                else
                {
                    Quality--;
                }
            }

            if (Quality < 0)
            {
                Quality = previousQuality;
            }

            if (Quality > 50)
            {
                Quality = 50;
            }

            SellIn--;
        }
    }
}

using System;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class InventoryLineRunner
    {
        public string UpdateAllLines(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var parsedInventoryLines = lines.Select(ParseInventoryLine).ToList();
            var inventoryLineManager = InventoryLineManagerFactory.GetWithUpdatersConfigured();
            foreach (var parsedInventoryLine in parsedInventoryLines)
            {
                inventoryLineManager.PerformDailyUpdate(parsedInventoryLine);
                if (parsedInventoryLine.NoSuchItem)
                {
                    stringBuilder.AppendLine("NO SUCH ITEM");
                }
                else
                {
                    var outputLine = $"{parsedInventoryLine.ItemName} {parsedInventoryLine.SellIn} {parsedInventoryLine.Quality}";
                    stringBuilder.AppendLine(outputLine);
                }
            }
            return stringBuilder.ToString().TrimEnd();
        }

        private InventoryLine ParseInventoryLine(string input)
        {
            var inventoryLine = new InventoryLine();
            var inputSplitReversed = input.Split(' ').Reverse();
            inventoryLine.ItemName = string.Join(" ", inputSplitReversed.Skip(2).Reverse().ToArray());
            inventoryLine.SellIn = int.Parse(inputSplitReversed.ElementAt(1));
            inventoryLine.Quality = int.Parse(inputSplitReversed.ElementAt(0));
            return inventoryLine;
        }
    }
}
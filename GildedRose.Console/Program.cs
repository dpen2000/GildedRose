using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args.FirstOrDefault();
            if (path == null || !File.Exists(path))
            {
                System.Console.WriteLine(@"Please pass path to input file (that exists) as argument like '.\GildedRose.Console.exe TestInput.txt'");
                return;
            }
            var inputFileText = File.ReadAllText(path);
            var inventoryLineRunner = new InventoryLineRunner();
            var output = inventoryLineRunner.UpdateAllLines(inputFileText);
            File.WriteAllText("output.txt", output);
            System.Console.WriteLine("Output written to output.txt file.");
        }
    }
}

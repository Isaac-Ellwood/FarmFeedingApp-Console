using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FarmFeedingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates livestock manager
            LivestockManager livestockManager = new LivestockManager();

            // Test previously saved data
            //int sIndex = Int32.Parse(Console.ReadLine());
            //int bIndex = Int32.Parse(Console.ReadLine());
            //Console.WriteLine(livestockManager.GetSpeciesList()[sIndex]);
            //Console.WriteLine(livestockManager.GetBreedsList()[sIndex][bIndex]);

            // Test data
            int species = 1;
            int breed = 4;
            string ID = $"{species}{breed}#{livestockManager.GetLivestockHoldersLength()}";
            LivestockHolder livestockHolder = new LivestockHolder(species, breed, ID);
            livestockHolder.foodQuantity = new List<float>() {100f, 89.56f, 87.66f, 90f , 23f, 78f, 64.9f, 78.9f};
            livestockHolder.foodType = new List<int>() { 0, 0, 1, 0, 0, 1, 0, 1};
            livestockHolder.dates = new List<DateTime>() {new DateTime(2023,12,8)};
            // Adds to livestock holder
            livestockManager.AddLivestockHolder(livestockHolder);

            // Serialises and saves save data
            livestockManager.SerialiseSaveData();
        }
    }
}

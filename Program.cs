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

            // Serialises and saves save data
            livestockManager.SerialiseSaveData();

            // Test previously saved data
            //int sIndex = Int32.Parse(Console.ReadLine());
            //int bIndex = Int32.Parse(Console.ReadLine());
            //Console.WriteLine(livestockManager.GetSpeciesList()[sIndex]);
            //Console.WriteLine(livestockManager.GetBreedsList()[sIndex][bIndex]);

            // Test data
            int species = 0;
            int breed = 0;
            string ID = "0000001";
            LivestockHolder livestockHolder = new LivestockHolder(species, breed, ID);

            livestockManager.AddLivestockHolder(livestockHolder);

            Console.WriteLine("Hello World!");
        }
    }
}

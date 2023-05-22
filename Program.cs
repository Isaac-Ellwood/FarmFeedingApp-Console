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
            int breed = 0;
            string ID = "0000020";
            LivestockHolder livestockHolder = new LivestockHolder(species, breed, ID);

            for (int i = 0; i < 1000000000; i++)
            {
                livestockManager.AddLivestockHolder(livestockHolder);
            }

            // Serialises and saves save data
            livestockManager.SerialiseSaveData();

            Console.WriteLine("Hello World!");
        }
    }
}

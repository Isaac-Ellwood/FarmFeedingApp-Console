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
            bool flag = true;
            while (flag)
            {
                // Species
                for (int i = 0; i < livestockManager.GetSpeciesList().Count; i++)
                {
                    Console.WriteLine($"{i}.{livestockManager.GetSpeciesList()[i]}");
                }
                int species = int.Parse(Console.ReadLine());

                // Breed
                for (int i = 0; i < livestockManager.GetBreedsList()[species].Count; i++)
                {
                    Console.WriteLine($"{i}.{livestockManager.GetBreedsList()[species][i]}");
                }
                int breed = int.Parse(Console.ReadLine());

                //
                string ID = $"{species}{breed}#{livestockManager.GetLivestockHoldersLength()}";
                LivestockHolder livestockHolder = new LivestockHolder(species, breed, ID);
                livestockHolder.foodQuantity = new List<float>() { 100f, 89.56f, 87.66f, 90f, 23f, 78f, 64.9f, 78.9f };
                livestockHolder.foodType = new List<int>() { 0, 0, 1, 0, 0, 1, 0, 1 };
                livestockHolder.dates = new List<DateTime>() { new DateTime(2023, 12, 8), new DateTime(2023, 12, 9), new DateTime(2023, 12, 10), new DateTime(2023, 12, 11), new DateTime(2023, 12, 12), new DateTime(2023, 12, 13), new DateTime(2023, 12, 14), new DateTime(2023, 12, 15) };

                // Adds to livestock holder
                livestockManager.AddLivestockHolder(livestockHolder);

                Console.WriteLine(livestockManager.foodHistory(livestockManager.GetLivestockHoldersLength() - 1, 7));

                Console.WriteLine("0. Continue\n" +
                    "1. Exit");
                int cont = int.Parse(Console.ReadLine());
                if (cont == 1)
                {
                    flag = false;
                }
            }
            

            // Serialises and saves save data
            livestockManager.SerialiseSaveData();
        }
    }
}

using System;
using System.Collections.Generic;

namespace FarmFeedingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates livestock manager
            LivestockManager livestockManager = new LivestockManager();

            // Sets lists with test data
            List<string> species = new List<string>();
            List<string> breeds = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                species.Add("s");
                breeds.Add("b");
            }

            livestockManager.SetSpeciesList(species);
            livestockManager.SetBreedList(breeds);

            // Serialises and saves save data
            livestockManager.SerialiseSaveData();

            Console.WriteLine("Hello World!");
        }
    }
}

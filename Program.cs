using System;

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

            Console.WriteLine("Hello World!");
        }
    }
}

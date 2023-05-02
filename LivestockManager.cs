using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFeedingApp
{
    class LivestockManager
    {
        // Attributes
        List<LivestockHolder> livestockHolders = new List<LivestockHolder>();

        // Constructs a Livestock Manager object
        public LivestockManager()
        {

        }

        public List<string> BreedsList(string species)
        {
            List<string> breeds = new List<string>();
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"\\{species}Breeds.txt");
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            directory = directory.Replace("\bin\Debug\net5.0", String.Empty);
            var path2 = Path.Combine(directory, $"{species}Breeds.txt");
            Console.WriteLine(path);
            Console.WriteLine(path2);
            foreach (string line in File.ReadLines(path2, Encoding.UTF8))
            {
                // process the line
                breeds.Add(line);
            }

            return breeds;
        }

    }
}

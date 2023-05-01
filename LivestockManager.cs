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
            foreach (string line in File.ReadLines(@"c:\SheepBreeds.txt", Encoding.UTF8))
            {
                // process the line
                breeds.Add(line);
            }

            return breeds;
        }

    }
}

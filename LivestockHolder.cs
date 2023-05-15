using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFeedingApp
{
    public class LivestockHolder
    {
        // Attributes
        private int species;
        private int breed;
        private string ID;
        private List<DateTime> dates = new List<DateTime>();
        private List<int> foodQuantities = new List<int>();

        
        // Constructs a LivestockHolder object and assigns attributes
        public LivestockHolder(int species, int breed, string ID)
        {
            this.species = species;
            this.breed = breed;
            this.ID = ID;
        }
    }
}

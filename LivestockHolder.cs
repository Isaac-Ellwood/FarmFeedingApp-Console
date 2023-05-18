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
        public int species;
        public int breed;
        public string ID;
        public List<float> foodQuantity = new List<float>();
        public List<int> foodType = new List<int>();
        public List<DateTime> dates = new List<DateTime>();


        // Constructs a LivestockHolder object and assigns attributes
        public LivestockHolder(int species, int breed, string ID)
        {
            this.species = species;
            this.breed = breed;
            this.ID = ID;
        }
    }
}

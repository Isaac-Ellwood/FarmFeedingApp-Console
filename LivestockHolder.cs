using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFeedingApp
{
    class LivestockHolder
    {
        // Attributes
        private string species;
        private string breed;
        private string ID;
        
        // Constructs a LivestockHolder object and assigns attributes
        public LivestockHolder(string species, string breed, string ID)
        {
            this.species = species;
            this.breed = breed;
            this.ID = ID;
        }
    }
}

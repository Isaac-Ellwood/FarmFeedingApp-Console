using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFeedingApp
{
    public class SaveData
    {
        // Attributes (things to save between sessions)
        public List<string> sList { get; set; }
        public List<List<string>> bList { get; set; }
        List<LivestockHolder> lHolders = new List<LivestockHolder>();
        public LivestockHolder lHolders { get; set; }
    }
}

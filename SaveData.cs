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
        public List<string> fList { get; set; }
        public List<float> fPriceList { get; set; }
        public List<string> sList { get; set; }
        public List<List<string>> bList { get; set; }

        // LivestockHolders data
        public List<int> lHoldersSpecies { get; set; }
        public List<int> lHoldersBreed { get; set; }
        public List<string> lHoldersID { get; set; }
        // 2D lists
        public List<List<float>> fQuantityListList { get; set; }
        public List<List<int>> fTypeListList { get; set; }
        public List<List<DateTime>> fDateListList { get; set; }
    }
}

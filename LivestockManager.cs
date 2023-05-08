using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace FarmFeedingApp
{
    class LivestockManager
    {
        // Attributes
        List<LivestockHolder> livestockHolders = new List<LivestockHolder>();

        List<string> speciesList = new List<string>();
        List<List<string>> breedsList = new List<List<string>>();

        // Constructs a Livestock Manager object
        public LivestockManager()
        {
            // Either deserialises save data or sets data to defaults
            try
            {
                // Deserialises Save Data
                string fileName = "SaveData.json";
                string jsonString = File.ReadAllText(fileName);
                SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonString)!;

                speciesList = saveData.sList;
                breedsList = saveData.bList;
            }
            catch
            {
                // Sets lists with default data
                speciesList = new List<string>()
                {
                    "Cows",
                    "Sheep"
                };

                breedsList = new List<List<string>>()
                {
                    new List<string>()
                    {
                        "Cow 1",
                        "Cow 2"
                    },
                    new List<string>()
                    {
                        "Sheep 1",
                        "Sheep 2"
                    }
                };
            }
        }

        // Returns species list
        public List<string> GetSpeciesList()
        {
            return speciesList;
        }

        // Sets species list
        public void SetSpeciesList(List<string> speciesList)
        {
            this.speciesList = speciesList;
        }
        
        // Returns list of breed list
        public List<List<string>> GetBreedsList()
        {
            return breedsList;
        }

        // Sets breed list
        public void SetBreedsList(List<List<string>> breedsList)
        {
            this.breedsList = breedsList;
        }

        // Serialises and saves save data
        public void SerialiseSaveData()
        {
            // Declares new SaveData and sets it
            var saveData = new SaveData
            {
                sList = speciesList,
                bList = breedsList
            };

            // Serialises data and saves to \bin\Debug\net5.0
            string fileName = "SaveData.json";
            string jsonString = JsonSerializer.Serialize(saveData);
            File.WriteAllText(fileName, jsonString);
        }
    }
}

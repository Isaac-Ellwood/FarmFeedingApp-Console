﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace FarmFeedingApp
{
    public class SaveData
    {
        // Attributes (things to save between sessions)
        public List<string> sList { get; set; }
        public List<string> bList { get; set; }
    }

    class LivestockManager
    {
        // Attributes
        List<LivestockHolder> livestockHolders = new List<LivestockHolder>();

        List<string> speciesList = new List<string>();
        List<string> breedList = new List<string>();

        // Constructs a Livestock Manager object
        public LivestockManager()
        {
            
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
        public List<string> GetBreedList()
        {
            return breedList;
        }

        // Sets breed list
        public void SetBreedList(List<string> breedList)
        {
            this.breedList = breedList;
        }

        // Serialises and saves save data
        public void SerialiseSaveData()
        {
            // Declares new SaveData and sets it
            var saveData = new SaveData
            {
                sList = speciesList,
                bList = breedList
            };

            // Serialises data and saves to \bin\Debug\net5.0
            string fileName = "SaveData.json";
            string jsonString = JsonSerializer.Serialize(saveData);
            File.WriteAllText(fileName, jsonString);
        }
    }
}

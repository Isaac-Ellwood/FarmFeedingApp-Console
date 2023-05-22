﻿using System;
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

        List<string> foods = new List<string>();
        List<float> foodPrices = new List<float>();
        List<string> speciesList = new List<string>();
        List<List<string>> breedsList = new List<List<string>>();

        // Constructs a Livestock Manager object
        public LivestockManager()
        {
            // Either deserialises save data or sets data to defaults
            try
            {
                DeserialiseSaveData();
            }
            catch
            {
                Console.WriteLine("Failed");
                // Sets lists with default data
                speciesList = new List<string>()
                {
                    "Cows (dairy)",
                    "Cows (beef)",
                    "Sheep"
                };

                breedsList = new List<List<string>>()
                {
                    // Cows (dairy) breeds
                    new List<string>()
                    {
                        "Cow 1",
                        "Cow 2"
                    },
                    // Cows (beef) breeds
                    new List<string>()
                    {
                        "Cow 1",
                        "Cow 2"
                    },
                    // Sheep breeds
                    new List<string>()
                    {
                        "Sheep 1",
                        "Sheep 2"
                    }
                };
            }
        }

        // Adds a livestock holder into livestockHolders list
        public void AddLivestockHolder(LivestockHolder livestockHolder)
        {
            livestockHolders.Add(livestockHolder);
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

        // Deserialises and sets save data
        public void DeserialiseSaveData()
        {
            // Deserialises Save Data
            string fileName = "SaveData.json";
            string jsonString = File.ReadAllText(fileName);
            SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonString)!;


            // Sorts livestockHolders list into a serialisable format

            // Makes lots of lists
            // 2d lists
            for (int i = 0; i < saveData.lHoldersID.Count; i++)
            {
                // Creates livestockholder and adds it to livestock holder list
                LivestockHolder livestockHolder = new LivestockHolder(saveData.lHoldersSpecies[i], saveData.lHoldersBreed[i], saveData.lHoldersID[i]);
                AddLivestockHolder(livestockHolder);
                // Pulls livestock data from 2d lists (prone to fails, so in try catch statements for now)
                try
                {
                    livestockHolders[livestockHolders.Count - 1].foodQuantity = saveData.fQuantityListList[i];
                }
                catch { }
                try
                {
                    livestockHolders[livestockHolders.Count - 1].foodType = saveData.fTypeListList[i];
                }
                catch{}
                try
                {
                    livestockHolders[livestockHolders.Count - 1].dates = saveData.fDateListList[i];
                }
                catch { }
            }

            // Sets lists with deserialised data
            foods = saveData.fList;
            foodPrices = saveData.fPriceList;
            speciesList = saveData.sList;
            breedsList = saveData.bList;
        }
        
        // Serialises and saves save data
        public void SerialiseSaveData()
        {
            // Sorts livestockHolders list into a serialisable format

            // Makes lots of lists
            List<int> livestockHoldersSpecies = new List<int>();
            List<int> livestockHoldersBreed = new List<int>();
            List<string> livestockHoldersID = new List<string>();
            // 2d lists
            List<List<float>> foodQuantityListList = new List<List<float>>();
            List<List<int>> foodTypeListList = new List<List<int>>();
            List<List<DateTime>> datesListList = new List<List<DateTime>>();

            for (int i = 0; i < livestockHolders.Count; i++)
            {
                // Adds livestock data to lists
                livestockHoldersSpecies.Add(livestockHolders[i].species);
                livestockHoldersBreed.Add(livestockHolders[i].breed);
                livestockHoldersID.Add(livestockHolders[i].ID);

                // Adds livestock data to 2d lists
                for (int listIndex = 0; listIndex < livestockHolders[i].foodQuantity.Count; listIndex++)
                {
                    foodQuantityListList[i][listIndex] = livestockHolders[i].foodQuantity[listIndex];
                }

                for (int listIndex = 0; listIndex < livestockHolders[i].foodType.Count; listIndex++)
                {
                    foodTypeListList[i][listIndex] = livestockHolders[i].foodType[listIndex];
                }

                for (int listIndex = 0; listIndex < livestockHolders[i].dates.Count; listIndex++)
                {
                    datesListList[i][listIndex] = livestockHolders[i].dates[listIndex];
                }
            }

            // Declares new SaveData and sets it
            var saveData = new SaveData
            {
                fList = foods,
                fPriceList = foodPrices,
                sList = speciesList,
                bList = breedsList,
                lHoldersSpecies = livestockHoldersSpecies,
                lHoldersBreed = livestockHoldersBreed,
                lHoldersID = livestockHoldersID,
                fQuantityListList = foodQuantityListList,
                fTypeListList = foodTypeListList,
                fDateListList = datesListList
            };

            // Serialises data and saves to \bin\Debug\net5.0
            string fileName = "SaveData.json";
            string jsonString = JsonSerializer.Serialize(saveData);
            File.WriteAllText(fileName, jsonString);
        }
    }
}

using AdultsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdultsWebAPI.Data
{
    public class FamilyManager : IFamilyManager
    {
        public string adultFile = "adults.json";
        private IList<Adult> adults;

        public FamilyManager()
        {
            if (!File.Exists(adultFile))
            {
                Seed();
                WriteAdultsToFile();

            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }
        public void Seed()
        {
            Adult[] ad =
            {
                new Adult
                {
                    Id= 1,
                    FirstName = "Lenka",
                    LastName = "Orincakova",
                    HairColor ="brown",
                    EyeColor="brown",
                    Age= 20,
                    Weight = 57,
                    Height=159,
                    Sex="Female"
                },
                new Adult
                {
                    Id= 2,
                    FirstName = "Simona",
                    LastName = "Orincakova",
                    HairColor ="brown",
                    EyeColor="brown",
                    Age= 22,
                    Weight = 56,
                    Height=159,
                    Sex="Female"
                }
            };
            adults = ad.ToList();

        }
        public async Task<Adult> AddAdultToFamilyAsync(Adult adultToAdd)
        {
            int max = adults.Max(adult => adult.Id);
            adultToAdd.Id = (++max);
            adults.Add(adultToAdd);
            WriteAdultsToFile();
            return adultToAdd;

        }
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> adl = new List<Adult>(adults);
            return adl;
        }
        public async Task RemoveAdultAsync(int id)
        {
            Adult toRemove = adults.First(p => p.Id == id);
            adults.Remove(toRemove);
            WriteAdultsToFile();
        }

        private void WriteAdultsToFile()
        {
            string productAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, productAsJson);
        }
        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Adult toUpdate = adults.First(p => p.Id == adult.Id);
            WriteAdultsToFile();
            return toUpdate;
        }



    }
}

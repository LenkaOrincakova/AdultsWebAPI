using AdultsWebAPI.Models;
using AdultsWebAPI.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdultsWebAPI.Data
{
    public class FamilyManager :IFamilyManager
    {


        private string adultsFile = "adults.json";
        private readonly FileContext familyFileHandler;
        private IList<Adult> adults;
        public FamilyManager()
        {

            if (!File.Exists(adultsFile))
            {
                Seed();
                WriteAdultsToFile();
            }
            else
            {
                string content = File.ReadAllText(adultsFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }

            //familyFileHandler = new FileContext();
        }


        public async Task<Adult> AddAdultToFamilyAsync(Adult adultToAdd)
        {
            int max = adults.Max(adultToAdd => adultToAdd.Id);
            adultToAdd.Id = (++max);
            adults.Add(adultToAdd);
            WriteAdultsToFile();
            return adultToAdd;
            //IList<Adult> adults = familyFileHandler.Adults;

            //int maxId = adults.Any() ? adults.Max(a => a.Id) : 0;

           // if (adults.Any(a => a.Equals(adultToAdd)))
             //   throw new Exception($"{adultToAdd.FirstName} {adultToAdd.LastName} not load");
            //adultToAdd.Id = ++maxId;
            //adults.Add(adultToAdd);
            //familyFileHandler.SaveChanges();
            //return adultToAdd;

        }


        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> tmp = new List<Adult>(adults);
           // IList<Adult> adults = familyFileHandler.Adults;
            return tmp;
        }

        public async Task RemoveAdultAsync(int id)//Adult adult)
        {
            Adult toRemove = adults.First(t => t.Id == id);
            adults.Remove(toRemove);
            WriteAdultsToFile();
            //IList<Adult> adults = familyFileHandler.Adults;

            //if (adults.Contains(adult))
            //{
              //  adults.Remove(adult);
                //familyFileHandler.SaveChanges();

            //}
        }
        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Adult toUpdate = adults.FirstOrDefault(t => t.Id == adult.Id);
            if (toUpdate == null) throw new Exception($"Did not find adult with id:{adult.Id}");
            WriteAdultsToFile();
            return toUpdate;
        }

       private void WriteAdultsToFile()
        {
            string productAsJson = JsonSerializer.Serialize(adults);
        }
        private void Seed()
        {
            Adult[] ts =
            {
                new Adult
                {
                    Id=1,
                    FirstName = "Lula",
                    LastName = "Orincakova",
                    HairColor = "brown",
                    EyeColor = "brown",
                    Age = 21,
                    Weight = 58,
                    Height = 160,
                    Sex = "F"
                },
            };
            adults = ts.ToList();
        }

        //private IList<Adult> CollectAdults(IList<Family> families)
        //  {
        //  IList<Adult> adults = new List<Adult>();
        //  foreach (var family in families)
        //  {
        //     foreach (var adult in family.Adults)
        //     {
        //        adults.Add(adult);
        //    }
        //  }
        //    return adults;
        // }

        //----Family----
        /*public bool AddFamily(Family toAdd)
        {
            IList<Family> families = familyFileHandler.Families;
            int max = families.Any() ? families.Max(f => f.Id) : 0;
            toAdd.Id = ++max;
            int same = families.Where(f => (f.Id == toAdd.Id || (f.HouseNumber == toAdd.HouseNumber && f.StreetName == toAdd.StreetName))).Count();
            if (same < 1)
            {
                families.Add(toAdd);
                familyFileHandler.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Already exists");
            }
                    //families.Add(family);
            //WriteFamiliesToFile();
        }
        public IList<Family> GetFamilies()
        {
            return familyFileHandler.Families;
        }
        public bool RemoveFamily(Family toRemove)
        {
            bool removed = familyFileHandler.Families.Remove(toRemove);
            if(removed)
            {
                familyFileHandler.SaveChanges();
        }
            return removed;
      
        }
        */
        /*public void UpdateFamily(Family family)
     {
         Family toUpdate = families.First(t => t.HouseNumber == family.HouseNumber);
         WriteFamiliesToFile();
     }
     */
    }
}
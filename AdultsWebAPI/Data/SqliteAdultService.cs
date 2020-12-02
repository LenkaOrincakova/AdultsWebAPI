using AdultsWebAPI.DataAccess;
using AdultsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdultsWebAPI.Data
{
    public class SqliteAdultService : IFamilyManager
    {
        private AdultsDBContext adc;
        public SqliteAdultService (AdultsDBContext adc)
        {
            this.adc = adc;
        }
        public async Task<Adult> AddAdultToFamilyAsync(Adult adultToAdd)
        {   
            EntityEntry<Adult> newlyAdded = await adc.Adults.AddAsync(adultToAdd);
            await adc.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return await adc.Adults.ToListAsync();        }

        public async Task RemoveAdultAsync(int id)
        {
            Adult toDelete = await adc.Adults.FirstOrDefaultAsync(t => t.Id == id);
            if(toDelete != null)
            {
                adc.Adults.Remove(toDelete);
                await adc.SaveChangesAsync();
            }
        }


        public async Task<Adult> UpdateAsync(Adult adult)
        {
            try
            {
                Adult toUpdate = await adc.Adults.FirstAsync(t => t.Id == adult.Id);
                adc.Update(toUpdate);
                await adc.SaveChangesAsync();
                return toUpdate;
            }
            catch(Exception e)
            {
                throw new Exception($"Could not find any adult with id {adult.Id}");

            }
        }
    }
}

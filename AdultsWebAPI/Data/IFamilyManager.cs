using AdultsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdultsWebAPI.Data
{
    public interface IFamilyManager
    {
        Task<Adult> AddAdultToFamilyAsync(Adult adultToAdd);

        Task<IList<Adult>> GetAdultsAsync();
        Task RemoveAdultAsync(int id);
        Task<Adult> UpdateAsync(Adult adult);
        // IList<Family> GetFamilies();
        //  bool AddFamily(Family toAdd);
        // bool RemoveFamily(Family toRemove);
        //bool AddAdultToFamily(Adult adultToAdd);//, Family familyToJoin);
    }
}

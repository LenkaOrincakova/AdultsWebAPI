using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdultsWebAPI.Models;

namespace AdultsWebAPI.Data
{
    public interface IUserService
    {
    Task<User> ValidateUser(string userName, string passWord);
    }
}

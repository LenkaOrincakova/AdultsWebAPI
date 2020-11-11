using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdultsWebAPI.Controllers;
using AdultsWebAPI.Data;
using AdultsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdultsWebAPI.Controllers
{
    public class UserController
    {
    
        [ApiController]
        [Route("[controller]")]
        public class UsersController : ControllerBase
        {

            private readonly IUserService userService;

            public UsersController(IUserService userService)
            {
                this.userService = userService;
            }

            [HttpGet]
            public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
            {
                Console.WriteLine("Here");
                try
                {
                    var user = await userService.ValidateUser(username, password);
                    return Ok(user);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
}

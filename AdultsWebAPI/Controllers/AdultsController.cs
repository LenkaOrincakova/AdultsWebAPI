using AdultsWebAPI.Data;
using AdultsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdultsWebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    
    public class AdultsController:ControllerBase
    {
        private IFamilyManager familyManager;

        public AdultsController(IFamilyManager familyManager)
        {
            this.familyManager = familyManager;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery] int? id)
        {
            try
            {
                IList<Adult> adults = await familyManager.GetAdultsAsync();
                    return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

           }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute]  int id) //Adult adult)
        {
            try
            {
                await familyManager.RemoveAdultAsync(id); //adult);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adultToAdd)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Adult added = await familyManager.AddAdultToFamilyAsync(adultToAdd);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult)
        {
            try
            {
                Adult updatedAdult = await familyManager.UpdateAsync(adult);
                return Ok(updatedAdult);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        
        
    }
}

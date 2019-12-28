using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;

namespace CoreERP.Controllers
{
  [ApiController]
    [Route("api/ProfitCenterMaster")]
    public class ProfitCenterMasterController : ControllerBase
    {
        

        [HttpGet("masters/profitMaster")]
        public async Task<IActionResult> GetAllProfitCenters()
        {

           return Ok(new
      {
       profitCenter=ProfitCenterHelper.GetProfitCenterList()
        
           });

    }


        [HttpPost("masters/profitMaster/register")]
        public async Task<IActionResult> Register([FromBody]ProfitCenters profitCenter)
        {

            if (profitCenter == null)
                return BadRequest($"{nameof(profitCenter)} cannot be null");
          
        try
        {
          int result = ProfitCenterHelper.RegisteProfitCenter(profitCenter);
          if (result > 0)
            return Ok(profitCenter);

            }
            catch(Exception ex)
            {
                return BadRequest($"{nameof(profitCenter)} Registration Failed");
            }
      return BadRequest("Registration Failed");
    }



        [HttpPut("masters/profitMaster/{code}")]
        public async Task<IActionResult> UpdateProfit(string code, [FromBody] ProfitCenters profitCenter)
        {
            if (profitCenter == null)
                return BadRequest($"{nameof(profitCenter)} cannot be null");
            try
            {
        if (profitCenter == null)
          return BadRequest($"{nameof(profitCenter)} cannot be null");

        int rs = ProfitCenterHelper.UpdateProfitCenter(profitCenter);
        if (rs > 0)
          return Ok(profitCenter);

      }
      catch { throw; }
      return BadRequest($"{nameof(profitCenter)} Updation Failed");
    }


        // Delete Branch
        [HttpDelete("masters/profitMaster/{code}")]
        public async Task<IActionResult> DeleteProfit(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

          
            try
            {
        if (string.IsNullOrWhiteSpace(code))
          return BadRequest($"{nameof(code)} cannot be null");

        int result = ProfitCenterHelper.DeleteProfitCenter(code);
        if (result > 0)
          return Ok(code);

      }
      catch { throw; }
      return BadRequest("Deletion Failed");
    }
    }
}

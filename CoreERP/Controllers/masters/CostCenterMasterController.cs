using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/CostCenterMaster")]
    public class CostCenterMasterController : ControllerBase
    {
        

        [HttpGet("masters/costCenter")]
        public async Task<IActionResult> GetAllCostCenters()
        {
      return Ok(
          new
          {
            costCenter = CostCenterHelper.GetCostCenterList()

          });
    }


        [HttpPost("masters/costCenter/register")]
        public async Task<IActionResult> Register([FromBody]CostCenters costCenter)
        {
          
            if (costCenter == null)
                return BadRequest($"{nameof(costCenter)} cannot be null");
           try
            {
                 int result = CostCenterHelper.RegisterCostCenter(costCenter);
                if(result > 0)
                return Ok(costCenter);
                
            }
      catch
            {
            }
      return BadRequest("Registration Failed");
    }



        [HttpPut("masters/costCenter/{code}")]
        public async Task<IActionResult> UpdateCostCenter(string code, [FromBody] CostCenters costCenter)
        {
            if (costCenter == null)
                return BadRequest($"{nameof(costCenter)} cannot be null");
            try
            {
                if (costCenter == null)
                    return BadRequest($"{nameof(costCenter)} cannot be null");

                int rs = CostCenterHelper.UpdateCostCenter(costCenter);
                if (rs > 0)
                    return Ok(costCenter);
                    
            }
           catch { throw; }
           return BadRequest($"{nameof(costCenter)} Updation Failed");
        }


        // Delete CostCenter
        [HttpDelete("masters/costCenter/{code}")]
        public async Task<IActionResult> DeleteCostCenter(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

           
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                    return BadRequest($"{nameof(code)} cannot be null");

                int result =CostCenterHelper.DeleteCostCenter(code);
                if(result > 0)
                        return Ok(code);
            }
            catch { }
            return BadRequest("Deletion Failed");
        }
    }
}

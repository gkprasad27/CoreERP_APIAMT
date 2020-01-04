using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using System.Dynamic;
using CoreERP.DataAccess;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/CostCenterMaster")]
    public class CostCenterMasterController : ControllerBase
    {
        

        [HttpGet("GetCostCenterList")]
        public async Task<IActionResult> GetCostCenterList()
        {
            try
            {
                var costcenterList = CostCenterHelper.GetCostCenterList();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.costcenterList = costcenterList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch 
            { 
                return BadRequest("No Data  Found");  
            }
    }


        [HttpPost("RegisterCostCenter")]
        public async Task<IActionResult> RegisterCostCenter([FromBody]CostCenters costCenter)
        {
            APIResponse apiResponse = null;
            if (costCenter == null)
                return BadRequest($"{nameof(costCenter)} cannot be null");
            try
            {
                int result = CostCenterHelper.RegisterCostCenter(costCenter);
                if (result > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

                return Ok(apiResponse);
            }
            catch
            {
            }
      return BadRequest("Registration Failed");
    }



        [HttpPut("UpdateCostCenter/{code}")]
        public async Task<IActionResult> UpdateCostCenter(string code, [FromBody] CostCenters costCenter)
        {
            APIResponse apiResponse = null;
            if (costCenter == null)
                return BadRequest($"{nameof(costCenter)} cannot be null");
            try
            {
                if (costCenter == null)
                    return BadRequest($"{nameof(costCenter)} cannot be null");

                int rs = CostCenterHelper.UpdateCostCenter(costCenter);
                if (rs > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);

            }
           catch { throw; }
        }


        // Delete CostCenter
        [HttpDelete("DeleteCostCenter/{code}")]
        public async Task<IActionResult> DeleteCostCenter(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

           
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                    return BadRequest($"{nameof(code)} cannot be null");

                int result =CostCenterHelper.DeleteCostCenter(code);
                if (result > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch { return BadRequest("Deletion Failed"); }
            
        }
    }
}

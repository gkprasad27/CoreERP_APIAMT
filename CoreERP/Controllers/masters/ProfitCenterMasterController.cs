using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/ProfitCenter")]
    public class ProfitCenterMasterController : ControllerBase
    {


        [HttpGet("GetProfitCenterList")]
        public async Task<IActionResult> GetProfitCenterList()
        {
            try
            {
                var profitCenterList = ProfitCenterHelper.GetProfitCenterList();
                //if (profitCenterList.Count > 0)
                //{
                    dynamic expando = new ExpandoObject();
                    expando.profitCenterList = profitCenterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                //}
                //else
                //{
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                //}
            }
            catch (Exception e)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = e.Message });
            }
        }


        [HttpPost("RegisterProfitCenters")]
        public async Task<IActionResult> RegisterProfitCenters([FromBody]ProfitCenters profitCenter)
        {

            if (profitCenter == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(profitCenter)} cannot be null" });

            try
            {
                var result = ProfitCenterHelper.RegisteProfitCenter(profitCenter);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }


        [HttpPut("UpdateProfitCenters")]
        public async Task<IActionResult> UpdateProfitCenters(string code, [FromBody] ProfitCenters profitCenter)
        {
            if (profitCenter == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(profitCenter)} cannot be null" });
            try
            {

                var result = ProfitCenterHelper.UpdateProfitCenter(profitCenter);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = profitCenter });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpDelete("DeleteProfitCenters/{code}")]
        public async Task<IActionResult> DeleteProfitCenters(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                    return BadRequest($"{nameof(code)} cannot be null");

                var result = ProfitCenterHelper.DeleteProfitCenter(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}

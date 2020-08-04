using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/TDSRates")]
    public class TDSRatesController : ControllerBase
    {

        [HttpPost("RegisterTDSRates")]
        public IActionResult RegisterTDSRates([FromBody]TblTdsRates tdsrates)
        {
            if (tdsrates == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (tdsratesHelper.GetList(tdsrates.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Incometype Code {nameof(tdsrates.Code)} is already exists ,Please Use Different Code " });

                var result = tdsratesHelper.Register(tdsrates);
                APIResponse apiResponse;
                if (result != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTDSRatesList")]
        public IActionResult GetTDSRatesList()
        {
            try
            {
                var tdsratesList = tdsratesHelper.GetList();
                if (tdsratesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.tdsratesList = tdsratesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateTDSRates")]
        public IActionResult UpdateTDSRates([FromBody] TblTdsRates tdsrates)
        {
            if (tdsrates == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(tdsrates)} cannot be null" });

            try
            {
                var rs = tdsratesHelper.Update(tdsrates);
                APIResponse apiResponse;
                if (rs != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteTDSRates/{code}")]
        public IActionResult DeleteTDSRatesByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = tdsratesHelper.Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
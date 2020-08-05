using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;


namespace CoreERP.Controllers.masters
{

    [ApiController]
    [Route("api/ChartOfAccount")]
    public class ChartOfAccountController : ControllerBase
    {
        [HttpPost("RegisterChartOfAccount")]
        public IActionResult RegisterChartOfAccount([FromBody]TblChartAccount coa)
        {
            if (coa == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (ChartofaccountHelper.GetList(coa.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Chartofaccount Code {nameof(coa.Code)} is already exists ,Please Use Different Code " });

                var result = ChartofaccountHelper.Register(coa);
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

        [HttpGet("GetChartOfAccountList")]
        public IActionResult GetChartOfAccountList()
        {
            try
            {
                var coaList = ChartofaccountHelper.GetList();
                if (coaList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.coaList = coaList;
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

        [HttpPut("UpdateChartOfAccount")]
        public IActionResult UpdateChartOfAccount([FromBody] TblChartAccount coa)
        {
            if (coa == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(coa)} cannot be null" });

            try
            {
                var rs = ChartofaccountHelper.Update(coa);
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


        [HttpDelete("DeleteChartOfAccount/{code}")]
        public IActionResult DeleteChartOfAccountID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = ChartofaccountHelper.Delete(code);
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
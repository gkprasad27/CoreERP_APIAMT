using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/AlternateControlAccount")]
    public class AlternateControlAccountController : ControllerBase
    {
        [HttpPost("RegisterAlternateControlAccountt")]
        public IActionResult RegisterAlternateControlAccount([FromBody]TblAlternateControlAccTrans alacunt)
        {
            if (alacunt == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (AlternateControlAccountHelper.GetList(alacunt.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"AlternateControlAccount Code {nameof(alacunt.Code)} is already exists ,Please Use Different Code " });

                var result = AlternateControlAccountHelper.Register(alacunt);
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

        [HttpGet("GetAlternateControlAccountList")]
        public IActionResult GetAlternateControlAccountList()
        {
            try
            {
                var alacuntList = AlternateControlAccountHelper.GetList();
                if (alacuntList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.alacuntList = alacuntList;
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

        [HttpPut("UpdateAlternateControlAccount")]
        public IActionResult UpdateAlternateControlAccount([FromBody] TblAlternateControlAccTrans alacunt)
        {
            if (alacunt == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(alacunt)} cannot be null" });

            try
            {
                var rs = AlternateControlAccountHelper.Update(alacunt);
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


        [HttpDelete("DeleteAlternateControlAccount/{code}")]
        public IActionResult DeleteAlternateControlAccountbyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = AlternateControlAccountHelper.Delete(code);
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
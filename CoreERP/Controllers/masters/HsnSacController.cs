using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/HsnSac")]
    public class HsnSacController : ControllerBase
    {
        [HttpPost("RegisterHsnSac")]
        public IActionResult RegisterHsnSac([FromBody]TblHsnsac hsnsac)
        {
            if (hsnsac == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (HsnsacHelper.GetList(hsnsac.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"language Code {nameof(hsnsac.Code)} is already exists ,Please Use Different Code " });

                var result = HsnsacHelper.Register(hsnsac);
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

        [HttpGet("GetHsnSacList")]
        public IActionResult GetHsnSacList()
        {
            try
            {
                var hsnsacList = HsnsacHelper.GetList();
                if (hsnsacList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.hsnsacList = hsnsacList;
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

        [HttpPut("UpdateHsnSac")]
        public IActionResult UpdateHsnSac([FromBody] TblHsnsac code)
        {
            if (code == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                var rs = HsnsacHelper.Update(code);
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


        [HttpDelete("DeleteHsnSac/{code}")]
        public IActionResult DeleteHsnSacByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = HsnsacHelper.Delete(code);
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
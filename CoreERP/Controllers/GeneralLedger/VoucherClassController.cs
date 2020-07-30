using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/VoucherClass")]
    public class VoucherClassController : ControllerBase
    {
        [HttpPost("RegisterVoucherClass")]
        public IActionResult RegisterVoucherClass([FromBody]VoucherClass vcclass)
        {
            if (vcclass == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (VoucherClassHelper.GetList(vcclass.VoucherCode).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"VocherClass Code {nameof(vcclass.VoucherCode)} is already exists ,Please Use Different Code " });

                var result = VoucherClassHelper.Register(vcclass);
                APIResponse apiResponse;
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetVoucherClassList")]
        public IActionResult GetVoucherClassList()
        {
            try
            {
                var vcclassList = VoucherClassHelper.GetList();
                if (vcclassList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.vcList = vcclassList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateVoucherClass")]
        public IActionResult UpdateVoucherClass([FromBody] VoucherClass vcclass)
        {
            if (vcclass == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(vcclass)} cannot be null" });

            try
            {
                var rs = VoucherClassHelper.Update(vcclass);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteVoucherClass/{code}")]
        public IActionResult DeleteVoucherClassByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = VoucherClassHelper.Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.Payroll;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.Payroll
{
    [ApiController]
    [Route("api/payroll/PTMaster")]
    public class PTMasterController : ControllerBase
    {
        [HttpGet("GetPTList")]
        public IActionResult GetPTList()
        {
            try
            {
                var ptList = PTMasterHelper.GetListOfPTMaster();
                if (ptList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ptList = ptList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterPT")]
        public IActionResult RegisterPT([FromBody]Ptmaster pt)
        {

            if (pt == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(pt)} cannot be null" });
            else
            {
                if (PTMasterHelper.GetPT(pt.Ptslab) != null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Code =" + pt.Ptslab + " is already Exists,Please Use Another Code" });

                try
                {
                    APIResponse apiResponse = null;
                    var result = PTMasterHelper.Register(pt);
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
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            }
        }

        [HttpPut("UpdatePT")]
        public IActionResult UpdatePT([FromBody] Ptmaster pt)
        {

            if (pt == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(pt)} cannot be null" });
            try
            {
                APIResponse apiResponse = null;

                Ptmaster result = PTMasterHelper.Update(pt);
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePT/{code}")]
        public IActionResult DeletePT(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = PTMasterHelper.DeletePT(code);
                APIResponse apiResponse;
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
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
    [Route("api/payroll/PFMaster")]
    public class PFMasterController : ControllerBase
    {
        [HttpGet("GetPFList")]
        public IActionResult GetPFList()
        {
            try
            {
                var pfList = PFMasterHelper.GetListOfPFTMaster();
                if (pfList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.pfList = pfList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetComponentsList")]
        public IActionResult GetComponentsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ComponentList = PFMasterHelper.GetComponentsList().Select(x => new { ID = x.ComponentCode, TEXT = x.ComponentName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterPF")]
        public IActionResult RegisterPF([FromBody]Pfmaster pf)
        {

            if (pf == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(pf)} cannot be null" });
            else
            {
                if (PFMasterHelper.GetPF(pf.PftypeName) != null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Code =" + pf.PftypeName + " is already Exists,Please Use Another Code" });

                try
                {
                    APIResponse apiResponse = null;
                    var result = PFMasterHelper.Register(pf);
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

        [HttpPut("UpdatePF")]
        public IActionResult UpdatePF([FromBody] Pfmaster pf)
        {

            if (pf == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(pf)} cannot be null" });
            try
            {
                APIResponse apiResponse = null;

                Pfmaster result = PFMasterHelper.Update(pf);
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

        [HttpDelete("DeletePF/{code}")]
        public IActionResult DeletePF(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = PFMasterHelper.DeletePF(code);
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
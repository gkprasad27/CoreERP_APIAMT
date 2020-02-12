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
    [Route("api/payroll/ComponentMaster")]
    public class CTCBreakupController : ControllerBase
    {
        [HttpGet("GetCTCList")]
        public async Task<IActionResult> GetCTCList()
        {
            try
            {
                var ctcList = CTCHelper.GetListOfCTCs();
                if (ctcList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ctcList = ctcList;
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
        public async Task<IActionResult> GetComponentsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ComponentsList = StructureHelper.GetComponentList().Select(x => new { ID = x.ComponentCode, TEXT = x.ComponentName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStructureList")]
        public async Task<IActionResult> GetStructureList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.StructureList = CTCHelper.GetStructureList().Select(x => new { ID = x.ComponentCode, TEXT = x.ComponentName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPayrollCycleList")]
        public async Task<IActionResult> GetPayrollCycleList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.PayrollCycleList = CTCHelper.GetPayrollCycleList().Select(x => new { ID = x.CycleName, TEXT = x.CycleName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPost("RegisterCTC")]
        public async Task<IActionResult> RegisterCTC([FromBody]Ctcbreakup ctcBreakup)
        {

            if (ctcBreakup == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(ctcBreakup)} cannot be null" });
            else
            {
                if (CTCHelper.GetCTCs(ctcBreakup.EarnDednCode) != null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Code =" + ctcBreakup.EarnDednCode + " is already Exists,Please Use Another Code" });

                try
                {
                    APIResponse apiResponse = null;
                    var result = CTCHelper.Register(ctcBreakup);
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

        [HttpPut("UpdateCTC")]
        public async Task<IActionResult> UpdateCTC([FromBody] Ctcbreakup ctcBreakup)
        {

            if (ctcBreakup == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(ctcBreakup)} cannot be null" });
            try
            {
                APIResponse apiResponse = null;

                Ctcbreakup result = CTCHelper.Update(ctcBreakup);
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

    }
}
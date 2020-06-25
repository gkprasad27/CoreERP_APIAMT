using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.SelfserviceHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.Selfservice
{
    [ApiController]
    [Route("api/Selfservice/Applyod")]
    public class ApplyodController : ControllerBase
    {

        [HttpGet("GetEmployeesList")]
        public async Task<IActionResult> GetEmployeesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.EmployeeList = LeaveRequestHelper.GetEmployeesList().Select(x => new { ID = x.EmployeeCode, TEXT = x.EmployeeName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetApplyodDetailsList/{code}")]
        public async Task<IActionResult> GetApplyodDetailsList(string code)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ApplyodDetailsList = ApplyodHelper.GetApplyodDetailsList(code).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterApplyOddataDetails")]
        public async Task<IActionResult> RegisterApplyOddataDetails([FromBody]ApplyOddata applyOddata)
        {
            if (applyOddata == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                string errorMessge = string.Empty;

                ApplyOddata result = ApplyodHelper.RegisterApplyOddataDetails(applyOddata, null, out errorMessge);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessge });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateApplyod")]
        public IActionResult UpdateApplyod([FromBody]ApplyOddata applyOddata)
        {
            if (applyOddata == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                string errorMessge = string.Empty;

                ApplyOddata result = ApplyodHelper.UpdateapplyOddata(applyOddata, out errorMessge);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessge });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}

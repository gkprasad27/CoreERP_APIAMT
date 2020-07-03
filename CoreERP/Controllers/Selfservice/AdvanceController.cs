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
    [Route("api/Selfservice/Advance")]
    public class AdvanceController : ControllerBase
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

        [HttpGet("GetApplyAdvanceDetailsList/{code}")]
        public async Task<IActionResult> GetApplyAdvanceDetailsList(string code)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ApplyAdvanceDetailsList = AdvanceHelper.GetApplyAdvanceDetailsList(code).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterApplyAdvancedataDetails")]
        public async Task<IActionResult> RegisterApplyAdvancedataDetails([FromBody]TblAdvance advancedata)
        {
            if (advancedata == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                string errorMessge = string.Empty;

                TblAdvance result = AdvanceHelper.RegisterApplyAdvancedataDetails(advancedata, null, out errorMessge);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessge });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAdvancedataDetails")]
        public IActionResult UpdateAdvancedataDetails([FromBody]TblAdvance applyadvancedata)
        {
            if (applyadvancedata == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                string errorMessge = string.Empty;

                TblAdvance result = AdvanceHelper.UpdateapplyAdvancedata(applyadvancedata, out errorMessge);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessge });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAdvancedataDetailslist")]
        public IActionResult GetAdvancedataDetailslist()
        {
            try
            {
                var advanceList = AdvanceHelper.GetAdvanceTypes();
                if (advanceList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.advancesList = advanceList.Select(n => new { ID = n.AdvanceTypeId, Text = n.AdvanceTypeName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
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
    [Route("api/Selfservice/LeaveRequest")]
    public class LeaveRequestController : ControllerBase
    {
        [HttpGet("GetEmployeesList")]
        public async Task<IActionResult> GetEmployeesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.EmployeeList = LeaveRequestHelper.GetEmployeesList().Select(x => new { ID = x.Code, TEXT = x.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLeavetpesList")]
        public async Task<IActionResult> GetLeavetpesList()
        {
            try
            {
                var leavetypeslist = LeaveRequestHelper.GetListOfleavetypes();
                if (leavetypeslist.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.leavetypesList = leavetypeslist;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLeaveApplDetailsList")]
        public async Task<IActionResult> GetLeaveApplDetailsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.LeaveApplDetailsList = LeaveRequestHelper.GetLeaveApplDetailsList().ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetNoDays/{fromdate}/{todate}")]
        public async Task<IActionResult> GetNoDays(string fromdate, string todate)
        {
            try
            {
                var noofdays = LeaveRequestHelper.GetNoDays(fromdate, todate);
                if (noofdays != null)
                {
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = noofdays });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterLeaveapplying")]
        public async Task<IActionResult> RegisterLeaveapplying([FromBody]LeaveApplDetails leaveApplDetails)
        {
            if (leaveApplDetails == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                string errorMessge = string.Empty;

                LeaveApplDetails result = LeaveRequestHelper.RegisterLeaveApplDetails(leaveApplDetails, out errorMessge);
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

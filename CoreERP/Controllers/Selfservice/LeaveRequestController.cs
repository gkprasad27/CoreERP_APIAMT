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
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.Selfservice
{
    [ApiController]
    [Route("api/Selfservice/LeaveRequest")]
    public class LeaveRequestController : ControllerBase
    {

        [HttpGet("GetLeavetpesList/{code}")]
        public async Task<IActionResult> GetLeavetpesList(string code)
        {

            if (string.IsNullOrEmpty(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

            try
            {
                string errorMessage = string.Empty;
                dynamic expando = new ExpandoObject();
                expando.leavetypesList = new LeaveRequestHelper().GetListOfleavetypes(code, out errorMessage);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLeaveApplDetailsList/{code}")]
        public async Task<IActionResult> GetLeaveApplDetailsList(string code)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.LeaveApplDetailsList = LeaveRequestHelper.GetLeaveApplDetailsList(code).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("GetEmployeeCode")]
        public IActionResult GetEmployeeCode([FromBody]JObject objData)
        {
            if (objData == null)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                string Code = objData["Code"].ToString();
                dynamic expando = new ExpandoObject();
                expando.Empcodes = new LeaveRequestHelper().GetEmpcodes(Code, null).OrderBy(x => x.EmployeeCode?.Length).Take(50).Select(p => new { ID = p.EmployeeCode, TEXT = p.EmployeeCode, Name = p.EmployeeName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetEmpName/{Code}")]
        public async Task<IActionResult> GetEmpName(string Code)
        {
            if (string.IsNullOrEmpty(Code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

            try
            {
                string errorMessage = string.Empty;
                dynamic expando = new ExpandoObject();
                expando.empname = new LeaveRequestHelper().GetEmpName(Code, out errorMessage);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
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

                LeaveApplDetails result = LeaveRequestHelper.RegisterLeaveApplDetails(leaveApplDetails, null, out errorMessge);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessge });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPut("UpdateLeaveapplying")]
        public IActionResult UpdateLeaveapplying([FromBody]LeaveApplDetails leaveApplDetails)
        {
            if (leaveApplDetails == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                string errorMessge = string.Empty;

                LeaveApplDetails result = LeaveRequestHelper.UpdateLeaveapplying(leaveApplDetails, out errorMessge);
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

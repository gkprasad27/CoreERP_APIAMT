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

    [HttpPost("RegisterLeaveapplying")]
    public async Task<IActionResult> RegisterLeaveapplying([FromBody]LeaveApplDetails leaveApplDetails)
    {
      if (leaveApplDetails == null)
        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
      try
      {
        //if (GLHelper.GetGLSubCodeList(leaveApplDetails.em).Count > 0)
        //return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Code ={leaveApplDetails.SubCode} alredy exists." });
        LeaveApplDetails result = LeaveRequestHelper.RegisterLeaveApplDetails(leaveApplDetails);
        if (result != null)
          return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
      }
      catch (Exception ex)
      {
        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
      }
    }
  }
}

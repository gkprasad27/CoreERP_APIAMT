using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.SelfserviceHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.Selfservice
{
  [ApiController]
  [Route("api/Selfservice/LeaveApproval")]
  public class LeaveApprovalController : ControllerBase
  {

        [HttpGet("GetLeaveApplDetailsList")]
        public async Task<IActionResult> GetLeaveApplDetailsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.LeaveApplDetailsList = LeaveApprovalHelper.GetLeaveApplDetailsList().ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpPost("RegisterLeaveApprovalDetails")]
        //public async Task<IActionResult> RegisterLeaveApprovalDetails([FromBody]LeaveApplDetails[] leaveapp)
        //{

        //    if (leaveapp == null || leaveapp?.Length == 0)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(leaveapp)} cannot be null" });
        //    try
        //    {
        //        var result = LeaveApprovalHelper.RegisterLeaveApprovalDetails(leaveapp);
        //        if (result.Count > 0)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}


    }
}

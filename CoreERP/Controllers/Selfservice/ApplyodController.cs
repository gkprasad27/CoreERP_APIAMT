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

    //[HttpGet("GetEmployeesList")]
    //public async Task<IActionResult> GetEmployeesList()
    //{
    //  try
    //  {
    //    dynamic expando = new ExpandoObject();
    //    expando.EmployeeList = LeaveRequestHelper.GetEmployeesList().Select(x => new { ID = x.Code, TEXT = x.Name });
    //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
    //  }
    //  catch (Exception ex)
    //  {
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
    //  }
    //}


    //    [HttpGet("GetApplyodDetailsList")]
    //    public async Task<IActionResult> GetApplyodDetailsList()
    //    {
    //        try
    //        {
    //            dynamic expando = new ExpandoObject();
    //            expando.LeaveApplDetailsList = ApplyodHelper.GetApplyodDetailsList().ToList();
    //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
    //        }
    //        catch (Exception ex)
    //        {
    //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
    //        }
    //    }

    //    [HttpPost("RegisterApplyOddataDetails")]
    //public async Task<IActionResult> RegisterApplyOddataDetails([FromBody]ApplyOddata applyOddata)
    //{
    //  if (applyOddata == null)
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
    //  try
    //  {
    //    ApplyOddata result = ApplyodHelper.RegisterApplyOddataDetails(applyOddata);
    //    if (result != null)
    //      return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
    //  }
    //  catch (Exception ex)
    //  {
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
    //  }
    //}
  }
}

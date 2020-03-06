using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.masters
{
  [ApiController]
  [Route("api/masters/Leaveopeningbalances")]
    public class LeaveOpeningbalancesController : ControllerBase
    {


    //[HttpGet("GetLeaveopeningbalancesList")]
    //public async Task<IActionResult> GetLeaveopeningbalancesList()
    //{
    //  try
    //  {
    //    var lopList = LeaveOpeningBalancesHelper.GetListOfLeaveopeningbalances();
    //    if (lopList.Count() > 0)
    //    {
    //      dynamic expdoObj = new ExpandoObject();
    //      expdoObj.lopList = lopList;
    //      return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
    //    }
    //    else
    //      return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
    //  }
    //  catch (Exception ex)
    //  {
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
    //  }
    //}


    //[HttpPost("RegisterLeaveopeningbalances")]
    //public async Task<IActionResult> RegisterLeaveopeningbalances([FromBody]Leaveopeningbalances lop)
    //{
    //  APIResponse apiResponse = null;
    //  if (lop == null)
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(lop)} cannot be null" });
    //  else
    //  {
    //    if (LeaveOpeningBalancesHelper.SearchLeaveopeningbalances(lop.Code).Count() > 0)
    //      return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $" Code {nameof(lop.Code)} is already Present ,Please Use Different Code" });
    //    try
    //    {
    //      var result = LeaveOpeningBalancesHelper.Register(lop);
    //      if (result != null)
    //      {
    //        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
    //      }
    //      else
    //      {
    //        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
    //      }

    //      return Ok(apiResponse);
    //    }
    //    catch (Exception ex)
    //    {
    //      return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
    //    }

    //  }
    //}

    //[HttpPut("UpdateLeaveopeningbalances")]
    //public async Task<IActionResult> UpdateLeaveopeningbalances([FromBody] Leaveopeningbalances lop)
    //{
    //  APIResponse apiResponse = null;
    //  if (lop == null)
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

    //  try
    //  {
    //    var result = LeaveOpeningBalancesHelper.Update(lop);
    //    if (result != null)
    //    {
    //      apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
    //    }
    //    else
    //    {
    //      apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
    //    }
    //    return Ok(apiResponse);
    //  }
    //  catch (Exception ex)
    //  {
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
    //  }
    //}

    //[HttpDelete("DeleteLeaveopeningbalances/{code}")]
    //public async Task<IActionResult> DeleteLeaveopeningbalances(string code)
    //{
    //  APIResponse apiResponse = null;
    //  if (code == null)
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

    //  try
    //  {
    //    var result = LeaveOpeningBalancesHelper.DeleteLeaveopeningbalances(code);
    //    if (result != null)
    //    {
    //      apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
    //    }
    //    else
    //    {
    //      apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
    //    }
    //    return Ok(apiResponse);
    //  }
    //  catch (Exception ex)
    //  {
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
    //  }
    //}
  }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using System.Dynamic;
using CoreERP.DataAccess;
using System;

namespace CoreERP.Controllers
{
  [Authorize]
    [Route("api/masters/LeaveTypeMaster")]
    public class LeaveTypeMasterController : Controller
    {
      

        [HttpGet("GetLeaveTypesList")]
        public async Task<IActionResult> GetLeaveTypesList()
        {
            try
            {
                var leavetypeList = LeaveTypeHelper.GetLeaveTypeList();
                if (leavetypeList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.leavetypeList = leavetypeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPost("RegisterLeaveType")]
        public async Task<IActionResult> RegisterLeaveType([FromBody]LeaveTypes leaveType)
        {
            APIResponse apiResponse = null;
            if (leaveType == null)
                return BadRequest($"{nameof(leaveType)} cannot be null");
            try
            {
               int result = LeaveTypeHelper.RegisterLeaveType(leaveType);
                if (result > 0)
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
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpPut("UpdateLeaveType/{leaveCode}")]
        public async Task<IActionResult> UpdateLeaveType(string Leavecode, [FromBody] LeaveTypes leaveType)
        {
            APIResponse apiResponse = null;
            if (leaveType == null)
                return BadRequest($"{nameof(leaveType)} cannot be null");
            try
            {
              if (leaveType == null)
                    return BadRequest($"{nameof(leaveType)} cannot be null");

                int rs = LeaveTypeHelper.UpdateLeaveType(leaveType);
                if (rs > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        // Delete Leave Type
        [HttpDelete("DeleteleaveType/{code}")]
        public async Task<IActionResult> DeleteleaveType(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

           
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                    return BadRequest($"{nameof(code)} cannot be null");

                int result =LeaveTypeHelper.DeleteLeaveType(code);
                if (result > 0)
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
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}

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
    [Route("api/masters/LeaveTypeMasters")]
    public class LeaveTypeMastersController : ControllerBase
    {
        [HttpGet("GetLeaveTypesList")]
        public async Task<IActionResult> GetLeaveTypesList()
        {
            try
            {
                var leavetypeList = LeaveTypeHelper.GetListOfLeaveTypes();
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

        [HttpPost("RegisterLeaveTypeMaster")]
        public async Task<IActionResult> RegisterLeaveTypeMaster([FromBody]LeaveTypes leaveType)
        {
            APIResponse apiResponse = null;
            if (leaveType == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(leaveType)} cannot be null" });
            else
            {
                if (LeaveTypeHelper.GetList(leaveType.LeaveName).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Leave Code {nameof(leaveType.LeaveName)} is already exists ,Please Use Different Code " });
                try
                {
                    var result = LeaveTypeHelper.Register(leaveType);
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
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }

        [HttpPut("UpdateLeaveTypeMaster")]
        public async Task<IActionResult> UpdateLeaveTypeMaster([FromBody] LeaveTypes leaveType)
        {
            APIResponse apiResponse = null;
            if (leaveType == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                var result = LeaveTypeHelper.Update(leaveType);
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
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteLeaveTypeMaster/{code}")]
        public async Task<IActionResult> DeleteLeaveTypeMaster(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = LeaveTypeHelper.DeleteLeaveTypes(code);
                if (result != null)
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

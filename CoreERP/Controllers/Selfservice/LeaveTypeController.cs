using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace CoreERP.Controllers.Selfservice
{
    [ApiController]
    [Route("api/Selfservice/LeaveType")]
    public class LeaveTypeController : ControllerBase
    {
        [HttpGet("GetLeaveTypeList")]
        public IActionResult GetLeaveTypeList()
        {
            try
            {
                var leavetypeList = LeaveTypeHelper.GetListOfLeaveTypes();
                if (leavetypeList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.leavetypeList = leavetypeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpPost("RegisterLeaveType/{Code}")]
        public IActionResult RegisterLeaveType([FromBody]LeaveTypes ltype, string Code)
        {
            if (ltype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(ltype)} cannot be null" });

            try
            {
                if (LeaveTypeHelper.GetList(ltype.LeaveCode).Count() > 0)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"Code {ltype.LeaveCode} is already exists ,please use different code" });

                var result = LeaveTypeHelper.Register(ltype, Code);
                APIResponse apiResponse;
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


        [HttpPut("UpdateLeaveType/{Code}")]
        //[HttpPut("UpdateLeaveType")]
        public IActionResult UpdateLeaveType([FromBody] LeaveTypes ltype, string code)
        {
            try
            {
                if (ltype == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(ltype)} cannot be null" });

                var result = LeaveTypeHelper.Update(ltype, code);
                APIResponse apiResponse;
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


        // Delete Branch
        [HttpDelete("DeleteLeaveType/{code}")]
        public IActionResult DeleteLeaveType(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });
            try
            {
                var result = LeaveTypeHelper.DeleteLeaveTypes(code);
                APIResponse apiResponse;
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
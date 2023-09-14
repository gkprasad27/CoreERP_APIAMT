using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/LeaveApply")]
    public class LeaveApplyController : ControllerBase
    {
        private readonly IRepository<LeaveApplDetails> _leaveRepository;
        public LeaveApplyController(IRepository<LeaveApplDetails> leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        [HttpPost("RegisterLeaveTypes")]
        public IActionResult RegisterLeaveTypes([FromBody] LeaveApplDetails leaveypes)
        {
            if (leaveypes == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _leaveRepository.Add(leaveypes);
                if (_leaveRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = leaveypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLeaveTypesList")]
        public IActionResult GetLeaveTypesList()
        {
            try
            {
                var LeaveTypesList = _leaveRepository.GetAll();
                if (!LeaveTypesList.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.LeaveTypesList = LeaveTypesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateLeaveTypes")]
        public IActionResult UpdateLeaveTypes([FromBody] LeaveApplDetails leaveypes)
        {
            if (leaveypes == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(leaveypes)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _leaveRepository.Update(leaveypes);
                if (_leaveRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = leaveypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteLeaveTypes/{code}")]
        public IActionResult DeleteLeaveTypes(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _leaveRepository.GetSingleOrDefault(x => x.Sno.Equals(code));
                _leaveRepository.Remove(record);
                if (_leaveRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }        
    }
}
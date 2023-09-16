using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/LeaveTypes")]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IRepository<LeaveTypes> _leaveTypesRepository;
        public LeaveTypesController(IRepository<LeaveTypes> leaveTypesRepository)
        {
            _leaveTypesRepository = leaveTypesRepository;
        }

        [HttpPost("RegisterLeaveTypes")]
        public IActionResult RegisterLeaveTypes([FromBody] LeaveTypes ltypes)
        {
            if (ltypes == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _leaveTypesRepository.Add(ltypes);
                if (_leaveTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ltypes };
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
                var LeaveTypesList = _leaveTypesRepository.GetAll();
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
        public IActionResult UpdateLeaveTypes([FromBody] LeaveTypes ltypes)
        {
            if (ltypes == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(ltypes)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _leaveTypesRepository.Update(ltypes);
                if (_leaveTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ltypes };
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
                var record = _leaveTypesRepository.GetSingleOrDefault(x => x.LeaveCode.Equals(code));
                _leaveTypesRepository.Remove(record);
                if (_leaveTypesRepository.SaveChanges() > 0)
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
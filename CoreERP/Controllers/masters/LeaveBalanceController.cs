using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/LeaveBalance")]
    public class LeaveBalanceController : ControllerBase
    {
        private readonly IRepository<LeaveBalanceMaster> _leaveBalanceRepository;
        public LeaveBalanceController(IRepository<LeaveBalanceMaster> leaveBalanceRepository)
        {
            _leaveBalanceRepository = leaveBalanceRepository;
        }

        [HttpPost("RegisterLeaveBalanceTypes")]
        public IActionResult RegisterLeaveBalanceTypes([FromBody] LeaveBalanceMaster lbtypes)
        {
            if (lbtypes == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _leaveBalanceRepository.Add(lbtypes);
                if (_leaveBalanceRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = lbtypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLeaveBalanceTypesList")]
        public IActionResult GetLeaveBalanceTypesList()
        {
            try
            {
                var LeaveTypesList = _leaveBalanceRepository.GetAll();
                if (!LeaveTypesList.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.LeaveBalanceTypesList = LeaveTypesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateLeaveBalanceTypes")]
        public IActionResult UpdateLeaveBalanceTypes([FromBody] LeaveBalanceMaster lbtypes)
        {
            if (lbtypes == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(lbtypes)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _leaveBalanceRepository.Update(lbtypes);
                if (_leaveBalanceRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = lbtypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteLeaveBalanceTypes/{code}")]
        public IActionResult DeleteLeaveBalanceTypes(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _leaveBalanceRepository.GetSingleOrDefault(x => x.LeaveCode.Equals(code));
                _leaveBalanceRepository.Remove(record);
                if (_leaveBalanceRepository.SaveChanges() > 0)
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
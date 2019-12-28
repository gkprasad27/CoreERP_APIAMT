using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;

namespace CoreERP.Controllers
{
  [Authorize]
    [Route("api/[controller]")]
    public class LeaveTypeMasterController : Controller
    {
      

        [HttpGet("masters/leaveType")]
        public async Task<IActionResult> GetAllLeaveTypes()
        {
            return Ok(
                new {
                   leaveType= LeaveTypeHelper.GetLeaveTypeList()
                    
                });
        }


        [HttpPost("masters/leaveType/register")]
        public async Task<IActionResult> Register([FromBody]LeaveTypes leaveType)
        {

            if (leaveType == null)
                return BadRequest($"{nameof(leaveType)} cannot be null");
            try
            {
               int result = LeaveTypeHelper.RegisterLeaveType(leaveType);
                if(result > 0)
                return Ok(leaveType);
            }
         catch { }
         return BadRequest("Registration Failed");
        }



        [HttpPut("masters/leaveType/{leaveCode}")]
        public async Task<IActionResult> UpdateLeave(string Leavecode, [FromBody] LeaveTypes leaveType)
        {
            if (leaveType == null)
                return BadRequest($"{nameof(leaveType)} cannot be null");
            try
            {
              if (leaveType == null)
                    return BadRequest($"{nameof(leaveType)} cannot be null");

                int rs = LeaveTypeHelper.UpdateLeaveType(leaveType);
                if (rs > 0)
                    return Ok(leaveType);
            }
           catch { throw; }
           return BadRequest($"{nameof(leaveType)} Updation Failed");
    }


        // Delete Leave Type
        [HttpDelete("masters/leaveType/{code}")]
        public async Task<IActionResult> DeleteleaveType(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

           
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                    return BadRequest($"{nameof(code)} cannot be null");

                int result =LeaveTypeHelper.DeleteLeaveType(code);
                if(result > 0)
                        return Ok(code);
            }
            catch { }
            return BadRequest("Deletion Failed");
        }
    }
}

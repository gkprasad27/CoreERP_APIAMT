using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/approval")]
    public class approvalController : ControllerBase
    {

        [HttpPost("approval/register")]
        public async Task<IActionResult> Register([FromBody]ApprovalType approvalType)
        {
            if (approvalType == null)
                return BadRequest("cannot be null");
            try
            {
                int result = ApprovalHelper.RegisterApprovalType(approvalType);
                if (result > 0)
                    return Ok(approvalType);

            }
            catch
            {
            }
            return BadRequest("Registration Failed");
        }

        [HttpGet("approval")]
        public async Task<IActionResult> GetAllApprovalTypes()
        {
            return Ok(
                new
                {
                    approvalType = ApprovalHelper.GetListOfApprovals()

                });
        }

        [HttpPut("approval/{approvalID}")]
        public async Task<IActionResult> UpdateApprovalType(string code, [FromBody] ApprovalType approvalType)
        {
            try
            {
                if (approvalType == null)
                    return BadRequest($"{nameof(approvalType)} cannot be null");

                int rs = ApprovalHelper.UpdateApprovalType(approvalType);
                if (rs > 0)
                    return Ok(approvalType);

            }
            catch { throw; }
            return BadRequest($"{nameof(approvalType)} Updation Failed");
        }


        [HttpDelete("approval/{approvalID}")]
        public async Task<IActionResult> DeleteApprovalTypeByID(int approvalId)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(approvalId))
                //  return BadRequest($"{nameof(approvalId)} cannot be null");

                int result = ApprovalHelper.DeleteApprovalType(approvalId);
                if (result > 0)
                    return Ok(approvalId);
            }
            catch { }
            return BadRequest("Deletion Failed");
        }
    }
}

using System;
using System.Dynamic;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/master/Approval")]
    public class ApprovalController : ControllerBase
    {

        [HttpPost("RegisterApprovalType")]
        public async Task<IActionResult> RegisterApprovalType([FromBody]ApprovalType approvalType)
        {
            if (approvalType == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });
            try
            {
                ApprovalType result = ApprovalHelper.RegisterApprovalType(approvalType);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="Registration Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GeApprovalTypeList")]
        public async Task<IActionResult> GeApprovalTypeList()
        {
            try
            {
                var approvalTypeList = ApprovalHelper.GetListOfApprovals();
                if (approvalTypeList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.approvalTypeList = approvalTypeList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateApprovalType")]
        public async Task<IActionResult> UpdateApprovalType([FromBody] ApprovalType approvalType)
        {
            try
            {
                if (approvalType == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(approvalType)} cannot be null"});

                ApprovalType result = ApprovalHelper.UpdateApprovalType(approvalType);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteApprovalType/{approvalID}")]
        public async Task<IActionResult> DeleteApprovalType(int approvalId)
        {
            try
            {

                ApprovalType result = ApprovalHelper.DeleteApprovalType(approvalId);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}

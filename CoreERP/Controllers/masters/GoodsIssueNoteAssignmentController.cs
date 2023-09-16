using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/GoodsIssueNoteAssignment")]
    public class GoodsIssueNoteAssignmentController : ControllerBase
    {
        private readonly IRepository<TblGinseriesAssignment> _ginseriesAssignmentRepository;
        public GoodsIssueNoteAssignmentController(IRepository<TblGinseriesAssignment> ginseriesAssignmentRepository)
        {
            _ginseriesAssignmentRepository = ginseriesAssignmentRepository;
        }

        [HttpPost("RegisterGoodsIssueNoteAssignment")]
        public IActionResult RegisterGoodsIssueNoteAssignment([FromBody]TblGinseriesAssignment assignment)
        {
            if (assignment == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _ginseriesAssignmentRepository.Add(assignment);
                if (_ginseriesAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assignment };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "GIN already Exist, Please use another key " + " " + (assignment.Ginseries) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGoodsIssueNoteAssignmentList")]
        public IActionResult GetGoodsIssueNoteAssignmentList()
        {
            try
            {
                var issueassnList = CommonHelper.GetGinseriesAssignment();
                if (issueassnList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.issueassnList = issueassnList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateGoodsIssueNoteAssignment")]
        public IActionResult UpdateGoodsIssueNoteAssignment([FromBody] TblGinseriesAssignment assignment)
        {
            if (assignment == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(assignment)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _ginseriesAssignmentRepository.Update(assignment);
                if (_ginseriesAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assignment };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "GIN already Exist, Please use another key " + " " + (assignment.Ginseries) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteGoodsIssueNoteAssignment/{code}")]
        public IActionResult DeleteGoodsIssueNoteAssignmentbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _ginseriesAssignmentRepository.GetSingleOrDefault(x => x.Ginseries.Equals(code));
                _ginseriesAssignmentRepository.Remove(record);
                if (_ginseriesAssignmentRepository.SaveChanges() > 0)
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
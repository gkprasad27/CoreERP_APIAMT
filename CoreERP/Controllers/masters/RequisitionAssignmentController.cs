using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/RequisitionAssignment")]
    public class RequisitionAssignmentController : ControllerBase
    {
        private readonly IRepository<TblReqNoAssignment> _reqNoAssignmentRepository;
        public RequisitionAssignmentController(IRepository<TblReqNoAssignment> reqNoAssignmentRepository)
        {
            _reqNoAssignmentRepository = reqNoAssignmentRepository;
        }

        [HttpPost("RegisterRequisitionAssignment")]
        public IActionResult RegisterRequisitionAssignment([FromBody]TblReqNoAssignment reqassgnmnt)
        {
            if (reqassgnmnt == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _reqNoAssignmentRepository.Add(reqassgnmnt);
                if (_reqNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = reqassgnmnt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetRequisitionAssignmentList")]
        public IActionResult GetRequisitionAssignmentList()
        {
            try
            {
                var reqassgnmntList = _reqNoAssignmentRepository.GetAll();
                if (reqassgnmntList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.reqassgnmntList = reqassgnmntList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateRequisitionAssignment")]
        public IActionResult UpdateRequisitionAssignment([FromBody] TblReqNoAssignment reqassgnmnt)
        {
            if (reqassgnmnt == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(reqassgnmnt)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _reqNoAssignmentRepository.Update(reqassgnmnt);
                if (_reqNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = reqassgnmnt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteRequisitionAssignment/{code}")]
        public IActionResult DeleteRequisitionAssignmentbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _reqNoAssignmentRepository.GetSingleOrDefault(x => x.NumberRange.Equals(code));
                _reqNoAssignmentRepository.Remove(record);
                if (_reqNoAssignmentRepository.SaveChanges() > 0)
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
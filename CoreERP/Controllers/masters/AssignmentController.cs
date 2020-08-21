using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Assignment")]
    public class AssignmentController : ControllerBase
    {
        private readonly IRepository<TblAssignment> _assignRepository;
        public AssignmentController(IRepository<TblAssignment> assignRepository)
        {
            _assignRepository = assignRepository;
        }

        [HttpPost("RegisterAssignment")]
        public IActionResult RegisterAssignment([FromBody]TblAssignment assignment)
        {
            if (assignment == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (AssignmentHelpercs.GetList(assignment.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Assignment Code {nameof(assignment.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _assignRepository.Add(assignment);
                if (_assignRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assignment };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssignmentList")]
        public IActionResult GetAssignmentList()
        {
            try
            {
                var asnmList = CommonHelper.GetAssignments();
                if (asnmList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.asnmList = asnmList;
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

        [HttpPut("UpdateAssignment")]
        public IActionResult UpdateAssignment([FromBody] TblAssignment assignment)
        {
            if (assignment == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(assignment)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _assignRepository.Update(assignment);
                if (_assignRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assignment };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssignment/{code}")]
        public IActionResult DeleteAssignmentbyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _assignRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _assignRepository.Remove(record);
                if (_assignRepository.SaveChanges() > 0)
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
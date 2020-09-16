using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;


namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/RejectionReasons")]
    public class RejectionReasonsController : ControllerBase
    {
        private readonly IRepository<TblRejectionReason> _rejectionReasonRepository;
        public RejectionReasonsController(IRepository<TblRejectionReason> rejectionReasonRepository)
        {
            _rejectionReasonRepository = rejectionReasonRepository;
        }

        [HttpPost("RegisterRejectionReasons")]
        public IActionResult RegisterRejectionReasons([FromBody]TblRejectionReason reason)
        {
            if (reason == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _rejectionReasonRepository.Add(reason);
                if (_rejectionReasonRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = reason };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetRejectionReasonsList")]
        public IActionResult GetRejectionReasonsList()
        {
            try
            {
                var reasonList = _rejectionReasonRepository.GetAll();
                if (reasonList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.reasonList = reasonList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateRejectionReasons")]
        public IActionResult UpdateRejectionReasons([FromBody] TblRejectionReason reasons)
        {
            if (reasons == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(reasons)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _rejectionReasonRepository.Update(reasons);
                if (_rejectionReasonRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = reasons };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteRejectionReasons/{code}")]
        public IActionResult DeleteRejectionReasonsbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _rejectionReasonRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _rejectionReasonRepository.Remove(record);
                if (_rejectionReasonRepository.SaveChanges() > 0)
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
using System;
using System.Collections.Generic;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/CommitmentItem")]
    public class CommitmentItemController : ControllerBase
    {
        private readonly IRepository<TblCommitmentItem> _commitmentItemRepository;
        public CommitmentItemController(IRepository<TblCommitmentItem> commitmentItemRepository)
        {
            _commitmentItemRepository = commitmentItemRepository;
        }

        [HttpPost("RegisterCommitmentItem")]
        public IActionResult RegisterCommitmentItem([FromBody]TblCommitmentItem citem)
        {
            if (citem == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _commitmentItemRepository.Add(citem);
                if (_commitmentItemRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = citem };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCommitmentItemList")]
        public IActionResult GetCommitmentItemList()
        {
            try
            {
                var citemList = _commitmentItemRepository.GetAll();
                if (citemList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.citemList = citemList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateCommitmentItem")]
        public IActionResult UpdateCommitmentItem([FromBody] TblCommitmentItem citem)
        {
            if (citem == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(citem)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _commitmentItemRepository.Update(citem);
                if (_commitmentItemRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = citem };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCommitmentItem/{code}")]
        public IActionResult DeleteCommitmentItembyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _commitmentItemRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _commitmentItemRepository.Remove(record);
                if (_commitmentItemRepository.SaveChanges() > 0)
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
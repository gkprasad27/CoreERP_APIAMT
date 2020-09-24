using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;


namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/BatchMaster")]
    public class BatchMasterController : ControllerBase
    {
        private readonly IRepository<TblBatchMaster> _batchMasterRepository;
        public BatchMasterController(IRepository<TblBatchMaster> batchMasterRepository)
        {
            _batchMasterRepository = batchMasterRepository;
        }

        [HttpPost("RegisterBatchMaster")]
        public IActionResult RegisterBatchMaster([FromBody]TblBatchMaster batchmaster)
        {
            if (batchmaster == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _batchMasterRepository.Add(batchmaster);
                if (_batchMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = batchmaster };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBatchMasterList")]
        public IActionResult GetBatchMasterList()
        {
            try
            {
                var batchmasterList = CommonHelper.GetBatchMaster();
                if (batchmasterList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.batchmasterList = batchmasterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateBatchMaster")]
        public IActionResult UpdateBatchMaster([FromBody] TblBatchMaster batchmaster)
        {
            if (batchmaster == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(batchmaster)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _batchMasterRepository.Update(batchmaster);
                if (_batchMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = batchmaster };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteBatchMaster/{code}")]
        public IActionResult DeleteBatchMasterbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _batchMasterRepository.GetSingleOrDefault(x => x.BatchNumber.Equals(code));
                _batchMasterRepository.Remove(record);
                if (_batchMasterRepository.SaveChanges() > 0)
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
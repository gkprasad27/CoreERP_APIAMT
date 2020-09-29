using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/DownTimeReason")]
    public class DownTimeReasonController : ControllerBase
    {
        private readonly IRepository<TblDownTimeReasons> _downtimeRepository;
        public DownTimeReasonController(IRepository<TblDownTimeReasons> downtimeRepository)
        {
            _downtimeRepository = downtimeRepository;
        }

        [HttpPost("RegisterDownTimeReason")]
        public IActionResult RegisterDownTimeReason([FromBody]TblDownTimeReasons dtimereason)
        {
            if (dtimereason == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _downtimeRepository.Add(dtimereason);
                if (_downtimeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dtimereason };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDownTimeReasonList")]
        public IActionResult GetDownTimeReasonList()
        {
            try
            {
                var downtimereasonList = _downtimeRepository.GetAll();
                if (downtimereasonList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.downtimereasonList = downtimereasonList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateDownTimeReason")]
        public IActionResult UpdateDownTimeReason([FromBody] TblDownTimeReasons dtimereason)
        {
            if (dtimereason == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(dtimereason)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _downtimeRepository.Update(dtimereason);
                if (_downtimeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dtimereason };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteDownTimeReason/{code}")]
        public IActionResult DeleteDownTimeReasonbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _downtimeRepository.GetSingleOrDefault(x => x.ReasonCode.Equals(code));
                _downtimeRepository.Remove(record);
                if (_downtimeRepository.SaveChanges() > 0)
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
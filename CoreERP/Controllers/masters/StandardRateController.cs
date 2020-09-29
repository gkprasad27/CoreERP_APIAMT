using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/StandardRate")]
    public class StandardRateController : ControllerBase
    {
        private readonly IRepository<TblStandardRateOutPut> _standardrateRepository;
        public StandardRateController(IRepository<TblStandardRateOutPut> standardrateRepository)
        {
            _standardrateRepository = standardrateRepository;
        }

        [HttpPost("RegisterStandardRate")]
        public IActionResult RegisterStandardRate([FromBody]TblStandardRateOutPut sroutput)
        {
            if (sroutput == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _standardrateRepository.Add(sroutput);
                if (_standardrateRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = sroutput };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStandardRateList")]
        public IActionResult GetStandardRateList()
        {
            try
            {
                var sropList = CommonHelper.GetStandardRateOutPut();
                if (sropList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.sropList = sropList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateStandardRate")]
        public IActionResult UpdateStandardRate([FromBody] TblStandardRateOutPut sroutput)
        {
            if (sroutput == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(sroutput)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _standardrateRepository.Update(sroutput);
                if (_standardrateRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = sroutput };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteStandardRate/{code}")]
        public IActionResult DeleteStandardRatebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _standardrateRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _standardrateRepository.Remove(record);
                if (_standardrateRepository.SaveChanges() > 0)
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
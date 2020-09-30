using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/FundCenter")]
    public class FundCenterController : ControllerBase
    {
        private readonly IRepository<TblFundCenter> _fundCenterRepository;
        public FundCenterController(IRepository<TblFundCenter> fundCenterRepository)
        {
            _fundCenterRepository = fundCenterRepository;
        }

        [HttpPost("RegisterFundCenter")]
        public IActionResult RegisterFundCenter([FromBody]TblFundCenter fcenter)
        {
            if (fcenter == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _fundCenterRepository.Add(fcenter);
                if (_fundCenterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = fcenter };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetFundCenterList")]
        public IActionResult GetFundCenterList()
        {
            try
            {
                var fcList = CommonHelper.GetFundCenter();
                if (fcList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.fcList = fcList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateFundCenter")]
        public IActionResult UpdateFundCenter([FromBody] TblFundCenter fcenter)
        {
            if (fcenter == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(fcenter)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _fundCenterRepository.Update(fcenter);
                if (_fundCenterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = fcenter };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteFundCenter/{code}")]
        public IActionResult DeleteFundCenterbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _fundCenterRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _fundCenterRepository.Remove(record);
                if (_fundCenterRepository.SaveChanges() > 0)
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
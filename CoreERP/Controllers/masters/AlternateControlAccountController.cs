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
    [Route("api/AlternateControlAccount")]
    public class AlternateControlAccountController : ControllerBase
    {
        private readonly IRepository<TblAlternateControlAccTrans> _alterRepository;
        public AlternateControlAccountController(IRepository<TblAlternateControlAccTrans> alterRepository)
        {
            _alterRepository = alterRepository;
        }

        [HttpPost("RegisterAlternateControlAccountt")]
        public IActionResult RegisterAlternateControlAccount([FromBody]TblAlternateControlAccTrans alacunt)
        {
            if (alacunt == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (AlternateControlAccountHelper.GetList(alacunt.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"AlternateControlAccount Code {nameof(alacunt.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _alterRepository.Add(alacunt);
                if (_alterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = alacunt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Alternate Control Account already Exist, Please use another key " + " " + (alacunt.AlternativeControlAccount) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAlternateControlAccountList")]
        public IActionResult GetAlternateControlAccountList()
        {
            try
            {
                var alacuntList = CommonHelper.GetAlternateControlAccounts();
                if (alacuntList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.alacuntList = alacuntList;
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

        [HttpPut("UpdateAlternateControlAccount")]
        public IActionResult UpdateAlternateControlAccount([FromBody] TblAlternateControlAccTrans alacunt)
        {
            if (alacunt == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(alacunt)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _alterRepository.Update(alacunt);
                if (_alterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = alacunt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Alternate Control Account already Exist, Please use another key " + " " + (alacunt.AlternativeControlAccount) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAlternateControlAccount/{code}")]
        public IActionResult DeleteAlternateControlAccountbyID(int code)
        {
            try
            {
                if (code == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _alterRepository.GetSingleOrDefault(x => x.id.Equals(code));
                _alterRepository.Remove(record);
                if (_alterRepository.SaveChanges() > 0)
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
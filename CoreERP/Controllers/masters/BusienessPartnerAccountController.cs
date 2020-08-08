using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/BusienessPartnerAccount")]
    public class BusienessPartnerAccountController : ControllerBase
    {
        private readonly IRepository<TblBusinessPartnerAccount> _businessPartnerAccountRepository;
        public BusienessPartnerAccountController(IRepository<TblBusinessPartnerAccount> businessPartnerAccountRepository)
        {
            _businessPartnerAccountRepository = businessPartnerAccountRepository;
        }
        [HttpGet("GetBusienessPartnerAccountList")]
        public async Task<IActionResult> GetBusienessPartnerAccountList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var bpaList = _businessPartnerAccountRepository.GetAll();
                    if (bpaList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.bpaList = bpaList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterBusienessPartnerAccount")]
        public async Task<IActionResult> RegisterBusienessPartnerAccount([FromBody]TblBusinessPartnerAccount bpa)
        {
            APIResponse apiResponse;
            if (bpa == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(bpa)} cannot be null" });
            else
            {
                try
                {
                    _businessPartnerAccountRepository.Add(bpa);
                    if (_businessPartnerAccountRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bpa };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }

        [HttpPut("UpdateBusienessPartnerAccount")]
        public async Task<IActionResult> UpdateBusienessPartnerAccount([FromBody] TblBusinessPartnerAccount bpa)
        {
            APIResponse apiResponse = null;
            if (bpa == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _businessPartnerAccountRepository.Update(bpa);
                if (_businessPartnerAccountRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bpa };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteBusienessPartnerAccount/{code}")]
        public async Task<IActionResult> DeleteBusienessPartnerAccount(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _businessPartnerAccountRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _businessPartnerAccountRepository.Remove(record);
                if (_businessPartnerAccountRepository.SaveChanges() > 0)
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
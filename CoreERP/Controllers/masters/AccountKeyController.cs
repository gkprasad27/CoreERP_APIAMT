using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/AccountKey")]
    public class AccountKeyController : ControllerBase
    {
        private readonly IRepository<TblAssetAccountkey> _assetAccountkeyRepository;
        public AccountKeyController(IRepository<TblAssetAccountkey> assetAccountkeyRepository)
        {
            _assetAccountkeyRepository = assetAccountkeyRepository;
        }
        [HttpGet("GetAccountKeyList")]
        public async Task<IActionResult> GetAccountKeyList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var acckeyList = _assetAccountkeyRepository.GetAll();
                    if (acckeyList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.acckeyList = acckeyList;
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

        [HttpPost("RegisterAccountKey")]
        public async Task<IActionResult> RegisterAccountKey([FromBody]TblAssetAccountkey acckey)
        {
            APIResponse apiResponse;
            if (acckey == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(acckey)} cannot be null" });
            else
            {
                try
                {
                    _assetAccountkeyRepository.Add(acckey);
                    if (_assetAccountkeyRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = acckey };
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

        [HttpPut("UpdateAccountKey")]
        public async Task<IActionResult> UpdateAccountKey([FromBody] TblAssetAccountkey acckey)
        {
            APIResponse apiResponse = null;
            if (acckey == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _assetAccountkeyRepository.Update(acckey);
                if (_assetAccountkeyRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = acckey };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAccountKey/{code}")]
        public async Task<IActionResult> DeleteAccountKey(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _assetAccountkeyRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _assetAccountkeyRepository.Remove(record);
                if (_assetAccountkeyRepository.SaveChanges() > 0)
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
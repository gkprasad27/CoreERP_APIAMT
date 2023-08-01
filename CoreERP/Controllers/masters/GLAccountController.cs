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
    [Route("api/GLAccount")]
    public class GLAccountController : ControllerBase
    {
        private readonly IRepository<GlaccGroup> _glagRepository;
        private readonly IRepository<Glaccounts> _glaccountsRepository;
        public GLAccountController(IRepository<Glaccounts> glaccountsRepository, IRepository<GlaccGroup> glagRepository)
        {
            _glaccountsRepository = glaccountsRepository;
            _glagRepository = glagRepository;
        }
        [HttpGet("GetGLAccountList")]
        public async Task<IActionResult> GetGlAccountList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var glList = CommonHelper.GetGlAccounts();
                    if (glList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.glList = glList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterGLAccount")]
        public async Task<IActionResult> RegisterGlAccount([FromBody]Glaccounts glacunts)
        {
            if (glacunts == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(glacunts)} cannot be null" });
            try
            {
                _glaccountsRepository.Add(glacunts);
                APIResponse apiResponse;
                if (_glaccountsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = glacunts };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateGLAccount")]
        public async Task<IActionResult> UpdateGlAccount([FromBody] Glaccounts glacunts)
        {
            if (glacunts == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _glaccountsRepository.Update(glacunts);
                APIResponse apiResponse;
                if (_glaccountsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = glacunts };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteGLAccount/{code}")]
        public async Task<IActionResult> DeleteGlAccount(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _glaccountsRepository.GetSingleOrDefault(x => x.AccountNumber.Equals(code));
                _glaccountsRepository.Remove(record);
                APIResponse apiResponse;
                if (_glaccountsRepository.SaveChanges() > 0)
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
        
        [HttpGet("GetaccountNumberList/{code}/{code1}")]
        public IActionResult GetaccountNumberList(string code, int code1)
        {
            try
            {
                var getaccnolist = _glagRepository.Where(x => x.GroupCode == code).FirstOrDefault();
                //if (!Enumerable.Range(Convert.ToInt32(getaccnolist?.NumberRange)).Contains(code1))
                //    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "incorrect data."});
                if (code1 >= Convert.ToInt32(getaccnolist?.NumberRange) && code1 <= Convert.ToInt32(getaccnolist.NumberRange))
                {
                    return Ok();
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
            }

            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
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
    [Route("api/GLAccount")]
    public class GLAccountController : ControllerBase
    {
        private readonly IRepository<GlaccGroup> _glagRepository;
        private readonly IRepository<TblChartAccount> _chartAccountRepository;
        private readonly IRepository<Glaccounts> _glaccountsRepository;
        public GLAccountController(IRepository<Glaccounts> glaccountsRepository,
         IRepository<TblChartAccount> chartAccountRepository, IRepository<GlaccGroup> glagRepository)
        {
            _glaccountsRepository = glaccountsRepository;
            _chartAccountRepository = chartAccountRepository;
            _glagRepository = glagRepository;
        }
        [HttpGet("GetGLAccountList")]
        public async Task<IActionResult> GetGLAccountList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var glList = _glaccountsRepository.GetAll();
                    if (glList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.glList = glList;
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

        [HttpPost("RegisterGLAccount")]
        public async Task<IActionResult> RegisterGLAccount([FromBody]Glaccounts glacunts)
        {
            APIResponse apiResponse;
            if (glacunts == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(glacunts)} cannot be null" });
            else
            {
                try
                {
                    _glaccountsRepository.Add(glacunts);
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
        }

        [HttpPut("UpdateGLAccount")]
        public async Task<IActionResult> UpdateGLAccount([FromBody] Glaccounts glacunts)
        {
            APIResponse apiResponse = null;
            if (glacunts == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _glaccountsRepository.Update(glacunts);
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
        public async Task<IActionResult> DeleteGLAccount(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _glaccountsRepository.GetSingleOrDefault(x => x.AccountNumber.Equals(code));
                _glaccountsRepository.Remove(record);
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

        [HttpGet("GetChartAccountList")]
        public IActionResult GetChartAccountList()
        {
            try
            {
                try
                {
                    var coalist = _chartAccountRepository.Where(x => x.Type == "Consolidated");
                    if (coalist.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.coalist = coalist;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for chartaccount." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
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
                var Getaccnolist = _glagRepository.Where(x => x.GroupCode == code).FirstOrDefault();
                //var Getassetnumrangelist = _assetNumberRangeRepository.Where(x => x.Code == Getaccnolist.NumberRange).FirstOrDefault();
                if (Enumerable.Range(Convert.ToInt32(Getaccnolist.NumberRangeFrom), Convert.ToInt32(Getaccnolist.NumberRangeTo)).Contains(code1))
                {
                    if (code1 >= Convert.ToInt32(Getaccnolist.NumberRangeFrom) && code1 <= Convert.ToInt32(Getaccnolist.NumberRangeTo))
                    {
                        return Ok();
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                //return Ok();
            }

            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
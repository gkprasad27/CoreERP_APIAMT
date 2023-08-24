using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/GLSubAccount")]
    public class GLSubAccountController : ControllerBase
    {
        private readonly IRepository<TblGlsubAccount> _glsubAccountRepository;
        public GLSubAccountController(IRepository<TblGlsubAccount> glsubAccountRepository)
        {
            _glsubAccountRepository = glsubAccountRepository;
        }
       
        [HttpPost("RegisterGLSubAccount")]
        public IActionResult RegisterGlSubAccount([FromBody]TblGlsubAccount glsub)
        {
            if (glsub == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _glsubAccountRepository.Add(glsub);
                if (_glsubAccountRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = glsub };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLSubAccountList")]
        public IActionResult GetGlSubAccountList()
        {
            try
            {
                var subAccountList = CommonHelper.GetGlSubAccounts();
                if (subAccountList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.SubAccountList = subAccountList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateGLSubAccount")]
        public IActionResult UpdateGlSubAccount([FromBody] TblGlsubAccount glsub)
        {
            if (glsub == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(glsub)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _glsubAccountRepository.Update(glsub);
                if (_glsubAccountRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = glsub };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteGLSubAccount/{code}")]
        public IActionResult DeleteGlSubAccountbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _glsubAccountRepository.GetSingleOrDefault(x => x.GlsubCode.Equals(code));
                _glsubAccountRepository.Remove(record);
                if (_glsubAccountRepository.SaveChanges() > 0)
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
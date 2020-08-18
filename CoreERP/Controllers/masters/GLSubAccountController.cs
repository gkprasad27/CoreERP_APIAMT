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
    [Route("api/GLSubAccount")]
    public class GLSubAccountController : ControllerBase
    {
        private readonly IRepository<TblGlsubAccount> _glsubAccountRepository;
        public GLSubAccountController(IRepository<TblGlsubAccount> glsubAccountRepository)
        {
            _glsubAccountRepository = glsubAccountRepository;
        }
        [HttpPost("RegisterGLSubAccount")]
        public IActionResult RegisterGLSubAccount([FromBody]TblGlsubAccount glsub)
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
        public IActionResult GetGLSubAccountList()
        {
            try
            {
                var SubAccountList = _glsubAccountRepository.GetAll();
                if (SubAccountList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.SubAccountList = SubAccountList;
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

        [HttpPut("UpdateGLSubAccount")]
        public IActionResult UpdateGLSubAccount([FromBody] TblGlsubAccount glsub)
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
        public IActionResult DeleteGLSubAccountbyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _glsubAccountRepository.GetSingleOrDefault(x => x.Glaccount.Equals(code));
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
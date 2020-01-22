using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/gl/GLSubCode")]
    public class GLSubCodeController : Controller
    {
        [HttpPost("RegisterGlsubCode")]
        public async Task<IActionResult> RegisterGlsubCode([FromBody]GlsubCode glsubcode)
        {
            if (glsubcode == null)
                return Ok(new APIResponse() { status=APIStatus.FAIL.ToString(),response="Requst can not be empty."});
            try
            {
                if(GLHelper.GetGLSubCodeList(glsubcode.SubCode).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Code ={glsubcode.SubCode} alredy exists." });

                GlsubCode result = GLHelper.RegisterGLSubCode(glsubcode);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
     
        [HttpPut("UpdateGLSubCode")]
        public async Task<IActionResult> UpdateGLSubCode([FromBody] GlsubCode subcode)
        {
            if (subcode == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(subcode)} cannot be null"});

            try
            {
                GlsubCode result = GLHelper.UpdateGLSubCode(subcode);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response =result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteGLSubCode/{code}")]
        public async Task<IActionResult> DeleteGLSubCode(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)} cannot be null"});

            try
            {
                GlsubCode result = GLHelper.DeleteGLSubCode(code);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed."});
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLSubCodeList")]
        public async Task<IActionResult> GetGLSubCodeList()
        {
            try
            {
                var subCodeList = GLHelper.GetGLSubCodeList();
                if (subCodeList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.GLSubCodeList = subCodeList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
     
        [HttpGet("GetGLUnderSubGroupList")]
        public async Task<IActionResult> GetGLUnderSubGroupList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLUnderSubGroupList = GLHelper.GetGLUnderSubGroupList().Select(x=> new { ID=x.UnderSubGroupCode,TEXT=x.UnderSubGroupName});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
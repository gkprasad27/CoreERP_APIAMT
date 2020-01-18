using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;
using CoreERP.BussinessLogic.GenerlLedger;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/gl/GLAccounts")]
    public class GLAccountsController : ControllerBase
    {
        [HttpPost("RegisterGlaccounts")]
        public async Task<IActionResult> RegisterGlaccounts([FromBody]Glaccounts glaccounts)
        {
            if (glaccounts == null)
                return  Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(glaccounts)} can not be null"});
            try
            {
                if(GLHelper.GetGLAccountsList(glaccounts.Glcode).Count > 0)
                    return Ok(new APIResponse() { status=APIStatus.FAIL.ToString(),response=$"Gl Code{glaccounts.Glcode} ALready Exists."});

                Glaccounts result = GLHelper.RegisterGLAccounts(glaccounts);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="Rgistration Failed." });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }
        }

        [HttpGet("GetGLAccountsList")]
        public async Task<IActionResult> GetGLAccountsList()
        {
            try
            {
                var glAccountsList = GLHelper.GetGLAccountsList();
                if (glAccountsList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.GLAccountsList = glAccountsList;
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateGLAccounts")]
        public async Task<IActionResult> UpdateGLAccounts( [FromBody] Glaccounts glaccounts)
        {
            if (glaccounts == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(glaccounts)} can not be null" });

            try
            {
                Glaccounts result = GLHelper.UpdateGLAccounts(glaccounts);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteGlAccount/{code}")]
        public async Task<IActionResult> DeleteGlAccount(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} can not be null" });

            try
            {
                Glaccounts result = GLHelper.DeleteGLAccounts(code);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetAccountGroupList")]
        public async Task<IActionResult> GetAccountGroupList()
        {
            try
            {
                dynamic expnado = new ExpandoObject();
                expnado.GLUnderSubGroupList = GLHelper.GetGLUnderSubGroupList().Select(x=> new { ID=x.UnderSubGroupCode,TEXT=x.UnderSubGroupName});
                return Ok(new APIResponse{ status=APIStatus.PASS.ToString(),response= expnado });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
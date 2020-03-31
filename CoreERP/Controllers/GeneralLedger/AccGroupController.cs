using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;
using CoreERP.BussinessLogic.GenerlLedger;
using System.Dynamic;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/gl/AccGroup")]
    public class AccGroupController : ControllerBase
    {
        [HttpPost("RegisterGlaccGroup")]
        public async Task<IActionResult> RegisterGlaccGroup([FromBody]GlaccGroup accGroup)
        {
            var result = await Task.Run(() =>
            {
                if (accGroup == null)
                return Ok(new APIResponse() {status=APIStatus.FAIL.ToString(),response= $"{nameof(accGroup)} cannot be null" });
            try
            {
                if (GLHelper.GetGLAccountGroupList().Where(x => x.GroupCode == accGroup.GroupCode).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Code {accGroup.GroupCode} is already exists"});

                GlaccGroup result = GLHelper.RegisterAccountsGroup(accGroup);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });

            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            });
            return result;
        }

        [HttpGet("GetAccountGroupList")]
        public async Task<IActionResult> GetAccountGroupList()
        {
            var result = await Task.Run(() =>
            {
                try
            {
                var glAccountGroupList = GLHelper.GetGLAccountGroupList();
                if (glAccountGroupList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.GLAccountGroupList = glAccountGroupList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found."});
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            });
            return result;
        }

        [HttpPut("UpdateAccountGroup")]
        public async Task<IActionResult> UpdateAccountGroup([FromBody] GlaccGroup accGroup)
        {
            var result = await Task.Run(() =>
            {
                if (accGroup == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(accGroup)} cannot be null" });

                try
                {
                    GlaccGroup result = GLHelper.UpdateAccountsGroup(accGroup);
                    if (result != null)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }


        [HttpDelete("DeleteAccountGroup/{code}")]
        public async Task<IActionResult> DeleteAccountGroup(string code)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(code))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

                try
                {
                    GlaccGroup result = GLHelper.DeleteAccountsGroup(code);
                    if (result != null)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "DeletionFailed." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
    }
}
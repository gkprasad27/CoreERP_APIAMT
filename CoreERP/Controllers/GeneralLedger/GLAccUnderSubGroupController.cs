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
    [Route("api/gl/GLAccUnderSubGroup")]
    public class GLAccUnderSubGroupController : ControllerBase
    {
        [HttpPost("gl/accundSubgp/register")]
        public async Task<IActionResult> Register([FromBody]GlaccUnderSubGroup glaccUnderSubGroup)
        {
            if (glaccUnderSubGroup == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(glaccUnderSubGroup)}cannot be null" });
            try
            {
                if(GLHelper.GetGLUnderSubGroupList(glaccUnderSubGroup.UnderSubGroupCode).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Under SubGroup Code{glaccUnderSubGroup.UnderSubGroupCode} already exists." });

                GlaccUnderSubGroup result = GLHelper.RegisterUnderSubGroup(glaccUnderSubGroup);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result});

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
      
        [HttpPut("UpdateGLAccUnderSubGroup")]
        public async Task<IActionResult> UpdateGLAccUnderSubGroup([FromBody] GlaccUnderSubGroup glaccUnderSubGroup)
        {
            if (glaccUnderSubGroup == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(glaccUnderSubGroup)} cannot be null"});

            try
            {
                GlaccUnderSubGroup result = GLHelper.UpdateUnderSubGroup(glaccUnderSubGroup);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteGLAccUnderSubGroup/{code}")]
        public async Task<IActionResult> DeleteGLAccUnderSubGroup(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                GlaccUnderSubGroup result = GLHelper.DeleteUnderSubGroup(code);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
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
                var glUnderSubGroupList = GLHelper.GetGLUnderSubGroupList();
                if (glUnderSubGroupList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.GLUnderSubGroupList = glUnderSubGroupList;
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLAccountGrouplist")]
        public async Task<IActionResult> GetGLAccountGrouplist()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLAccGroupList = GLHelper.GetGLAccountGroupList().Select(a=> new { ID=a.GroupCode,TEXT=a.GroupName});
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountSubGrouplist")]
        public async Task<IActionResult> GetAccountSubGrouplist()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLAccSubGroupList = GLHelper.GetGLAccountSubGroupList().Select(a => new { ID = a.SubGroupCode, TEXT = a.SubGroupName });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
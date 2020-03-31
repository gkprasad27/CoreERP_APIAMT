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
    [Route("api/gl/GLAccSubGroup")]
    public class GLAccSubGroupController : ControllerBase
    {
        [HttpPost("RegisterGlaccSubGroup")]
        public IActionResult RegisterGlaccSubGroup([FromBody]GlaccSubGroup accSubGroup)
        {
            if (accSubGroup == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(accSubGroup)} can not be null" });

            try
            {
                if (GLHelper.GetGLAccountSubGroupList(accSubGroup.SubGroupCode).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Code {accSubGroup.SubGroupCode} is already exists" });

                GlaccSubGroup result = GLHelper.RegisterAccSubGroup(accSubGroup);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateGLAccSubGroup")]
        public IActionResult UpdateGLAccSubGroup([FromBody] GlaccSubGroup accSubGroup)
        {
            if (accSubGroup == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(accSubGroup)} can not be null" });

            try
            {
                GlaccSubGroup result = GLHelper.UpdateAccSubGroup(accSubGroup);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAccountSubGroup/{code}")]
        public IActionResult DeleteAccountSubGroup(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} can not be null" });

            try
            {
                GlaccSubGroup result = GLHelper.DeleteAccSubGroup(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLAccountSubGroupList")]
        public IActionResult GetGLAccountSubGroupList()
        {
            try
            {
                var glAccountSubGroupList = GLHelper.GetGLAccountSubGroupList();
                if (glAccountSubGroupList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.GLAccountSubGroupList = glAccountSubGroupList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLAccountGroupList")]
        public IActionResult GetGLAccountGroupList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLAccountGroupList = GLHelper.GetGLAccountGroupList().Select(x => new { ID = x.GroupCode, TEXT = x.GroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
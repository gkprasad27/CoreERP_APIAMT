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
        [HttpPost("RegisterGlaccUnderSubGroup")]
        public IActionResult RegisterGlaccUnderSubGroup([FromBody]GlaccUnderSubGroup glaccUnderSubGroup)
        {
            if (glaccUnderSubGroup == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(glaccUnderSubGroup)}cannot be null" });
            try
            {
                if (GLHelper.GetGLUnderSubGroupList(glaccUnderSubGroup.UnderSubGroupCode).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Under SubGroup Code{glaccUnderSubGroup.UnderSubGroupCode} already exists." });

                GlaccUnderSubGroup result = GLHelper.RegisterUnderSubGroup(glaccUnderSubGroup);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterTblAccGroup")]
        public IActionResult RegisterTblAccGroup([FromBody]TblAccountGroup tblAccGrp)
        {
            if (tblAccGrp == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(tblAccGrp)} can not be null" });

            try
            {
                TblAccountGroup result = new GLHelper().RegisterTblAccGroup(tblAccGrp);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateGLAccUnderSubGroup")]
        public IActionResult UpdateGLAccUnderSubGroup([FromBody] GlaccUnderSubGroup glaccUnderSubGroup)
        {
            if (glaccUnderSubGroup == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(glaccUnderSubGroup)} cannot be null" });

            try
            {
                GlaccUnderSubGroup result = GLHelper.UpdateUnderSubGroup(glaccUnderSubGroup);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateTblAccountGroup")]
        public IActionResult UpdateTblAccountGroup([FromBody] TblAccountGroup tblAccGrp)
        {
            if (tblAccGrp == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(tblAccGrp)} cannot be null" });

            try
            {
                TblAccountGroup result = new GLHelper().UpdateTblAccountGroup(tblAccGrp);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteTblAccountGroup/{code}")]
        public IActionResult DeleteTblAccountGroup(int code)
        {

            //if (string.IsNullOrWhiteSpace(code))
            //    return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                TblAccountGroup result = new GLHelper().DeleteTblAccountGroup(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteGLAccUnderSubGroup/{code}")]
        public IActionResult DeleteGLAccUnderSubGroup(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                GlaccUnderSubGroup result = GLHelper.DeleteUnderSubGroup(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLUnderSubGroupList")]
        public IActionResult GetGLUnderSubGroupList()
        {
            try
            {
                var glUnderSubGroupList = GLHelper.GetGLUnderSubGroupList();
                if (glUnderSubGroupList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.GLUnderSubGroupList = glUnderSubGroupList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTblAccountGroupList")]
        public IActionResult GetTblAccountGroupList()
        {
            try
            {
                var tblAccountGroupList = new GLHelper().GetTblAccountGroupList();
                if (tblAccountGroupList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.tblAccountGroupList = tblAccountGroupList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLAccountGrouplist")]
        public IActionResult GetGLAccountGrouplist()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLAccGroupList = GLHelper.GetGLAccountGroupList().Select(a => new { ID = a.GroupCode, TEXT = a.GroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountNamelist")]
        public IActionResult GetAccountNamelist()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GetAccountNamelist = new GLHelper().GetTblAccountGroupList().Select(a => new { ID = a.AccountGroupId, TEXT = a.AccountGroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountSubGrouplist/{glaccGroupCode}")]
        public IActionResult GetAccountSubGrouplist(string glaccGroupCode)
        {
            if (string.IsNullOrEmpty(glaccGroupCode))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Account group Can not be null/empty." });
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLAccSubGroupList = GLHelper.GetGLAccountSubGroup(glaccGroupCode).Select(a => new { ID = a.SubGroupCode, TEXT = a.SubGroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
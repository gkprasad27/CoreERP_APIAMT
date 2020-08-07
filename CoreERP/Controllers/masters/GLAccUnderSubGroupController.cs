using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/GLAccUnderSubGroup")]
    public class GLAccUnderSubGroupController : ControllerBase
    {
        private readonly IRepository<TblAccountGroup> _glaugRepository;
        public GLAccUnderSubGroupController(IRepository<TblAccountGroup> glaugRepository)
        {
            _glaugRepository = glaugRepository;
        }

        [HttpPost("RegisterTblAccGroup")]
        public IActionResult RegisterTblAccGroup([FromBody] TblAccountGroup tblAccGrp)
        {
            if (tblAccGrp == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(tblAccGrp)} can not be null" });

            try
            {
                APIResponse apiResponse;

                tblAccGrp.ExtraDate = DateTime.Now;
                tblAccGrp.IsDefault = false;

                _glaugRepository.Add(tblAccGrp);
                if (_glaugRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = tblAccGrp });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });

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
                tblAccGrp.ExtraDate = DateTime.Now;
                tblAccGrp.IsDefault = false;

                APIResponse apiResponse;
                _glaugRepository.Update(tblAccGrp);
                if (_glaugRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = tblAccGrp });

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
                APIResponse apiResponse;
                var record = _glaugRepository.GetSingleOrDefault(x => x.AccountGroupId.Equals(code));
                _glaugRepository.Remove(record);
                if (_glaugRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = record });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLUnderSubGroupList/{undersubgroup}")]
        public IActionResult GetGLUnderSubGroupList(int undersubgroup)
        {
            try
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.GetAccountNamelist = new GLHelper().GetGLUnderSubGroupList(undersubgroup).Select(a => new { ID = a.AccountGroupId, TEXT = a.AccountGroupName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
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

        [HttpGet("GetTblAccountGroupList")]
        public IActionResult GetTblAccountGroupList()
        {
            try
            {
                var tblAccountGroupList = new GLHelper().GetTblAccountGroupList();
                if (tblAccountGroupList != null)
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

        [HttpGet("GetAccountNamelist/{nature}")]
        public IActionResult GetAccountNamelist(string nature)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GetAccountNamelist = new GLHelper().GetTblAccountGroupList(nature).Select(a => new { ID = a.AccountGroupId, TEXT = a.AccountGroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountGrouplist/{glaccGroupCode}")]
        public IActionResult GetAccountSubGrouplist(int glaccGroupCode)
        {

            try
            {
                dynamic expando = new ExpandoObject();
                expando.GetAccountSubGrouplist = new GLHelper().GetGLUnderSubGroupList(glaccGroupCode).Select(a => new { ID = a.AccountGroupId, TEXT = a.AccountGroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
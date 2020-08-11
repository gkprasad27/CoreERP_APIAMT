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
        private readonly IRepository<GlaccGroup> _glgroupRepository;
        public GLAccUnderSubGroupController(IRepository<TblAccountGroup> glaugRepository,IRepository<GlaccGroup>glgroupRepository)
        {
            _glaugRepository = glaugRepository;
            _glgroupRepository = glgroupRepository;
        }

        [HttpPost("RegisterTblAccGroup")]
        public IActionResult RegisterTblAccGroup([FromBody] TblAccountGroup tblAccGrp)
        {
            if (tblAccGrp == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(tblAccGrp)} can not be null" });

            try
            {
                APIResponse apiResponse;

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
        public IActionResult GetGLUnderSubGroupList(string undersubgroup)
        {
            try
            {
                try
                {
                    var GetAccountNamelist = _glaugRepository.Where(x=>x.GroupUnder== undersubgroup);
                    if (GetAccountNamelist.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.GetAccountNamelist = GetAccountNamelist;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
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
                
                var tblAccountGroupList = _glaugRepository.GetAll().OrderBy(x=>x.Nature);
                if (tblAccountGroupList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.tblAccountGroupList = tblAccountGroupList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
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
                
                var GLAccGroupList = _glgroupRepository.GetAll().OrderBy(x => x.GroupCode);
                if (GLAccGroupList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.GLAccGroupList = GLAccGroupList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
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
              
                var GetAccountNamelist = _glaugRepository.Where(x => x.Nature == nature);
                if (GetAccountNamelist.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.GetAccountNamelist = GetAccountNamelist;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountGrouplist/{glaccGroupCode}")]
        public IActionResult GetAccountSubGrouplist(string glaccGroupCode)
        {

            try
            {
               
                var GetAccountSubGrouplist = _glaugRepository.Where(x => x.GroupUnder == glaccGroupCode);
                if (GetAccountSubGrouplist.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.GetAccountSubGrouplist = GetAccountSubGrouplist;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
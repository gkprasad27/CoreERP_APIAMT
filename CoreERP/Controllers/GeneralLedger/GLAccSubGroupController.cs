using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;
using CoreERP.BussinessLogic.GenerlLedger;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/GLAccSubGroup")]
    public class GLAccSubGroupController : ControllerBase
    {/*
        [HttpPost("generalledger/accsubgroup/register")]
        public async Task<IActionResult> Register([FromBody]GlaccSubGroup accSubGroup)
        {
            if (accSubGroup == null)
                return BadRequest($"{nameof(accSubGroup)} can not be null");

            try
            {
                //if (_unitOfWork.GLSubAccounts.GetAll().Where(x => x.SubGroupCode == accSubGroup.SubGroupCode).Count() > 0)
                //    return BadRequest($"Code {accSubGroup.SubGroupCode} is already exists ,Please Use different code");

                if (GLHelper.GetGLAccountSubGroupList().Where(x => x.SubGroupCode == accSubGroup.SubGroupCode).Count() > 0)
                    return BadRequest($"Code {accSubGroup.SubGroupCode} is already exists,Please use different code");

                int result = GLHelper.RegisterAccSubGroup(accSubGroup);
                if (result > 0)
                    return Ok(accSubGroup);

            }
            catch { }

            return BadRequest("Registration Failed");

        }

        [HttpGet("generalledger/accsubgroup")]
        public async Task<IActionResult> GetAllAccountSubGroup()
        {

            return Ok(
                 new
                 {
                     glAccountSubGroup = GLHelper.GetGLAccountSubGroupList()

                 });
        }

        [HttpPut("generalledger/accsubgroup/{code}")]
        public async Task<IActionResult> UpdateGLAccSubGroup(string code, [FromBody] GlaccSubGroup accSubGroup)
        {
            if (accSubGroup == null)
                return BadRequest($"{nameof(accSubGroup)} cannot be null");

            if (!string.IsNullOrWhiteSpace(accSubGroup.SubGroupCode) && code != accSubGroup.SubGroupCode)
                return BadRequest("Conflicting role id in parameter and model data");


            try
            {
                int result = GLHelper.UpdateAccSubGroup(accSubGroup);
                if (result > 0)
                    return Ok(accSubGroup);
            }
            catch { }

            return BadRequest("Updation Failed");
        }


        [HttpDelete("generalledger/accsubgroup/{code}")]
        public async Task<IActionResult> DeleteAccountSubGroupID(string code)
        {
            
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                //var result = _unitOfWork.GLSubAccounts.GetAll();
                //var subaccount = (from t in result
                //                      where t.SubGroupCode == code
                //                      select t).FirstOrDefault();
                //_unitOfWork.GLSubAccounts.Remove(subaccount);
                //if (_unitOfWork.SaveChanges() > 0)
                //    return Ok(subaccount);
                //else
                //    return BadRequest("Delete Operation Failed");
                int result = GLHelper.DeleteAccSubGroup(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");


        }


        [HttpGet("generalledger/accsubgroup/accgrplist")]

        public async Task<IActionResult> GetAllAccountGrouplist()
        {
            try
            {
                return Ok(new { accGroupList = GLHelper.GetGLAccountGroupList() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Account Group List.");
            }
        }
        //public async Task<IActionResult> GetAllAccountGrouplist()
        //{
        //    try
        //    {
        //        var accgrplist = _unitOfWork.AccGroup.GetAll();
        //        if (accgrplist == null)
        //            return NotFound("Data Not Found");

        //        return Ok(accgrplist);
        //    }
        //    catch(Exception ex)
        //    {
        //        return NotFound("Data Not Found");
        //    }


        //}
        */
    }
}
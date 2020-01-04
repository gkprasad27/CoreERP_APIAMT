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
    [Route("api/AccGroup")]
    public class AccGroupController : ControllerBase
    {
        [HttpPost("gl/accgroups/register")]
        public async Task<IActionResult> Register([FromBody]GlaccGroup accGroup)
        {
            //    if (accGroup == null)
            //        return BadRequest($"{nameof(accGroup)} can not be null");

            //    try
            //    {
            //        if (GLHelper.AccGroup.GetAll().Where(x => x.GroupCode == accGroup.GroupCode).Count() > 0)
            //            return BadRequest($"Code {accGroup.GroupCode} is already exists,Please use different code");

            //        _unitOfWork.AccGroup.Add(accGroup);
            //        if (_unitOfWork.SaveChanges() > 0)
            //            return Ok(accGroup);
            //        else
            //            return BadRequest(" Registration Operation Failed");
            //    }
            //    catch (Exception ex)
            //    {
            //        return BadRequest(" Registration Operation Failed");
            //    }

            //}
            if (accGroup == null)
                return BadRequest($"{nameof(accGroup)} cannot be null");
            try
            {
                if(GLHelper.GetGLAccountGroupList().Where(x=>x.GroupCode==accGroup.GroupCode).Count()>0)
                    return BadRequest($"Code {accGroup.GroupCode} is already exists,Please use different code");
                int result = GLHelper.RegisterAccountsGroup(accGroup);
                if (result > 0)
                    return Ok(accGroup);

            }
            catch { }

            return BadRequest("Registration Failed");
        }



        [HttpGet("gl/accgroups")]
        public async Task<IActionResult> GetAllAccountGroup()
        {

            return Ok(
                 new
                 {
                     glAccountGroup = GLHelper.GetGLAccountGroupList()

                 });
        }

        [HttpPut("gl/accgroups/{code}")]
        public async Task<IActionResult> UpdateAccountGroup(string code, [FromBody] GlaccGroup accGroup)
        {
            if (accGroup == null)
                return BadRequest($"{nameof(accGroup)} cannot be null");

            if (!string.IsNullOrWhiteSpace(accGroup.GroupCode) && code != accGroup.GroupCode)
                return BadRequest("Conflicting role id in parameter and model data");


            try
            {
                int result = GLHelper.UpdateAccountsGroup(accGroup);
                if (result > 0)
                    return Ok(accGroup);
            }
            catch { }

            return BadRequest("Updation Failed");
        }


        [HttpDelete("gl/accgroups/{code}")]
        public async Task<IActionResult> DeleteAccountGroupID(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                //var result = _unitOfWork.AccGroup.GetAll();
                //var glaccounts = (from t in result
                //                  where t.GroupCode == code
                //                  select t).FirstOrDefault();
                //_unitOfWork.AccGroup.Remove(glaccounts);
                //if (_unitOfWork.SaveChanges() > 0)
                //    return Ok(glaccounts);
                //else
                //    return BadRequest("Delete Operation Failed");
               
                int result = GLHelper.DeleteAccountsGroup(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");


        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;
using CoreERP.BussinessLogic.GenerlLedger;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/GLAccUnderSubGroup")]
    public class GLAccUnderSubGroupController : ControllerBase
    {
        [HttpPost("gl/accundSubgp/register")]
        public async Task<IActionResult> Register([FromBody]GlaccUnderSubGroup glaccUnderSubGroup)
        {
            if (glaccUnderSubGroup == null)
                return BadRequest("cannot be null");
            try
            {
                int result = GLHelper.RegisterUnderSubGroup(glaccUnderSubGroup);
                if (result > 0)
                    return Ok(glaccUnderSubGroup);

            }
            catch
            {
            }
            return BadRequest("Registration Failed");

        }


        [HttpGet("gl/accundSubgp")]
        public async Task<IActionResult> GetAllGLAccUnderSubGroup()
        {
            return Ok(
               new
               {
                   glUnderSubGroup = GLHelper.GetGLUnderSubGroupList()

               });
        }

        [HttpPut("gl/accundSubgp/{code}")]
        public async Task<IActionResult> UpdateGLAccUnderSubGroup(string code, [FromBody] GlaccUnderSubGroup glaccUnderSubGroup)
        {
            if (glaccUnderSubGroup == null)
                return BadRequest($"{nameof(glaccUnderSubGroup)} cannot be null");


            try
            {
                int result = GLHelper.UpdateUnderSubGroup(glaccUnderSubGroup);
                if (result > 0)
                    return Ok(glaccUnderSubGroup);
            }
            catch { }

            return BadRequest("Updation Failed");
        }


        [HttpDelete("gl/accundSubgp/{code}")]
        public async Task<IActionResult> DeleteGLAccUnderSubGroupByID(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                int result = GLHelper.DeleteUnderSubGroup(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");


        }



        [HttpGet("gl/accundSubgp/accgrplist")]
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


        [HttpGet("gl/accundSubgp/accsubgrplist")]
        public async Task<IActionResult> GetAllAccountSubGrouplist()
        {
            try
            {
                return Ok(new { accGroupList = GLHelper.GetGLAccountSubGroupList() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Account Subgroup List.");
            }
        }
    }
}
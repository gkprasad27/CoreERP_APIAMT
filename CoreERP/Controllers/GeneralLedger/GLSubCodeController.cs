using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/GLSubCode")]
    public class GLSubCodeController : Controller
    {
     /*   [HttpPost("gl/glsubcode/register")]
        public async Task<IActionResult> Register([FromBody]GlsubCode subcode)
        {
            try
            {
                int result = GLHelper.RegisterGLSubCode(subcode);
                if (result > 0)
                    return Ok(subcode);
            }
            catch
            {
            }
            return BadRequest("Registration Failed");

        }



        [HttpGet("gl/glsubcode")]
        public async Task<IActionResult> GetAllGLSubCode()
        {
            return Ok(
               new
               {
                   glsubCode = GLHelper.GetGLSubCodeList()

               });
        }

        [HttpPut("gl/glsubcode/{code}")]
         public async Task<IActionResult> UpdateGLSubCode(string code, [FromBody] GlsubCode subcode)
        {
            if (subcode == null)
                return BadRequest($"{nameof(subcode)} cannot be null");

            try
            {
                int result = GLHelper.UpdateGLSubCode(subcode);
                if (result > 0)
                    return Ok(subcode);
            }
            catch { }

            return BadRequest("Updation Failed");
        }


        [HttpDelete("gl/glsubcode/{code}")]
        public async Task<IActionResult> DeleteGLSubCodeID(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                int result = GLHelper.DeleteGLSubCode(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");

        }



        [HttpGet("gl/glsubcode/glacclist")]
        //[Produces(typeof(List<GLAccUnderSubGroup>))]
        public async Task<IActionResult> GetAllGLAccounts()
        {
            //return Ok(_unitOfWork.GLAccounts.GetAll());
            try
            {
                return Ok(new { glAccounts = GLHelper.GetGLUnderSubGroupList() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Account Subgroup List.");
            }
        }*/
    }
}
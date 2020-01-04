using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;
using CoreERP.BussinessLogic.GenerlLedger;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/GLAccounts")]
    public class GLAccountsController : ControllerBase
    {
        [HttpPost("generalledger/glaccounts/register")]
        public async Task<IActionResult> Register([FromBody]Glaccounts glaccounts)
        {
            if (glaccounts == null)
                return BadRequest($"{nameof(glaccounts)} can not be null");
            try
            {
                int result = GLHelper.RegisterGLAccounts(glaccounts);
                if (result > 0)
                    return Ok(glaccounts);
            }
            catch
            {
            }
            return BadRequest("Registration Failed");

        }

        [HttpGet("generalledger/glaccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok(
                new
                {
                    glAcc = GLHelper.GetGLAccountsList()

                });
        }

        [HttpPut("generalledger/glaccounts/{code}")]
        public async Task<IActionResult> UpdateAccounts(string code, [FromBody] Glaccounts glaccounts)
        {
            if (glaccounts == null)
                return BadRequest($"{nameof(glaccounts)} cannot be null");

            if (!string.IsNullOrWhiteSpace(glaccounts.Glcode) && code != glaccounts.Glcode)
                return BadRequest("Conflicting role id in parameter and model data");


            try
            {
                int result = GLHelper.UpdateGLAccounts(glaccounts);
                if (result > 0)
                    return Ok(glaccounts);
            }
            catch { }

            return BadRequest("Updation Failed");
        }


        [HttpDelete("generalledger/glaccounts/{code}")]
        public async Task<IActionResult> DeleteAccountByID(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                int result = GLHelper.DeleteGLAccounts(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");

        }


        [HttpGet("generalledger/glaccounts/accsubgrplist")]
        public async Task<IActionResult> GetAllAccountGroup()
        {
            try
            {
                return Ok(new { glAccUndersubList = GLHelper.GetGLUnderSubGroupList() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Account Under Subgroup List.");
            }

        }
    }
}
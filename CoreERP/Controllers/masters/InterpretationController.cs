using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/Interpretation")]
    public class InterpretationController : ControllerBase
    {
        //[HttpPut("masters/{ID}")]
        //public async Task<IActionResult> Update(string ID, [FromBody] Company company)
        //{
        //    return NoContent();
        //}      

        
        [HttpPost("masters/interpretation/register")]
        public async Task<IActionResult> Register([FromBody]Interpretation interpretation)  
        {
            if (interpretation == null)
                return BadRequest($"{nameof(interpretation)} can not be null");
            try
            {
                int result = InterpretationHelper.RegisterInterpretation(interpretation);
                if (result > 0)
                    return Ok(interpretation);

                return BadRequest("Registration Failed");
            }
            catch
            {
                return BadRequest("Registration Failed");
            }
        }



        [HttpGet("masters/interpretation")]
        public async Task<IActionResult> GetAllInterpretation()
        {            
            return Ok(
                new {
                   interpretation= InterpretationHelper.GetInterpretationList()
                  // glaccounts = _unitOfWork.GLAccounts.GetAll()
                    
                });
        }

        [HttpPut("masters/interpretation/{code}")]
        public async Task<IActionResult> UpdateInterpretation(string code, [FromBody] Interpretation interpretation)
        {
            try
            {
                if (interpretation == null)
                    return BadRequest($"{nameof(interpretation)} cannot be null");

                int rs =InterpretationHelper.UpdateInterpretation(interpretation);
                if (rs > 0)
                    return Ok(interpretation);

                return BadRequest("Updation Failed");
            }
            catch
            {
                return BadRequest("Updation Failed");
            }
        }


        [HttpDelete("masters/interpretation/{code}")]
        public async Task<IActionResult> DeleteInterpretation(string code)
        {
            try
            {
               int result = InterpretationHelper.DeleteInterpretation(code);
               if (result > 0)
                        return Ok(code);
            }
            catch
            {

            }

            return BadRequest("Delete Failed");
        }
    }
}

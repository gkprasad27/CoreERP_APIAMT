using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/masters/Interpretation")]
    public class InterpretationController : ControllerBase
    {
        //[HttpPut("masters/{ID}")]
        //public async Task<IActionResult> Update(string ID, [FromBody] Company company)
        //{
        //    return NoContent();
        //}      

        
        [HttpPost("RegisterInterpretation")]
        public async Task<IActionResult> RegisterInterpretation([FromBody]Interpretation interpretation)  
        {
            APIResponse apiResponse = null;
            if (interpretation == null)
                return BadRequest($"{nameof(interpretation)} can not be null");
            try
            {
                int result = InterpretationHelper.RegisterInterpretation(interpretation);
                if (result > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

                return Ok(apiResponse);
            }
            catch
            {
                return BadRequest("Registration Failed");
            }
        }



        [HttpGet("GetInterpretationList")]
        public async Task<IActionResult> GetInterpretationList()
        {
            try
            {
                var interpretationList = InterpretationHelper.GetInterpretationList();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.interpretationList = interpretationList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch
            {
                return BadRequest("No Data  Found");
            }

        }

        [HttpPut("UpdateInterpretation/{code}")]
        public async Task<IActionResult> UpdateInterpretation(string code, [FromBody] Interpretation interpretation)
        {
            APIResponse apiResponse = null;
            try
            {
                if (interpretation == null)
                    return BadRequest($"{nameof(interpretation)} cannot be null");

                int rs =InterpretationHelper.UpdateInterpretation(interpretation);
                if (rs > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch
            {
                return BadRequest("Updation Failed");
            }
        }


        [HttpDelete("DeleteInterpretation/{code}")]
        public async Task<IActionResult> DeleteInterpretation(string code)
        {
            APIResponse apiResponse = null;
            try
            {
               int result = InterpretationHelper.DeleteInterpretation(code);
                if (result > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch
            {

            }

            return BadRequest("Delete Failed");
        }
    }
}

using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult RegisterInterpretation([FromBody]Interpretation interpretation)
        {
            if (interpretation == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });
            try
            {
                int result = InterpretationHelper.RegisterInterpretation(interpretation);
                APIResponse apiResponse;
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
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpGet("GetInterpretationList")]
        public IActionResult GetInterpretationList()
        {
            try
            {
                var interpretationList = InterpretationHelper.GetInterpretationList();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.interpretationList = interpretationList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpPut("UpdateInterpretation")]
        public IActionResult UpdateInterpretation([FromBody] Interpretation interpretation)
        {
            try
            {
                if (interpretation == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

                int rs = InterpretationHelper.UpdateInterpretation(interpretation);
                APIResponse apiResponse;
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
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteInterpretation/{code}")]
        public IActionResult DeleteInterpretation(string code)
        {
            try
            {
                int result = InterpretationHelper.DeleteInterpretation(code);
                APIResponse apiResponse;
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
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}

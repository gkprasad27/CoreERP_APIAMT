using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/StateWiseGst")]
    public class StateWiseGstController : Controller
    {
        [HttpGet("GetStateWiseGstList")]
        public async Task<IActionResult> GetStateWiseGstList()
        {
            try
            {
                var stateWiseGstList = new StateWiseGstHelper().GetStatesWiseGstList();
                if (stateWiseGstList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.stateWiseGstList = stateWiseGstList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStatesList")]
        public async Task<IActionResult> GetStatesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.StatesList = new StateWiseGstHelper().GetStatesList().Select(x => new { ID = x.Id, TEXT = x.StateName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterStateWiseGst")]
        public async Task<IActionResult> RegisterStateWiseGst([FromBody]TblStateWiseGst stateWiseGst)
        {

            if (stateWiseGst == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(stateWiseGst)} cannot be null" });
            try
            {
                var reponse = new StateWiseGstHelper().Register(stateWiseGst);
                if (reponse != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = reponse });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpPut("UpdateStateWiseGst")]
        public async Task<IActionResult> UpdateStateWiseGst([FromBody] TblStateWiseGst stateWiseGst)
        {

            if (stateWiseGst == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(stateWiseGst)} cannot be null" });
            try
            {
                APIResponse apiResponse = null;

                TblStateWiseGst result = new StateWiseGstHelper().Update(stateWiseGst);
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteStateWiseGst/{code}")]
        public async Task<IActionResult> DeleteStateWiseGst(int code)
        {
            APIResponse apiResponse = null;
            if (code == 0)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = new StateWiseGstHelper().Delete(code);
                if (result != null)
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
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
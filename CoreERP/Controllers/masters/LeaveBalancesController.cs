using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.masters
{
    [Route("api/masters/LeaveBalances")]
    [ApiController]
    public class LeaveBalancesController : ControllerBase
    {
        [HttpGet("GetLeaveBalancesList")]
        public async Task<IActionResult> GetLeaveBalancesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.lopList = new LeaveBalancesHelper().GetLeaveOpeningBalancesList().ToList();
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetLeavetpeList/{code}")]
        public async Task<IActionResult> GetLeavetpeList(string code)
        {

            if (string.IsNullOrEmpty(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

            try
            {
                string errorMessage = string.Empty;
                dynamic expando = new ExpandoObject();
                expando.leavetypesList = new LeaveBalancesHelper().GetListOfleavetypes(code, out errorMessage);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterLeaveBalancesList")]
        public IActionResult RegisterLeaveBalancesList([FromBody]LeaveBalanceMaster lbm)
        {
            if (lbm == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (new LeaveBalancesHelper().GetList(lbm.LeaveCode).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"LeaveCode Code {nameof(lbm.LeaveCode)} is already exists ,Please Use Different Code " });

                var result = new LeaveBalancesHelper().Register(lbm);
                APIResponse apiResponse;
                if (result != null)
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


        [HttpPut("UpdateLeaveBalancesList")]
        public IActionResult UpdateLeaveBalancesList([FromBody] LeaveBalanceMaster lbm)
        {
            if (lbm == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(lbm)} cannot be null" });

            try
            {
                var rs = new LeaveBalancesHelper().Update(lbm);
                APIResponse apiResponse;
                if (rs != null)
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


        [HttpDelete("DeleteLeaveBalancesList/{code}")]
        public IActionResult DeleteLeaveBalancesList(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = new LeaveBalancesHelper().Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
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
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

        [HttpPost("RegisterLeaveBalancesList")]
        public IActionResult RegisterLeaveBalancesList([FromBody]LeaveBalanceMaster lbm)
        {
            APIResponse apiResponse = null;
            if (lbm == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (new LeaveBalancesHelper().GetList(lbm.LeaveCode).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"LeaveCode Code {nameof(lbm.LeaveCode)} is already exists ,Please Use Different Code " });

                var result = new LeaveBalancesHelper().Register(lbm);
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
            APIResponse apiResponse = null;
            if (lbm == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(lbm)} cannot be null" });

            try
            {
                var rs = new LeaveBalancesHelper().Update(lbm);
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
            APIResponse apiResponse = null;
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = new LeaveBalancesHelper().Delete(code);
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
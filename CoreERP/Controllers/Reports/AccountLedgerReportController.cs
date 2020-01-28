using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.ReportsHelpers;

namespace CoreERP.Controllers.Reports
{
    [Route("api/Reports/AccountLedgerReport")]
    [ApiController]
    public class AccountLedgerReportController : ControllerBase
    {
        [HttpGet("GetAccountLedgerReportData")]
        public async Task<IActionResult> GetAccountLedgerReportData(string UserID)
        {
            try
            {
                var employeeRegisterList = ReportsHelperClass.GetAccountLedgerReportData(UserID);
                if (employeeRegisterList != null)
                {
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = employeeRegisterList });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
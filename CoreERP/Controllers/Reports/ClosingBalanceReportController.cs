using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.ReportsHelpers;
using System.Dynamic;
using System.Data;

namespace CoreERP.Controllers.Reports
{
    [Route("api/Reports/[controller]")]
    [ApiController]
    public class ClosingBalanceReportController : ControllerBase
    {
        [HttpGet("GetClosingBalanceReportData")]
        public async Task<IActionResult> GetClosingBalanceReportData(DateTime fromDate, DateTime toDate,string userID,string fromLedgerCode,string toLedgerCode, int ClosingreportType)
        {
            try
            {
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetClosingBalanceReportDataList(fromDate,toDate,userID, fromLedgerCode, toLedgerCode, ClosingreportType));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.closingBalanceList = serviceResult.Item1;
                expdoObj.headerList = serviceResult.Item2;
                expdoObj.footerList = serviceResult.Item3;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
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
    public class IntimateSaleReportController : ControllerBase
    {

        [HttpGet("GetIntimateSaleReportData")]
        public async Task<IActionResult> GetIntimateSaleReportData(string ledgerCode, DateTime fromDate, DateTime toDate, string UserID)
        {
            try
            {
                if (fromDate == Convert.ToDateTime("01-01-0001 00:00:00") && toDate == Convert.ToDateTime("01-01-0001 00:00:00"))
                {
                    fromDate = DateTime.Now;
                    toDate = DateTime.Now;
                }
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetIntimateSaleReportDataList(ledgerCode,fromDate,toDate,UserID));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.IntimateSaleList = serviceResult.Item1;
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

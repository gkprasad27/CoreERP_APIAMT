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
    [Route("api/Reports/FourColumnCashBookReport")]
    [ApiController]
    public class FourColumnCashBookReportController : ControllerBase
    {
        [HttpGet("GetFourColumnCashBookReportData")]
        public async Task<IActionResult> GetFourColumnCashBookReportData(string UserID, DateTime fromDate, DateTime toDate,string branchCode, int fourColumnreportType)
        {
            try
            {
                if (fromDate == Convert.ToDateTime("01-01-0001 00:00:00") && toDate == Convert.ToDateTime("01-01-0001 00:00:00"))
                {
                    fromDate = DateTime.Now;
                    toDate = DateTime.Now;
                    // return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                var serviceResult =await Task.FromResult(ReportsHelperClass.GetFourColumnCashBookReportDataList(UserID,fromDate,toDate,branchCode, fourColumnreportType));
                if (serviceResult.Item1 != null && serviceResult.Item1.Count>0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.fourColumnList = serviceResult.Item1;
                    expdoObj.headerList = serviceResult.Item2;
                    expdoObj.footerList = serviceResult.Item3;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
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
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
    public class StockTransferPrintReportController : ControllerBase
    {

        [HttpGet("GetStockTransferPrintReportData")]
        public async Task<IActionResult> GetStockTransferPrintReportData(string userName, string fromBranchCode, string stockTransferNo)
        {
            try
            {
                //if (fromDate == Convert.ToDateTime("01-01-0001 00:00:00") && toDate == Convert.ToDateTime("01-01-0001 00:00:00"))
                //{
                //    fromDate = DateTime.Now;
                //    toDate = DateTime.Now;
                //    // return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                //}
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetStockTransferPrintReportDataList(userName, fromBranchCode, stockTransferNo));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.StockList = serviceResult.Item1;
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

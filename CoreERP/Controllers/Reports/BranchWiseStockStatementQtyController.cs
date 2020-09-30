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
    public class BranchWiseStockStatementQtyController : ControllerBase
    {

        [HttpGet("GetBranchWiseStockStatementQtyReportData")]
        public async Task<IActionResult> GetBranchWiseStockStatementQtyReportData(string userID, string branchCode, DateTime fromDate, DateTime toDate)
        {
            try
            {
                //Date = { 01 - 01 - 0001 00:00:00}
                if (fromDate ==Convert.ToDateTime("01-01-0001 00:00:00")&& toDate == Convert.ToDateTime("01-01-0001 00:00:00"))
                {
                    fromDate = DateTime.Now;
                    toDate = DateTime.Now;
                    // return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetBranchWiseStockStatementQtyReportDataList(userID, branchCode,fromDate,toDate));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.branchWiseStockQty = serviceResult.Item1;
                expdoObj.headerList = serviceResult.Item2;
                expdoObj.footerList = serviceResult.Item3;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetReportBranchList")]
        public async Task<IActionResult> GetReportBranchList()
        {
            try
            {
                var reportBranchesList = await Task.FromResult(ReportsHelperClass.GetReportBranches());
                if (reportBranchesList != null && reportBranchesList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.reportBranchesList = reportBranchesList;
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

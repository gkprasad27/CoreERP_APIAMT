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
    public class SaleValueReportController : ControllerBase
    {

        [HttpGet("GetSaleValueReportData")]
        public async Task<IActionResult> GetSaleValueReportData(string userID, string branchCode, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetSaleValueReportDataList(userID, branchCode,fromDate,toDate));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.savleValueList = serviceResult.Item1;
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

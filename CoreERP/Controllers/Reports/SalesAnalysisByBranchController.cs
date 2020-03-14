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
    public class SalesAnalysisByBranchController : ControllerBase
    {
        [HttpGet("GetSalesAnalysisByBranchrReportData")]
        public async Task<IActionResult> GetSalesAnalysisByBranchrReportData(string branchID, string productCode)
        {
            try
            {
                var SalesAnalysisByBranchrList = await Task.FromResult(ReportsHelperClass.GetSalesAnalysisByBranchReportDataList(branchID));
                if (SalesAnalysisByBranchrList != null && SalesAnalysisByBranchrList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.SalesAnalysisByBranchrList = SalesAnalysisByBranchrList;
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
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
    public class DailySalesReportController : ControllerBase
    {
        [HttpGet("GetDailySalesReportData")]
        public async Task<IActionResult> GetDailySalesReportData(string companyId, string branchID, string userName)
        {
            try
            {
                var DailySalesList = await Task.FromResult(ReportsHelperClass.GetDailySalesReportDataList(companyId, branchID, userName));
                if (DailySalesList != null && DailySalesList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.DailySalesList = DailySalesList;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.ReportsHelpers;
using System.Dynamic;

namespace CoreERP.Controllers.Reports
{
    [Route("api/Reports/[controller]")]
    [ApiController]
    public class TwoFourehrsSalesStockReportController : ControllerBase
    {
        [HttpGet("Get24hrsSalesStockReportData")]
        public async Task<IActionResult> Get24hrsSalesStockReportData(string userID, DateTime fromDate, DateTime toDate, string branchCode)
        {
            try
            {
                var serviceResult = await Task.FromResult(ReportsHelperClass.Get24hrsSalesStockReportDataList(userID,fromDate,toDate,branchCode));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.shrsSalesStockListhiftViewList = serviceResult.Item1;
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

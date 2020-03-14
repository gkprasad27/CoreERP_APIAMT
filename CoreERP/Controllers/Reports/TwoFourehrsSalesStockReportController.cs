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
        public async Task<IActionResult> Get24hrsSalesStockReportData(string compnayID,string branchID)
        {
            try
            {
                var hrsSalesStockList = await Task.FromResult(ReportsHelperClass.Get24hrsSalesStockReportDataList(compnayID,branchID));
                if (hrsSalesStockList != null && hrsSalesStockList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.hrsSalesStockList = hrsSalesStockList;
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
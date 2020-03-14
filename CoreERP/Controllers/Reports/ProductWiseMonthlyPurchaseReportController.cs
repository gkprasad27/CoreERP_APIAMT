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
    public class ProductWiseMonthlyPurchaseReportController : ControllerBase
    {

        [HttpGet("GetProductWiseMonthlyPurchaseReportData")]
        public async Task<IActionResult> GetProductWiseMonthlyPurchaseReportData(string CompanyID,string branchID)
        {
            try
            {
                var ProductWiseMonthlyPurchaseList = await Task.FromResult(ReportsHelperClass.GetProductWiseMonthlyPurchaseReportDataList(CompanyID,branchID));
                if (ProductWiseMonthlyPurchaseList != null && ProductWiseMonthlyPurchaseList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ProductWiseMonthlyPurchaseList = ProductWiseMonthlyPurchaseList;
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
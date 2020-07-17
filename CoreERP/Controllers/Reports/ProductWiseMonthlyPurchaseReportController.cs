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
        public async Task<IActionResult> GetProductWiseMonthlyPurchaseReportData(string userID, DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (fromDate == Convert.ToDateTime("01-01-0001 00:00:00") && toDate == Convert.ToDateTime("01-01-0001 00:00:00"))
                {
                    fromDate = DateTime.Now;
                    toDate = DateTime.Now;
                    // return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetProductWiseMonthlyPurchaseReportDataList(userID,fromDate,toDate));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.ProductWiseMonthlyPurchaseList = serviceResult.Item1;
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
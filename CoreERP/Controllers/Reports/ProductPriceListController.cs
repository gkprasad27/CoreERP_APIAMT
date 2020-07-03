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
    public class ProductPriceListController : ControllerBase
    {
        [HttpGet("GetProductPriceListReportData")]
        public async Task<IActionResult> GetProductPriceListReportData(string userName, string branchCode, DateTime fromDate, DateTime toDate, int reportType)
        {
            try
            {
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetProductPriceListReportDataList(userName, branchCode, fromDate, toDate, reportType));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.productPriceList = serviceResult.Item1;
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

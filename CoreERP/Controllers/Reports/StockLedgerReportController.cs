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
    public class StockLedgerReportController : ControllerBase
    {

        [HttpGet("GetStockLedgerReportData")]
        public async Task<IActionResult> GetStockLedgerReportData(string branchCode, string productCode, DateTime fromDate, DateTime toDate, string UserID)
        {
            try
            {
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetStockLedgerReportDataList(branchCode, productCode,fromDate,toDate,UserID));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.StockLedgerList = serviceResult.Item1;
                expdoObj.headerList = serviceResult.Item2;
                expdoObj.footerList = serviceResult.Item3;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetProductList")]
        public async Task<IActionResult> GetProductList()
        {
            try
            {
                var productList = await Task.FromResult(ReportsHelperClass.GetProducts());
                if (productList != null && productList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.productList = productList;
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

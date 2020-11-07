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
                if (fromDate == Convert.ToDateTime("01-01-0001 00:00:00") && toDate == Convert.ToDateTime("01-01-0001 00:00:00"))
                {
                    fromDate = DateTime.Now;
                    toDate = DateTime.Now;
                }
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetStockLedgerReportDataList(branchCode, productCode, fromDate, toDate, UserID));
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
        //[HttpGet("GetProductList")]
        //public async Task<IActionResult> GetProductList()
        //{
        //    try
        //    {
        //        var productList = await Task.FromResult(ReportsHelperClass.GetProducts());
        //        if (productList != null && productList.Count > 0)
        //        {
        //            dynamic expdoObj = new ExpandoObject();
        //            expdoObj.productList = productList;
        //            return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
        //        }
        //        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpGet("GetStockProductList/{productCode}")]
        public async Task<IActionResult> GetStockProductList(string productCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject(); 
                    expando.ProductList = new ReportsHelperClass().GetProducts(productCode).OrderBy(p => p.ProductCode.Length).Select(x => new { ID = x.ProductCode, TEXT = x.ProductName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }


    }
}
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
    [Route("api/Reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
       [HttpGet("GetSalesReport/{fromDate}/{toDate}/{company}")]
        public async Task<IActionResult> GetSalesReport(DateTime fromDate, DateTime toDate, string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.SalesReport = ReportsHelperClass.GetSalesReport(fromDate, toDate, company);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetGoodsReceiptsReport/{fromDate}/{toDate}/{company}")]
        public async Task<IActionResult> GetPurchasesReport(DateTime fromDate, DateTime toDate, string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.GoodsReceiptReport = ReportsHelperClass.GetGoodsReceiptsReport(fromDate, toDate, company);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetPurchaseReport/{fromDate}/{toDate}/{company}")]
        public async Task<IActionResult> GetPurchaseReport(DateTime fromDate, DateTime toDate, string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.PurchaseReport = ReportsHelperClass.GetPurchaseReport(fromDate, toDate, company);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        //public async Task<IActionResult> GetSalesReport(string company, DateTime fromDate, DateTime toDate)
        //{
        //    try
        //    {
        //        var DailySalesList = await Task.FromResult(ReportsHelperClass.GetSalesReport( company, fromDate, toDate));
        //        dynamic expdoObj = new ExpandoObject();
        //        expdoObj.dailySalesList = DailySalesList.Item1;
        //        expdoObj.headerList = DailySalesList.Item2;
        //        expdoObj.footerList = DailySalesList.Item3;
        //        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}
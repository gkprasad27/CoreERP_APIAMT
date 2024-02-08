using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.ReportsHelpers;
using System.Dynamic;
using System.Data;
using Microsoft.Build.Framework;

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
                    DataSet ds = ReportsHelperClass.GetSalesReport(fromDate, toDate, company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.SalesReport = ds.Tables[0];
                        expando.SalesReportTotals = ds.Tables[1];
                    }

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
        public async Task<IActionResult> GetGoodsReceiptsReport(DateTime fromDate, DateTime toDate, string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetGoodsReceiptsReport(fromDate, toDate, company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.GoodsReceiptReport = ds.Tables[0];
                        expando.GoodsReceiptReportTotals = ds.Tables[1];

                    }
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
                    DataSet ds =  ReportsHelperClass.GetPurchaseReport(fromDate, toDate, company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.PurchaseReport = ds.Tables[0];
                        expando.PurchaseReportTotals = ds.Tables[1];
                    }
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetStockValuation/{company}")]
        public async Task<IActionResult> GetStockValuation(string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.StockReport = ReportsHelperClass.GetStockValuation(company);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }


        [HttpGet("GetPendingSales/{company}")]
        public async Task<IActionResult> GetPendingSales(string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetPendingSales(company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.PendingSOReport = ds.Tables[0];
                        expando.PendingSOReportTotals = ds.Tables[1];
                    }
                    
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetPendingPOs/{company}")]
        public async Task<IActionResult> GetPendingPOs(string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetPendingPOs(company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.PendingPOReport = ds.Tables[0];
                        expando.PendingPOReportTotals = ds.Tables[1];
                    }

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
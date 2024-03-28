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
        [HttpGet("GetSalesReport/{fromDate}/{toDate}/{company}/{CustomerCode}/{MaterialCode}")]
        public async Task<IActionResult> GetSalesReport(DateTime fromDate, DateTime toDate, string company, string CustomerCode, string MaterialCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetSalesReport(fromDate, toDate, company, CustomerCode, MaterialCode);
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

        [HttpGet("GetSalesGSTReport/{fromDate}/{toDate}/{company}")]
        public async Task<IActionResult> GetSalesGSTReport(DateTime fromDate, DateTime toDate, string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetSalesGSTReport(fromDate, toDate, company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.GSTSalesReport = ds.Tables[0];
                        expando.GSTSalesReportTotals = ds.Tables[1];
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

        [HttpGet("GetPurchaseGSTReport/{fromDate}/{toDate}/{company}")]
        public async Task<IActionResult> GetPurchaseGSTReport(DateTime fromDate, DateTime toDate, string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetPurchaseGSTReport(fromDate, toDate, company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.GSTPOReport = ds.Tables[0];
                        expando.GSTPOReportTotals = ds.Tables[1];
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

        [HttpGet("GetGoodsReceiptsReport/{fromDate}/{toDate}/{company}/{CustomerCode}/{MaterialCode}")]
        public async Task<IActionResult> GetGoodsReceiptsReport(DateTime fromDate, DateTime toDate, string company, string CustomerCode,string MaterialCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetGoodsReceiptsReport(fromDate, toDate, company, CustomerCode, MaterialCode);
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

        [HttpGet("GetOrdersvsSales/{fromDate}/{toDate}/{company}")]
        public async Task<IActionResult> GetOrdersvsSales(DateTime fromDate, DateTime toDate, string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetOrdersvsSales(fromDate, toDate, company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.OrdersvsSales = ds.Tables[0];
                        //expando.PurchaseReportTotals = ds.Tables[1];
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

        [HttpGet("GetPendingJO/{company}")]
        public async Task<IActionResult> GetPendingJO(string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetPendingJO(company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.PendingJOReport = ds.Tables[0];
                        expando.PendingJOReportTotals = ds.Tables[1];
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

        [HttpGet("GetSuppliedVsRejected/{fromDate}/{toDate}/{company}")]
        public async Task<IActionResult> GetSuppliedVsRejected(DateTime fromDate, DateTime toDate, string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetSuppliedVsRejected(fromDate, toDate, company);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.SuppliedVsRejected = ds.Tables[0];
                        //expando.SalesReportTotals = ds.Tables[1];
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

        [HttpGet("GetEmpPresent/{company}")]
        public async Task<IActionResult> GetGetEmpPresent(string company)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.EmpPresent = ReportsHelperClass.GetEmpPresent(company);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("VendorPaymentsReport/{fromDate}/{toDate}/{company}/{Status}/{BPType}/{Customer}")]
        public async Task<IActionResult> VendorPaymentsReport(DateTime fromDate, DateTime toDate, string company, string Status, string BPType, string Customer)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.VendorPaymentsReport(fromDate, toDate, company, Status, BPType, Customer);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.VendorPayments = ds.Tables[0];
                        expando.VendorPaymentsTotals = ds.Tables[1];

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
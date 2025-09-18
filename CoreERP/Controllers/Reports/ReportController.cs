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
using System.Web;

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


        [HttpGet("GetCPReport/{fromDate}")]
        public async Task<IActionResult> GetSalesGSTReport(DateTime fromDate)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetCPReport(fromDate);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.GCP = ds.Tables[0];
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

        [HttpGet("GetSalesGSTReport/{fromDate}/{toDate}/{company}/{customerCode}")]
        public async Task<IActionResult> GetSalesGSTReport(DateTime fromDate, DateTime toDate, string company, string customerCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetSalesGSTReport(fromDate, toDate, company, customerCode);
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

        [HttpGet("GetPurchaseGSTReport/{fromDate}/{toDate}/{company}/{vendorCode}")]
        public async Task<IActionResult> GetPurchaseGSTReport(DateTime fromDate, DateTime toDate, string company, string vendorCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetPurchaseGSTReport(fromDate, toDate, company, vendorCode);
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

        [HttpGet("GetPurchaseReport/{fromDate}/{toDate}/{company}/{customerCode}/{MaterialCode}")]
        public async Task<IActionResult> GetPurchaseReport(DateTime fromDate, DateTime toDate, string company,string customerCode, string MaterialCode)
        {
            string code = MaterialCode.Replace(@"\r", string.Empty).Trim();
            // Using HttpUtility.UrlDecode (requires System.Web)
            string decodedString = HttpUtility.UrlDecode(code);
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds =  ReportsHelperClass.GetPurchaseReport(fromDate, toDate, company, customerCode, decodedString);
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

        [HttpGet("GetStockValuation/{company}/{materialCode}")]
        public async Task<IActionResult> GetStockValuation(string company,string materialCode)
        {
            string code = materialCode.Replace(@"\r", string.Empty).Trim();
            // Using HttpUtility.UrlDecode (requires System.Web)
            string decodedString = HttpUtility.UrlDecode(code);
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.StockReport = ReportsHelperClass.GetStockValuation(company, decodedString);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }


        [HttpGet("GetPendingSales/{company}/{CustomerCode}")]
        public async Task<IActionResult> GetPendingSales(string company, string CustomerCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetPendingSales(company, CustomerCode);
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

        [HttpGet("GetPendingJO/{company}/{vendorCode}")]
        public async Task<IActionResult> GetPendingJO(string company,string vendorCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetPendingJO(company,vendorCode);
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

        [HttpGet("GetPendingPOs/{company}/{vendorCode}")]
        public async Task<IActionResult> GetPendingPOs(string company, string vendorCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetPendingPOs(company, vendorCode);
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

        [HttpGet("GetemployeeotreportReport/{fromDate}/{toDate}/{company}/{EmployeeCode}")]
        public async Task<IActionResult> GetemployeeotreportReport(DateTime fromDate, DateTime toDate, string company, string EmployeeCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetemployeeotreportReport(fromDate, toDate, company, EmployeeCode);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.EMPOTReport = ds.Tables[0];
                        //expando.GoodsReceiptReportTotals = ds.Tables[1];

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


        [HttpGet("GetemployeeattendanceReport/{fromDate}/{toDate}/{company}/{EmployeeCode}")]
        public async Task<IActionResult> GetemployeeattendanceReport(DateTime fromDate, DateTime toDate, string company, string EmployeeCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetemployeeattendanceReport(fromDate, toDate, company, EmployeeCode);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.EMPAttendanceReport = ds.Tables[0];
                        //expando.GoodsReceiptReportTotals = ds.Tables[1];

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

        [HttpGet("GetemployeeAbsentReport/{fromYear}/{fromMonth}/{toYear}/{toMonth}/{EmployeeCode}")]
        public async Task<IActionResult> GetemployeeAbsentReport(string fromYear, string fromMonth,string toYear, string toMonth, string EmployeeCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.GetemployeeAbsentReport(fromYear, fromMonth, toYear, toMonth, EmployeeCode);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.EMPAttendanceReport = ds.Tables[0];
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

        [HttpGet("Employeeattendance/{fromDate}/{toDate}/{company}/{EmployeeCode}")]
        public async Task<IActionResult> Employeeattendance(DateTime fromDate, DateTime toDate, string company, string EmployeeCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.Employeeattendance(fromDate, toDate, company, EmployeeCode);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.EMPAttendanceReport = ds.Tables[0];
                        //expando.GoodsReceiptReportTotals = ds.Tables[1];

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

        [HttpGet("EemployeeAttendanceChange/{fromDate}/{toDate}/{company}/{EmployeeCode}")]
        public async Task<IActionResult> EemployeeAttendanceChange(DateTime fromDate, DateTime toDate, string company, string EmployeeCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    DataSet ds = ReportsHelperClass.EemployeeAttendanceChange(fromDate, toDate, company, EmployeeCode);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        expando.EMPAttendanceReport = ds.Tables[0];
                        //expando.GoodsReceiptReportTotals = ds.Tables[1];

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

        [HttpGet("GetAttendanceProcess/{fromDate}/{toDate}/{company}/{EmployeeCode}")]
        public async Task<IActionResult> GetAttendanceProcess(DateTime fromDate, DateTime toDate, string company, string EmployeeCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    var empList = CommonHelper.CheckAttendanceData(fromDate.Month, fromDate.Year, company);
                    if (empList.Any())
                    {
                        expando.AttendanceProcess = empList;
                    }
                    else
                    {
                        DataSet ds = ReportsHelperClass.GetAttendanceProcess(fromDate, toDate, company, EmployeeCode);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            expando.AttendanceProcess = ds.Tables[0];
                            //expando.GoodsReceiptReportTotals = ds.Tables[1];

                        }
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

        [HttpGet("GetPayslip/{month}/{year}/{company}/{employee}")]
        public async Task<IActionResult> GetPayslip(string year, string month, string company, string employee)
        {
            {
                var result = await Task.Run(() =>
                {
                    try
                    {
                        dynamic expando = new ExpandoObject();
                        DataSet ds = ReportsHelperClass.GetPayslip(year, month, company,employee);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            expando.Payslip = ds.Tables[0];
                            expando.Attendance = ds.Tables[1];
                            expando.OT = ds.Tables[2];

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
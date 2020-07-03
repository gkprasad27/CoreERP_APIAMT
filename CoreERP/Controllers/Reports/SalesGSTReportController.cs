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
    public class SalesGSTReportController : ControllerBase
    {
        [HttpGet("GetSalesGSTReportData")]
        public async Task<IActionResult> GetSalesGSTReportData(string userId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetSalesGSTReportDataList(userId, fromDate, toDate));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.salesGst = serviceResult.Item1;
                expdoObj.headerList = serviceResult.Item2;
                expdoObj.footerList = serviceResult.Item3;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("SalesGSTCSVReport")]
        //public async Task<ActionResult> SalesGSTCSVReport(string userId, DateTime fromDate, DateTime toDate)
        //{
        //    try
        //    {
        //        var SalesGST = await Task.FromResult(ReportsHelperClass.GetSalesGSTReportDataTable(userId, fromDate, toDate));
        //        System.Text.StringBuilder fileContent = new System.Text.StringBuilder();
        //        IEnumerable<string> columnNames = SalesGST.Columns.Cast<DataColumn>().
        //                                          Select(column => column.ColumnName);
        //        fileContent.AppendLine(string.Join(",", columnNames));

        //        foreach (DataRow row in SalesGST.Rows)
        //        {
        //            IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
        //            fileContent.AppendLine(string.Join(",", fields));
        //        }

        //        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(fileContent.ToString());
        //        return File(fileContents: bytes, contentType: "text/csv", fileDownloadName: "SalesGSTReport.csv");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}
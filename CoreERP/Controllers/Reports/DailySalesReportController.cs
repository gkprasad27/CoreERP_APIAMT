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
    public class DailySalesReportController : ControllerBase
    {
        [HttpGet("GetDailySalesReportData")]
        public async Task<IActionResult> GetDailySalesReportData(string companyId, string branchID, string userName)
        {
            try
            {
                var DailySalesList = await Task.FromResult(ReportsHelperClass.GetDailySalesReportDataList(companyId, branchID, userName));
                if (DailySalesList != null && DailySalesList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.DailySalesList = DailySalesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("DailySalesExcelReport")]
        public async Task<ActionResult> DailySalesExcelReport(string companyId, string branchID, string userName)
        {
            try
            {
                var DailySales = await Task.FromResult(ReportsHelperClass.GetDailySalesReportDataTable(companyId, branchID, userName));
                var fileContent = ReportsHelperClass.getExcelFromDatatable(DailySales, "Sales GST Report");
                return File(fileContents: fileContent, contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "DailySalesReport.xlsx");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("DailySalesCSVReport")]
        public async Task<ActionResult> DailySalesCSVReport(string companyId, string branchID, string userName)
        {
            try
            {
                var DailySales = await Task.FromResult(ReportsHelperClass.GetDailySalesReportDataTable(companyId, branchID, userName));
                System.Text.StringBuilder fileContent = new System.Text.StringBuilder();
                IEnumerable<string> columnNames = DailySales.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                fileContent.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in DailySales.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    fileContent.AppendLine(string.Join(",", fields));
                }

                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(fileContent.ToString());
                return File(fileContents: bytes, contentType: "text/csv", fileDownloadName: "DailySalesReport.csv");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
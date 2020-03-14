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
        public async Task<IActionResult> GetStockLedgerReportData(string branchID, string productCode)
        {
            try
            {
                var StockLedgerList = await Task.FromResult(ReportsHelperClass.GetStockLedgerReportDataList(branchID, productCode));
                if (StockLedgerList != null && StockLedgerList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.StockLedgerList = StockLedgerList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("StockLedgerExcelReport")]
        public async Task<ActionResult> StockLedgerExcelReport(string branchID, string productCode)
        {
            try
            {
                var StockLedger = await Task.FromResult(ReportsHelperClass.GetStockLedgerReportDataTable(branchID, productCode));
                var fileContent = ReportsHelperClass.getExcelFromDatatable(StockLedger, "Sales GST Report");
                return File(fileContents: fileContent, contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "StockLedgerReport.xlsx");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("StockLedgerCSVReport")]
        public async Task<ActionResult> StockLedgerCSVReport(string branchID, string productCode)
        {
            try
            {
                var StockLedger = await Task.FromResult(ReportsHelperClass.GetStockLedgerReportDataTable(branchID, productCode));
                System.Text.StringBuilder fileContent = new System.Text.StringBuilder();
                IEnumerable<string> columnNames = StockLedger.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                fileContent.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in StockLedger.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    fileContent.AppendLine(string.Join(",", fields));
                }

                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(fileContent.ToString());
                return File(fileContents: bytes, contentType: "text/csv", fileDownloadName: "StockLedgerReport.csv");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
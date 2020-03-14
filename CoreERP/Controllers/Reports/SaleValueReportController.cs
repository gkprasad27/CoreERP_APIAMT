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
    public class SaleValueReportController : ControllerBase
    {

        [HttpGet("GetSaleValueReportData")]
        public async Task<IActionResult> GetSaleValueReportData(string UserID)
        {
            try
            {
                var savleValueList =await Task.FromResult(ReportsHelperClass.GetSaleValueReportDataList(UserID));
                if (savleValueList != null && savleValueList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.savleValueList = savleValueList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("SaleValueExcelReport")]
        public async Task<ActionResult> SaleValueExcelReport(string UserID)
        {
            try
            {
                var SaleValue =await Task.FromResult(ReportsHelperClass.GetSaleValueReportDataTable(UserID));
                var fileContent = ReportsHelperClass.getExcelFromDatatable(SaleValue,"Sale Value Report");
                return File(fileContents: fileContent, contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "SaleValueReport.xlsx");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("SaleValueCSVReport")]
        public async Task<ActionResult> SaleValueCSVReport(string UserID)
        {
            try
            {
                var SaleValue =await Task.FromResult(ReportsHelperClass.GetSaleValueReportDataTable(UserID));
                System.Text.StringBuilder fileContent = new System.Text.StringBuilder();
                IEnumerable<string> columnNames = SaleValue.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                fileContent.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in SaleValue.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    fileContent.AppendLine(string.Join(",", fields));
                }

                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(fileContent.ToString());
                return File(fileContents: bytes, contentType: "text/csv", fileDownloadName: "SaleValueReport.csv");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
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
    public class StockVerificationReportController : ControllerBase
    {
        [HttpGet("GetStockVerificationReportData")]
        public async Task<IActionResult> GetStockVerificationReportData(string companyId, string branchID, string userName)
        {
            try
            {
                var StockVerificationList = await Task.FromResult(ReportsHelperClass.GetStockVerificationReportDataList(companyId, branchID, userName));
                if (StockVerificationList != null && StockVerificationList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.StockVerificationList = StockVerificationList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
       
        [HttpGet("StockVerificationCSVReport")]
        public async Task<ActionResult> StockVerificationCSVReport(string companyId, string branchID, string userName)
        {
            try
            {
                var StockVerification = await Task.FromResult(ReportsHelperClass.GetStockVerificationReportDataTable(companyId, branchID, userName));
                System.Text.StringBuilder fileContent = new System.Text.StringBuilder();
                IEnumerable<string> columnNames = StockVerification.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                fileContent.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in StockVerification.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    fileContent.AppendLine(string.Join(",", fields));
                }

                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(fileContent.ToString());
                return File(fileContents: bytes, contentType: "text/csv", fileDownloadName: "StockVerificationReport.csv");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
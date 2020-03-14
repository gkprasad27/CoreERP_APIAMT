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
    public class IntimateSaleReportController : ControllerBase
    {

        [HttpGet("GetIntimateSaleReportData")]
        public async Task<IActionResult> GetIntimateSaleReportData(string companyId, string branchID, string ledgerCode, string ledgerName, DateTime fDate, DateTime tDate, string userName)
        {
            try
            {
                var IntimateSaleList = await Task.FromResult(ReportsHelperClass.GetIntimateSaleReportDataList(companyId, branchID, ledgerCode,ledgerName,fDate,tDate,userName));
                if (IntimateSaleList != null && IntimateSaleList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.l = IntimateSaleList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("IntimateSaleExcelReport")]
        public async Task<ActionResult> IntimateSaleExcelReport(string companyId, string branchID, string ledgerCode, string ledgerName, DateTime fDate, DateTime tDate, string userName)
        {
            try
            {
                var IntimateSale = await Task.FromResult(ReportsHelperClass.GetIntimateSaleReportDataTable(companyId, branchID, ledgerCode,ledgerName,fDate,tDate,userName));
                var fileContent = ReportsHelperClass.getExcelFromDatatable(IntimateSale,"Intimate Sale Report");
                return File(fileContents:fileContent, contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "IntimateSaleReport.xlsx");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("IntimateSaleCSVReport")]
        public async Task<ActionResult> IntimateSaleCSVReport(string companyId, string branchID, string ledgerCode, string ledgerName, DateTime fDate, DateTime tDate, string userName)
        {
            try
            {
                var IntimateSale = await Task.FromResult(ReportsHelperClass.GetIntimateSaleReportDataTable(companyId, branchID, ledgerCode,ledgerName,fDate,tDate,userName));
                System.Text.StringBuilder fileContent = new System.Text.StringBuilder();
                IEnumerable<string> columnNames = IntimateSale.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                fileContent.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in IntimateSale.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    fileContent.AppendLine(string.Join(",", fields));
                }

                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(fileContent.ToString());
                return File(fileContents: bytes, contentType: "text/csv", fileDownloadName: "IntimateSaleReport.csv");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
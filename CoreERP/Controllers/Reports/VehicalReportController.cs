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
    public class VehicalReportController : ControllerBase
    {

        [HttpGet("GetVehicalReportData")]
        public async Task<IActionResult> GetVehicalReportData(string vehicleRegNo, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var VehicalList =await Task.FromResult(ReportsHelperClass.GetVehicalReportDataList(vehicleRegNo,fromDate,toDate));
                if (VehicalList != null && VehicalList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.VehicalList = VehicalList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("VehicalExcelReport")]
        public async Task<ActionResult> VehicalExcelReport(string vehicleRegNo, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var Vehical =await Task.FromResult(ReportsHelperClass.GetVehicalReportDataTable(vehicleRegNo,fromDate,toDate));
                var fileContent = ReportsHelperClass.getExcelFromDatatable(Vehical,"Vehical Report");
                return File(fileContents: fileContent, contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "VehicalReport.xlsx");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("VehicalCSVReport")]
        public async Task<ActionResult> VehicalCSVReport(string vehicleRegNo, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var Vehical =await Task.FromResult(ReportsHelperClass.GetVehicalReportDataTable(vehicleRegNo,fromDate,toDate));
                System.Text.StringBuilder fileContent = new System.Text.StringBuilder();
                IEnumerable<string> columnNames = Vehical.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                fileContent.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in Vehical.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    fileContent.AppendLine(string.Join(",", fields));
                }

                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(fileContent.ToString());
                return File(fileContents: bytes, contentType: "text/csv", fileDownloadName: "VehicalReport.csv");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
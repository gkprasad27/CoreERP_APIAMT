using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.ReportsHelpers;
using System.Dynamic;
using System.Data;

namespace CoreERP.Controllers
{
    [Route("api/Reports/MemberMasterReport")]
    [ApiController]
    public class MemberMasterReportController : ControllerBase
    {
        [HttpGet("GetMemberMasterReportData")]
        public async Task<IActionResult> GetMemberMasterReportData(string isMobileNumberRequired,string UserID)
        {
            try
            {
                var memberMasterList =await Task.FromResult(ReportsHelperClass.GetMemberMasterReportDataList(isMobileNumberRequired, UserID));
                if (memberMasterList.Count>0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.memberMasterList = memberMasterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("MemberMasterExcelReport")]
        public async Task<ActionResult> MemberMasterExcelReport(string isMobileNumberRequired, string UserID)
        {
            try
            {
                var memberMaster =await Task.FromResult(ReportsHelperClass.GetMemberMasterReportDataTable(isMobileNumberRequired, UserID));
                var fileContent = ReportsHelperClass.getExcelFromDatatable(memberMaster,"Member Master Report");
                return File(fileContents: fileContent, contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "MemberMasterReport.xlsx");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("MemberMasterCSVReport")]
        public async Task<ActionResult> MemberMasterCSVReport(string isMobileNumberRequired, string UserID)
        {
            try
            {
                var memberMaster =await Task.FromResult(ReportsHelperClass.GetMemberMasterReportDataTable(isMobileNumberRequired, UserID));
                System.Text.StringBuilder fileContent = new System.Text.StringBuilder();
                IEnumerable<string> columnNames = memberMaster.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                fileContent.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in memberMaster.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    fileContent.AppendLine(string.Join(",", fields));
                }

                byte[] bytes =System.Text.Encoding.ASCII.GetBytes(fileContent.ToString());
                return File(fileContents: bytes, contentType: "text/csv", fileDownloadName: "MemberMasterReport.csv");
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
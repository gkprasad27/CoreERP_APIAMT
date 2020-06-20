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
    public class ShiftViewReportController : ControllerBase
    {
        [HttpGet("GetShiftViewReportList")]
        public async Task<IActionResult> GetShiftViewReportList(string userName, string userID, string branchCode, string shiftId, DateTime fromDate, DateTime toDate,int reportID)
        {
            try
            {
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetShiftViewReportDataList(userName, userID,branchCode,shiftId,fromDate,toDate, reportID));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.shiftViewList = serviceResult.Item1;
                expdoObj.headerList = serviceResult.Item2;
                expdoObj.footerList = serviceResult.Item3;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDefaultShiftReportDataTableList")]
        public async Task<IActionResult> GetDefaultShiftReportDataTableList(string userName, string userID, string branchCode, string shiftId, DateTime fromDate, DateTime toDate, int reportID)
        {
            try
            {
                if (reportID == 0)
                {
                    var serviceResult = await Task.FromResult(ReportsHelperClass.GetDefaultShiftReportDataTableList());
                    if (serviceResult.Item1 != null && serviceResult.Item1.Count > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.shiftViewList = serviceResult.Item1;
                        expdoObj.headerList = serviceResult.Item2;
                        expdoObj.footerList = serviceResult.Item3;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
                else
                {
                    var serviceResult = await Task.FromResult(ReportsHelperClass.GetDefaultShiftReportDataTableList1(userName, userID, branchCode, shiftId, fromDate, toDate, reportID));
                    if (serviceResult.Item1 != null && serviceResult.Item1.Count > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.shiftViewList = serviceResult.Item1;
                        expdoObj.headerList = serviceResult.Item2;
                        expdoObj.footerList = serviceResult.Item3;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}

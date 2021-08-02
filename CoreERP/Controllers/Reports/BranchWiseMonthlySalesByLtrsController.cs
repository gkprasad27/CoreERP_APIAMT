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
    public class BranchWiseMonthlySalesByLtrsController : ControllerBase
    {

        [HttpGet("GetBranchWiseMonthlySalesByLtrsReportData")]
        public async Task<IActionResult> GetBranchWiseMonthlySalesByLtrsReportData(string userID, string branchCode, DateTime fromDate, DateTime toDate,string groupName,string supplierGroup)
        {
            try
            {
                //Date = { 01 - 01 - 0001 00:00:00}
                if (fromDate ==Convert.ToDateTime("01-01-0001 00:00:00")&& toDate == Convert.ToDateTime("01-01-0001 00:00:00"))
                {
                    fromDate = DateTime.Now;
                    toDate = DateTime.Now;
                    // return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                var serviceResult = await Task.FromResult(ReportsHelperClass.GetBranchWiseMonthlySalesByLtrsReportData(userID, branchCode,fromDate,toDate,groupName,supplierGroup));
                dynamic expdoObj = new ExpandoObject();
                expdoObj.branchwiseLtrs = serviceResult.Item1;
                expdoObj.headerList = serviceResult.Item2;
                expdoObj.footerList = serviceResult.Item3;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetReportBranchList")]
        public async Task<IActionResult> GetReportBranchList()
        {
            try
            {
                var reportBranchesList = await Task.FromResult(ReportsHelperClass.GetReportBranches());
                if (reportBranchesList != null && reportBranchesList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.reportBranchesList = reportBranchesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetReportPGList")]
        public async Task<IActionResult> GetReportPGList()
        {
            try
            {
                var reportPGList = await Task.FromResult(ReportsHelperClass.GetReportProductGroup());
                if (reportPGList != null && reportPGList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.reportPGList = reportPGList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetSupplierGroupList")]
        public async Task<IActionResult> GetSupplierGroupList()
        {
            try
            {
                var reportSGList = await Task.FromResult(ReportsHelperClass.GetSupplierGroupName());
                if (reportSGList != null && reportSGList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.reportSGList = reportSGList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}

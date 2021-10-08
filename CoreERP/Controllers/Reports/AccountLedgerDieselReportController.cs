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
    [Route("api/Reports/AccountLedgerDieselReport")]
    [ApiController]
    public class AccountLedgerDieselReportController : ControllerBase
    {
        [HttpGet("GetAccountLedgerDieselReportData")]
        public async Task<IActionResult> GetAccountLedgerDieselReportData(string UserID,string ledgerCode, DateTime fromDate, DateTime toDate,string branchCode)
        {
            try
            {
                if (fromDate == Convert.ToDateTime("01-01-0001 00:00:00") && toDate == Convert.ToDateTime("01-01-0001 00:00:00"))
                {
                    fromDate = DateTime.Now;
                    toDate = DateTime.Now;
                    // return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                var serviceResult =await Task.FromResult(ReportsHelperClass.GetAccountLedgerDieselReportDataList(UserID,ledgerCode, fromDate,toDate,branchCode));
                if (serviceResult.Item2 != null && serviceResult.Item2.Count>0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.accountLedgerList = serviceResult.Item1;
                    expdoObj.headerList = serviceResult.Item2;
                    expdoObj.footerList = serviceResult.Item3;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }       
        [HttpGet("GetAccountLedgersList")]
        public async Task<IActionResult> GetAccountLedgersList()
        {
            try
            {
                var accountLedgerList = await Task.FromResult(ReportsHelperClass.GetAccountLedgers());
                if (accountLedgerList != null && accountLedgerList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.accountLedgerList = accountLedgerList;
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
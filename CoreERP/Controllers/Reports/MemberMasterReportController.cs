using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.ReportsHelpers;

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
                var memberMasterList =ReportsHelperClass.GetMemberMasterReportData(isMobileNumberRequired, UserID);
                if (memberMasterList!=null)
                {
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response =memberMasterList });
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
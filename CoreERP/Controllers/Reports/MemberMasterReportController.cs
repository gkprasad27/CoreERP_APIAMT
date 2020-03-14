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
       
        
    }
}
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
    [Route("api/Reports/EmployeeRegisterReport")]
    [ApiController]
    public class EmployeeRegisterReportController : ControllerBase
    {
        [HttpGet("GetEmployeeRegisterReportData")]
        public async Task<IActionResult> GetEmployeeRegisterReportData(string UserID)
        {
            try
            {
                var employeeRegisterList = await Task.FromResult(ReportsHelperClass.GetEmployeeRegisterReportList(UserID));
                if (employeeRegisterList != null && employeeRegisterList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.employeeRegisterList = employeeRegisterList;
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
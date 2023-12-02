using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.Payroll;

namespace CoreERP.Controllers.Payroll
{
    [Route("api/Payroll/SalaryProcess")]
    [ApiController]
    public class SalaryProcessController : Controller
    {
        [HttpGet("SalaryProcess")]
        public IActionResult SalaryProcess(string Year, string Month, string CompanyCode, string EmpCode, string Status)
        {
            try
            {
                var salaryprocessList = SalaryProcessHelper.SalaryProcess(Year, Month, CompanyCode, EmpCode, Status);
                if (salaryprocessList != null)
                {
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = salaryprocessList });
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
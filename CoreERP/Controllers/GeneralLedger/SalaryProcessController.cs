using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.Payroll;
using Newtonsoft.Json.Linq;
using Microsoft.JSInterop.Implementation;

namespace CoreERP.Controllers.Payroll
{
    [Route("api/Ledger")]
    [ApiController]
    public class SalaryProcessController : Controller
    {
        [HttpPost("SalaryProcess")]
        public IActionResult SalaryProcess([FromBody] JObject obj)
        {
            try
            {
                var sal_Year = obj["sal_Year"].ToString();
                var sal_Month = obj["sal_Month"].ToString();
                //var structureName = obj["structureName"].ToString();
                var salaryprocessList = SalaryProcessHelper.SalaryProcess(sal_Year, sal_Month);
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
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.Payroll;
using Newtonsoft.Json.Linq;
using Microsoft.JSInterop.Implementation;
using CoreERP.BussinessLogic.ReportsHelpers;
using System.Data;
using System.Dynamic;

namespace CoreERP.Controllers.Payroll
{
    [Route("api/Ledger")]
    [ApiController]
    public class SalaryProcessController : Controller
    {
        [HttpPost("SalaryProcess/{month}/{year}/{company}/{employee}")]
        public async Task<IActionResult> SalaryProcess(string year, string month, string company, string employee)
        {
            {
                var result = await Task.Run(() =>
                {
                    try
                    {
                        dynamic expando = new ExpandoObject();
                        var salaryprocessList = SalaryProcessHelper.SalaryProcess(year, month, company, employee);
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
                });
                return result;
            }
            //try
            //{
            //    var sal_Year = obj["sal_Year"].ToString();
            //    var sal_Month = obj["sal_Month"].ToString();
            //    //var structureName = obj["structureName"].ToString();
            //    var salaryprocessList = SalaryProcessHelper.SalaryProcess(sal_Year, sal_Month);
            //    if (salaryprocessList != null)
            //    {
            //        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = salaryprocessList });
            //    }
            //    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            //}
            //catch (Exception ex)
            //{
            //    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            //}
        }
    }
}
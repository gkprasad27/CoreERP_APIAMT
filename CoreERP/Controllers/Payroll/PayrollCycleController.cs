using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.Payroll;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.Payroll
{
    [ApiController]
    [Route("api/payroll/PayrollCycle")]
    public class PayrollCycleController : ControllerBase
    {
        [HttpGet("GetPayrollCycleList")]
        public IActionResult GetPayrollCycleList()
        {
            try
            {
                var payCycle = PayrollCycleHelper.GetListOfPayrollCycles();
                if (payCycle.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.payCycle = payCycle;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetDepartmentsList")]
        //public async Task<IActionResult> GetDepartmentsList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.DepartmentList = PayrollCycleHelper.GetDepartmentsList().Select(x => new { ID = x.DepartmentId, TEXT = x.DepartmentName });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpPost("RegisterPayrollCycle")]
        public IActionResult RegisterPayrollCycle([FromBody]PayrollCycle payCycle)
        {

            if (payCycle == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(payCycle)} cannot be null" });
            else
            {
                if (PayrollCycleHelper.GetPayrollCycle(payCycle.CycleName) != null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Code =" + payCycle.CycleName + " is already Exists,Please Use Another Code" });

                try
                {
                    APIResponse apiResponse = null;
                    var result = PayrollCycleHelper.Register(payCycle);
                    if (result != null)
                    {
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    }
                    else
                    {
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                    }

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            }
        }

        [HttpPut("UpdatePayrollCycle")]
        public IActionResult UpdatePayrollCycle([FromBody] PayrollCycle payCycle)
        {

            if (payCycle == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(payCycle)} cannot be null" });
            try
            {
                APIResponse apiResponse = null;

                PayrollCycle result = PayrollCycleHelper.Update(payCycle);
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePayrollCycle/{code}")]
        public IActionResult DeletevPF(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = PayrollCycleHelper.Delete(code);
                APIResponse apiResponse;
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
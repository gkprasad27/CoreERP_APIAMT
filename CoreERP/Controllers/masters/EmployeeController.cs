using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/Employee")]
    public class EmployeeController : ControllerBase
    {

        [HttpGet("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {
            try
            {
                var employeesList = EmployeeHelper.GetEmployes();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.employeesList = employeesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           

        }


        [HttpPost("RegisterEmployee")]
        public async Task<IActionResult> RegisterEmployee([FromBody]Employees employee)
        {
            APIResponse apiResponse = null;
            if (employee == null)
                return BadRequest($"{nameof(employee)} cannot be null");
            try
            {
                if (EmployeeHelper.GetEmployesByID(employee.Code).Count() > 0)
                    return BadRequest($"Code {employee.Code} is already exists ,please use different code");

                int result = EmployeeHelper.Register(employee);
                if (result > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

                return Ok(apiResponse);
            }
            catch
            {
                return BadRequest("Registration Failed");
            }
            
        }



        [HttpPut("UpdateEmployee/{code}")]
        public async Task<IActionResult> UpdateEmployee(string code, [FromBody] Employees employee)
        {
            APIResponse apiResponse = null;
            try
            {
                if (employee == null)
                    return BadRequest($"{nameof(employee)} cannot be null");

                int result = EmployeeHelper.Update(employee);
                if (result > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch
            {
                return BadRequest("Updation Failed");
            }
        }


        // Delete Branch
        [HttpDelete("DeleteEmployee/{code}")]
        public async Task<IActionResult> DeleteEmployee(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");
          
            try
            {
                int result = EmployeeHelper.Delete(code);
                if (result > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch{}

            return BadRequest("Delete Operation failed");
        }
    }
}
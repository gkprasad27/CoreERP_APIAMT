using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {

        [HttpGet("masters/employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(new { employees = EmployeeHelper.GetEmployes() });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
           

        }


        [HttpPost("masters/employees/register")]
        public async Task<IActionResult> Register([FromBody]Employees employee)
        {
            if (employee == null)
                return BadRequest($"{nameof(employee)} cannot be null");
            try
            {
                if (EmployeeHelper.GetEmployesByID(employee.Code).Count() > 0)
                    return BadRequest($"Code {employee.Code} is already exists ,please use different code");

                int result = EmployeeHelper.Register(employee);
                if (result > 0)
                    return Ok(employee);

                return BadRequest("Registration Failed");

            }
            catch
            {
                return BadRequest("Registration Failed");
            }
            
        }



        [HttpPut("masters/employees/{code}")]
        public async Task<IActionResult> UpdateEmployee(string code, [FromBody] Employees employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest($"{nameof(employee)} cannot be null");

                int result = EmployeeHelper.Update(employee);
                if (result > 0)
                    return Ok(employee);

                return BadRequest("Updation Failed");
            }
            catch
            {
                return BadRequest("Updation Failed");
            }
        }


        // Delete Branch
        [HttpDelete("masters/employees/{code}")]
        public async Task<IActionResult> DeleteEmployee(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");
          
            try
            {
                int result = EmployeeHelper.Delete(code);
                if (result > 0)
                    return Ok(code);
            }
            catch{}

            return BadRequest("Delete Operation failed");
        }
    }
}
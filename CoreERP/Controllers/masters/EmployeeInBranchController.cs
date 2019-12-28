using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeInBranchController : ControllerBase
    {
       
        [HttpGet("masters/employeeinbranch")]
        public async Task<IActionResult> GetAllEMployeesInBranch()
        {

            try { return Ok(new { empinbr = EmployeeHelper.GetEmployeeInBranches() }); }
            catch { return BadRequest("No Data found"); }

        }


        [HttpGet("masters/employeeinbranch/emplst")]
        public async Task<IActionResult> GetAllEMployees()
        {

            try { return Ok(new { employees = EmployeeHelper.GetEmployes()}); }
            catch { return BadRequest("No Data Found for Employees."); }

        }


        [HttpGet("masters/employeeinbranch/branchlst")]
        public async Task<IActionResult> GetAllBranch()
        {
            try { return Ok(new { branches = BrancheHelper.GetBranches() }); }
            catch { return BadRequest("No Data Found for Branches."); }
        }


        [HttpPost("masters/employeeinbranch/register")]
        public async Task<IActionResult> Register([FromBody]EmployeeInBranches employeeInBranch)
        {
            if (employeeInBranch == null)
                return BadRequest($"{nameof(employeeInBranch)} cannot be null");
            try
            {
                int result = EmployeeHelper.RegisterEmployeeInBranch(employeeInBranch);
                if (result > 0)
                    return Ok(employeeInBranch);

                return BadRequest("Registration Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Registration Failed");
            }
        }



        [HttpPut("masters/employeeinbranch/{code}")]
        public async Task<IActionResult> UpdateEmployeeInBranch(string code, [FromBody] EmployeeInBranches employeeInBranch)
        {
            if (employeeInBranch == null)
                return BadRequest($"{nameof(employeeInBranch)} cannot be null");
            try
            {
                int result = EmployeeHelper.UpdateEmployeeInBranches(employeeInBranch);
                if (result > 0)
                    return Ok(employeeInBranch);

                return BadRequest($"{nameof(employeeInBranch)} Updation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(employeeInBranch)} Updation Failed");
            }
        }


        // Delete Branch
        [HttpDelete("masters/employeeinbranch/{code}")]
        public async Task<IActionResult> DeleteEmployeeInBranch(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                int result = EmployeeHelper.DeleteEmployeeInBranches(code);
                if (result > 0)
                    return Ok(code);

                return BadRequest($"Delete Operation Failed");

            }
            catch (Exception ex)
            {
                return BadRequest($"Delete Operation Failed");
            }

        }
    }
}
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

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/EmployeeInBranch")]
    public class EmployeeInBranchController : ControllerBase
    {
       
        [HttpGet("GetAllEmployeesInBranch")]
        public async Task<IActionResult> GetAllEmployeesInBranch()
        {
            try
            {
                var empinbrList = EmployeeHelper.GetEmployeeInBranches();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.empinbrList = empinbrList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch { return BadRequest("No Data found"); }

        }


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
            catch { return BadRequest("No Data Found for Employees."); }

        }


        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            try
            {
                var branchesList = BrancheHelper.GetBranches();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.branchesList = branchesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch { return BadRequest("No Data Found for Branches."); }
        }


        [HttpPost("RegisterEmployeeInBranch")]
        public async Task<IActionResult> RegisterEmployeeInBranch([FromBody]EmployeeInBranches employeeInBranch)
        {
            APIResponse apiResponse = null;
            if (employeeInBranch == null)
                return BadRequest($"{nameof(employeeInBranch)} cannot be null");
            try
            {
                int result = EmployeeHelper.RegisterEmployeeInBranch(employeeInBranch);
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
            catch (Exception ex)
            {
                return BadRequest("Registration Failed");
            }
        }



        [HttpPut("UpdateEmployeeInBranch/{code}")]
        public async Task<IActionResult> UpdateEmployeeInBranch(string code, [FromBody] EmployeeInBranches employeeInBranch)
        {
            APIResponse apiResponse = null;
            if (employeeInBranch == null)
                return BadRequest($"{nameof(employeeInBranch)} cannot be null");
            try
            {
                int result = EmployeeHelper.UpdateEmployeeInBranches(employeeInBranch);
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
            catch (Exception ex)
            {
                return BadRequest($"{nameof(employeeInBranch)} Updation Failed");
            }
        }


        // Delete Branch
        [HttpDelete("DeleteEmployeeInBranch/{code}")]
        public async Task<IActionResult> DeleteEmployeeInBranch(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                int result = EmployeeHelper.DeleteEmployeeInBranches(code);
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
            catch (Exception ex)
            {
                return BadRequest($"Delete Operation Failed");
            }

        }
    }
}
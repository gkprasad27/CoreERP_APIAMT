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
       
        [HttpGet("GetAllEmployeesInBranch/{BranchCode}")]
        public async Task<IActionResult> GetAllEmployeesInBranch(string BranchCode)
        {
            try
            {
                var empinbrList = EmployeeHelper.GetEmployeeInBranches(null,BranchCode);
                if (empinbrList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.empinbrList = empinbrList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = "No Data Found." });
            }
            catch { }
            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Failed to load data." });
        }


        [HttpGet("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {

            try
            {
                var employeesList = EmployeeHelper.GetEmployes();
                if (employeesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.employeesList = employeesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch {  }
            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Failed to load data." });
        }


        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            try
            {
                var branchesList = BrancheHelper.GetBranches();
                if (branchesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.branchesList = branchesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch { }
            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Failed to load data." });
        }


        [HttpPost("RegisterEmployeeInBranch")]
        public async Task<IActionResult> RegisterEmployeeInBranch([FromBody]EmployeeInBranches employeeInBranch)
        {
            APIResponse apiResponse = null;
            if (employeeInBranch == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(employeeInBranch)} cannot be null" });
            try
            {
                var result = EmployeeHelper.RegisterEmployeeInBranch(employeeInBranch);
                if (result !=null)
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
            }

            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
        }



        [HttpPut("UpdateEmployeeInBranch")]
        public async Task<IActionResult> UpdateEmployeeInBranch(string code, [FromBody] EmployeeInBranches employeeInBranch)
        {
            APIResponse apiResponse = null;
            if (employeeInBranch == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(employeeInBranch)} cannot be null." });

            try
            {
                var result = EmployeeHelper.UpdateEmployeeInBranches(employeeInBranch);
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
            }
            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = " Updation Failed" });
        }


        // Delete Branch
        [HttpDelete("DeleteEmployeeInBranch/{code}")]
        public async Task<IActionResult> DeleteEmployeeInBranch(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = EmployeeHelper.DeleteEmployeeInBranches(code);
                if (result !=null)
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
            }
            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
        }
    }
}
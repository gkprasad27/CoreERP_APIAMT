using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<TblEmployee> _employeeRepository;
        public EmployeeController(IRepository<TblEmployee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetEmployeeList/{companycode}")]

        public async Task<IActionResult> GetEmployeeList(string companycode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var employeesList = EmployeeHelper.GetEmployeesByCompany(companycode);
                    if (employeesList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.employeesList = employeesList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterEmployee")]

        public async Task<IActionResult> RegisterEmployee([FromBody] TblEmployee employee)
        {
            APIResponse apiResponse;
            if (employee == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(employee)} cannot be null" });
            else
            {
                try
                {
                    _employeeRepository.Add(employee);
                    if (_employeeRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = employee };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }


        [HttpPut("UpdateEmployee")]

        public async Task<IActionResult> UpdateEmployee([FromBody] TblEmployee employee)
        {
            APIResponse apiResponse = null;
            if (employee == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _employeeRepository.Update(employee);
                if (_employeeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = employee };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        //// Delete Branch
        [HttpDelete("DeleteEmployee/{code}")]

        public async Task<IActionResult> DeleteEmployee(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _employeeRepository.GetSingleOrDefault(x => x.EmployeeCode.Equals(code));
                _employeeRepository.Remove(record);
                if (_employeeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
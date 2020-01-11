using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
  
    [ApiController]
    [Route("api/masters/Company")]
    public class CompanyController : ControllerBase
    {
        
     

        [HttpGet("GetCompanysList")]
        public async Task<IActionResult> GetCompanysList()
        {
            try
            {
                var companiesList = CompaniesHelper.GetListOfCompanies();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.companiesList = companiesList;
                return   Ok(new APIResponse{ status= APIStatus.PASS.ToString(), response= expdoObj });
            }
            catch(Exception ex) 
            {
               // return NotFound("No Data Found.");

               // return Ok(new { companies = ex.Message });
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Failed to load Companies" });
            }
        }


            [HttpPost("RegisterCompany")]
            public async Task<IActionResult> RegisterCompany([FromBody]Companies company)
            {
            // listobh.Add(company);
            APIResponse apiResponse = null;
                if (company == null)
                    return BadRequest($"{nameof(company)} cannot be null");
                else
                {
                if (CompaniesHelper.GetCompanies(company.CompanyCode) !=null)
                    return BadRequest("Code =" + company.CompanyCode + " is already Exists,Please Use Another Code");

                try
                {
                    int result = CompaniesHelper.Register(company);
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
                    return BadRequest($"{nameof(company)} cannot be null");
                }
                      
                }
            }



            [HttpPut("UpdateCompany/{code}")]
            public async Task<IActionResult> UpdateCompany(string code, [FromBody] Companies company)
            {
            APIResponse apiResponse = null;
            if (company == null)
                    return BadRequest($"{nameof(company)} cannot be null");

                if (!string.IsNullOrWhiteSpace(company.CompanyCode) && code != company.CompanyCode)
                    return BadRequest("Conflicting role id in parameter and model data");

            try
            {
                int result = CompaniesHelper.Update(company);
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
                return BadRequest($"{nameof(company)} Updation Failed");
            }

        }


            // Delete 
            [HttpDelete("DeleteCompany/{code}")]
            public async Task<IActionResult> DeleteCompany(string code)
            {
            APIResponse apiResponse = null;
            if (code == null)
                    return BadRequest($"{nameof(code)}can not be null");

               try
               {
                var result=CompaniesHelper.DeleteCompanies(code);
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
               catch(Exception ex)
               {
                 return BadRequest($"{nameof(code)} Deletion Failed");
               }
                
            }
        
    }
}
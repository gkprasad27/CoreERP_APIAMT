using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
  
    [ApiController]
    [Route("api/Company")]
    public class CompanyController : ControllerBase
    {
        
     

        [HttpGet("GetCompaniesList")]
        public async Task<IActionResult> GetCompaniesList()
        {
            try
            {
                return   Ok(new { companies = CompaniesHelper.GetListOfCompanies() });
            }
            catch(Exception ex) 
            {
               // return NotFound("No Data Found.");

                return Ok(new { companies = ex.Message });
            }
        }


        [HttpPost("RegisterCompany")]
        public async Task<IActionResult> RegisterCompany([FromBody]Companies company)
        {
            // listobh.Add(company);

            if (company == null)
                return BadRequest($"{nameof(company)} cannot be null");
            else
            {
                if (CompaniesHelper.GetCompanies(company.Code) != null)
                    return BadRequest("Code =" + company.Code + " is already Exists,Please Use Another Code");

                try
                {
                    int result = CompaniesHelper.Register(company);
                    if (result > 0)
                        return Ok(company);
                    else
                        return BadRequest($"{nameof(company)} Register Failed");
                }
                catch (Exception ex)
                {
                    return BadRequest($"{nameof(company)} cannot be null");
                }

            }
        }



        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany([FromBody] Companies company)
        {
            if (company == null)
                return BadRequest($"{nameof(company)} cannot be null");

            try
            {
                int result = CompaniesHelper.Update(company);
                if (result > 0)
                    return Ok(company);
                else
                    return BadRequest("Updation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Updation Failed");
            }

        }


        // Delete 
        [HttpDelete("DeleteCompany/{code}")]
        public async Task<IActionResult> DeleteCompany(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                Companies comp = CompaniesHelper.GetCompanies(code);
                comp.Active = "N";
                int result = CompaniesHelper.Update(comp);
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest("Deletion Failed");
            }

        }
    }
}
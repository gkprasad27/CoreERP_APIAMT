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
        
        //public CompanyController()
        //{

        //    _unitOfWork = unitOfWork;
        //    _logger = logger;
        //    _emailer = emailer;
        //}

        [HttpGet("masters/companies")]
        public async Task<IActionResult> GetAllCompanys()
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


            [HttpPost("masters/companies/register")]
            public async Task<IActionResult> Register([FromBody]Companies company)
            {
               // listobh.Add(company);

                if (company == null)
                    return BadRequest($"{nameof(company)} cannot be null");
                else
                {
                if (CompaniesHelper.GetListOfCompanies(company.Code).Count() > 0)
                    return BadRequest("Code =" + company.Code + " is already Exists,Please Use Another Code");

                    try
                    {
                      int result= CompaniesHelper.Register(company);
                    if (result > 0)
                        return Ok(company);
                    else
                       return BadRequest($"{nameof(company)} Register Failed");
                }
                    catch(Exception ex)
                    {
                       return BadRequest($"{nameof(company)} cannot be null");
                    }
                      
                }
            }



            [HttpPut("masters/companies/{code}")]
            public async Task<IActionResult> UpdateCompany(string code, [FromBody] Companies company)
            {
                if (company == null)
                    return BadRequest($"{nameof(company)} cannot be null");

                if (!string.IsNullOrWhiteSpace(company.Code) && code != company.Code)
                    return BadRequest("Conflicting role id in parameter and model data");

                try
                {
                    int result =CompaniesHelper.Update(company);
                    if (result > 0)
                      return Ok(company);
                    else
                      return BadRequest($"{nameof(company)} Updation Failed");
                }
                catch(Exception ex)
                {
                  return BadRequest($"{nameof(company)} Updation Failed");
                }

            }


            // Delete 
            [HttpDelete("masters/companies/{code}")]
            public async Task<IActionResult> DeleteCompany(string code)
            {
                if (code == null)
                    return BadRequest($"{nameof(code)}can not be null");

               try
               {
                int result=CompaniesHelper.Delete(code);
                return Ok(code);
               }
               catch(Exception ex)
               {
                 return BadRequest($"{nameof(code)} Deletion Failed");
               }
                
            }
        
    }
}
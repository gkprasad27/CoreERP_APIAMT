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
    [Route("api/Company")]
    public class CompanyController : ControllerBase
    {


        [HttpGet("GetStatesList")]
        public IActionResult GetStatesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.StatesList = CompaniesHelper.GetStatesList().Select(x => new { ID = x.StateCode, TEXT = x.StateName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        

        [HttpGet("GetCurrencyList")]
        public IActionResult GetCurrencyList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CurrencyList = CompaniesHelper.GetCurrencyList().Select(x => new { ID = x.CurrencySymbol, TEXT = x.CurrencyName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLanguageList")]
        public IActionResult GetLanguageList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.LanguageList = CompaniesHelper.GetLanguageList().Select(x => new { ID = x.LanguageCode, TEXT = x.LanguageName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetRegionList")]
        public IActionResult GetRegionList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.RegionList = CompaniesHelper.GetRegionListList().Select(x => new { ID = x.RegionCode, TEXT = x.RegionName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCountrysList")]
        public IActionResult GetCountrysList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CountryList = CompaniesHelper.GetCountryList().Select(x => new { ID = x.CountryCode, TEXT = x.CountryName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCompanysList")]
        public IActionResult GetCompanysList()
        {
            try
            {
                var companiesList = CompaniesHelper.GetListOfCompanies();
                if (companiesList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.companiesList = companiesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetEmployeesList")]
        public IActionResult GetEmployeesList()
        {
            try
            {
                var empList = CompaniesHelper.GetListOfEmployes();
                if (empList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.emplist = empList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

       
        [HttpPost("RegisterCompany")]
        public IActionResult RegisterCompany([FromBody]TblCompany company)
        {

            if (company == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(company)} cannot be null" });
            else
            {
                if (CompaniesHelper.GetCompanies(company.CompanyCode)!=null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Code =" + company.CompanyCode + " is already Exists,Please Use Another Code" });

                try
                 {
                    APIResponse apiResponse = null;
                    var result = CompaniesHelper.Register(company);
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
        
       [HttpPut("UpdateCompany")]
        public IActionResult UpdateCompany([FromBody] TblCompany company)
        {

            if (company == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(company)} cannot be null" });
            try
            {
                APIResponse apiResponse = null;

                TblCompany result = CompaniesHelper.Update(company);
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
        

        [HttpDelete("DeleteCompany/{code}")]
        public IActionResult DeleteCompany(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = CompaniesHelper.DeleteCompanies(code);
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
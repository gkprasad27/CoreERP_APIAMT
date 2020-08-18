using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/Company")]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository<TblCompany> _companyRepository;
        private readonly IRepository<States> _stateRepository;
        private readonly IRepository<TblCurrency> _currencyRepository;
        private readonly IRepository<TblLanguage> _languageRepository;
        private readonly IRepository<TblRegion> _regionRepository;
        private readonly IRepository<Countries> _countryRepository;
        private readonly IRepository<TblEmployee> _employeeRepository;
        public CompanyController(IRepository<TblCompany> companyRepository, IRepository<States> stateRepository, IRepository<TblCurrency> currencyRepository, IRepository<TblLanguage> languageRepository,
                                 IRepository<TblRegion> regionRepository, IRepository<Countries> countryRepository, IRepository<TblEmployee> employeeRepository)
        {
            _companyRepository = companyRepository;
            _stateRepository = stateRepository;
            _currencyRepository = currencyRepository;
            _languageRepository = languageRepository;
            _regionRepository = regionRepository;
            _countryRepository = countryRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetStatesList")]
        public IActionResult GetStatesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.StatesList = _stateRepository.GetAll().Select(x => new { ID = x.StateCode, TEXT = x.StateName });
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
                expando.CurrencyList = _currencyRepository.GetAll().Select(x => new { ID = x.CurrencySymbol, TEXT = x.CurrencyName });
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
                expando.LanguageList = _languageRepository.GetAll().Select(x => new { ID = x.LanguageCode, TEXT = x.LanguageName });
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
                expando.RegionList = _regionRepository.GetAll().Select(x => new { ID = x.RegionCode, TEXT = x.RegionName });
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
                expando.CountryList = _countryRepository.GetAll().Select(x => new { ID = x.CountryCode, TEXT = x.CountryName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetEmployeesList")]
        public IActionResult GetEmployeesList()
        {
            try
            {
                var empList = _employeeRepository.GetAll();
                if (empList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.emplist = empList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCompanysList")]
        public IActionResult GetCompanysList()
        {
            try
            {
                var companiesList = _companyRepository.GetAll();
                if (companiesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.companiesList = companiesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterCompany")]
        public IActionResult RegisterCompany([FromBody] TblCompany company)
        {

            if (company == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(company)} cannot be null" });
            else
            {
                //if (CompaniesHelper.GetCompanies(company.CompanyCode)!=null)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Code =" + company.CompanyCode + " is already Exists,Please Use Another Code" });

                try
                {
                    APIResponse apiResponse;
                    _companyRepository.Add(company);
                    if (_companyRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = company };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

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
                APIResponse apiResponse;

                _companyRepository.Update(company);
                if (_companyRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = company };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

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
                APIResponse apiResponse;
                var record = _companyRepository.GetSingleOrDefault(x => x.CompanyCode.Equals(code));
                _companyRepository.Remove(record);
                if (_companyRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
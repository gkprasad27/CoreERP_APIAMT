using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/Common")]
    public class CommonController : ControllerBase
    {
        private readonly IRepository<TblCompany> _companyRepository;
        private readonly IRepository<States> _stateRepository;
        private readonly IRepository<TblCurrency> _currencyRepository;
        private readonly IRepository<TblLanguage> _languageRepository;
        private readonly IRepository<TblRegion> _regionRepository;
        private readonly IRepository<Countries> _countryRepository;
        private readonly IRepository<TblLocation> _locationRepository;
        private readonly IRepository<TblEmployee> _employeeRepository;
        private readonly IRepository<TblPlant> _plantRepository;
        private readonly IRepository<TblBranch> _branchRepository;
        private readonly IRepository<TblVoucherType> _vtRepository;
        private readonly IRepository<TblVoucherSeries> _vsRepository;

        public CommonController(IRepository<TblCompany> companyRepository, IRepository<States> stateRepository, IRepository<TblCurrency> currencyRepository, IRepository<TblLanguage> languageRepository,
                                IRepository<TblRegion> regionRepository, IRepository<Countries> countryRepository, IRepository<TblEmployee> employeeRepository,IRepository<TblLocation> locationRepository,
                                IRepository<TblPlant> plantRepository,IRepository<TblBranch>branchRepository,IRepository<TblVoucherType>vtRepository, IRepository<TblVoucherSeries>vsRepository)
        {
            _companyRepository = companyRepository;
            _stateRepository = stateRepository;
            _currencyRepository = currencyRepository;
            _languageRepository = languageRepository;
            _regionRepository = regionRepository;
            _countryRepository = countryRepository;
            _locationRepository = locationRepository;
            _employeeRepository = employeeRepository;
            _plantRepository = plantRepository;
            _branchRepository = branchRepository;
            _vtRepository = vtRepository;
            _vsRepository = vsRepository;
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

        [HttpGet("GetCompanyList")]
        public IActionResult GetCompanysList()
        {
            try
            {
                var companiesList = _companyRepository.GetAll().Select(x => new { ID = x.CompanyCode, TEXT = x.CompanyName });
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

        [HttpGet("GetEmployeeList")]
        public IActionResult GetEmployeesList()
        {
            try
            {
                var empList = _employeeRepository.GetAll().Select(x=> new { ID = x.EmployeeCode, TEXT = x.EmployeeName });
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

        [HttpGet("GetLocationsList")]
        public IActionResult GetLocationsList()
        {
            try
            {
                var locationList = _locationRepository.GetAll().Select(x => new { ID = x.LocationId, TEXT = x.Description });
                if (locationList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.locationList = locationList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPlantsList")]
        public IActionResult GetPlantList()
        {
            try
            {
                var plantList = _plantRepository.GetAll().Select(x => new { ID = x.PlantCode, TEXT = x.Plantname });
                if (plantList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.plantsList = plantList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBranchList")]
        public IActionResult GetBranchList()
        {
            try
            {
                var branchList = _branchRepository.GetAll().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                if (branchList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.branchsList = branchList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetVoucherTypesList")]
        public IActionResult GetVoucherTypesList()
        {
            try
            {
                var vouchertypeList = _vtRepository.GetAll().Select(x => new { ID = x.VoucherTypeId, TEXT = x.VoucherTypeName });
                if (vouchertypeList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.vouchertypeList = vouchertypeList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetVouchersSeriesList")]
        public IActionResult GetVouchersSeriesList()
        {
            try
            {
                var vcseriesList = _vsRepository.GetAll().Select(x=>new { ID =x.VoucherSeriesKey});
                if (vcseriesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.vseriesList = vcseriesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
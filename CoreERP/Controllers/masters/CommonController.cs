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
        private readonly IRepository<TblTaxtransactions> _ttRepository;
        private readonly IRepository<TblTaxRates> _trRepository;
        private readonly IRepository<Glaccounts> _glaccountRepository;
        private readonly IRepository<TblTdsRates> _tdsRatesRepository;
        private readonly IRepository<TblBpgroup> _bpgroupRepository;
        private readonly IRepository<TblAssetClass> _assetClassRepository;
        private readonly IRepository<TblAssetBlock> _assetBlockRepository;
        private readonly IRepository<TblAssetAccountkey> _assetAccountkeyRepository;
        private readonly IRepository<TblBankMaster> _bankMasterRepository;
        private readonly IRepository<TblPaymentTerms> _paymentTermsRepository;
        private readonly IRepository<ProfitCenters> _profitCentersRepository;
        private readonly IRepository<CostCenters> _ccRepository;

        public CommonController(IRepository<TblCompany> companyRepository, IRepository<States> stateRepository, IRepository<TblCurrency> currencyRepository, IRepository<TblLanguage> languageRepository,
                                IRepository<TblRegion> regionRepository, IRepository<Countries> countryRepository, IRepository<TblEmployee> employeeRepository,IRepository<TblLocation> locationRepository,
                                IRepository<TblPlant> plantRepository,IRepository<TblBranch>branchRepository,IRepository<TblVoucherType>vtRepository, IRepository<TblVoucherSeries>vsRepository,
                                IRepository<TblTaxtransactions>ttRepository, IRepository<TblTaxRates>trRepository, IRepository<Glaccounts> glaccountRepository, IRepository<TblTdsRates> tdsRatesRepository,
                                IRepository<TblBpgroup> bpgroupRepository, IRepository<TblAssetClass> assetClassRepository, IRepository<TblAssetBlock> assetBlockRepository, IRepository<TblAssetAccountkey> assetAccountkeyRepository,
                                IRepository<TblBankMaster> bankMasterRepository, IRepository<TblPaymentTerms> paymentTermsRepository, IRepository<ProfitCenters> profitCentersRepository, IRepository<CostCenters> ccRepository)
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
            _ttRepository = ttRepository;
            _trRepository = trRepository;
            _glaccountRepository = glaccountRepository;
            _tdsRatesRepository = tdsRatesRepository;
            _bpgroupRepository = bpgroupRepository;
            _assetClassRepository = assetClassRepository;
            _assetBlockRepository = assetBlockRepository;
            _assetAccountkeyRepository = assetAccountkeyRepository;
            _bankMasterRepository = bankMasterRepository;
            _paymentTermsRepository = paymentTermsRepository;
            _profitCentersRepository = profitCentersRepository;
            _ccRepository = ccRepository;
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
                var vouchertypeList = _vtRepository.GetAll().Select(x => new { ID = x.VoucherTypeId, TEXT = x.VoucherTypeName,VoucherClassName=x.VoucherClass });
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

        [HttpGet("GetTaxTransactionsList")]
        public IActionResult GetTaxTransaction()
        {
            try
            {
                var taxtransactionList = _ttRepository.GetAll().Select(x=> new {ID=x.Code,TEXT=x.Description });
                if (taxtransactionList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.TaxtransactionList = taxtransactionList;
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

        [HttpGet("GetTaxRateList")]
        public async Task<IActionResult> GetTaxRateList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    var TaxRatesList = _trRepository.GetAll().Select(x => new { ID = x.TaxRateCode, TEXT = x.Description });
                    expando.TaxratesList = TaxRatesList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetTaxRate/{taxRateCode}")]
        public async Task<IActionResult> GetTaxRateList(string taxRateCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.Taxrates = _trRepository.Where(x => x.TaxRateCode == taxRateCode).FirstOrDefault(); ;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetGLAccountsList")]
        public async Task<IActionResult> GetGLAccountsList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var glList = _glaccountRepository.GetAll().Select(x => new { ID = x.AccountNumber, TEXT = x.GlaccountName, TAXCategory = x.TaxCategory });
                    if (glList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.glList = glList;
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

        [HttpGet("GLAccountListbyCatetory/{code}")]
        public async Task<IActionResult> GLAccountListbyCatetory(string code)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var glList = _glaccountRepository.Where(x=>x.TaxCategory== code).Select(x => new { ID = x.AccountNumber, TEXT = x.GlaccountName,TAXCategory =x.TaxCategory, AccGroup =x.AccGroup});
                    if (glList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.glList = glList;
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

        [HttpGet("GLAccountListbyCatetory")]
        public async Task<IActionResult> GLAccountListbyCatetory()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var glList = _glaccountRepository.GetAll().Select(x => new { ID = x.AccountNumber, TEXT = x.GlaccountName, controlaccount = x.ControlAccount,category=x.TaxCategory, accGroup = x.AccGroup });
                    if (glList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.glList = glList;
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

        [HttpGet("GetTDSRateList")]
        public IActionResult GetTDSRateList()
        {
            try
            {
                var tdsratesList = _tdsRatesRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Desctiption });
                if (tdsratesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.tdsratesList = tdsratesList;
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

        [HttpGet("GetBusienessPartnersGroupsList")]
        public IActionResult GetBusienessPartnersGroupsList()
        {
            try
            {
                var bpgList = _bpgroupRepository.GetAll().Select(x => new { ID = x.Bpgroup, TEXT = x.Description });
                if (bpgList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.bpgList = bpgList;
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

        [HttpGet("GetAssetsBlockList")]
        public IActionResult GetAssetsBlockList()
        {
            try
            {
                var assetblockList = _assetBlockRepository.GetAll().Select(x=>new { ID=x.Code,TEXT=x.Description});
                if (assetblockList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetblockList = assetblockList;
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

        [HttpGet("GetAssetsClassList")]
        public IActionResult GetAssetsClassList()
        {
            try
            {
                var assetList = _assetClassRepository.GetAll().Select(x=>new { ID=x.Code,TEXT=x.Description});
                if (assetList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetList = assetList;
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

        [HttpGet("GetAccountsKeyList")]
        public async Task<IActionResult> GetAccountsKeyList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var acckeyList = _assetAccountkeyRepository.GetAll().Select(x=>new { ID=x.Code,TEXT=x.Description});
                    if (acckeyList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.acckeyList = acckeyList;
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

        [HttpGet("GetBankMastersList")]
        public async Task<IActionResult> GetBankMastersList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var bankList = _bankMasterRepository.GetAll().Select(x=>new { ID=x.BankCode,TEXT=x.BankName});
                    if (bankList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.bankList = bankList;
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

        [HttpGet("GetPaymentsTermsList")]
        public IActionResult GetPaymentsTermsList()
        {
            try
            {
                var ptermsList = _paymentTermsRepository.GetAll().Select(x=>new { ID=x.Code,TEXT=x.Description});
                if (ptermsList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ptermsList = ptermsList;
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

        [HttpGet("GetProfitCentersList")]
        public IActionResult GetProfitCentersList()
        {
            try
            {
                var profitCenterList =  _profitCentersRepository.GetAll().Select(x=>new { ID=x.Code,TEXT=x.Description});
                if (profitCenterList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.profitCenterList = profitCenterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception e)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = e.Message });
            }
        }

        [HttpGet("GetCostCentersList")]
        public IActionResult GetCostCentersList()
        {
            try
            {
                var costcenterList = _ccRepository.GetAll().Select(x=>new { ID=x.Code,TEXT=x.Name});
                if (costcenterList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costcenterList = costcenterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
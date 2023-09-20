using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private readonly IRepository<TblUnit> _unitRepository;
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
        private readonly IRepository<TblBusinessPartnerAccount> _bpRepository;
        private readonly IRepository<TblInvoiceMemoHeader> _InvoiceMemoHeaderRepository;
        private readonly IRepository<TblMainAssetMaster> _tblMainAssetRepository;
        private readonly IRepository<TblSubAssetMaster> _tblsubAssetRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<TblSecondaryCostElement> _secondaryCostElementRepository;
        private readonly IRepository<TblCostingObjectTypes> _costingObjectTypesRepository;
        private readonly IRepository<TblCostingNumberSeries> _costingNumberSeriesRepository;
        private readonly IRepository<TblCostingUnitsCreation> _costingUnitsCreationRepository;
        private readonly IRepository<TblMaterialMaster> _materialMasterRepository;
        private readonly IRepository<TblWbs> _wbsRepository;
        private readonly IRepository<TblWorkcenterMaster> _workcenterMasterRepository;
        private readonly IRepository<TblMaterialRequisitionMaster> _materialRequisitionMasterRepository;
        private readonly IRepository<TblMaterialRequisitionDetails> _materialRequisitionDetailsRepository;
        private readonly IRepository<TblPurchaseOrderDetails> _purchaseOrderDetailsRepository;
        private readonly IRepository<TblQuotationAnalysis> _quotationAnalysisRepository;
        private readonly IRepository<TblPurchaseOrder> _purchaseOrderRepository;
        private readonly IRepository<TblGoodsReceiptMaster> _goodsReceiptMasterRepository;
        private readonly IRepository<TblGoodsReceiptDetails> _goodsReceiptDetailsRepository;
        private readonly IRepository<TblHsnsac> _hsnsacRepository;
        private readonly IRepository<TblMaterialTypes> _materialTypesRepository;
        private readonly IRepository<TblPrimaryCostElement> _primaryCostElementRepository;
        private readonly IRepository<LeaveTypes> _leaveTyperepository;
        private readonly IRepository<ConfigurationTable> _configurationRepository;
        public CommonController(IRepository<TblCompany> companyRepository, IRepository<Department> departmentRepository, IRepository<States> stateRepository, IRepository<TblCurrency> currencyRepository, IRepository<TblLanguage> languageRepository,
                                IRepository<TblRegion> regionRepository, IRepository<Countries> countryRepository, IRepository<TblEmployee> employeeRepository, IRepository<TblLocation> locationRepository,
                                IRepository<TblPlant> plantRepository, IRepository<TblBranch> branchRepository, IRepository<TblVoucherType> vtRepository, IRepository<TblVoucherSeries> vsRepository,
                                IRepository<TblTaxtransactions> ttRepository, IRepository<TblTaxRates> trRepository, IRepository<Glaccounts> glaccountRepository, IRepository<TblTdsRates> tdsRatesRepository,
                                IRepository<TblBpgroup> bpgroupRepository, IRepository<TblAssetClass> assetClassRepository, IRepository<TblAssetBlock> assetBlockRepository, IRepository<TblAssetAccountkey> assetAccountkeyRepository,
                                IRepository<TblBankMaster> bankMasterRepository, IRepository<TblPaymentTerms> paymentTermsRepository, IRepository<ProfitCenters> profitCentersRepository, IRepository<CostCenters> ccRepository,
                                IRepository<TblBusinessPartnerAccount> bpRepository, IRepository<TblUnit> unitRepository, IRepository<TblMainAssetMaster> tblMainAssetRepository, IRepository<TblSubAssetMaster> tblsubAssetRepository,
                                IRepository<TblInvoiceMemoHeader> tblInvoiceMemoHeaderRepository,
                                IRepository<TblSecondaryCostElement> secondaryCostElementRepository,
                                 IRepository<TblCostingObjectTypes> costingObjectTypesRepository, IRepository<TblCostingUnitsCreation> costingUnitsCreationRepository,
                                IRepository<TblCostingNumberSeries> costingNumberSeriesRepository,
                                IRepository<TblMaterialMaster> materialMasterRepository,
                                IRepository<TblPurchaseOrderDetails> PurchaseOrderDetailsRepository,
                                IRepository<TblWbs> wbsRepository, IRepository<TblMaterialRequisitionDetails> materialRequisitionDetailsRepository,
                                IRepository<TblMaterialRequisitionMaster> materialRequisitionMasterRepository,
                                IRepository<TblWorkcenterMaster> workcenterMasterRepository, IRepository<TblPurchaseOrder> purchaseOrderRepository,
                                IRepository<TblQuotationAnalysis> quotationAnalysisRepository,
                                IRepository<TblGoodsReceiptMaster> goodsReceiptMasterRepository,
                                IRepository<TblGoodsReceiptDetails> GoodsReceiptDetailsRepository,
                                IRepository<TblHsnsac> hsnsacRepository, IRepository<TblPrimaryCostElement> primaryCostElementRepository,
                                IRepository<TblMaterialTypes> materialTypesRepository, IRepository<ConfigurationTable> configurationRepository,IRepository<LeaveTypes> leaveTypeRepository)
        {
            _primaryCostElementRepository = primaryCostElementRepository;
            _materialTypesRepository = materialTypesRepository;
            _hsnsacRepository = hsnsacRepository;
            _goodsReceiptMasterRepository = goodsReceiptMasterRepository;
            _goodsReceiptDetailsRepository = GoodsReceiptDetailsRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _quotationAnalysisRepository = quotationAnalysisRepository;
            _workcenterMasterRepository = workcenterMasterRepository;
            _materialRequisitionMasterRepository = materialRequisitionMasterRepository;
            _InvoiceMemoHeaderRepository = tblInvoiceMemoHeaderRepository;
            _companyRepository = companyRepository;
            _unitRepository = unitRepository;
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
            _bpRepository = bpRepository;
            _tblMainAssetRepository = tblMainAssetRepository;
            _tblsubAssetRepository = tblsubAssetRepository;
            _departmentRepository = departmentRepository;
            _secondaryCostElementRepository = secondaryCostElementRepository;
            _costingObjectTypesRepository = costingObjectTypesRepository;
            _costingNumberSeriesRepository = costingNumberSeriesRepository;
            _costingUnitsCreationRepository = costingUnitsCreationRepository;
            _materialMasterRepository = materialMasterRepository;
            _wbsRepository = wbsRepository;
            _purchaseOrderDetailsRepository = PurchaseOrderDetailsRepository;
            _materialRequisitionDetailsRepository = materialRequisitionDetailsRepository;
            _configurationRepository = configurationRepository;
            _leaveTyperepository = leaveTypeRepository;
        }

        [HttpGet("GetPrimaryCostElementList")]
        public IActionResult GetPrimaryCostElementList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.PRCList = _primaryCostElementRepository.GetAll().Select(x => new { ID = x.GeneralLedger, TEXT = x.GeneralLedger });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetHSNSACList")]
        public IActionResult GetHSNSACList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.HSNSACList = _hsnsacRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Description });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBPList")]
        public IActionResult GetBPList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BPList = _bpRepository.GetAll().Select(x => new { ID = x.Bpnumber, TEXT = x.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetWorkcenterList")]
        public IActionResult GetWorkcenterList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.wcList = _workcenterMasterRepository.GetAll().Select(x => new { ID = x.WorkcenterCode, TEXT = x.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetQuotationnoList")]
        public IActionResult GetQuotationnoList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.qnoList = _quotationAnalysisRepository.GetAll().Select(x => new { ID = x.QuotationNumber, TEXT = x.QuotationNumber });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetInspectionnoList")]
        public IActionResult GetInspectionnoList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.inspectionnoList = _goodsReceiptMasterRepository.GetAll().Select(x => new { ID = x.InspectionNoteNo, TEXT = x.InspectionNoteNo });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetGoodsReceiptList")]
        public IActionResult GetGoodsReceiptList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.grList = _goodsReceiptMasterRepository.GetAll();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchaseOrdernoList")]
        public IActionResult GetPurchaseOrdernoList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.purchaseordernoList = _purchaseOrderRepository.GetAll().Select(x => new { ID = x.PurchaseOrderNumber, TEXT = x.PurchaseOrderNumber });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetMaterialreqdetailsList")]
        public IActionResult GetMaterialreqdetailsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.mreqdetailsList = _materialRequisitionDetailsRepository.GetAll();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetPOdetailsList")]
        public IActionResult GetPOdetailsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.podetailsList = _purchaseOrderDetailsRepository.GetAll();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetInspectiondetailsList")]
        public IActionResult GetInspectiondetailsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.inspectiondetailsList = _goodsReceiptDetailsRepository.GetAll();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetMaterialreqList")]
        public IActionResult GetMaterialreqList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.mreqList = _materialRequisitionMasterRepository.GetAll().Select(x => new { ID = x.RequisitionNmber, TEXT = x.RequisitionNmber });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetWbsList")]
        public IActionResult GetWbsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.wbsList = _wbsRepository.GetAll().Select(x => new { ID = x.Wbscode, TEXT = x.Description });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialList")]
        public IActionResult GetMaterialList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.materialList = _materialMasterRepository.GetAll().Select(x => new { ID = x.MaterialCode, TEXT = x.Description, ClosingQty = x.ClosingQty });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialListForCostunits")]
        public IActionResult GetMaterialListForCostunits()
        {
            try
            {
                var favouriteCities = new List<string>();
                List<TblMaterialMaster> mmDetails = new List<TblMaterialMaster>();
                List<TblMaterialMaster> mmaster = new List<TblMaterialMaster>();

                dynamic expando = new ExpandoObject();
                //var data = _materialTypesRepository.Where(x => x.Class == "Finished" || x.Class == "Semi-Finished").ToArray();
                var data = _materialTypesRepository.GetAll().ToArray();
                foreach (var item in data)
                {
                    mmDetails = _materialMasterRepository.Where(x => x.MaterialType == item.Code || x.MaterialType == item.Code).ToList();
                    foreach (var item1 in mmDetails)
                    {
                        mmaster.Add(item1);
                    }
                }
                expando.mtypeList = mmaster.Select(x => new { ID = x.MaterialCode, TEXT = x.Description });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCostingObjectTypeList")]
        public IActionResult GetCostingObjectTypeList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.cotList = _costingObjectTypesRepository.GetAll().Select(x => new { ID = x.ObjectType, TEXT = x.Description, Usage = x.Usage });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCostingNumberSeriesList")]
        public IActionResult GetCostingNumberSeriesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.cnsList = _costingNumberSeriesRepository.GetAll().Select(x => new { ID = x.NumberObject, TEXT = x.NumberObject });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCostingSecondaryList")]
        public IActionResult GetCostingSecondaryList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.csList = _secondaryCostElementRepository.GetAll().Select(x => new { ID = x.SecondaryCostCode, TEXT = x.Description });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetDepartmentList")]
        public IActionResult GetDepartmentList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.deptList = _departmentRepository.GetAll().Select(x => new { ID = x.DepartmentId, TEXT = x.DepartmentName });
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

        [HttpGet("GetUOMList")]
        public IActionResult GetUOMList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.UOMList = _unitRepository.GetAll().Select(x => new { ID = x.UnitId, TEXT = x.UnitName });
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
                if (companiesList.Any())
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

        [HttpGet("GetEmployeeList")]
        public IActionResult GetEmployeesList()
        {
            try
            {
                var empList = _employeeRepository.GetAll().Select(x => new { ID = x.EmployeeCode, TEXT = x.EmployeeName });
                if (empList.Any())
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

        [HttpGet("GetCostUnitList")]
        public IActionResult GetCostUnitList()
        {
            try
            {
                var costunitList = _costingUnitsCreationRepository.GetAll().Select(x => new { ID = x.ObjectNumber, TEXT = x.Description, MATERIAL = x.Material, CostUnitType = x.CostUnitType });
                if (costunitList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costunitList = costunitList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetMaterialMasterList")]
        public IActionResult GetMaterialMasterList()
        {
            try
            {
                var mmasterList = _materialMasterRepository.GetAll().Select(x => new { ID = x.MaterialCode, TEXT = x.Description, MATERIAL = x.MaterialType, AvailQTY = x.ClosingQty });
                if (mmasterList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.mmasterList = mmasterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                if (locationList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.locationList = locationList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                if (plantList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.plantsList = plantList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                if (branchList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.branchsList = branchList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                //var vouchertypeList = _vtRepository.GetAll().Select(x => new { ID = x.VoucherTypeId, TEXT = x.VoucherTypeName, VoucherClassName = x.VoucherClass,accountType=x.AccountType });
                var vouchertypeList = CommonHelper.GetVoucherType();
                if (vouchertypeList.Any())
                {
                    dynamic expando = new ExpandoObject();
                    expando.vouchertypeList = vouchertypeList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

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
                var vcseriesList = _vsRepository.GetAll().Select(x => new { ID = x.VoucherSeriesKey });
                if (vcseriesList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.vseriesList = vcseriesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                var taxtransactionList = _ttRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Description });
                if (taxtransactionList.Any())
                {
                    dynamic expando = new ExpandoObject();
                    expando.TaxtransactionList = taxtransactionList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

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
                    var taxRatesList = _trRepository.GetAll().Select(x => new { ID = x.TaxRateCode, TEXT = x.Description });
                    expando.TaxratesList = taxRatesList;
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
                    expando.Taxrates = _trRepository.Where(x => x.TaxRateCode == taxRateCode).FirstOrDefault();
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
        public async Task<IActionResult> GetGlAccountsList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var glList = _glaccountRepository.GetAll().Select(x => new { ID = x.AccountNumber, TEXT = x.GlaccountName, TAXCategory = x.TaxCategory,ControlAccount=x.ControlAccount });
                    if (glList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.glList = glList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

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
        public async Task<IActionResult> GlAccountListbyCatetory(string code)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var glList = _glaccountRepository.Where(x => x.TaxCategory == code).Select(x => new { ID = x.AccountNumber, TEXT = x.GlaccountName, TAXCategory = x.TaxCategory, x.AccGroup });
                    if (glList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.glList = glList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

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
        public async Task<IActionResult> GlAccountListbyCatetory()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var glList = _glaccountRepository.GetAll().Select(x => new { ID = x.AccountNumber, TEXT = x.GlaccountName, controlaccount = x.ControlAccount, category = x.TaxCategory, accGroup = x.AccGroup });
                    if (glList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.glList = glList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

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
        public IActionResult GetTdsRateList()
        {
            try
            {
                var tdsratesList = _tdsRatesRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Desctiption });
                if (tdsratesList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.tdsratesList = tdsratesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                var bpgList = _bpgroupRepository.GetAll().Select(x => new { ID = x.Bpgroup, TEXT = x.Description, BPTYPE = x.Bptype });
                if (bpgList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.bpgList = bpgList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                var assetblockList = _assetBlockRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Description });
                if (assetblockList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetblockList = assetblockList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                var assetList = _assetClassRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Description });
                if (assetList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetList = assetList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                    var acckeyList = _assetAccountkeyRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Description });
                    if (acckeyList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.acckeyList = acckeyList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

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
                    var bankList = _bankMasterRepository.GetAll().Select(x => new { ID = x.BankCode, TEXT = x.BankName });
                    if (bankList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.bankList = bankList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

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
                var ptermsList = _paymentTermsRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Description });
                if (ptermsList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ptermsList = ptermsList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

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
                var profitCenterList = _profitCentersRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Name });
                if (profitCenterList.Any())
                {
                    dynamic expando = new ExpandoObject();
                    expando.profitCenterList = profitCenterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

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
                var costcenterList = _ccRepository.GetAll().Select(x => new { ID = x.Code, TEXT = x.Name });
                if (costcenterList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costcenterList = costcenterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCustomerList")]
        public IActionResult GetCustomerList()
        {
            try
            {
                var bpList = CommonHelper.BPList().Select(x => new { ID = x.Bpnumber, TEXT = x.Name, BPTYPE = x.BpTypeName ,BPGROUP=x.BpGroupName});
                if (bpList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.bpList = bpList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchaseInvoiceList")]
        public IActionResult GetPurchaseInvoiceList()
        {
            try
            {
                var purchaseinvoiceList = _InvoiceMemoHeaderRepository.GetAll().Select(x => new { x.PartyAccount, x.PartyInvoiceNo, x.TotalAmount, x.PostingDate, x.Paymentterms, x.DueDate });
                if (purchaseinvoiceList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.purchaseinvoiceList = purchaseinvoiceList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        //[HttpGet("GetFieldsConfig/{screenmodel}/{screenName}/{userName}")]
        //public IActionResult GetFieldsConfig(string screenmodel, string screenName,string userName)
        //{
        //    try
        //    {
        //        dynamic expdoObj = new ExpandoObject();
        //        expdoObj.FieldsConfiguration = CommonHelper.GetScreenConfig(screenmodel,screenName, userName);
        //        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpGet("GetMainAssetMasterList")]
        public IActionResult GetMainAssetMasterList()
        {
            try
            {
                var costcenterList = _tblMainAssetRepository.GetAll().Select(x => new { ID = x.AssetNumber, TEXT = x.Name });
                if (costcenterList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.mamList = costcenterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetSubAssetMasterList")]
        public IActionResult GetSubAssetMasterList()
        {
            try
            {
                var costcenterList = _tblsubAssetRepository.GetAll().Select(x => new { ID = x.SubAssetNumber, TEXT = x.Description });
                if (costcenterList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.saList = costcenterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetUserPermissions/{roleId}/{screenName}")]
        public IActionResult GetUserPermissions(string roleId, string screenName)
        {
            try
            {
                var permission = CommonHelper.GetUserPermissions(roleId, screenName);
                if (permission == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = null });

                var showControl = CommonHelper.GetScreenConfig(permission.OperationCode);
                dynamic expdoObj = new ExpandoObject();
                expdoObj.Permissions = permission;
                expdoObj.ShowControl = showControl;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetConfigurationList")]
        public IActionResult GetConfigurationList()
        {
            try
            {
                var ConfigurationList = _configurationRepository.GetAll();
                if (!ConfigurationList.Any())
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.ComponentTypesList = ConfigurationList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLeaveTypeList/{companyCode}")]
        public IActionResult GetLeaveTypeList(string companyCode)
        {
            try
            {
                var leaveTypeList = _leaveTyperepository.GetAll().Select(x => new { ID = x.LeaveCode, TEXT = x.LeaveName });
                if (leaveTypeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.leaveTypeList = leaveTypeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
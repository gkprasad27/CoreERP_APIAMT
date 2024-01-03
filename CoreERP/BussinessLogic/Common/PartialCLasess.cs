using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    partial class Countries
    {
        [NotMapped]
        public string LangName { get; set; }
        [NotMapped]
        public string CurrName { get; set; }

    }

    public partial class tblQCResults
    {
        [NotMapped]
        public string UOMName { get; set; }
    }

    public partial class tblQCDetails
    {
        [NotMapped]
        public string UOMName { get; set; }
    }
    public partial class tblQCResults
    {
        [NotMapped]
        public string MaterialName { get; set; }
    }
    partial class TblPurchaseOrderDetails
    {
        [NotMapped]
        public int? AvailableQTY { get; set; }

    }
    partial class TblSaleOrderDetail
    {
        [NotMapped]
        public int AvailableQTY { get; set; }

    }
    partial class TblRegion
    {
        [NotMapped]
        public string CountryName { get; set; }
    }

    partial class TblPurchaseNoRange
    {
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string departmentname { get; set; }
    }


    partial class States
    {
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string LangName { get; set; }
    }

    partial class TblPurchasePerson
    {
        [NotMapped]
        public string PurchaseGroupName { get; set; }
        [NotMapped]
        public string PurchaseTypesName { get; set; }
        [NotMapped]
        public string PersonName { get; set; }
    }

    partial class TblReqNoAssignment
    {
        [NotMapped]
        public string NoRangeName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }

    }
    partial class TblQuotationNoAssignment
    {
        [NotMapped]
        public string NoRangeName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }

    }


    partial class TblPurchaseOrder
    {
        [NotMapped]
        public string PurchaseOrderName { get; set; }
    }
    partial class TblPurchaseOrderNoAssignment
    {
        [NotMapped]
        public string NoRangeName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string PorderGroupName { get; set; }
    }

    partial class TblLotAssignment
    {
        [NotMapped]
        public string NoRangeName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
    }
    partial class TblInspectionCheckDetails
    {
        [NotMapped]
        public string MaterialName { get; set; }
    }
    partial class TblGrnassignment
    {
        [NotMapped]
        public string GrnseriesName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
    }
    partial class TblWorkcenterMaster
    {
        [NotMapped]
        public string Activity { get; set; }
        [NotMapped]
        public string Description { get; set; }
        [NotMapped]
        public string UOM { get; set; }
        [NotMapped]
        public string CostCenter { get; set; }
        [NotMapped]
        public string Formula { get; set; }
        [NotMapped]
        public string Resource { get; set; }
        [NotMapped]
        public string Capacity { get; set; }
        [NotMapped]
        public string WorkingHours { get; set; }
        [NotMapped]
        public string BreakTime { get; set; }
        [NotMapped]
        public string NetHours { get; set; }
        [NotMapped]
        public string Shifts { get; set; }
        [NotMapped]
        public string TotalCapacity { get; set; }
        [NotMapped]
        public string WeekDays { get; set; }
        [NotMapped]
        public string HoursPerWeek { get; set; }
    }

    partial class TblTaskMaster
    {
        [NotMapped]
        public string Resource { get; set; }
        [NotMapped]
        public string MaterialCode { get; set; }
        [NotMapped]
        public string QTY { get; set; }
        [NotMapped]
        public string CostCenter { get; set; }
        [NotMapped]
        public string Activity { get; set; }
        [NotMapped]
        public string Rate { get; set; }
    }

    partial class TblRoutingMasterData
    {
        [NotMapped]
        public string Operation { get; set; }
        [NotMapped]
        public string SubOperation { get; set; }
        [NotMapped]
        public string WorkCenter { get; set; }
        [NotMapped]
        public string BaseQuantity { get; set; }
        [NotMapped]
        public string OperationUnit { get; set; }
        [NotMapped]
        public string CostCenter { get; set; }
        [NotMapped]
        public string Activity { get; set; }
        [NotMapped]
        public string StandardValue { get; set; }
        [NotMapped]
        public string UOM { get; set; }
        [NotMapped]
        public string Formula { get; set; }
        [NotMapped]
        public string Qty { get; set; }
        [NotMapped]
        public string ToolsEqupment { get; set; }
        [NotMapped]
        public string Numbers { get; set; }
    }


    partial class TblGinseriesAssignment
    {
        [NotMapped]
        public string GinseriesName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
    }

    partial class TblMrnnoAssignment
    {
        [NotMapped]
        public string MaterialseriesName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
    }


    partial class TblGoodsReceiptDetails
    {
        [NotMapped]
        public string TblPurchaseRequisitionDetails { get; set; }
    }

    partial class TblMaterialNoAssignment
    {
        [NotMapped]
        public string NumberRangeName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
    }

    partial class TblBinsCreation
    {
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string EmployeeName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
        [NotMapped]
        public string UomName { get; set; }
    }

    partial class TblRequisitionNoRange
    {
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string Departmentname { get; set; }

    }

    partial class TblPrimaryCostElement
    {
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string ChartAccountName { get; set; }
        [NotMapped]
        public string UomName { get; set; }
        [NotMapped]
        public string AccGroupName { get; set; }
    }
    partial class TblSecondaryCostElement
    {
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string ChartAccountName { get; set; }
        [NotMapped]
        public string UomName { get; set; }
    }
    partial class TblCostingActivity
    {
        [NotMapped]
        public string SecondCostName { get; set; }
        [NotMapped]
        public string UomName { get; set; }
    }

    partial class TblCostingnumberAssigntoObject
    {
        [NotMapped]
        public string ObjectName { get; set; }
        [NotMapped]
        public string SeriesName { get; set; }
    }
    partial class TblCostingUnitsCreation
    {
        [NotMapped]
        public string ObjectName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
    }
    partial class TblBatchMaster
    {
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string EmployeeName { get; set; }
        [NotMapped]
        public string UomName { get; set; }
    }
    partial class TblOrderType
    {
        [NotMapped]
        public string CostUnitName { get; set; }

    }
    partial class TblProcess
    {
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string CostunitName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
    }

    partial class TblCostingKeyFigures
    {
        [NotMapped]
        public string UomName { get; set; }
    }
    partial class tblQCMaster
    {
        [NotMapped]
        public string UomName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
     
    }
    partial class TblInspectionCheckMaster
    {
        [NotMapped]
        public string Type { get; set; }
    }
    partial class TblMaterialMaster
    {
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string MaterialName { get; set; }
        [NotMapped]
        public string MaterialGroupName { get; set; }
        [NotMapped]
        public string MaterialSizeName { get; set; }
        [NotMapped]
        public string UomName { get; set; }
        [NotMapped]
        public string ModelPatternName { get; set; }
        [NotMapped]
        public string DivisionName { get; set; }
        [NotMapped]
        public string PurchaseGroupName { get; set; }
    }

    partial class TblCompany
    {
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
        [NotMapped]
        public string LanguageName { get; set; }
    }

    partial class ProfitCenters
    {
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
        [NotMapped]
        public string LanguageName { get; set; }
        [NotMapped]
        public string ResponsibleName { get; set; }
    }

    partial class TblBranch
    {
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
        [NotMapped]
        public string LanguageName { get; set; }
        [NotMapped]
        public string ResponsibleName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }

    }

    partial class Divisions
    {
        [NotMapped]
        public string ResponsibleName { get; set; }
    }
    partial class CostCenters
    {
        [NotMapped]
        public string ResponsibleName { get; set; }
        [NotMapped]
        public string ObjectName { get; set; }
        [NotMapped]
        public string UomName { get; set; }
    }
    partial class TblFundCenter
    {
        [NotMapped]
        public string PersonName { get; set; }
        [NotMapped]
        public string ProfitName { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }
        [NotMapped]
        public string CostCenterName { get; set; }
        [NotMapped]
        public string SegmentName { get; set; }
    }

    partial class TblFunctionalDepartment
    {
        [NotMapped]
        public string ResponsibleName { get; set; }
    }

    partial class CostCenters
    {
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }
        [NotMapped]
        public string Uom { get; set; }
    }

    partial class TblPlant
    {
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
        [NotMapped]
        public string LanguageName { get; set; }
        [NotMapped]
        public string ResponsibleName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
    }

    partial class TblLocation
    {
        [NotMapped]
        public string PlantName { get; set; }
    }

    partial class SalesDepartment
    {
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
        [NotMapped]
        public string LanguageName { get; set; }
        [NotMapped]
        public string ResponsibleName { get; set; }
    }

    partial class TblSalesOffice
    {
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
        [NotMapped]
        public string LanguageName { get; set; }
        [NotMapped]
        public string ResponsibleName { get; set; }
    }

    partial class TblMaintenancearea
    {
        [NotMapped]
        public string PlantName { get; set; }
    }

    partial class TblStorageLocation
    {
        [NotMapped]
        public string PlantName { get; set; }
    }

    partial class TblOpenLedger
    {
        [NotMapped]
        public string LedgerName { get; set; }
    }

    partial class TblVoucherType
    {
        [NotMapped]
        public string voucherClassName { get; set; }
        [NotMapped]
        public string VoucherNature { get; set; }
    }

    partial class TblVoucherSeries
    {
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string BranchName { get; set; }
    }

    partial class TblAssignmentVoucherSeriestoVoucherType
    {
        [NotMapped]
        public string VoucherTypeName { get; set; }
    }

    partial class TblTaxtransactions
    {
        [NotMapped]
        public string TaxTypeName { get; set; }
    }

    partial class TblTaxRates
    {
        [NotMapped]
        public string TaxTransactionName { get; set; }
    }

    partial class TblAssignTaxacctoTaxcode
    {
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string BranchName { get; set; }
        [NotMapped]
        public string ChartAccountName { get; set; }
        [NotMapped]
        public string SGSTName { get; set; }
        [NotMapped]
        public string CGSTName { get; set; }
        [NotMapped]
        public string UGSTName { get; set; }
        [NotMapped]
        public string IGSTName { get; set; }
        [NotMapped]
        public string CompositeAccountName { get; set; }
    }

    partial class TblTdsRates
    {
        [NotMapped]
        public string IncomeTypeName { get; set; }
        [NotMapped]
        public string TdsTypeName { get; set; }
    }

    partial class TblPosting
    {
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string BranchName { get; set; }
        [NotMapped]
        public string ChartAccountName { get; set; }
        [NotMapped]
        public string TdsRatetName { get; set; }
        [NotMapped]
        public string GLAccountName { get; set; }
    }

    partial class TblAssignchartaccttoCompanycode
    {
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string OchartAccountName { get; set; }
        [NotMapped]
        public string GchartAccountName { get; set; }

    }

    partial class TblAccountGroup
    {
        [NotMapped]
        public string UnderAccountName { get; set; }

    }

    partial class AssignmentSubaccounttoGl
    {
        [NotMapped]
        public string UnderAccountName { get; set; }
        [NotMapped]
        public string GlAccountName { get; set; }
    }

    partial class TblBpgroup
    {
        [NotMapped]
        public string PartnerTypeName { get; set; }
    }

    partial class TblAssignment
    {
        [NotMapped]
        public string BpGroupName { get; set; }
    }

    partial class TblAlternateControlAccTrans
    {
        [NotMapped]
        public string NcName { get; set; }
        [NotMapped]
        public string AcName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string ChartAccountName { get; set; }
    }

    partial class TblAssetBlock
    {
        [NotMapped]
        public string DepreciationName { get; set; }
    }

    partial class TblAssignAssetClasstoBlockAsset
    {
        [NotMapped]
        public string AssetClassName { get; set; }
        [NotMapped]
        public string AssetBlockName { get; set; }
    }

    partial class TblAssignAccountkeytoAsset
    {
        [NotMapped]
        public string AssetClassName { get; set; }
        [NotMapped]
        public string AccountKeyName { get; set; }
    }

    partial class TblAssetAccountkey
    {
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string ChartAccountName { get; set; }
        [NotMapped]
        public string AcquisationName { get; set; }
        [NotMapped]
        public string AccumulatedName { get; set; }
        [NotMapped]
        public string AucName { get; set; }
        [NotMapped]
        public string SalesRevenueName { get; set; }
        [NotMapped]
        public string LossonSalesName { get; set; }
        [NotMapped]
        public string GainonSalesName { get; set; }
        [NotMapped]
        public string ScrapGLName { get; set; }
        [NotMapped]
        public string DepreciationGLName { get; set; }

    }

    partial class TblBankMaster
    {
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
    }

    partial class Glaccounts
    {
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string ChartAccountName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
        [NotMapped]
        public string AccGroupName { get; set; }
        [NotMapped]
        public string BankName { get; set; }
    }

    partial class TblGlsubAccount
    {
        [NotMapped]
        public string AccGroupName { get; set; }
    }

    partial class TblBusinessPartnerAccount
    {
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string BpTypeName { get; set; }
        [NotMapped]
        public string BpGroupName { get; set; }
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string RegionName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string ControlAccountName { get; set; }
        [NotMapped]
        public string PaymentTermsName { get; set; }
        [NotMapped]
        public string TdsTypeName { get; set; }
        [NotMapped]
        public string TdsStateName { get; set; }
    }

    partial class TblMainAssetMaster
    {
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string AssetClassName { get; set; }
        [NotMapped]
        public string AccountKeyName { get; set; }
        [NotMapped]
        public string BranchName { get; set; }
        [NotMapped]
        public string ProfitCenterName { get; set; }
        [NotMapped]
        public string SegmentName { get; set; }
        [NotMapped]
        public string DivisionName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string DepreciationDataName { get; set; }
        [NotMapped]
        public string DepreciationAreaName { get; set; }
    }

    partial class TblSubAssetMaster
    {
        [NotMapped]
        public string MainAssetName { get; set; }
        [NotMapped]
        public string AccountKeyName { get; set; }
        [NotMapped]
        public string BranchName { get; set; }
        [NotMapped]
        public string ProfitCenterName { get; set; }
        [NotMapped]
        public string SegmentName { get; set; }
        [NotMapped]
        public string DivisionName { get; set; }
        [NotMapped]
        public string PlantName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string DepreciationDataName { get; set; }
        [NotMapped]
        public string DepreciationAreaName { get; set; }
    }
}


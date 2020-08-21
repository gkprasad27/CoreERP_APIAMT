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

    partial class TblRegion
    {
        [NotMapped]
        public string CountryName { get; set; }
    }

    partial class States
    {
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string LangName { get; set; }
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

    partial class TblFunctionalDepartment
    {
        [NotMapped]
        public string ResponsibleName { get; set; }
    }

    partial class CostCenters
    {
        [NotMapped]
        public string ResponsibleName { get; set; }
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
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
        public string VoucherClassName { get; set; }
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
}


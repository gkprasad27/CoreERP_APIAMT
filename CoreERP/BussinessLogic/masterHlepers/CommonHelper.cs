using CoreERP.Controllers;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP
{
    public class CommonHelper
    {
        public static string IncreaseCode(string code)
        {
            try
            {
                string strnum = string.Empty;
                string prefix = string.Empty;
                for (int i = 0; i < code.Length; i++)
                {
                    if (char.IsDigit(code[i]))
                    {
                        if (string.IsNullOrEmpty(strnum) && code[i] == '0')
                            strnum += code[i];

                        strnum += code[i];
                    }
                    else if (char.IsLetter(code[i]) || code[i] == '0')
                        prefix += code[i];
                }

                return prefix + (Convert.ToInt64(strnum) + 1).ToString();
            }
            catch { throw; }
        }

        public static List<Countries> GetCountries()
        {
            try
            {
                using (Repository<Countries> repo = new Repository<Countries>())
                {
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();
                    repo.Countries.ToList()
                        .ForEach(c =>
                            {
                                c.LangName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                                c.CurrName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                            });
                    return repo.Countries.ToList();
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblRegion> GetRegions()
        {
            try
            {
                using (Repository<TblRegion> repo = new Repository<TblRegion>())
                {
                    List<Countries> countries = repo.Countries.ToList();
                    var resul = repo.TblRegion.ToList();

                    resul.ForEach(c =>
                        {
                            c.CountryName = countries.Where(cur => cur.CountryCode == c.Country).FirstOrDefault()?.CountryName;
                        });
                    return resul;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<States> GetStates()
        {
            try
            {
                using (Repository<States> repo = new Repository<States>())
                {
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                    List<Countries> countries = repo.Countries.ToList();
                    var result = repo.States.ToList();

                    result.ForEach(c =>
                    {
                        c.CountryName = countries.Where(cur => cur.CountryCode == c.CountryCode).FirstOrDefault()?.CountryName;
                         c.LangName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblCompany> GetCompanies()
        {
            try
            {
                using (Repository<TblCompany> repo = new Repository<TblCompany>())
                {
                    List<States> states = repo.States.ToList();
                    List<TblRegion> regions = repo.TblRegion.ToList();
                    List<Countries> countries = repo.Countries.ToList();
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                 
                    var result = repo.TblCompany.ToList();

                    result.ForEach(c =>
                    {
                        c.StateName = states.Where(cur => cur.StateCode == c.State).FirstOrDefault()?.StateName;
                        c.RegionName = regions.Where(cur => cur.RegionCode == c.Region).FirstOrDefault()?.RegionName;
                        c.CountryName = countries.Where(cur => cur.CountryCode == c.Country).FirstOrDefault()?.CountryName;
                        c.CurrencyName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                        c.LanguageName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<ProfitCenters> GetProfitcenters()
        {
            try
            {
                using (Repository<ProfitCenters> repo = new Repository<ProfitCenters>())
                {
                    List<States> states = repo.States.ToList();
                    List<TblRegion> regions = repo.TblRegion.ToList();
                    List<Countries> countries = repo.Countries.ToList();
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                    List<TblEmployee> employees = repo.TblEmployee.ToList();

                    var result = repo.ProfitCenters.ToList();

                    result.ForEach(c =>
                    {
                        c.StateName = states.Where(cur => cur.StateCode == c.State).FirstOrDefault()?.StateName;
                        c.RegionName = regions.Where(cur => cur.RegionCode == c.Region).FirstOrDefault()?.RegionName;
                        c.CountryName = countries.Where(cur => cur.CountryCode == c.Country).FirstOrDefault()?.CountryName;
                        c.CurrencyName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                        c.LanguageName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                        c.ResponsibleName = employees.Where(l => l.EmployeeCode == c.ResponsiblePerson).FirstOrDefault()?.EmployeeName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblBranch> GetBranches()
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    List<States> states = repo.States.ToList();
                    List<TblRegion> regions = repo.TblRegion.ToList();
                    List<Countries> countries = repo.Countries.ToList();
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                    List<TblEmployee> employees = repo.TblEmployee.ToList();
                    List<TblCompany> companies = repo.TblCompany.ToList();

                    var result = repo.TblBranch.ToList();

                    result.ForEach(c =>
                    {
                        c.StateName = states.Where(cur => cur.StateCode == c.State).FirstOrDefault()?.StateName;
                        c.RegionName = regions.Where(cur => cur.RegionCode == c.Region).FirstOrDefault()?.RegionName;
                        c.CountryName = countries.Where(cur => cur.CountryCode == c.Country).FirstOrDefault()?.CountryName;
                        c.CurrencyName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                        c.LanguageName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                        c.ResponsibleName = employees.Where(l => l.EmployeeCode == c.ResponsiblePerson).FirstOrDefault()?.EmployeeName;
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.CompanyCode).FirstOrDefault()?.CompanyName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<CostCenters> GetCostcenters()
        {
            try
            {
                using (Repository<CostCenters> repo = new Repository<CostCenters>())
                {
                    List<States> states = repo.States.ToList();
                    List<TblEmployee> employees = repo.TblEmployee.ToList();
                    List<TblCompany> companies = repo.TblCompany.ToList();

                    var result = repo.CostCenters.ToList();

                    result.ForEach(c =>
                    {
                        c.StateName = states.Where(cur => cur.StateCode == c.State).FirstOrDefault()?.StateName;
                        c.ResponsibleName = employees.Where(l => l.EmployeeCode == c.ResponsiblePerson).FirstOrDefault()?.EmployeeName;
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.CompCode).FirstOrDefault()?.CompanyName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblFunctionalDepartment> GetFunctionalDepts()
        {
            try
            {
                using (Repository<TblFunctionalDepartment> repo = new Repository<TblFunctionalDepartment>())
                {
                    List<TblEmployee> employees = repo.TblEmployee.ToList();

                    var result = repo.TblFunctionalDepartment.ToList();

                    result.ForEach(c =>
                    {
                        c.ResponsibleName = employees.Where(l => l.EmployeeCode == c.ResponsiblePerson).FirstOrDefault()?.EmployeeName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<Divisions> GetDivisions()
        {
            try
            {
                using (Repository<Divisions> repo = new Repository<Divisions>())
                {
                    List<TblEmployee> employees = repo.TblEmployee.ToList();

                    var result = repo.Divisions.ToList();

                    result.ForEach(c =>
                    {
                        c.ResponsibleName = employees.Where(l => l.EmployeeCode == c.ResponsiblePerson).FirstOrDefault()?.EmployeeName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblPlant> GetPlants()
        {
            try
            {
                using (Repository<TblPlant> repo = new Repository<TblPlant>())
                {
                    List<States> states = repo.States.ToList();
                    List<TblRegion> regions = repo.TblRegion.ToList();
                    List<Countries> countries = repo.Countries.ToList();
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                    List<TblEmployee> employees = repo.TblEmployee.ToList();
                    List<TblLocation> locations = repo.TblLocation.ToList();

                    var result = repo.TblPlant.ToList();

                    result.ForEach(c =>
                    {
                        c.StateName = states.Where(cur => cur.StateCode == c.State).FirstOrDefault()?.StateName;
                        c.RegionName = regions.Where(cur => cur.RegionCode == c.Region).FirstOrDefault()?.RegionName;
                        c.CountryName = countries.Where(cur => cur.CountryCode == c.Country).FirstOrDefault()?.CountryName;
                        c.CurrencyName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                        c.LanguageName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                        c.ResponsibleName = employees.Where(l => l.EmployeeCode == c.ResponsiblePerson).FirstOrDefault()?.EmployeeName;
                        c.LocationName = locations.Where(l => l.LocationId == c.Location).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblLocation> Getlocations()
        {
            try
            {
                using (Repository<TblLocation> repo = new Repository<TblLocation>())
                {
                    List<TblPlant> plants = repo.TblPlant.ToList();

                    var result = repo.TblLocation.ToList();

                    result.ForEach(c =>
                    {
                        c.PlantName = plants.Where(l => l.PlantCode == c.Plant).FirstOrDefault()?.Plantname;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<SalesDepartment> GetSalesDepartments()
        {
            try
            {
                using (Repository<SalesDepartment> repo = new Repository<SalesDepartment>())
                {
                    List<States> states = repo.States.ToList();
                    List<TblRegion> regions = repo.TblRegion.ToList();
                    List<Countries> countries = repo.Countries.ToList();
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                    List<TblEmployee> employees = repo.TblEmployee.ToList();

                    var result = repo.SalesDepartment.ToList();

                    result.ForEach(c =>
                    {
                        c.StateName = states.Where(cur => cur.StateCode == c.State).FirstOrDefault()?.StateName;
                        c.RegionName = regions.Where(cur => cur.RegionCode == c.Region).FirstOrDefault()?.RegionName;
                        c.CountryName = countries.Where(cur => cur.CountryCode == c.Country).FirstOrDefault()?.CountryName;
                        c.CurrencyName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                        c.LanguageName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                        c.ResponsibleName = employees.Where(l => l.EmployeeCode == c.ResponsiblePerson).FirstOrDefault()?.EmployeeName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblSalesOffice> GetSalesOffice()
        {
            try
            {
                using (Repository<TblSalesOffice> repo = new Repository<TblSalesOffice>())
                {
                    List<States> states = repo.States.ToList();
                    List<TblRegion> regions = repo.TblRegion.ToList();
                    List<Countries> countries = repo.Countries.ToList();
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                    List<TblEmployee> employees = repo.TblEmployee.ToList();

                    var result = repo.TblSalesOffice.ToList();

                    result.ForEach(c =>
                    {
                        c.StateName = states.Where(cur => cur.StateCode == c.State).FirstOrDefault()?.StateName;
                        c.RegionName = regions.Where(cur => cur.RegionCode == c.Region).FirstOrDefault()?.RegionName;
                        c.CountryName = countries.Where(cur => cur.CountryCode == c.Country).FirstOrDefault()?.CountryName;
                        c.CurrencyName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                        c.LanguageName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                        c.ResponsibleName = employees.Where(l => l.EmployeeCode == c.ResponsiblePerson).FirstOrDefault()?.EmployeeName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblMaintenancearea> GetMaintenance()
        {
            try
            {
                using (Repository<TblMaintenancearea> repo = new Repository<TblMaintenancearea>())
                {
                    List<TblPlant> plants = repo.TblPlant.ToList();

                    var result = repo.TblMaintenancearea.ToList();

                    result.ForEach(c =>
                    {
                        c.PlantName = plants.Where(l => l.PlantCode == c.Plant).FirstOrDefault()?.Plantname;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblStorageLocation> GetStorageLocation()
        {
            try
            {
                using (Repository<TblStorageLocation> repo = new Repository<TblStorageLocation>())
                {
                    List<TblPlant> plants = repo.TblPlant.ToList();

                    var result = repo.TblStorageLocation.ToList();

                    result.ForEach(c =>
                    {
                        c.PlantName = plants.Where(l => l.PlantCode == c.Plant).FirstOrDefault()?.Plantname;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblOpenLedger> GetOpenLedger()
        {
            try
            {
                using (Repository<TblOpenLedger> repo = new Repository<TblOpenLedger>())
                {
                    List<Ledger> ledgers = repo.Ledger.ToList();

                    var result = repo.TblOpenLedger.ToList();

                    result.ForEach(c =>
                    {
                        c.LedgerName = ledgers.Where(l => l.Code == c.LedgerKey).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblVoucherType> GetVoucherType()
        {
            try
            {
                using (Repository<TblVoucherType> repo = new Repository<TblVoucherType>())
                {
                    List<TblVoucherclass> voucherclasses = repo.TblVoucherclass.ToList();

                    var result = repo.TblVoucherType.ToList();

                    result.ForEach(c =>
                    {
                        c.VoucherClassName = voucherclasses.Where(l => l.VoucherKey == c.VoucherClass).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblVoucherSeries> GetVoucherseries()
        {
            try
            {
                using (Repository<TblVoucherSeries> repo = new Repository<TblVoucherSeries>())
                {
                    List<TblPlant> plants = repo.TblPlant.ToList();
                    List<TblBranch> branches = repo.TblBranch.ToList();
                    List<TblCompany> companies = repo.TblCompany.ToList();

                    var result = repo.TblVoucherSeries.ToList();

                    result.ForEach(c =>
                    {
                        c.PlantName = plants.Where(cur => cur.PlantCode == c.Plant).FirstOrDefault()?.Plantname;
                        c.BranchName = branches.Where(l => l.BranchCode == c.Branch).FirstOrDefault()?.BranchName;
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.Company).FirstOrDefault()?.CompanyName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssignmentVoucherSeriestoVoucherType> GetAssignVoucherseriesVoucherType()
        {
            try
            {
                using (Repository<TblAssignmentVoucherSeriestoVoucherType> repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>())
                {
                    List<TblVoucherType> tblVoucherTypes = repo.TblVoucherType.ToList();

                    var result = repo.TblAssignmentVoucherSeriestoVoucherType.ToList();

                    result.ForEach(c =>
                    {
                        c.VoucherTypeName = tblVoucherTypes.Where(l => l.VoucherTypeId == c.VoucherType).FirstOrDefault()?.VoucherTypeName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblTaxtransactions> GetTaxTransactions()
        {
            try
            {
                using (Repository<TblTaxtransactions> repo = new Repository<TblTaxtransactions>())
                {
                    List<TblTaxtypes> tblTaxtypes = repo.TblTaxtypes.ToList();

                    var result = repo.TblTaxtransactions.ToList();

                    result.ForEach(c =>
                    {
                        c.TaxTypeName = tblTaxtypes.Where(l => l.TaxKey == c.TaxType).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblTaxRates> GetTaxRates()
        {
            try
            {
                using (Repository<TblTaxRates> repo = new Repository<TblTaxRates>())
                {
                    List<TblTaxtransactions> tblTaxtransactions = repo.TblTaxtransactions.ToList();

                    var result = repo.TblTaxRates.ToList();

                    result.ForEach(c =>
                    {
                        c.TaxTransactionName = tblTaxtransactions.Where(l => l.Code == c.TaxTransaction).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssignTaxacctoTaxcode> GetTaxaccountsTaxcodes()
        {
            try
            {
                using (Repository<TblAssignTaxacctoTaxcode> repo = new Repository<TblAssignTaxacctoTaxcode>())
                {
                    List<TblPlant> plants = repo.TblPlant.ToList();
                    List<TblBranch> branches = repo.TblBranch.ToList();
                    List<TblCompany> companies = repo.TblCompany.ToList();
                    List<TblChartAccount> chartAccounts = repo.TblChartAccount.ToList();
                    List<Glaccounts> glaccounts = repo.Glaccounts.ToList();

                    var result = repo.TblAssignTaxacctoTaxcode.ToList();

                    result.ForEach(c =>
                    {
                        c.PlantName = plants.Where(cur => cur.PlantCode == c.Plant).FirstOrDefault()?.Plantname;
                        c.BranchName = branches.Where(l => l.BranchCode == c.Branch).FirstOrDefault()?.BranchName;
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.Company).FirstOrDefault()?.CompanyName;
                        c.ChartAccountName = chartAccounts.Where(l => l.Code == c.ChartofAccount).FirstOrDefault()?.Desctiption;
                        c.CGSTName = glaccounts.Where(l => l.AccountNumber == c.Cgstgl).FirstOrDefault()?.GlaccountName;
                        c.SGSTName = glaccounts.Where(l => l.AccountNumber == c.Sgstgl).FirstOrDefault()?.GlaccountName;
                        c.IGSTName = glaccounts.Where(l => l.AccountNumber == c.Igstgl).FirstOrDefault()?.GlaccountName;
                        c.UGSTName = glaccounts.Where(l => l.AccountNumber == c.Ugstgl).FirstOrDefault()?.GlaccountName;
                        c.CompositeAccountName = glaccounts.Where(l => l.AccountNumber == c.CompositeAccount).FirstOrDefault()?.GlaccountName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblTdsRates> GetTdsRates()
        {
            try
            {
                using (Repository<TblTdsRates> repo = new Repository<TblTdsRates>())
                {
                    List<TblTdstypes> tdstypes = repo.TblTdstypes.ToList();
                    List<TblIncomeTypes> incomeTypes = repo.TblIncomeTypes.ToList();

                    var result = repo.TblTdsRates.ToList();
                    
                    result.ForEach(c =>
                    {
                        c.TdsTypeName = tdstypes.Where(l => l.TdsCode == c.Tdstype).FirstOrDefault()?.Desctiption;
                        c.IncomeTypeName = incomeTypes.Where(l => l.Code == c.IncomeType).FirstOrDefault()?.Desctiption;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblPosting> GetPosting()
        {
            try
            {
                using (Repository<TblPosting> repo = new Repository<TblPosting>())
                {
                    List<TblPlant> plants = repo.TblPlant.ToList();
                    List<TblBranch> branches = repo.TblBranch.ToList();
                    List<TblCompany> companies = repo.TblCompany.ToList();
                    List<TblChartAccount> chartAccounts = repo.TblChartAccount.ToList();
                    List<Glaccounts> glaccounts = repo.Glaccounts.ToList();
                    List<TblTdsRates> tdsRates = repo.TblTdsRates.ToList();

                    var result = repo.TblPosting.ToList();

                    result.ForEach(c =>
                    {
                        c.PlantName = plants.Where(cur => cur.PlantCode == c.Plant).FirstOrDefault()?.Plantname;
                        c.BranchName = branches.Where(l => l.BranchCode == c.Branch).FirstOrDefault()?.BranchName;
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.Company).FirstOrDefault()?.CompanyName;
                        c.ChartAccountName = chartAccounts.Where(l => l.Code == c.ChartofAccount).FirstOrDefault()?.Desctiption;
                        c.GLAccountName = glaccounts.Where(l => l.AccountNumber == c.Glaccount).FirstOrDefault()?.GlaccountName;
                        c.TdsRatetName = tdsRates.Where(l => l.Code == c.Tdsrate).FirstOrDefault()?.Desctiption;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssignchartaccttoCompanycode> GetChartofAccounttoCompany()
        {
            try
            {
                using (Repository<TblAssignchartaccttoCompanycode> repo = new Repository<TblAssignchartaccttoCompanycode>())
                {
                    List<TblCompany> companies = repo.TblCompany.ToList();
                    List<TblChartAccount> chartAccounts = repo.TblChartAccount.ToList();

                    var result = repo.TblAssignchartaccttoCompanycode.ToList();

                    result.ForEach(c =>
                    {
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.Company).FirstOrDefault()?.CompanyName;
                        c.OchartAccountName = chartAccounts.Where(l => l.Code == c.OperationCoa).FirstOrDefault()?.Desctiption;
                        c.GchartAccountName = chartAccounts.Where(l => l.Code == c.GroupCoa).FirstOrDefault()?.Desctiption;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAccountGroup> GetAccountGroups()
        {
            try
            {
                using (Repository<TblAccountGroup> repo = new Repository<TblAccountGroup>())
                {
                    var result = repo.TblAccountGroup.ToList();

                    result.ForEach(c =>
                    {
                        c.UnderAccountName = result.Where(l => l.AccountGroupId == c.GroupUnder).FirstOrDefault()?.AccountGroupName;
                        
                    });
                    return result.OrderBy(x => x.Sequence); 
                }
            }
            catch { throw; }
        }

        public static IEnumerable<AssignmentSubaccounttoGl> GetAssignmentsubaccounttoGL()
        {
            try
            {
                using (Repository<AssignmentSubaccounttoGl> repo = new Repository<AssignmentSubaccounttoGl>())
                {
                    List<TblAccountGroup> tblAccountGroups = repo.TblAccountGroup.ToList();
                    List<Glaccounts> glaccounts = repo.Glaccounts.ToList();

                    var result = repo.AssignmentSubaccounttoGl.ToList();

                    result.ForEach(c =>
                    {
                        c.UnderAccountName = tblAccountGroups.Where(l => l.AccountGroupId == c.SubAccount).FirstOrDefault()?.AccountGroupName;
                        c.GlAccountName = glaccounts.Where(l => l.AccountNumber == c.FromGl).FirstOrDefault()?.GlaccountName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblBpgroup> GetBPGroups()
        {
            try
            {
                using (Repository<TblBpgroup> repo = new Repository<TblBpgroup>())
                {
                    List<PartnerType> partnertypes = repo.PartnerType.ToList();

                    var result = repo.TblBpgroup.ToList();

                    result.ForEach(c =>
                    {
                        c.PartnerTypeName = partnertypes.Where(l => l.Code == c.Bptype).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssignment> GetAssignments()
        {
            try
            {
                using (Repository<TblAssignment> repo = new Repository<TblAssignment>())
                {
                    List<TblBpgroup> tblBpgroups = repo.TblBpgroup.ToList();

                    var result = repo.TblAssignment.ToList();

                    result.ForEach(c =>
                    {
                        c.BpGroupName = tblBpgroups.Where(l => l.Bpgroup == c.Bpgroup).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAlternateControlAccTrans> GetAlternateControlAccounts()
        {
            try
            {
                using (Repository<TblAlternateControlAccTrans> repo = new Repository<TblAlternateControlAccTrans>())
                {
                    List<TblCompany> companies = repo.TblCompany.ToList();
                    List<TblChartAccount> chartAccounts = repo.TblChartAccount.ToList();
                    List<Glaccounts> glaccounts = repo.Glaccounts.ToList();

                    var result = repo.TblAlternateControlAccTrans.ToList();

                    result.ForEach(c =>
                    {
                        c.NcName = glaccounts.Where(l => l.AccountNumber == c.NormalControlAccount).FirstOrDefault()?.GlaccountName;
                        c.AcName = glaccounts.Where(l => l.AccountNumber == c.AlternativeControlAccount).FirstOrDefault()?.GlaccountName;
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.Company).FirstOrDefault()?.CompanyName;
                        c.ChartAccountName = chartAccounts.Where(l => l.Code == c.ChartofAccount).FirstOrDefault()?.Desctiption;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssetBlock> GetAssetBlock()
        {
            try
            {
                using (Repository<TblAssetBlock> repo = new Repository<TblAssetBlock>())
                {
                    List<TblDepreciationAreas> tblDepreciationAreas = repo.TblDepreciationAreas.ToList();

                    var result = repo.TblAssetBlock.ToList();

                    result.ForEach(c =>
                    {
                        c.DepreciationName = tblDepreciationAreas.Where(l => l.Code == c.DepreciationKey).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssignAssetClasstoBlockAsset> GetAssetClassBlock()
        {
            try
            {
                using (Repository<TblAssignAssetClasstoBlockAsset> repo = new Repository<TblAssignAssetClasstoBlockAsset>())
                {
                    List<TblAssetBlock> tblAssetBlocks = repo.TblAssetBlock.ToList();
                    List<TblAssetClass> tblAssetClasses = repo.TblAssetClass.ToList();

                    var result = repo.TblAssignAssetClasstoBlockAsset.ToList();

                    result.ForEach(c =>
                    {
                        c.AssetBlockName = tblAssetBlocks.Where(l => l.Code == c.AssetBlock).FirstOrDefault()?.Description;
                        c.AssetClassName = tblAssetClasses.Where(l => l.Code == c.AssetClass).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssignAccountkeytoAsset> GetAssetAccountkeytoasset()
        {
            try
            {
                using (Repository<TblAssignAccountkeytoAsset> repo = new Repository<TblAssignAccountkeytoAsset>())
                {
                    List<TblAssetAccountkey> tblAssetAccountkeys = repo.TblAssetAccountkey.ToList();
                    List<TblAssetClass> tblAssetClasses = repo.TblAssetClass.ToList();

                    var result = repo.TblAssignAccountkeytoAsset.ToList();

                    result.ForEach(c =>
                    {
                        c.AccountKeyName = tblAssetAccountkeys.Where(l => l.Code == c.AccountKey).FirstOrDefault()?.Description;
                        c.AssetClassName = tblAssetClasses.Where(l => l.Code == c.AssetClass).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssetAccountkey> GetAssetAccountKey()
        {
            try
            {
                using (Repository<TblAssetAccountkey> repo = new Repository<TblAssetAccountkey>())
                {
                    List<TblCompany> companies = repo.TblCompany.ToList();
                    List<TblChartAccount> chartAccounts = repo.TblChartAccount.ToList();
                    List<Glaccounts> glaccounts = repo.Glaccounts.ToList();

                    var result = repo.TblAssetAccountkey.ToList();

                    result.ForEach(c =>
                    {
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.CompanyCode).FirstOrDefault()?.CompanyName;
                        c.ChartAccountName = chartAccounts.Where(l => l.Code == c.ChartofAccount).FirstOrDefault()?.Desctiption;
                        c.AcquisationName = glaccounts.Where(l => l.AccountNumber == c.AcquisitionsGl).FirstOrDefault()?.GlaccountName;
                        c.AccumulatedName = glaccounts.Where(l => l.AccountNumber == c.AccumulatedGl).FirstOrDefault()?.GlaccountName;
                        c.AucName = glaccounts.Where(l => l.AccountNumber == c.Auggl).FirstOrDefault()?.GlaccountName;
                        c.SalesRevenueName = glaccounts.Where(l => l.AccountNumber == c.SalesRevenueGl).FirstOrDefault()?.GlaccountName;
                        c.LossonSalesName = glaccounts.Where(l => l.AccountNumber == c.LossOnSaleGl).FirstOrDefault()?.GlaccountName;
                        c.GainonSalesName = glaccounts.Where(l => l.AccountNumber == c.GainOnSaleGl).FirstOrDefault()?.GlaccountName;
                        c.ScrapGLName = glaccounts.Where(l => l.AccountNumber == c.ScrappingGl).FirstOrDefault()?.GlaccountName;
                        c.DepreciationGLName = glaccounts.Where(l => l.AccountNumber == c.DepreciationGl).FirstOrDefault()?.GlaccountName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblBankMaster> GetBankMaster()
        {
            try
            {
                using (Repository<TblBankMaster> repo = new Repository<TblBankMaster>())
                {
                    List<States> states = repo.States.ToList();
                    List<TblRegion> regions = repo.TblRegion.ToList();
                    List<Countries> countries = repo.Countries.ToList();
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();

                    var result = repo.TblBankMaster.ToList();

                    result.ForEach(c =>
                    {
                        c.StateName = states.Where(cur => cur.StateCode == c.State).FirstOrDefault()?.StateName;
                        c.RegionName = regions.Where(cur => cur.RegionCode == c.Region).FirstOrDefault()?.RegionName;
                        c.CountryName = countries.Where(cur => cur.CountryCode == c.Country).FirstOrDefault()?.CountryName;
                        c.CurrencyName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<Glaccounts> GetGLAccounts()
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();
                    List<TblCompany> companies = repo.TblCompany.ToList();
                    List<TblChartAccount> chartAccounts = repo.TblChartAccount.ToList();
                    List<GlaccGroup> gLAccGroups = repo.GlaccGroup.ToList();
                    List<TblBankMaster> tblBankMasters = repo.TblBankMaster.ToList();

                    var result = repo.Glaccounts.ToList();

                    result.ForEach(c =>
                    {
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.Company).FirstOrDefault()?.CompanyName;
                        c.ChartAccountName = chartAccounts.Where(l => l.Code == c.ChartAccount).FirstOrDefault()?.Desctiption;
                        c.CurrencyName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                        c.AccGroupName = gLAccGroups.Where(cur => cur.GroupCode == c.AccGroup).FirstOrDefault()?.GroupName;
                        c.BankName = tblBankMasters.Where(cur => cur.BankCode == c.BankKey).FirstOrDefault()?.BankName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblGlsubAccount> GetGLSubAccounts()
        {
            try
            {
                using (Repository<TblGlsubAccount> repo = new Repository<TblGlsubAccount>())
                {
                    
                    List<Glaccounts> gLAccGroups = repo.Glaccounts.ToList();

                    var result = repo.TblGlsubAccount.ToList();

                    result.ForEach(c =>
                    {
                       
                        c.AccGroupName = gLAccGroups.Where(cur => cur.AccountNumber == c.Glaccount).FirstOrDefault()?.GlaccountName;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblBusinessPartnerAccount> GetBusinessPartner()
        {
            try
            {
                using (Repository<TblBusinessPartnerAccount> repo = new Repository<TblBusinessPartnerAccount>())
                {
                    List<TblCompany> companies = repo.TblCompany.ToList();
                    List<PartnerType> partnerTypes = repo.PartnerType.ToList();
                    List<TblBpgroup> tblBpgroups = repo.TblBpgroup.ToList();
                    List<States> states = repo.States.ToList();
                    List<TblRegion> regions = repo.TblRegion.ToList();
                    List<Countries> countries = repo.Countries.ToList();
                    List<Glaccounts> gLAccGroups = repo.Glaccounts.ToList();
                    List<TblPaymentTerms> tblPaymentTerms = repo.TblPaymentTerms.ToList();
                    List<TblTdstypes> tblTdstypes = repo.TblTdstypes.ToList();
                    List<TblTdsRates> tblTdsRates = repo.TblTdsRates.ToList();

                    var result = repo.TblBusinessPartnerAccount.ToList();

                    result.ForEach(c =>
                    {
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.Company).FirstOrDefault()?.CompanyName;
                        c.BpTypeName = partnerTypes.Where(l => l.Code == c.Bptype).FirstOrDefault()?.Description;
                        c.BpGroupName = tblBpgroups.Where(cur => cur.Bpgroup == c.Bpgroup).FirstOrDefault()?.Description;
                        c.StateName = states.Where(cur => cur.StateCode == c.State).FirstOrDefault()?.StateName;
                        c.RegionName = regions.Where(cur => cur.RegionCode == c.Region).FirstOrDefault()?.RegionName;
                        c.CountryName = countries.Where(cur => cur.CountryCode == c.Country).FirstOrDefault()?.CountryName;
                        c.ControlAccountName = gLAccGroups.Where(cur => cur.AccountNumber == c.ControlAccount).FirstOrDefault()?.GlaccountName;
                        c.PaymentTermsName = tblPaymentTerms.Where(cur => cur.Code == c.PaymentTerms).FirstOrDefault()?.Description;
                        c.TdsTypeName = tblTdstypes.Where(cur => cur.TdsCode == c.Tdstype).FirstOrDefault()?.Desctiption;
                        c.TdsStateName = tblTdsRates.Where(cur => cur.Code == c.Tdsrate).FirstOrDefault()?.Desctiption;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblMainAssetMaster> GetMainAssetMaster()
        {
            try
            {
                using (Repository<TblMainAssetMaster> repo = new Repository<TblMainAssetMaster>())
                {
                    List<TblCompany> companies = repo.TblCompany.ToList();
                    List<TblAssetClass> tblAssetClasses = repo.TblAssetClass.ToList();
                    List<TblAssetAccountkey> tblAssetAccountkeys = repo.TblAssetAccountkey.ToList();
                    List<TblBranch> branches = repo.TblBranch.ToList();
                    List<ProfitCenters> profitCenters = repo.ProfitCenters.ToList();
                    List<Segment> segments = repo.Segment.ToList();
                    List<Divisions> divisions = repo.Divisions.ToList();
                    List<TblPlant> plants = repo.TblPlant.ToList();
                    List<TblLocation> tblLocations = repo.TblLocation.ToList();
                    List<TblDepreciation> tblDepreciations = repo.TblDepreciation.ToList();
                    List<TblDepreciationAreas> tblDepreciationAreas = repo.TblDepreciationAreas.ToList();

                    var result = repo.TblMainAssetMaster.ToList();

                    result.ForEach(c =>
                    {
                        c.CompanyName = companies.Where(l => l.CompanyCode == c.Company).FirstOrDefault()?.CompanyName;
                        c.AssetClassName = tblAssetClasses.Where(l => l.Code == c.Assetclass).FirstOrDefault()?.Description;
                        c.AccountKeyName = tblAssetAccountkeys.Where(cur => cur.Code == c.AccountKey).FirstOrDefault()?.Description;
                        c.BranchName = branches.Where(cur => cur.BranchCode == c.Branch).FirstOrDefault()?.BranchName;
                        c.ProfitCenterName = profitCenters.Where(cur => cur.Code == c.ProfitCenter).FirstOrDefault()?.Description;
                        c.SegmentName = segments.Where(cur => cur.Id == c.Segment).FirstOrDefault()?.Name;
                        c.DivisionName = divisions.Where(cur => cur.Code == c.Division).FirstOrDefault()?.Description;
                        c.PlantName = plants.Where(cur => cur.PlantCode == c.Plant).FirstOrDefault()?.Plantname;
                        c.LocationName = tblLocations.Where(cur => cur.LocationId == c.Location).FirstOrDefault()?.Description;
                        c.DepreciationDataName = tblDepreciations.Where(cur => cur.Code == c.DepreciationData).FirstOrDefault()?.Description;
                        c.DepreciationAreaName = tblDepreciationAreas.Where(cur => cur.Code == c.DepreciationArea).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<TblSubAssetMaster> GetSubAssetMaster()
        {
            try
            {
                using (Repository<TblSubAssetMaster> repo = new Repository<TblSubAssetMaster>())
                {
                    List<TblMainAssetMaster> tblMainAssetMasters = repo.TblMainAssetMaster.ToList();
                    List<TblAssetAccountkey> tblAssetAccountkeys = repo.TblAssetAccountkey.ToList();
                    List<TblBranch> branches = repo.TblBranch.ToList();
                    List<ProfitCenters> profitCenters = repo.ProfitCenters.ToList();
                    List<Segment> segments = repo.Segment.ToList();
                    List<Divisions> divisions = repo.Divisions.ToList();
                    List<TblPlant> plants = repo.TblPlant.ToList();
                    List<TblLocation> tblLocations = repo.TblLocation.ToList();
                    List<TblDepreciation> tblDepreciations = repo.TblDepreciation.ToList();
                    List<TblDepreciationAreas> tblDepreciationAreas = repo.TblDepreciationAreas.ToList();

                    var result = repo.TblSubAssetMaster.ToList();

                    result.ForEach(c =>
                    {
                        c.MainAssetName = tblMainAssetMasters.Where(l => l.AssetNumber == c.MainAssetNo).FirstOrDefault()?.Name;
                        c.AccountKeyName = tblAssetAccountkeys.Where(cur => cur.Code == c.AccountKey).FirstOrDefault()?.Description;
                        c.BranchName = branches.Where(cur => cur.BranchCode == c.Branch).FirstOrDefault()?.BranchName;
                        c.ProfitCenterName = profitCenters.Where(cur => cur.Code == c.ProfitCenter).FirstOrDefault()?.Description;
                        c.SegmentName = segments.Where(cur => cur.Id == c.Segment).FirstOrDefault()?.Name;
                        c.DivisionName = divisions.Where(cur => cur.Code == c.Division).FirstOrDefault()?.Description;
                        c.PlantName = plants.Where(cur => cur.PlantCode == c.Plant).FirstOrDefault()?.Plantname;
                        c.LocationName = tblLocations.Where(cur => cur.LocationId == c.Location).FirstOrDefault()?.Description;
                        c.DepreciationDataName = tblDepreciations.Where(cur => cur.Code == c.DepreciationData).FirstOrDefault()?.Description;
                        c.DepreciationAreaName = tblDepreciationAreas.Where(cur => cur.Code == c.DepreciationArea).FirstOrDefault()?.Description;
                    });
                    return result;
                }
            }
            catch { throw; }
        }

        public static IEnumerable<Segment> GetSegments()
        {
            try
            {
                using(Repository<Segment> _repo=new Repository<Segment>())
                {
                    return _repo.Segment.ToList();
                }
            }
            catch(Exception ex) { throw ex; }
        }
        public static IEnumerable<TblHsnsac> GetHsnsac()
        {
            try
            {
                using (Repository<Segment> _repo = new Repository<Segment>())
                {
                    return _repo.TblHsnsac.ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static TblAssignmentVoucherSeriestoVoucherType GetVoucherNo(string voucherTypeId,out Int32 startNumber,out Int32 endNumber)
        {
            startNumber = 0;
            endNumber = 0;
            try
            {
                using (ERPContext _repo = new ERPContext())
                {
                    TblVoucherSeries voucherSeries= (from avsvt in _repo.TblAssignmentVoucherSeriestoVoucherType
                                                     join vs in _repo.TblVoucherSeries on avsvt.VoucherSeries equals vs.VoucherSeriesKey
                                                     where avsvt.VoucherType == voucherTypeId
                                                     select vs).FirstOrDefault();

                    startNumber = Convert.ToInt32(voucherSeries.FromInterval ?? "0");
                    endNumber= Convert.ToInt32(voucherSeries.ToInterval ?? "0");

                    return _repo.TblAssignmentVoucherSeriestoVoucherType.Where(t => t.VoucherType == voucherTypeId).FirstOrDefault();
                };
            }
            catch { throw; }
        }
    }
}

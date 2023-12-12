using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoreERP
{
    public class CommonHelper
    {
        public bool Paymentterms(TblPaymentTerms ptrms, List<TblPaymentTermDetails> ptrmsDetails)
        {
            ptrmsDetails.ForEach(x =>
            {
                x.PaymentTermCode = ptrms.Code;
            });

            using (ERPContext context = new ERPContext())
            {
                using (var dbtrans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var data = context.TblPaymentTermDetails.FirstOrDefault(obj => obj.PaymentTermCode == ptrms.Code)?.Id;
                        if (data > 0)
                        {
                            context.TblPaymentTerms.Update(ptrms);
                            context.SaveChanges();

                            context.TblPaymentTermDetails.UpdateRange(ptrmsDetails);
                            context.SaveChanges();
                            dbtrans.Commit();
                            return true;
                        }

                        context.TblPaymentTerms.Add(ptrms);
                        context.SaveChanges();

                        context.TblPaymentTermDetails.AddRange(ptrmsDetails);
                        context.SaveChanges();

                        dbtrans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbtrans.Rollback();
                        throw;
                    }
                }
            }
        }

        //paymentterms transaction
        public TblPaymentTerms GetpaymenttermsById(string code)
        {
            using var repo = new Repository<TblPaymentTerms>();
            return repo.TblPaymentTerms.FirstOrDefault(x => x.Code == code);
        }

        public static IEnumerable<TblPurchaseOrder> GetPurchaseOrderMaster()
        {
            using var repo = new Repository<TblPurchaseOrder>();
            var BP = repo.TblBusinessPartnerAccount.ToList();

            var result = repo.TblPurchaseOrder.ToList();

            repo.TblPurchaseOrder.ToList().ForEach(c =>
            {
                c.SupplierName = BP.FirstOrDefault(l => l.Bpnumber == c.SupplierCode)?.Name;
            });
            return result;
        }

        public List<TblPaymentTermDetails> GetTblPaymentTermDetails(string code)
        {
            using var repo = new Repository<TblPaymentTermDetails>();
            return repo.TblPaymentTermDetails.Where(cd => cd.PaymentTermCode == code).ToList();
        }
        //depreciationcode
        public bool Depreciationcode(TblDepreciation dprctn, List<TblDepreciationcodeDetails> dpDetails)
        {
            dpDetails.ForEach(x =>
            {
                x.DepreciationCode = dprctn.Code;
            });

            using (ERPContext context = new ERPContext())
            {
                using (var dbtrans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var data = context.TblDepreciationcodeDetails.FirstOrDefault(obj => obj.DepreciationCode == dprctn.Code)?.Id;
                        if (data > 0)
                        {
                            context.TblDepreciation.Update(dprctn);
                            context.SaveChanges();

                            context.TblDepreciationcodeDetails.UpdateRange(dpDetails);
                            context.SaveChanges();
                            dbtrans.Commit();
                            return true;
                        }

                        context.TblDepreciation.Add(dprctn);
                        context.SaveChanges();

                        context.TblDepreciationcodeDetails.AddRange(dpDetails);
                        context.SaveChanges();

                        dbtrans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbtrans.Rollback();
                        throw;
                    }
                }
            }
        }


        public TblDepreciation GetDepreciationById(string code)
        {
            using var repo = new Repository<TblDepreciation>();
            return repo.TblDepreciation.FirstOrDefault(x => x.Code == code);
        }

        public List<TblDepreciationcodeDetails> GetTblDepreciationcodeDetails(string code)
        {
            using var repo = new Repository<TblDepreciationcodeDetails>();
            return repo.TblDepreciationcodeDetails.Where(cd => cd.DepreciationCode == code).ToList();
        }

        public static List<Countries> GetCountries()
        {
            using var repo = new Repository<Countries>();
            var languages = repo.TblLanguage.ToList();
            var currencies = repo.TblCurrency.ToList();
            repo.Countries.ToList()
                .ForEach(c =>
                {
                    c.LangName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                    c.CurrName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                });
            return repo.Countries.ToList();
        }

        public static IEnumerable<TblRegion> GetRegions()
        {
            using var repo = new Repository<TblRegion>();
            var countries = repo.Countries.ToList();
            var resul = repo.TblRegion.ToList();

            resul.ForEach(c =>
            {
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
            });
            return resul;
        }


        public static IEnumerable<TblReqNoAssignment> GetReqNoAssignment()
        {
            using var repo = new Repository<TblReqNoAssignment>();
            var norange = repo.TblRequisitionNoRange.ToList();
            var plant = repo.TblPlant.ToList();
            var dept = repo.Department.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblReqNoAssignment.ToList();

            result.ForEach(c =>
            {
                c.NoRangeName = norange.FirstOrDefault(cur => cur.numberRange == c.numberRange)?.numberRange;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.DepartmentName = dept.FirstOrDefault(cur => cur.DepartmentId == c.Department)?.DepartmentName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
            });
            return result;
        }

        public static IEnumerable<TblQuotationNoAssignment> GetQuotationNoAssignment()
        {
            using var repo = new Repository<TblQuotationNoAssignment>();
            var norange = repo.TblQuotationNoRange.ToList();
            var plant = repo.TblPlant.ToList();
            var dept = repo.Department.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblQuotationNoAssignment.ToList();

            result.ForEach(c =>
            {
                c.NoRangeName = norange.FirstOrDefault(cur => cur.NumberRange == c.NumberRange)?.NumberRange;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
            });
            return result;
        }

        public static IEnumerable<TblPurchaseOrderNoAssignment> GetPurchaseOrderNoAssignment()
        {
            using var repo = new Repository<TblPurchaseOrderNoAssignment>();
            var norange = repo.TblPurchaseNoRange.ToList();
            var plant = repo.TblPlant.ToList();
            var pordertype = repo.TblPurchaseOrderType.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblPurchaseOrderNoAssignment.ToList();

            result.ForEach(c =>
            {
                c.NoRangeName = norange.FirstOrDefault(cur => cur.code == c.NumberRange)?.code;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.CompanyCode)?.CompanyName;
                c.PorderGroupName = pordertype.FirstOrDefault(l => l.purchaseType == c.PurchaseOrderType)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblLotAssignment> GetLotAssignment()
        {
            using var repo = new Repository<TblLotAssignment>();
            var norange = repo.TblLotSeries.ToList();
            var plant = repo.TblPlant.ToList();
            var materialtype = repo.TblMaterialTypes.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblLotAssignment.ToList();

            result.ForEach(c =>
            {
                c.NoRangeName = norange.FirstOrDefault(cur => cur.SeriesKey == c.LotSeries)?.SeriesKey;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.MaterialName = materialtype.FirstOrDefault(l => l.Code == c.MaterialType)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblGrnassignment> GetGrnassignment()
        {
            using var repo = new Repository<TblGrnassignment>();
            var grnseries = repo.TblGrnnoSeries.ToList();
            var plant = repo.TblPlant.ToList();
            var materialtype = repo.TblMaterialTypes.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblGrnassignment.ToList();

            result.ForEach(c =>
            {
                c.GrnseriesName = grnseries.FirstOrDefault(cur => cur.Grnseries == c.Grnseries)?.Grnseries;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.MaterialName = materialtype.FirstOrDefault(l => l.Code == c.MaterialType)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblGinseriesAssignment> GetGinseriesAssignment()
        {
            using var repo = new Repository<TblGinseriesAssignment>();
            var ginseries = repo.TblGinnoSeries.ToList();
            var plant = repo.TblPlant.ToList();
            var materialtype = repo.TblMaterialTypes.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblGinseriesAssignment.ToList();

            result.ForEach(c =>
            {
                c.GinseriesName = ginseries.FirstOrDefault(cur => cur.Ginseries == c.Ginseries)?.Description;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.MaterialName = materialtype.FirstOrDefault(l => l.Code == c.MaterilaType)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblMrnnoAssignment> GetMrnnoAssignment()
        {
            using var repo = new Repository<TblMrnnoAssignment>();
            var materialseries = repo.TblMaterialNoSeries.ToList();
            var plant = repo.TblPlant.ToList();
            var materialtype = repo.TblMaterialTypes.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblMrnnoAssignment.ToList();

            result.ForEach(c =>
            {
                c.MaterialseriesName = materialseries.FirstOrDefault(cur => cur.Code == c.Mrnseries)?.Code;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.MaterialName = materialtype.FirstOrDefault(l => l.Code == c.MaterialType)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblMaterialNoAssignment> GetMaterialNoAssignment()
        {
            using var repo = new Repository<TblMaterialNoAssignment>();
            var numberrange = repo.TblMaterialNoSeries.ToList();
            var plant = repo.TblPlant.ToList();
            var materialtype = repo.TblMaterialTypes.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblMaterialNoAssignment.ToList();

            result.ForEach(c =>
            {
                c.NumberRangeName = numberrange.FirstOrDefault(cur => cur.Code == c.NumberRange)?.Code;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.CompanyCode)?.CompanyName;
                c.MaterialName = materialtype.FirstOrDefault(l => l.Code == c.MaterialType)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblBinsCreation> GetBinsCreation()
        {
            using var repo = new Repository<TblBinsCreation>();
            var stloc = repo.TblStorageLocation.ToList();
            var plant = repo.TblPlant.ToList();
            var materialtype = repo.TblMaterialTypes.ToList();
            var employee = repo.TblEmployee.ToList();
            var uom = repo.TblUnit.ToList();
            var result = repo.TblBinsCreation.ToList();

            result.ForEach(c =>
            {
                c.LocationName = stloc.FirstOrDefault(cur => cur.Code == c.StorageLocation)?.Code;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.EmployeeName = employee.FirstOrDefault(l => l.EmployeeCode == c.StoreIncharge)?.EmployeeName;
                c.MaterialName = materialtype.FirstOrDefault(l => l.Code == c.Material)?.Description;
                c.UomName = uom.FirstOrDefault(l => l.UnitId == Convert.ToDecimal(c.Uom))?.UnitName;
            });
            return result;
        }

        public static IEnumerable<TblPurchasePerson> GetPurchasePerson()
        {
            using var repo = new Repository<TblPurchasePerson>();
            var pgroup = repo.TblPurchaseGroup.ToList();
            var ptype = repo.TblPurchaseType.ToList();
            var employee = repo.TblEmployee.ToList();
            var result = repo.TblPurchasePerson.ToList();

            result.ForEach(c =>
            {
                c.PurchaseGroupName = pgroup.FirstOrDefault(cur => cur.PruchaseGroup == c.PurchaseGroup)?.Description;
                c.PurchaseTypesName = ptype.FirstOrDefault(l => l.PurchaseType == c.PurchaseTypes)?.Description;
                c.PersonName = employee.FirstOrDefault(emp => emp.EmployeeCode == c.PurchasePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblPurchaseNoRange> GetPrnoRange()
        {
            using var repo = new Repository<TblPurchaseNoRange>();
            var plant = repo.TblPlant.ToList();
            var dept = repo.TblFunctionalDepartment.ToList();
            var result = repo.TblPurchaseNoRange.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.departmentname = dept.FirstOrDefault(l => l.Code == c.Department)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblMaterialMaster> GetMaterialMaster()
        {
            using var repo = new Repository<TblMaterialMaster>();
            var company = repo.TblCompany.ToList();
            var plant = repo.TblPlant.ToList();
            var materialtype = repo.TblMaterialTypes.ToList();
            var materialgroup = repo.TblMaterialGroups.ToList();
            var materialsize = repo.TblMaterialSize.ToList();
            var uom = repo.TblUnit.ToList();
            var modelpattern = repo.TblModelPattern.ToList();
            var division = repo.Divisions.ToList();
            var purchasegroup = repo.TblMaterialGroups.ToList();
            var result = repo.TblMaterialMaster.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = company.FirstOrDefault(cur => cur.CompanyCode == c.Company)?.CompanyName;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.MaterialName = materialtype.FirstOrDefault(l => l.Code == c.MaterialType)?.Description;
                c.MaterialGroupName = materialgroup.FirstOrDefault(l => l.GroupKey == c.MaterialGroup)?.Description;
                c.MaterialSizeName = materialsize.FirstOrDefault(l => l.unitId == c.Size)?.unitName;
                c.UomName = uom.FirstOrDefault(l => l.UnitId == Convert.ToDecimal(c.Uom))?.UnitName;
                c.ModelPatternName = modelpattern.FirstOrDefault(l => l.Code == c.ModelPattern)?.Description;
                c.DivisionName = division.FirstOrDefault(l => l.Code == c.Division)?.Description;
                c.PurchaseGroupName = purchasegroup.FirstOrDefault(l => l.GroupKey == c.PurchasingGroup)?.Description;
            });
            return result;
        }


        public static IEnumerable<TblPrimaryCostElement> GetPrimarycostelement()
        {
            using var repo = new Repository<TblPrimaryCostElement>();
            var company = repo.TblCompany.ToList();
            var chartaccount = repo.TblChartAccount.ToList();
            var uom = repo.TblUnit.ToList();
            var gl = repo.Glaccounts.ToList();

            var result = repo.TblPrimaryCostElement.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = company.FirstOrDefault(cur => cur.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartaccount.FirstOrDefault(cur => cur.Code == c.ChartofAccount)?.Desctiption;
                c.UomName = uom.FirstOrDefault(l => l.UnitId == Convert.ToDecimal(c.Uom))?.UnitName;
                c.AccGroupName = gl.FirstOrDefault(l => l.AccountNumber == c.GeneralLedger)?.GlaccountName;
            });
            return result;
        }

        public static IEnumerable<TblSecondaryCostElement> GetSecondarycostelement()
        {
            using var repo = new Repository<TblSecondaryCostElement>();
            var company = repo.TblCompany.ToList();
            var chartaccount = repo.TblChartAccount.ToList();
            var uom = repo.TblUnit.ToList();

            var result = repo.TblSecondaryCostElement.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = company.FirstOrDefault(cur => cur.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartaccount.FirstOrDefault(cur => cur.Code == c.ChartofAccount)?.Desctiption;
                c.UomName = uom.FirstOrDefault(l => l.UnitId == Convert.ToDecimal(c.Uom))?.UnitName;
            });
            return result;
        }

        public static IEnumerable<TblCostingActivity> GetActivities()
        {
            using var repo = new Repository<TblCostingActivity>();
            var secondarycost = repo.TblSecondaryCostElement.ToList();
            var uom = repo.TblUnit.ToList();

            var result = repo.TblCostingActivity.ToList();

            result.ForEach(c =>
            {
                c.SecondCostName = secondarycost.FirstOrDefault(cur => cur.SecondaryCostCode == c.CostElement)?.Description;
                c.UomName = uom.FirstOrDefault(l => l.UnitId == Convert.ToDecimal(c.Uom))?.UnitName;
            });
            return result;
        }

        public static IEnumerable<TblCostingKeyFigures> GetCostingKeyFigures()
        {
            using var repo = new Repository<TblCostingKeyFigures>();
            var uom = repo.TblUnit.ToList();

            var result = repo.TblCostingKeyFigures.ToList();

            result.ForEach(c =>
            {
                c.UomName = uom.FirstOrDefault(l => l.UnitId == Convert.ToDecimal(c.Uom))?.UnitName;
            });
            return result;
        }
        public static IEnumerable<tblQCMaster> GetStandardRateOutPut(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-30), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-30);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<tblQCMaster>();

            return repo.tblQCMaster.AsEnumerable()
                .Where(x =>
                {

                    // Debug.Assert(x.CreatedDate != null, "x.AddDate != null");
                    return Convert.ToString(x.MaterialCode) != null
                              && Convert.ToString(x.MaterialCode).Contains(searchCriteria.searchCriteria ?? Convert.ToString(x.MaterialCode))
                              && Convert.ToDateTime(x.AddDate) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                              && Convert.ToDateTime(x.EditDate.ToShortDateString()) <= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                }).OrderByDescending(x => x.AddDate)
                .ToList();
        }

        public static IEnumerable<TblCostingnumberAssigntoObject> GetCostingnumberAssigntoObject()
        {
            using var repo = new Repository<TblCostingnumberAssigntoObject>();
            var objectype = repo.TblCostingObjectTypes.ToList();
            var noseries = repo.TblCostingNumberSeries.ToList();

            var result = repo.TblCostingnumberAssigntoObject.ToList();

            result.ForEach(c =>
            {
                c.ObjectName = objectype.FirstOrDefault(cur => cur.ObjectType == c.ObjectType)?.Description;
                c.SeriesName = noseries.FirstOrDefault(l => l.NumberObject == c.NumberSeries)?.NumberObject;
            });
            return result;
        }

        public static IEnumerable<TblCostingUnitsCreation> GetCostingUnitsCreation()
        {
            using var repo = new Repository<TblCostingnumberAssigntoObject>();
            var objectype = repo.TblCostingObjectTypes.ToList();
            var material = repo.TblMaterialMaster.ToList();

            var result = repo.TblCostingUnitsCreation.ToList();

            result.ForEach(c =>
            {
                c.ObjectName = objectype.FirstOrDefault(cur => cur.ObjectType == c.ObjectType)?.Description;
                c.MaterialName = material.FirstOrDefault(l => l.Description == c.Material)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblOrderType> GetOrderType()
        {
            using var repo = new Repository<TblOrderType>();
            var costunit = repo.TblCostingUnitsCreation.ToList();
            var result = repo.TblOrderType.ToList();
            result.ForEach(c =>
            {
                c.CostUnitName = costunit.FirstOrDefault(cur => cur.ObjectNumber == c.CostUnit)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblBatchMaster> GetBatchMaster()
        {
            using var repo = new Repository<TblBatchMaster>();
            var company = repo.TblCompany.ToList();
            var plant = repo.TblPlant.ToList();
            var uom = repo.TblUnit.ToList();
            var employee = repo.TblEmployee.ToList();

            var result = repo.TblBatchMaster.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = company.FirstOrDefault(cur => cur.CompanyCode == c.Company)?.CompanyName;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.EmployeeName = employee.FirstOrDefault(l => l.EmployeeCode == c.CreatedBy)?.EmployeeName;
                c.UomName = uom.FirstOrDefault(l => l.UnitId == Convert.ToDecimal(c.Uom))?.UnitName;
            });
            return result;
        }

        public static IEnumerable<TblProcess> GetProcess()
        {
            using var repo = new Repository<TblProcess>();
            var company = repo.TblCompany.ToList();
            var plant = repo.TblPlant.ToList();
            var costunit = repo.TblCostingUnitsCreation.ToList();
            var material = repo.TblMaterialTypes.ToList();

            var result = repo.TblProcess.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = company.FirstOrDefault(cur => cur.CompanyCode == c.Company)?.CompanyName;
                c.PlantName = plant.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.CostunitName = costunit.FirstOrDefault(l => l.ObjectNumber == c.CostUnit)?.Description;
                c.MaterialName = material.FirstOrDefault(l => l.Code == c.Material)?.Description;
            });
            return result;
        }


        public static IEnumerable<States> GetStates()
        {
            using var repo = new Repository<States>();
            var languages = repo.TblLanguage.ToList();
            var countries = repo.Countries.ToList();
            var result = repo.States.ToList();

            result.ForEach(c =>
            {
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.CountryCode)?.CountryName;
                c.LangName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
            });
            return result;
        }

        public static IEnumerable<TblCompany> GetCompanies()
        {
            using var repo = new Repository<TblCompany>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var result = repo.TblCompany.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
            });
            return result;
        }

        public static IEnumerable<TblDesignation> GetDesignation()
        {
            using var repo = new Repository<TblDesignation>();

            var result = repo.TblDesignation.ToList();

            return result;
        }

        public static IEnumerable<Department> GetDepartment()
        {
            using var repo = new Repository<Department>();

            var result = repo.Department.ToList();

            return result;
        }

        public static IEnumerable<ProfitCenters> GetProfitcenters()
        {
            using var repo = new Repository<ProfitCenters>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();
            var result = repo.ProfitCenters.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblBranch> GetBranches()
        {
            using var repo = new Repository<TblBranch>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblBranch.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.CompanyCode)?.CompanyName;
            });
            return result;
        }

        public static IEnumerable<CostCenters> GetCostcenters()
        {
            using var repo = new Repository<CostCenters>();
            var objecttype = repo.TblCostingObjectTypes.ToList();
            var employees = repo.TblEmployee.ToList();
            var department = repo.TblFunctionalDepartment.ToList();
            var uom = repo.TblUnit.ToList();
            var result = repo.CostCenter.ToList();

            result.ForEach(c =>
            {
                c.ObjectName = objecttype.FirstOrDefault(cur => cur.ObjectType == c.Name)?.Description;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
                c.DepartmentName = department.FirstOrDefault(l => l.Code == c.Department)?.Description;
                c.UomName = uom.FirstOrDefault(l => l.UnitId == Convert.ToDecimal(c.Uom))?.UnitName;
            });
            return result;
        }

        public static IEnumerable<TblFunctionalDepartment> GetFunctionalDepts()
        {
            using var repo = new Repository<TblFunctionalDepartment>();
            var employees = repo.TblEmployee.ToList();

            var result = repo.TblFunctionalDepartment.ToList();

            result.ForEach(c =>
            {
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblFundCenter> GetFundCenter()
        {
            using var repo = new Repository<TblFundCenter>();
            var costcenter = repo.CostCenter.ToList();
            var employees = repo.TblEmployee.ToList();
            var department = repo.Department.ToList();
            var profitcenter = repo.ProfitCenters.ToList();
            var segment = repo.Segment.ToList();
            var result = repo.TblFundCenter.ToList();

            result.ForEach(c =>
            {
                c.CostCenterName = costcenter.FirstOrDefault(cur => cur.Code == c.CostCenter)?.Name;
                c.PersonName = employees.FirstOrDefault(l => l.EmployeeCode == c.Person)?.EmployeeName;
                c.DepartmentName = department.FirstOrDefault(l => l.DepartmentId == c.Department)?.DepartmentName;
                c.ProfitName = profitcenter.FirstOrDefault(l => l.Code == c.ProfitCenter)?.Name;
                c.SegmentName = segment.FirstOrDefault(l => l.Id == c.Segment)?.Name;
            });
            return result;
        }

        public static IEnumerable<Divisions> GetDivisions()
        {
            using var repo = new Repository<Divisions>();
            var employees = repo.TblEmployee.ToList();

            var result = repo.Divisions.ToList();

            result.ForEach(c =>
            {
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblPlant> GetPlants()
        {
            using var repo = new Repository<TblPlant>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();
            var locations = repo.TblLocation.ToList();

            var result = repo.TblPlant.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
                c.LocationName = locations.FirstOrDefault(l => l.LocationId == c.Location)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblLocation> Getlocations()
        {
            using var repo = new Repository<TblLocation>();
            var plants = repo.TblPlant.ToList();

            var result = repo.TblLocation.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(l => l.PlantCode == c.Plant)?.Plantname;
            });
            return result;
        }

        public static IEnumerable<SalesDepartment> GetSalesDepartments()
        {
            using var repo = new Repository<SalesDepartment>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();

            var result = repo.SalesDepartment.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblSalesOffice> GetSalesOffice()
        {
            using var repo = new Repository<TblSalesOffice>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();

            var result = repo.TblSalesOffice.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblMaintenancearea> GetMaintenance()
        {
            using var repo = new Repository<TblMaintenancearea>();
            var plants = repo.TblPlant.ToList();

            var result = repo.TblMaintenancearea.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(l => l.PlantCode == c.Plant)?.Plantname;
            });
            return result;
        }

        public static IEnumerable<TblStorageLocation> GetStorageLocation()
        {
            using Repository<TblStorageLocation> repo = new Repository<TblStorageLocation>();
            var plants = repo.TblPlant.ToList();

            var result = repo.TblStorageLocation.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(l => l.PlantCode == c.Plant)?.Plantname;
            });
            return result;
        }

        public static IEnumerable<TblOpenLedger> GetOpenLedger()
        {
            using Repository<TblOpenLedger> repo = new Repository<TblOpenLedger>();
            var ledgers = repo.Ledger.ToList();

            var result = repo.TblOpenLedger.ToList();

            result.ForEach(c =>
            {
                c.LedgerName = ledgers.FirstOrDefault(l => l.Code == c.LedgerKey)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblVoucherType> GetVoucherType()
        {
            using var repo = new Repository<TblVoucherType>();
            var voucherclasses = repo.TblVoucherclass.ToList();

            var result = repo.TblVoucherType.ToList();

            result.ForEach(c =>
            {
                c.voucherClassName = voucherclasses.FirstOrDefault(l => l.VoucherKey == c.voucherClass)?.Description;
                c.VoucherNature = voucherclasses.FirstOrDefault(l => l.VoucherKey == c.voucherClass)?.VoucherNature;
            });
            return result;
        }

        public static IEnumerable<TblVoucherSeries> GetVoucherseries()
        {
            using var repo = new Repository<TblVoucherSeries>();
            var plants = repo.TblPlant.ToList();
            var branches = repo.TblBranch.ToList();
            var companies = repo.TblCompany.ToList();

            var result = repo.TblVoucherSeries.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.BranchName = branches.FirstOrDefault(l => l.BranchCode == c.Branch)?.BranchName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
            });
            return result;
        }

        public static IEnumerable<TblAssignmentVoucherSeriestoVoucherType> GetAssignVoucherseriesVoucherType()
        {
            using var repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>();
            var tblVoucherTypes = repo.TblVoucherType.ToList();

            var result = repo.TblAssignmentVoucherSeriestoVoucherType.ToList();

            result.ForEach(c =>
            {
                c.VoucherTypeName = tblVoucherTypes.FirstOrDefault(l => l.VoucherTypeId == c.VoucherType)?.VoucherTypeName;
            });
            return result;
        }

        public static IEnumerable<TblTaxtransactions> GetTaxTransactions()
        {
            using Repository<TblTaxtransactions> repo = new Repository<TblTaxtransactions>();
            var tblTaxtypes = repo.TblTaxtypes.ToList();

            var result = repo.TblTaxtransactions.ToList();

            result.ForEach(c =>
            {
                c.TaxTypeName = tblTaxtypes.FirstOrDefault(l => l.TaxKey == c.TaxType)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblTaxRates> GetTaxRates()
        {
            using Repository<TblTaxRates> repo = new Repository<TblTaxRates>();
            var tblTaxtransactions = repo.TblTaxtransactions.ToList();

            var result = repo.TblTaxRates.ToList();

            result.ForEach(c =>
            {
                c.TaxTransactionName = tblTaxtransactions.FirstOrDefault(l => l.Code == c.TaxTransaction)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssignTaxacctoTaxcode> GetTaxaccountsTaxcodes()
        {
            using var repo = new Repository<TblAssignTaxacctoTaxcode>();
            var plants = repo.TblPlant.ToList();
            var branches = repo.TblBranch.ToList();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var glaccounts = repo.Glaccounts.ToList();

            var result = repo.TblAssignTaxacctoTaxcode.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.BranchName = branches.FirstOrDefault(l => l.BranchCode == c.Branch)?.BranchName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartofAccount)?.Desctiption;
                c.CGSTName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Cgstgl)?.GlaccountName;
                c.SGSTName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Sgstgl)?.GlaccountName;
                c.IGSTName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Igstgl)?.GlaccountName;
                c.UGSTName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Ugstgl)?.GlaccountName;
                c.CompositeAccountName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.CompositeAccount)?.GlaccountName;
            });
            return result;
        }

        public static IEnumerable<TblTdsRates> GetTdsRates()
        {
            using var repo = new Repository<TblTdsRates>();
            var tdstypes = repo.TblTdstypes.ToList();
            var incomeTypes = repo.TblIncomeTypes.ToList();

            var result = repo.TblTdsRates.ToList();

            result.ForEach(c =>
            {
                c.TdsTypeName = tdstypes.FirstOrDefault(l => l.TdsCode == c.Tdstype)?.Desctiption;
                c.IncomeTypeName = incomeTypes.FirstOrDefault(l => l.Code == c.IncomeType)?.Desctiption;
            });
            return result;
        }

        public static IEnumerable<TblPosting> GetPosting()
        {
            using var repo = new Repository<TblPosting>();
            var plants = repo.TblPlant.ToList();
            var branches = repo.TblBranch.ToList();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var glaccounts = repo.Glaccounts.ToList();
            var tdsRates = repo.TblTdsRates.ToList();

            var result = repo.TblPosting.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.BranchName = branches.FirstOrDefault(l => l.BranchCode == c.Branch)?.BranchName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartofAccount)?.Desctiption;
                c.GLAccountName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Glaccount)?.GlaccountName;
                c.TdsRatetName = tdsRates.FirstOrDefault(l => l.Code == c.Tdsrate)?.Desctiption;
            });
            return result;
        }

        public static IEnumerable<TblAssignchartaccttoCompanycode> GetChartofAccounttoCompany()
        {
            using var repo = new Repository<TblAssignchartaccttoCompanycode>();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();

            var result = repo.TblAssignchartaccttoCompanycode.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.OchartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.OperationCoa)?.Desctiption;
                c.GchartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.GroupCoa)?.Desctiption;
            });
            return result;
        }

        public static IEnumerable<TblAccountGroup> GetAccountGroups()
        {
            using var repo = new Repository<TblAccountGroup>();
            var result = repo.TblAccountGroup.ToList();

            result.ForEach(c =>
            {
                c.UnderAccountName = result.FirstOrDefault(l => l.AccountGroupId == c.GroupUnder)?.AccountGroupName;

            });
            return result.OrderBy(x => x.AccountGroupId);
        }

        public static IEnumerable<AssignmentSubaccounttoGl> GetAssignmentsubaccounttoGl()
        {
            using var repo = new Repository<AssignmentSubaccounttoGl>();
            var tblAccountGroups = repo.TblAccountGroup.ToList();
            var glaccounts = repo.Glaccounts.ToList();

            var result = repo.AssignmentSubaccounttoGl.ToList();

            result.ForEach(c =>
            {
                c.UnderAccountName = tblAccountGroups.FirstOrDefault(l => l.AccountGroupId == c.SubAccount)?.AccountGroupName;
                c.GlAccountName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.FromGl)?.GlaccountName;
            });
            return result;
        }

        public static IEnumerable<TblBpgroup> GetBpGroups()
        {
            using Repository<TblBpgroup> repo = new Repository<TblBpgroup>();
            var partnertypes = repo.PartnerType.ToList();

            var result = repo.TblBpgroup.ToList();

            result.ForEach(c =>
            {
                c.PartnerTypeName = partnertypes.FirstOrDefault(l => l.Code == c.Bptype)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssignment> GetAssignments()
        {
            using var repo = new Repository<TblAssignment>();
            var tblBpgroups = repo.TblBpgroup.ToList();

            var result = repo.TblAssignment.ToList();

            result.ForEach(c =>
            {
                c.BpGroupName = tblBpgroups.FirstOrDefault(l => l.Bpgroup == c.Bpgroup)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAlternateControlAccTrans> GetAlternateControlAccounts()
        {
            using var repo = new Repository<TblAlternateControlAccTrans>();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var glaccounts = repo.Glaccounts.ToList();

            var result = repo.TblAlternateControlAccTrans.ToList();

            result.ForEach(c =>
            {
                c.NcName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.NormalControlAccount)?.GlaccountName;
                c.AcName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.AlternativeControlAccount)?.GlaccountName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartofAccount)?.Desctiption;
            });
            return result;
        }

        public static IEnumerable<TblAssetBlock> GetAssetBlock()
        {
            using var repo = new Repository<TblAssetBlock>();
            var tblDepreciationAreas = repo.TblDepreciationAreas.ToList();

            var result = repo.TblAssetBlock.ToList();

            result.ForEach(c =>
            {
                c.DepreciationName = tblDepreciationAreas.FirstOrDefault(l => l.Code == c.DepreciationKey)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssignAssetClasstoBlockAsset> GetAssetClassBlock()
        {
            using Repository<TblAssignAssetClasstoBlockAsset> repo = new Repository<TblAssignAssetClasstoBlockAsset>();
            var tblAssetBlocks = repo.TblAssetBlock.ToList();
            var tblAssetClasses = repo.TblAssetClass.ToList();

            var result = repo.TblAssignAssetClasstoBlockAsset.ToList();

            result.ForEach(c =>
            {
                c.AssetBlockName = tblAssetBlocks.FirstOrDefault(l => l.Code == c.AssetBlock)?.Description;
                c.AssetClassName = tblAssetClasses.FirstOrDefault(l => l.Code == c.AssetClass)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssignAccountkeytoAsset> GetAssetAccountkeytoasset()
        {
            using Repository<TblAssignAccountkeytoAsset> repo = new Repository<TblAssignAccountkeytoAsset>();
            var tblAssetAccountkeys = repo.TblAssetAccountkey.ToList();
            var tblAssetClasses = repo.TblAssetClass.ToList();

            var result = repo.TblAssignAccountkeytoAsset.ToList();

            result.ForEach(c =>
            {
                c.AccountKeyName = tblAssetAccountkeys.FirstOrDefault(l => l.Code == c.AccountKey)?.Description;
                c.AssetClassName = tblAssetClasses.FirstOrDefault(l => l.Code == c.AssetClass)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssetAccountkey> GetAssetAccountKey()
        {
            using Repository<TblAssetAccountkey> repo = new Repository<TblAssetAccountkey>();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var glaccounts = repo.Glaccounts.ToList();

            var result = repo.TblAssetAccountkey.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.CompanyCode)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartofAccount)?.Desctiption;
                c.AcquisationName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.AcquisitionsGl)?.GlaccountName;
                c.AccumulatedName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.AccumulatedGl)?.GlaccountName;
                c.AucName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Auggl)?.GlaccountName;
                c.SalesRevenueName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.SalesRevenueGl)?.GlaccountName;
                c.LossonSalesName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.LossOnSaleGl)?.GlaccountName;
                c.GainonSalesName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.GainOnSaleGl)?.GlaccountName;
                c.ScrapGLName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.ScrappingGl)?.GlaccountName;
                c.DepreciationGLName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.DepreciationGl)?.GlaccountName;
            });
            return result;
        }

        public static IEnumerable<TblBankMaster> GetBankMaster()
        {
            using Repository<TblBankMaster> repo = new Repository<TblBankMaster>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();

            var result = repo.TblBankMaster.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
            });
            return result;
        }

        public static IEnumerable<TblBusinessPartnerAccount> BPList()
        {
            using Repository<TblBusinessPartnerAccount> repo = new Repository<TblBusinessPartnerAccount>();
            var BpGroup = repo.TblBpgroup.ToList();
            var BpType = repo.PartnerType.ToList();

            var result = repo.TblBusinessPartnerAccount.ToList();

            result.ForEach(c =>
            {
                c.BpGroupName = BpGroup.FirstOrDefault(cur => cur.Bpgroup == c.Bpgroup)?.Description;
                c.BpTypeName = BpType.FirstOrDefault(cur => cur.Code == c.Bptype)?.Bpcategory;
            });
            return result;
        }

        public static IEnumerable<Glaccounts> GetGlAccounts()
        {
            using var repo = new Repository<Glaccounts>();
            var currencies = repo.TblCurrency.ToList();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var gLAccGroups = repo.GlaccGroup.ToList();
            var tblBankMasters = repo.TblBankMaster.ToList();

            var result = repo.Glaccounts.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartAccount)?.Desctiption;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.AccGroupName = gLAccGroups.FirstOrDefault(cur => cur.GroupCode == c.AccGroup)?.GroupName;
                c.BankName = tblBankMasters.FirstOrDefault(cur => cur.BankCode == c.BankKey)?.BankName;
            });
            return result;
        }

        public static IEnumerable<TblGlsubAccount> GetGlSubAccounts()
        {
            using var repo = new Repository<TblGlsubAccount>();
            var gLAccGroups = repo.Glaccounts.ToList();

            var result = repo.TblGlsubAccount.ToList();

            result.ForEach(c =>
            {

                c.AccGroupName = gLAccGroups.FirstOrDefault(cur => cur.AccountNumber == c.Glaccount)?.GlaccountName;
            });
            return result;
        }

        public static IEnumerable<TblBusinessPartnerAccount> GetBusinessPartner()
        {
            using var repo = new Repository<TblBusinessPartnerAccount>();
            var companies = repo.TblCompany.ToList();
            var partnerTypes = repo.PartnerType.ToList();
            var tblBpgroups = repo.TblBpgroup.ToList();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var gLAccGroups = repo.Glaccounts.ToList();
            var tblPaymentTerms = repo.TblPaymentTerms.ToList();
            var tblTdstypes = repo.TblTdstypes.ToList();
            var tblTdsRates = repo.TblTdsRates.ToList();

            var result = repo.TblBusinessPartnerAccount.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.BpTypeName = partnerTypes.FirstOrDefault(l => l.Code == c.Bptype)?.Bpcategory;
                c.BpGroupName = tblBpgroups.FirstOrDefault(cur => cur.Bpgroup == c.Bpgroup)?.Description;
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.ControlAccountName = gLAccGroups.FirstOrDefault(cur => cur.AccountNumber == c.ControlAccount)?.GlaccountName;
                c.PaymentTermsName = tblPaymentTerms.FirstOrDefault(cur => cur.Code == c.PaymentTerms)?.Description;
                c.TdsTypeName = tblTdstypes.FirstOrDefault(cur => cur.TdsCode == c.Tdstype)?.Desctiption;
                c.TdsStateName = tblTdsRates.FirstOrDefault(cur => cur.Code == c.Tdsrate)?.Desctiption;
            });

            return result;
        }

        public static IEnumerable<TblMainAssetMaster> GetMainAssetMaster()
        {
            using var repo = new Repository<TblMainAssetMaster>();
            var companies = repo.TblCompany.ToList();
            var tblAssetClasses = repo.TblAssetClass.ToList();
            var tblAssetAccountkeys = repo.TblAssetAccountkey.ToList();
            var branches = repo.TblBranch.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var segments = repo.Segment.ToList();
            var divisions = repo.Divisions.ToList();
            var plants = repo.TblPlant.ToList();
            var tblLocations = repo.TblLocation.ToList();
            var tblDepreciations = repo.TblDepreciation.ToList();
            var tblDepreciationAreas = repo.TblDepreciationAreas.ToList();

            var result = repo.TblMainAssetMaster.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.AssetClassName = tblAssetClasses.FirstOrDefault(l => l.Code == c.Assetclass)?.Description;
                c.AccountKeyName = tblAssetAccountkeys.FirstOrDefault(cur => cur.Code == c.AccountKey)?.Description;
                c.BranchName = branches.FirstOrDefault(cur => cur.BranchCode == c.Branch)?.BranchName;
                c.ProfitCenterName = profitCenters.FirstOrDefault(cur => cur.Code == c.ProfitCenter)?.Name;
                c.SegmentName = segments.FirstOrDefault(cur => cur.Id == c.Segment)?.Name;
                c.DivisionName = divisions.FirstOrDefault(cur => cur.Code == c.Division)?.Description;
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.LocationName = tblLocations.FirstOrDefault(cur => cur.LocationId == c.Location)?.Description;
                c.DepreciationDataName = tblDepreciations.FirstOrDefault(cur => cur.Code == c.DepreciationData)?.Description;
                c.DepreciationAreaName = tblDepreciationAreas.FirstOrDefault(cur => cur.Code == c.DepreciationArea)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblSubAssetMaster> GetSubAssetMaster()
        {
            using var repo = new Repository<TblSubAssetMaster>();
            var tblMainAssetMasters = repo.TblMainAssetMaster.ToList();
            var tblAssetAccountkeys = repo.TblAssetAccountkey.ToList();
            var branches = repo.TblBranch.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var segments = repo.Segment.ToList();
            var divisions = repo.Divisions.ToList();
            var plants = repo.TblPlant.ToList();
            var tblLocations = repo.TblLocation.ToList();
            var tblDepreciations = repo.TblDepreciation.ToList();
            var tblDepreciationAreas = repo.TblDepreciationAreas.ToList();

            var result = repo.TblSubAssetMaster.ToList();

            result.ForEach(c =>
            {
                c.MainAssetName = tblMainAssetMasters.FirstOrDefault(l => l.AssetNumber == c.MainAssetNo)?.Name;
                c.AccountKeyName = tblAssetAccountkeys.FirstOrDefault(cur => cur.Code == c.AccountKey)?.Description;
                c.BranchName = branches.FirstOrDefault(cur => cur.BranchCode == c.Branch)?.BranchName;
                c.ProfitCenterName = profitCenters.FirstOrDefault(cur => cur.Code == c.ProfitCenter)?.Name;
                c.SegmentName = segments.FirstOrDefault(cur => cur.Id == c.Segment)?.Name;
                c.DivisionName = divisions.FirstOrDefault(cur => cur.Code == c.Division)?.Description;
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.LocationName = tblLocations.FirstOrDefault(cur => cur.LocationId == c.Location)?.Description;
                c.DepreciationDataName = tblDepreciations.FirstOrDefault(cur => cur.Code == c.DepreciationData)?.Description;
                c.DepreciationAreaName = tblDepreciationAreas.FirstOrDefault(cur => cur.Code == c.DepreciationArea)?.Description;
            });
            return result;
        }

        public static TblAssignmentVoucherSeriestoVoucherType GetVoucherNo(string voucherTypeId, out int startNumber, out int endNumber)
        {
            startNumber = 0;
            endNumber = 0;
            using var repo = new ERPContext();
            var voucherSeries = (from avsvt in repo.TblAssignmentVoucherSeriestoVoucherType
                                 join vs in repo.TblVoucherSeries on avsvt.VoucherSeries equals vs.VoucherSeriesKey
                                 where avsvt.VoucherType == voucherTypeId
                                 select vs).FirstOrDefault();

            startNumber = Convert.ToInt32(voucherSeries?.FromInterval ?? "0");
            endNumber = Convert.ToInt32(voucherSeries?.ToInterval ?? "0");

            return repo.TblAssignmentVoucherSeriestoVoucherType.FirstOrDefault(t => t.VoucherType == voucherTypeId);
        }

        //AssetBeingAquisition
        public bool AssetBeingAquisition(TblAssetBeginingAcquisition bngaqsn, List<TblAssetBeginingAcquisitionDetail> astbngdsrpnDetails)
        {

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                if (bngaqsn.Id > 0)
                {
                    context.TblAssetBeginingAcquisition.Update(bngaqsn);
                    context.SaveChanges();
                    foreach (var item in astbngdsrpnDetails)
                    {
                        if (item.id != 0)
                        {
                            astbngdsrpnDetails.ForEach(x =>
                            {
                                x.Code = bngaqsn.Code;
                            });
                            context.TblAssetBeginingAcquisitionDetail.UpdateRange(astbngdsrpnDetails);
                            context.SaveChanges();
                            dbtrans.Commit();
                            return true;
                        }
                    }

                }

                context.TblAssetBeginingAcquisition.Add(bngaqsn);
                context.SaveChanges();
                astbngdsrpnDetails.ForEach(x =>
                {
                    x.Code = bngaqsn.Code;
                });

                context.TblAssetBeginingAcquisitionDetail.AddRange(astbngdsrpnDetails);
                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception)
            {
                dbtrans.Rollback();
                throw;
            }
        }

        public TblAssetBeginingAcquisition GetmainAqsnById(string code)
        {
            using var repo = new Repository<TblAssetBeginingAcquisition>();
            return repo.TblAssetBeginingAcquisition.FirstOrDefault(x => x.Code == code);
        }

        public List<TblAssetBeginingAcquisitionDetail> GetAqsnDetailDetails(string code)
        {
            using var repo = new Repository<TblAssetBeginingAcquisitionDetail>();
            return repo.TblAssetBeginingAcquisitionDetail.Where(cd => cd.Code == code).ToList();
        }

        //Main Asset
        public bool MainAssetsdatas(TblMainAssetMaster mainassetMaster, List<TblMainAssetMasterTransaction> mainassetDetails)
        {
            mainassetDetails.ForEach(x =>
            {
                x.AssetNumber = mainassetMaster.AssetNumber;

            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                var data = context.TblMainAssetMasterTransaction.FirstOrDefault(obj => obj.AssetNumber == mainassetMaster.AssetNumber)?.Id;
                if (data > 0)
                {

                    context.TblMainAssetMaster.Update(mainassetMaster);
                    context.SaveChanges();

                    context.TblMainAssetMasterTransaction.UpdateRange(mainassetDetails);
                    context.SaveChanges();
                    dbtrans.Commit();
                    return true;
                }

                TblAssetClass assetclass;
                using (var repo = new Repository<TblAssetClass>())
                {
                    assetclass = repo.TblAssetClass.FirstOrDefault(c => c.Code == mainassetMaster.Assetclass);
                }
                assetclass.LastNumberRange = Convert.ToInt32(mainassetMaster.AssetNumber);
                context.TblAssetClass.Update(assetclass);
                context.SaveChanges();

                context.TblMainAssetMaster.Add(mainassetMaster);
                context.SaveChanges();

                context.TblMainAssetMasterTransaction.AddRange(mainassetDetails);
                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception)
            {
                dbtrans.Rollback();
                throw;
            }
        }

        public TblMainAssetMaster GetmainassetMastersById(string assetNumber)
        {
            using var repo = new Repository<TblMainAssetMaster>();
            return repo.TblMainAssetMaster.FirstOrDefault(x => x.AssetNumber == assetNumber);
        }

        public List<TblMainAssetMasterTransaction> GetMainAssetMasterTransactionDetails(string assetNumber)
        {
            using var repo = new Repository<TblMainAssetMasterTransaction>();
            return repo.TblMainAssetMasterTransaction.Where(cd => cd.AssetNumber == assetNumber).ToList();
        }

        //subassets
        public bool SubAssetsdatas(TblSubAssetMaster assetMaster, List<TblSubAssetMasterTransaction> assetDetails)
        {
            assetDetails.ForEach(x =>
            {
                x.SubAssetNumber = assetMaster.MainAssetNo + assetMaster.SubAssetNumber;
                x.MainAssetNumber = assetMaster.MainAssetNo;

            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                var data = context.TblSubAssetMasterTransaction.FirstOrDefault(obj => obj.SubAssetNumber == assetMaster.SubAssetNumber)?.SubAssetNumber;
                if (!string.IsNullOrEmpty(data))
                {
                    context.TblSubAssetMaster.Update(assetMaster);
                    context.SaveChanges();

                    context.TblSubAssetMasterTransaction.UpdateRange(assetDetails);
                    context.SaveChanges();
                    dbtrans.Commit();
                    return true;
                }

                assetMaster.SubAssetNumber = assetMaster.MainAssetNo + assetMaster.SubAssetNumber;
                context.TblSubAssetMaster.Add(assetMaster);
                context.SaveChanges();

                context.TblSubAssetMasterTransaction.AddRange(assetDetails);
                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception)
            {
                dbtrans.Rollback();
                throw;
            }
        }

        public TblSubAssetMaster GetsubassetMastersById(string assetNumber)
        {
            using var repo = new Repository<TblSubAssetMaster>();
            return repo.TblSubAssetMaster.FirstOrDefault(x => x.SubAssetNumber == assetNumber);
        }

        public List<TblSubAssetMasterTransaction> GetSubAssetMasterTransactionDetails(string assetNumber)
        {
            using var repo = new Repository<TblSubAssetMasterTransaction>();
            return repo.TblSubAssetMasterTransaction.Where(cd => cd.SubAssetNumber == assetNumber).ToList();
        }

        public static string GetScreenConfig(string operationCode)
        {
            try
            {
                //using var repo = new Repository<TblFieldsConfiguration>();
                //return repo.TblFieldsConfiguration
                //         .Where(fc => fc.OperationCode == operationCode)
                //         .FirstOrDefault().OperationCode;

                using (Repository<TblFieldsConfiguration> _repo = new Repository<TblFieldsConfiguration>())
                {
                    TblFieldsConfiguration screenConfig = new TblFieldsConfiguration();
                    screenConfig = _repo.TblFieldsConfiguration.Where(m => m.OperationCode == operationCode).FirstOrDefault();
                    if (screenConfig != null)
                        return screenConfig.ShowControl;
                    else
                        return null;
                };
            }
            catch (NullReferenceException Exception)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Menus GetMenu(string operationCode)
        {
            try
            {
                using (Repository<Menus> _repo = new Repository<Menus>())
                {
                    return _repo.Menus.Where(m => m.OperationCode == operationCode).FirstOrDefault();
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static MenuAccesses GetUserPermissions(string roleid, string screenName)
        {
            try
            {
                using (Repository<TblPermissions> _repo = new Repository<TblPermissions>())
                {

                    return (from m in _repo.Menus
                            join ma in _repo.MenuAccesses
                            on m.OperationCode equals ma.OperationCode
                            where m.Route == screenName
                               && ma.RoleId == roleid
                            select ma).FirstOrDefault();
                    //return _repo.MenuAccesses
                    //            .Where(x => x.ScreenName == screenName
                    //                     && x.RoleId == roleid).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //latest
        public bool updatemmaterielcode(TblMaterialMaster mmaster)
        {
            TblMaterialNoSeries mseries;
            using (var repo = new Repository<TblMaterialNoSeries>())
            {
                mseries = repo.TblMaterialNoSeries.FirstOrDefault(c => c.Code == mmaster.MaterialType);
            }
            using (ERPContext context = new ERPContext())
            {
                using (var dbtrans = context.Database.BeginTransaction())
                {
                    try
                    {
                        mseries.Code = mmaster.MaterialType;
                        mseries.FromInterval = mseries.FromInterval;
                        mseries.ToInterval = mseries.ToInterval;
                        mseries.CurrentNumber = Convert.ToInt32(mmaster.MaterialCode);
                        context.TblMaterialNoSeries.Update(mseries);
                        context.SaveChanges();

                        dbtrans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbtrans.Rollback();
                        return false;
                    }
                }
            }
        }
        //latest
        public bool updateobjectcode(TblCostingUnitsCreation costunits)
        {
            TblCostingnumberAssigntoObject cunumseries;
            using (var repo = new Repository<TblCostingnumberAssigntoObject>())
            {
                cunumseries = repo.TblCostingnumberAssigntoObject.FirstOrDefault(c => c.ObjectType == costunits.ObjectType);
            }
            using (ERPContext context = new ERPContext())
            {
                using (var dbtrans = context.Database.BeginTransaction())
                {
                    try
                    {
                        cunumseries.ObjectType = costunits.ObjectType;
                        //cunumseries.FromInterval = cunumseries.FromInterval;
                        //cunumseries.ToInterval = cunumseries.ToInterval;
                        cunumseries.PresentNumber = Convert.ToInt32(costunits.ObjectNumber);
                        context.TblCostingnumberAssigntoObject.Update(cunumseries);
                        context.SaveChanges();

                        dbtrans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbtrans.Rollback();
                        return false;
                    }
                }
            }
        }
        public bool UpdatePcosts(List<TblPrimaryCostElement> pcostDetails)
        {
            TblPrimaryCostElement pcost;
            using var context = new ERPContext();
            foreach (var item in pcostDetails)
            {
                using (var repo = new Repository<TblPrimaryCostElement>())
                {
                    pcost = repo.TblPrimaryCostElement.FirstOrDefault(c => c.GeneralLedger == item.GeneralLedger);
                    pcost.Company = item.Company;
                    pcost.ChartofAccount = item.ChartofAccount;
                    pcost.GeneralLedger = pcost.GeneralLedger;
                    pcost.Usage = item.Usage;
                    pcost.Element = item.Element;
                    pcost.Qty = item.Qty;
                    pcost.Uom = item.Uom;
                    context.TblPrimaryCostElement.Update(pcost);
                }
            }



            using var dbtrans = context.Database.BeginTransaction();
            try
            {

                //context.TblPrimaryCostElement.UpdateRange(pcostDetails);
                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception)
            {
                dbtrans.Rollback();
                throw;
            }
        }


        public static string getEmployeeattendance()
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_employeeattendance";
           
            DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            return null;
        }
    }
}

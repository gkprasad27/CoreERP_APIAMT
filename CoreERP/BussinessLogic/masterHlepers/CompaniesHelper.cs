using CoreERP.DataAccess;
using CoreERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class CompaniesHelper
    {
        public  static IEnumerable<TblCompany> GetListOfCompanies()
        {
            try
            {
                return Repository<TblCompany>.Instance.GetAll().OrderBy(x => x.CompanyCode);
            }
            catch { throw; }
        }
        public static IEnumerable<TblEmployee> GetListOfEmployes()
        {
            try
            {
                return Repository<TblEmployee>.Instance.GetAll().OrderBy(x => x.EmployeeCode);
            }
            catch { throw; }
        }

        public static IEnumerable<States> GetStatesList()
        {
            try
            {
                return Repository<States>.Instance.GetAll().OrderBy(x => x.StateCode);
            }
            catch { throw; }
        }
        public static IEnumerable<TblLanguage> GetLanguageList()
        {
            try
            {
                return Repository<TblLanguage>.Instance.GetAll().OrderBy(x => x.LanguageCode);
            }
            catch { throw; }
        }
        
        public static IEnumerable<TblCurrency> GetCurrencyList()
        {
            try
            {
                return Repository<TblCurrency>.Instance.GetAll().OrderBy(x => x.CurrencySymbol);
            }
            catch { throw; }
        }

        public static IEnumerable<TblRegion> GetRegionListList()
        {
            try
            {
                return Repository<TblRegion>.Instance.GetAll().OrderBy(x => x.RegionCode);
            }
            catch { throw; }
        }

        public static IEnumerable<Countries> GetCountryList()
        {
            try
            {
                return Repository<Countries>.Instance.GetAll().OrderBy(x => x.CountryCode);
            }
            catch { throw; }
        }

        public static IEnumerable <TblCompany> GetCompanies(string compCode)
        {
            try
            {
               return Repository<TblCompany>.Instance.Where(x => x.CompanyCode == compCode);
            }
            catch { throw; }
        }


        public static TblCompany Register(TblCompany companies)
        {
            try
            {
                Repository<TblCompany>.Instance.Add(companies);
                if (Repository<TblCompany>.Instance.SaveChanges() > 0)
                    return companies;

                return null;
            }
            catch { throw; }
        }


        public static TblCompany Update(TblCompany companies)
        {
            try
            {
                Repository<TblCompany>.Instance.Update(companies);
                if (Repository<TblCompany>.Instance.SaveChanges() > 0)
                    return companies;

                return null;
            }
            catch { throw; }
        }

        public static TblCompany DeleteCompanies(string  code)
        {
            try
            {
                var ccode = Repository<TblCompany>.Instance.GetSingleOrDefault(x => x.CompanyCode == code);
                Repository<TblCompany>.Instance.Remove(ccode);
                if (Repository<TblCompany>.Instance.SaveChanges() > 0)
                    return ccode;

                return null;
            }
            catch { throw; }
        }
    }
}

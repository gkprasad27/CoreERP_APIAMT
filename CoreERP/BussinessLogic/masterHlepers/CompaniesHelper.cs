using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class CompaniesHelper
    {
        public  static List<TblCompany> GetListOfCompanies()
        {
            try
            {
                using Repository<TblCompany> repo = new Repository<TblCompany>();
                return repo.TblCompany.ToList();
            }
            catch { throw; }
        }
        public static List<TblEmployee> GetListOfEmployes()
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                return repo.TblEmployee.ToList();
            }
            catch { throw; }
        }

        public static List<States> GetStatesList()
        {
            try
            {
                using Repository<States> repo = new Repository<States>();
                return repo.States.ToList();
            }
            catch { throw; }
        }
        public static List<TblLanguage> GetLanguageList()
        {
            try
            {
                using Repository<TblLanguage> repo = new Repository<TblLanguage>();
                return repo.TblLanguage.ToList();
            }
            catch { throw; }
        }
        
        public static List<TblCurrency> GetCurrencyList()
        {
            try
            {
                using Repository<TblCurrency> repo = new Repository<TblCurrency>();
                return repo.TblCurrency.ToList();
            }
            catch { throw; }
        }

        public static List<TblRegion> GetRegionListList()
        {
            try
            {
                using Repository<TblRegion> repo = new Repository<TblRegion>();
                return repo.TblRegion.ToList();
            }
            catch { throw; }
        }

        public static List<Countries> GetCountryList()
        {
            try
            {
                using Repository<Countries> repo = new Repository<Countries>();
                return repo.Countries.ToList();
            }
            catch { throw; }
        }

        public static TblCompany GetCompanies(string compCode)
        {
            try
            {
                using Repository<TblCompany> repo = new Repository<TblCompany>();
                return repo.TblCompany.Where(x => x.CompanyCode == compCode).FirstOrDefault();
            }
            catch { throw; }
        }


        public static TblCompany Register(TblCompany companies)
        {
            try
            {
                using Repository<TblCompany> repo = new Repository<TblCompany>();
               // companies.Active = "Y";
                repo.TblCompany.Add(companies);
                if (repo.SaveChanges() > 0)
                    return companies;

                return null;
            }
            catch { throw; }
        }


        public static TblCompany Update(TblCompany companies)
        {
            try
            {
                using Repository<TblCompany> repo = new Repository<TblCompany>();
                repo.TblCompany.Update(companies);
                if (repo.SaveChanges() > 0)
                    return companies;

                return null;
            }
            catch { throw; }
        }

        public static TblCompany DeleteCompanies(string  code)
        {
            try
            {
                using Repository<TblCompany> repo = new Repository<TblCompany>();
                var comp = repo.TblCompany.Where(x => x.CompanyCode ==code).FirstOrDefault();
                repo.TblCompany.Remove(comp);
                if (repo.SaveChanges() > 0)
                    return comp;

                return null;
            }
            catch { throw; }
        }
    }
}

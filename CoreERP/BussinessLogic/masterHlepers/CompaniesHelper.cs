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


        public static TblCompany GetCompanies(int compCode)
        {
            try
            {
                using Repository<TblCompany> repo = new Repository<TblCompany>();
                return repo.TblCompany.Where(x => x.CompanyId == compCode).FirstOrDefault();
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

        public static TblCompany DeleteCompanies(decimal  code)
        {
            try
            {
                using Repository<TblCompany> repo = new Repository<TblCompany>();
                var comp = repo.TblCompany.Where(x => x.CompanyId == code).FirstOrDefault();
                repo.TblCompany.Remove(comp);
                if (repo.SaveChanges() > 0)
                    return comp;

                return null;
            }
            catch { throw; }
        }
    }
}

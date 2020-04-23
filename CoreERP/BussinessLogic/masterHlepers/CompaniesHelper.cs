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
        public  static List<Companies> GetListOfCompanies()
        {
            try
            {
                //using Repository<Companies> repo = new Repository<Companies>();
                //return repo.Companies.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                return null;
            }
            catch { throw; }
        }


        public static Companies GetCompanies(string compCode)
        {
            try
            {
                //                using Repository<Companies> repo = new Repository<Companies>();
                //                return repo.Companies.AsEnumerable()
                //.Where(x => x.CompanyCode.Equals(compCode))
                //.FirstOrDefault();
                return null;
            }
            catch { throw; }
        }


        public static Companies Register(Companies companies)
        {
            try
            {
                //using Repository<Companies> repo = new Repository<Companies>();
                //companies.Active = "Y";
                //repo.Companies.Add(companies);
                //if (repo.SaveChanges() > 0)
                //    return companies;

                return null;
            }
            catch { throw; }
        }


        public static Companies Update(Companies companies)
        {
            try
            {
                //using Repository<Companies> repo = new Repository<Companies>();
                //repo.Companies.Update(companies);
                //if (repo.SaveChanges() > 0)
                //    return companies;

                return null;
            }
            catch { throw; }
        }

        public static Companies DeleteCompanies(string  code)
        {
            try
            {
                //using Repository<Companies> repo = new Repository<Companies>();
                //var comp = repo.Companies.Where(x => x.CompanyCode == code).FirstOrDefault();
                //comp.Active = "N";
                //repo.Companies.Update(comp);
                //if (repo.SaveChanges() > 0)
                //    return comp;

                return null;
            }
            catch { throw; }
        }
    }
}

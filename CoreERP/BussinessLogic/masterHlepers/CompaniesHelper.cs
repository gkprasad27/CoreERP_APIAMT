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
                using(Repository<Companies> repo=new Repository<Companies>())
                {
                    return repo.Companies.Where(c=> c.Active.Equals("Y",StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }


        public static Companies GetCompanies(string compCode)
        {
            try
            {
                using (Repository<Companies> repo = new Repository<Companies>())
                {
                    return repo.Companies.Where(x => x.Code == compCode 
                                                 &&  x.Active.Equals("Y",StringComparison.OrdinalIgnoreCase))
                                         .FirstOrDefault();
                }
            }
            catch { throw; }
        }


        public static int Register(Companies companies)
        {
            try
            {
                using (Repository<Companies> repo = new Repository<Companies>())
                {
                    companies.Active = "Y";
                    repo.Companies.Add(companies);
                    return repo.SaveChanges();
                }
            }
            catch { throw; }
        }


        public static int Update(Companies companies)
        {
            try
            {
                using(Repository<Companies> repo = new Repository<Companies>())
                {
                    repo.Update(companies);
                    return repo.SaveChanges();
                }
            }
            catch { throw; }
        }
    }
}

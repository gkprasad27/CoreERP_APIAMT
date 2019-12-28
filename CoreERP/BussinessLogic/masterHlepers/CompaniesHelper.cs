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
        private static Repository<Companies> _repo = null;
        private static Repository<Companies>  repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Companies>();
                return _repo;
            }
        }


        public  static List<Companies> GetListOfCompanies()
        {
            try
            {
                return repo.GetAll().ToList();
            }
            catch { throw; }
        }


        public static List<Companies> GetListOfCompanies(string compCode)
        {
            try
            {
                using (CoreERPContext contex = new CoreERPContext())
                {

                    return repo.Companies.Where(x => x.Code == compCode).ToList();
                   // return  contex.Where(x => x.Name.ToLower() == compName.ToLower()).ToList();
                  
                }
               // return repo.GetAll().
            }
            catch { throw; }
        }


        public static int Register(Companies companies)
        {
            try
            {
                using (CoreERPContext contex = new CoreERPContext())
                {
                    contex.Add(companies);
                    return contex.SaveChanges();
                }
            }
            catch { throw; }
        }


        public static int Update(Companies companies)
        {
            try
            {
                repo.Update(companies);
              return  repo.SaveChanges();
            }
            catch { throw; }
        }


        public static int Delete(string  compCode)
        {
            try
            {
                var comp = repo.Companies.Where(x => x.Code == compCode).SingleOrDefault();
                repo.Remove(comp);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

    }
}

using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class TaxmasterHelper
    {
        private static Repository<TaxMasters> _repo = null;
        private static Repository<TaxMasters> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<TaxMasters>();
                return _repo;
            }
        }

        public static List<TaxMasters> GetListOfTaxMasters()
        {
            try
            {
                return repo.GetAll().ToList();
            }
            catch { throw; }
        }

        public static int RegisterTaxMaster(TaxMasters taxMaster)
        {
            try
            {
                repo.TaxMasters.Add(taxMaster);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateTaxMaster(TaxMasters taxMaster)
        {
            try
            {
                repo.TaxMasters.Update(taxMaster);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteTaxMaster(string taxMasterCode)
        {
            try
            {
                var taxmstr = repo.TaxMasters.Where(a => a.Code == taxMasterCode).FirstOrDefault();
                repo.TaxMasters.Remove(taxmstr);
                return repo.SaveChanges();
            }
            catch { throw; }
        }
    }
}

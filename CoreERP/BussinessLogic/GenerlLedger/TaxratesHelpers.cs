using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class TaxratesHelpers
    {
        public List<TblTaxRates> GetList(string code)
        {
            try
            {
                using Repository<TblTaxRates> repo = new Repository<TblTaxRates>();
                return repo.TblTaxRates
                           .Where(x => x.TaxRateCode== code)
                           .ToList();
            }
            catch { throw; }
        }

        public  List<TblTaxRates> GetList()
        {
            try
            {
                using Repository<TblTaxRates> repo = new Repository<TblTaxRates>();
                return repo.TblTaxRates.ToList();
            }
            catch { throw; }
        }

        public TblTaxRates Register(TblTaxRates taxrates)
        {
            try
            {
                using Repository<TblTaxRates> repo = new Repository<TblTaxRates>();
                repo.TblTaxRates.Add(taxrates);
                if (repo.SaveChanges() > 0)
                    return taxrates;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblTaxRates Update(TblTaxRates taxrates)
        {
            try
            {
                using Repository<TblTaxRates> repo = new Repository<TblTaxRates>();
                repo.TblTaxRates.Update(taxrates);
                if (repo.SaveChanges() > 0)
                    return taxrates;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblTaxRates Delete(string Code)
        {
            try
            {
                using Repository<TblTaxRates> repo = new Repository<TblTaxRates>();
                var taxcode = repo.TblTaxRates.Where(x => x.TaxRateCode ==Code).FirstOrDefault();
                repo.TblTaxRates.Remove(taxcode);
                if (repo.SaveChanges() > 0)
                    return taxcode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}

using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class TaxratesHelpers
    {
        public IEnumerable<TblTaxRates> GetList(string code)
        {
            try
            {
                return Repository<TblTaxRates>.Instance.Where(x => x.TaxRateCode == code);
            }
            catch { throw; }
        }

        public  IEnumerable<TblTaxRates> GetList()
        {
            try
            {
                return Repository<TblTaxRates>.Instance.GetAll().OrderBy(x => x.TaxRateCode);
            }
            catch { throw; }
        }

        public TblTaxRates Register(TblTaxRates taxrates)
        {
            try
            {
                Repository<TblTaxRates>.Instance.Add(taxrates);
                if (Repository<TblTaxRates>.Instance.SaveChanges() > 0)
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
                Repository<TblTaxRates>.Instance.Update(taxrates);
                if (Repository<TblTaxRates>.Instance.SaveChanges() > 0)
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
                var rcode = Repository<TblTaxRates>.Instance.GetSingleOrDefault(x => x.TaxRateCode == Code);
                Repository<TblTaxRates>.Instance.Remove(rcode);
                if (Repository<TblTaxRates>.Instance.SaveChanges() > 0)
                    return rcode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}

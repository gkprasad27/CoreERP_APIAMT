using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class CurrencyHelper
    {
        public static List<TblCurrency> GetList(string currency)
        {
            try
            {
                using Repository<TblCurrency> repo = new Repository<TblCurrency>();
                return repo.TblCurrency.Where(x => x.CurrencySymbol == currency).ToList();
            }
            catch { throw; }
        }

        public static List<TblCurrency> GetList()
        {
            try
            {
                using Repository<TblCurrency> repo = new Repository<TblCurrency>();
                return repo.TblCurrency.ToList();
            }
            catch { throw; }
        }

        public static TblCurrency Register(TblCurrency currency)
        {
            try
            {
                using Repository<TblCurrency> repo = new Repository<TblCurrency>();
                repo.TblCurrency.Add(currency);
                if (repo.SaveChanges() > 0)
                    return currency;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblCurrency Update(TblCurrency currency)
        {
            try
            {
                using Repository<TblCurrency> repo = new Repository<TblCurrency>();
                repo.TblCurrency.Update(currency);
                if (repo.SaveChanges() > 0)
                    return currency;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblCurrency Delete(string ccodes)
        {
            try
            {
                using Repository<TblCurrency> repo = new Repository<TblCurrency>();
                var ccode = repo.TblCurrency.Where(x => x.CurrencySymbol == ccodes).FirstOrDefault();
                repo.TblCurrency.Remove(ccode);
                if (repo.SaveChanges() > 0)
                    return ccode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

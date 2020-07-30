using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class TaxTransactionHelper
    {
        public static List<TblTaxtransactions> GetList(string code)
        {
            try
            {
                using Repository<TblTaxtransactions> repo = new Repository<TblTaxtransactions>();
               return repo.TblTaxtransactions.Where(x => x.Code == code).ToList();
            }
            catch { throw; }
        }

        public static List<TblTaxtransactions> GetList()
        {
            try
            {
                using Repository<TblTaxtransactions> repo = new Repository<TblTaxtransactions>();
                return repo.TblTaxtransactions.ToList();
            }
            catch { throw; }
        }

        public static TblTaxtransactions Register(TblTaxtransactions transaction)
        {
            try
            {
                using Repository<TblTaxtransactions> repo = new Repository<TblTaxtransactions>();
                repo.TblTaxtransactions.Add(transaction);
                if (repo.SaveChanges() > 0)
                    return transaction;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblTaxtransactions Update(TblTaxtransactions transaction)
        {
            try
            {
                using Repository<TblTaxtransactions> repo = new Repository<TblTaxtransactions>();
                repo.TblTaxtransactions.Update(transaction);
                if (repo.SaveChanges() > 0)
                    return transaction;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblTaxtransactions Delete(string Code)
        {
            try
            {
                using Repository<TblTaxtransactions> repo = new Repository<TblTaxtransactions>();
                var code = repo.TblTaxtransactions.Where(x => x.Code == Code).FirstOrDefault();
                repo.TblTaxtransactions.Remove(code);
                if (repo.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

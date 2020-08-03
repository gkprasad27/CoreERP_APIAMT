using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class LedgerHelper
    {
        public  static IEnumerable<Ledger> GetList(string code)
        {
            try
            {
                return Repository<Ledger>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<Ledger> GetList()
        {
            try
            {
             return Repository<Ledger>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static Ledger Register(Ledger ledger)
        {
            try
            {
                Repository<Ledger>.Instance.Add(ledger);
                if (Repository<Ledger>.Instance.SaveChanges() > 0)
                    return ledger;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Ledger Update(Ledger ledger)
        {
            try
            {
                    Repository<Ledger>.Instance.Update(ledger);
                if (Repository<Ledger>.Instance.SaveChanges() > 0)
                    return ledger;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Ledger Delete(string Code)
        {
            try
            {
                var rcode = Repository<Ledger>.Instance.GetSingleOrDefault(x => x.Code == Code);
                Repository<Ledger>.Instance.Remove(rcode);
                if (Repository<Ledger>.Instance.SaveChanges() > 0)
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

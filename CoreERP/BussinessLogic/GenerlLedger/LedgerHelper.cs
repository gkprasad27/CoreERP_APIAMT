using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class LedgerHelper
    {
        public  static List<Ledger> GetList(string code)
        {
            try
            {
                using Repository<Ledger> repo = new Repository<Ledger>();
                return repo.Ledger
                           .Where(x => x.Code == code)
                           .ToList();
            }
            catch { throw; }
        }

        public static List<Ledger> GetList()
        {
            try
            {
                using Repository<Ledger> repo = new Repository<Ledger>();
                return repo.Ledger.ToList();
            }
            catch { throw; }
        }

        public static Ledger Register(Ledger ledger)
        {
            try
            {
                using Repository<Ledger> repo = new Repository<Ledger>();
                repo.Ledger.Add(ledger);
                if (repo.SaveChanges() > 0)
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
                using Repository<Ledger> repo = new Repository<Ledger>();
                repo.Ledger.Update(ledger);
                if (repo.SaveChanges() > 0)
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
                using Repository<Ledger> repo = new Repository<Ledger>();
                var code = repo.Ledger.Where(x => x.Code == Code).FirstOrDefault();
                repo.Ledger.Remove(code);
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

using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class AccountClassHelper
    {
        private static Repository<AccountingClass> _repo = null;
        private static Repository<AccountingClass> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<AccountingClass>();
                return _repo;
            }
        }
        public static int RegisterAccountingClass(AccountingClass accountingClass)
        {
            try
            {
                var record = ((from acc in repo.AccountingClass select acc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
                
                if (record != 0)
                {
                    accountingClass.Code = (record + 1).ToString();
                }
                else
                    accountingClass.Code = "1";

                repo.AccountingClass.Add(accountingClass);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<AccountingClass> GetAccountingClassList()
        {
            try
            {  
                return repo.AccountingClass.Select(x => x).ToList();
            }
            catch { throw; }
        }
        public static int UpdateAccountingClass(AccountingClass accountingClass)
        {
            try
            {
                repo.AccountingClass.Update(accountingClass);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteAccountingClass(string code)
        {
            try
            {
                var accountClass = repo.AccountingClass.Where(x => x.Code == code).FirstOrDefault();
                repo.AccountingClass.Remove(accountClass);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

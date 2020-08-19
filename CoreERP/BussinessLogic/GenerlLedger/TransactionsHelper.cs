using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class TransactionsHelper
    {
        #region Cash Bank
        public List<TblVoucherclass> GetTblVoucherclasses()
        {
            try
            {
                using (Repository<TblVoucherclass> _repo = new Repository<TblVoucherclass>())
                {
                    return _repo.TblVoucherclass.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> GetTransactionType()
        {
            try
            {
               return AppManager.GetAppConfigValue("TRANSACTIONTYPE");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<Glaccounts> GetGlaccounts()
        {
            try
            {
                using (Repository<Glaccounts> _repo = new Repository<Glaccounts>())
                {
                    return _repo.Glaccounts.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblVoucherType> GetVoucherTypes()
        {
            try
            {
                using(Repository<TblVoucherType> _repo=new Repository<TblVoucherType>())
                {
                    return _repo.TblVoucherType.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<string> GetNatureOfTransaction()
        {
            try 
            {
                return AppManager.GetAppConfigValue("NATUREOFTRANSACTION");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<string> GetAccountingIndicator()
        {
            try
            {
                return AppManager.GetAppConfigValue("ACCOUNTINGINDICATOR");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

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
        public bool AddCashBank(TblCashBankMaster cashBankMaster,List<TblCashBankDetails> cashBankDetails)
        {
            try
            {
                using(ERPContext context=new ERPContext())
                {
                    using(var dbtrans=context.Database.BeginTransaction())
                    {
                        try
                        {

                            context.TblCashBankMaster.Add(cashBankMaster);
                            context.SaveChanges();

                            cashBankDetails.ForEach(cb =>
                            {
                                cb.VoucherNumber = cashBankMaster.Id.ToString();
                            });

                            context.TblCashBankDetails.AddRange(cashBankDetails);

                            context.SaveChanges();

                            dbtrans.Commit();
                            return true;
                        }
                        catch(Exception ex)
                        {
                            dbtrans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblCashBankMaster> GetCashBankMasters(TblCashBankMaster cashBankMaster)
        {
            try
            {
                if (cashBankMaster == null)
                    cashBankMaster = new TblCashBankMaster();
               
                using(Repository<TblCashBankMaster> _repo=new Repository<TblCashBankMaster>())
                {
                    return _repo.TblCashBankMaster
                                .Where(x => x.VoucherNumber.Contains(x.VoucherNumber ?? cashBankMaster.VoucherNumber)
                                        // &&  x.VoucherDate.
                                )
                                .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblCashBankDetails> GetCashBankDetails(string voucherNumber)
        {
            try
            {
                using(Repository<TblCashBankDetails> _repo=new Repository<TblCashBankDetails>())
                {
                    return _repo.TblCashBankDetails.Where(cd => cd.VoucherNumber == voucherNumber).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

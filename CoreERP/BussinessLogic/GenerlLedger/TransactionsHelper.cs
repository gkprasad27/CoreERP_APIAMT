using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
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
        public string GetVoucherNumber(string voucherType)
        {
            try
            {
               
                  var _voucerTypeNoseries = CommonHelper.GetVoucherNo(voucherType);

                while (true)
                {
                    if (this.IsVoucherNumberExists(_voucerTypeNoseries.LastNumber + "-" + _voucerTypeNoseries.Suffix))
                    {
                        _voucerTypeNoseries.LastNumber += 1;
                        continue;
                    }
                    if (_voucerTypeNoseries.LastNumber == 0)
                        _voucerTypeNoseries.LastNumber = 1;
                    break;
                }
                using(Repository<TblAssignmentVoucherSeriestoVoucherType> _repo=new Repository<TblAssignmentVoucherSeriestoVoucherType>())
                {
                    _repo.TblAssignmentVoucherSeriestoVoucherType.Update(_voucerTypeNoseries);
                    _repo.SaveChanges();
                }

                return _voucerTypeNoseries.LastNumber + "-" + _voucerTypeNoseries.Suffix;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

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
        public List<string> GetTransactionType(string transactionName)
        {
            try
            {
               return AppManager.GetAppConfigValue(transactionName);
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
                if (cashBankMaster.VoucherDate == null)
                    throw new Exception("Voucher Date Canot be empty/null.");

                if (cashBankMaster.VoucherNumber == null)
                    throw new Exception("Voucher Number Canot be empty/null.");

                if (this.IsVoucherNumberExists(cashBankMaster.VoucherNumber))
                 throw new Exception("Voucher number exists.");

                if (cashBankMaster.VoucherDate == null)
                    cashBankMaster.VoucherDate = DateTime.Now;

                if (cashBankMaster.NatureofTransaction.ToUpper().Contains("RECEIPTS"))
                    cashBankMaster.Indicator = "Debit";

                if (cashBankMaster.NatureofTransaction.ToUpper().Contains("PAYMENT"))
                    cashBankMaster.Indicator = "Debit";

                cashBankDetails.ForEach(x => { x.VoucherDate = cashBankMaster.VoucherDate; });

                using (ERPContext context=new ERPContext())
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
        public bool IsVoucherNumberExists(string voucherNo)
        {
            using (Repository<TblCashBankMaster> _repo = new Repository<TblCashBankMaster>())
            {
                return _repo.TblCashBankMaster.Where(v => v.VoucherNumber == voucherNo).Count() > 0;
            };
        }
        public List<TblCashBankMaster> GetCashBankMasters(SearchCriteria searchCriteria)
        {
            try
            {
                if (searchCriteria == null)
                    searchCriteria = new SearchCriteria() { FromDate= DateTime.Today.AddDays(-1), ToDate=DateTime.Today };
                if (searchCriteria.FromDate == null)
                    searchCriteria.FromDate = DateTime.Today.AddDays(-1);
                if (searchCriteria.ToDate == null)
                    searchCriteria.ToDate = DateTime.Today;

                using (Repository<TblCashBankMaster> _repo=new Repository<TblCashBankMaster>())
                {
                    return _repo.TblCashBankMaster.AsEnumerable()
                                .Where(x => x.VoucherNumber.Contains(searchCriteria.searchCriteria ?? x.VoucherNumber)
                                         &&  Convert.ToDateTime(x.VoucherDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                                         && Convert.ToDateTime(x.VoucherDate.Value.ToShortDateString()) <= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString())
                                         )
                                .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public TblCashBankMaster GetCashBankMastersById(int id)
        {
            try
            {
                using (Repository<TblCashBankMaster> _repo = new Repository<TblCashBankMaster>())
                {
                    return _repo.TblCashBankMaster
                                .Where(x => x.Id == id)
                                .FirstOrDefault();
                }
            }
            catch (Exception ex)
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

        #region General Journels

        #endregion
    }
}

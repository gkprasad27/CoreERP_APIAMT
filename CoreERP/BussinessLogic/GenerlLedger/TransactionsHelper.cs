using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class TransactionsHelper
    {
        #region VoucherNumber & TransactionType

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
                using (Repository<TblAssignmentVoucherSeriestoVoucherType> _repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>())
                {
                    _repo.TblAssignmentVoucherSeriestoVoucherType.Update(_voucerTypeNoseries);
                    _repo.SaveChanges();
                }

                return _voucerTypeNoseries.LastNumber + "-" + _voucerTypeNoseries.Suffix;
            }
            catch (Exception ex)
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

        public List<string> GetTransactionType(string transactionName)
        {
            try
            {
                return AppManager.GetAppConfigValue(transactionName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion

        #region Cash Bank

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

        public bool ReturnCashBank(int id)
        {
            try
            {
                TblCashBankMaster cashBankMaster = null, cashBankMaster1 = null;
                List<TblCashBankDetails> cashBankDetails = null;
                using (Repository<TblCashBankMaster> _repo = new Repository<TblCashBankMaster>())
                {
                    cashBankMaster = _repo.TblCashBankMaster.Where(c => c.Id == id).FirstOrDefault();
                };

                if (cashBankMaster == null)
                    return false;
                using (Repository<TblCashBankMaster> _repo = new Repository<TblCashBankMaster>())
                {
                    cashBankDetails = _repo.TblCashBankDetails.Where(t => t.VoucherNumber == id.ToString()).ToList();
                };

                cashBankMaster.Indicator = cashBankMaster.Indicator == CRDRINDICATORS.DEBIT.ToString() ? CRDRINDICATORS.CREDIT.ToString() : CRDRINDICATORS.DEBIT.ToString();


                //deep copy 
                cashBankMaster1 = (JObject.FromObject(cashBankMaster)).ToObject<TblCashBankMaster>();
                cashBankMaster1.VoucherNumber = this.GetVoucherNumber(cashBankMaster1.VoucherType);
                cashBankMaster1.Id = 0;

                cashBankDetails.ForEach(csh =>
                {
                    csh.Id = 0;
                    csh.Ext = cashBankMaster.Indicator == CRDRINDICATORS.DEBIT.ToString() ? CRDRINDICATORS.CREDIT.ToString() : CRDRINDICATORS.DEBIT.ToString();
                });
                using (ERPContext context = new ERPContext())
                {
                    using (var dbtrans = context.Database.BeginTransaction())
                    {
                        try
                        {
                            cashBankMaster.Ext = "Y";
                            context.TblCashBankMaster.Update(cashBankMaster);
                            context.SaveChanges();

                            context.TblCashBankMaster.Add(cashBankMaster1);
                            context.SaveChanges();

                            cashBankDetails.ForEach(csh => { csh.VoucherNumber = cashBankMaster1.Id.ToString(); });
                            context.TblCashBankDetails.AddRange(cashBankDetails);
                            context.SaveChanges();

                            dbtrans.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            dbtrans.Rollback();
                            return false;
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region General Journels

        #endregion
    }
}

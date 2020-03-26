using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoreERP.BussinessLogic.transactionsHelpers
{
    public class CashPaymentHelper
    {
        public List<TblBranch> GetBranchesList()
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<TblCashPaymentMaster> GetCashPayments()
        {
            try
            {
                using (Repository<TblCashPaymentMaster> repo = new Repository<TblCashPaymentMaster>())
                {
                    return repo.TblCashPaymentMaster.ToList();
                }
              
            }
            catch { throw; }
        }

        public List<TblCashPaymentMaster> GetCashPaymentMasters(SearchCriteria searchCriteria)
        {
            try
            {

                using (Repository<TblCashPaymentMaster> repo = new Repository<TblCashPaymentMaster>())
                {
                    List<TblCashPaymentMaster> _cashpaymentMasterList = null;


                    _cashpaymentMasterList = repo.TblCashPaymentMaster.AsEnumerable()
                              .Where(cp =>
                                         DateTime.Parse(cp.CashPaymentDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.CashPaymentDate).Value.ToShortDateString())
                                       && DateTime.Parse(cp.CashPaymentDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.CashPaymentDate).Value.ToShortDateString())
                                 )
                               .ToList();

                    if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo))
                        _cashpaymentMasterList = _cashpaymentMasterList.Where(x => x.VoucherNo == searchCriteria.InvoiceNo).ToList();


                    return _cashpaymentMasterList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
      

        public List<TblCashPaymentDetails> GetCashpaymentDetails(string invoiceNo)
        {
            try
            {
               
                using (Repository<TblCashPaymentDetails> repo = new Repository<TblCashPaymentDetails>())
                {
                    var cashpMaster = GetCashPayments().Where(c=>c.VoucherNo==invoiceNo).FirstOrDefault();
                    return repo.TblCashPaymentDetails.Where(x => x.CashPaymentMasterId == cashpMaster.CashPaymentMasterId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblAccountLedger> GetAccountLedgersCode(string ledgercode = null, string ledgerName = null)
        {
            try
            {
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger
                        .Where(al => al.LedgerName.ToLower().Contains((ledgerName ?? al.LedgerName).ToLower())
                         && al.LedgerCode == (ledgercode ?? al.LedgerCode)
                         )
                        .ToList();
                    //
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<TblAccountLedger> GetAccountLedgers(string ledegerCode)
        {
            try
            {
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger.Where(acl => acl.LedgerCode.Contains(ledegerCode)).ToList();
                }

            }
            catch { throw; }
        }

        public  List<TblAccountLedger> GetAccountLedgerList()
        {
            try
            {
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger.ToList();
                }
            }
            catch { throw; }
        }
        public static List<TblVoucherMaster> GetVoucherMasters()
        {
            try
            {
                using (Repository<TblVoucherMaster> repo = new Repository<TblVoucherMaster>())
                {
                    return repo.TblVoucherMaster.ToList();
                }

            }
            catch { throw; }
        }

        public static List<TblVoucherType> GetVoucherType()
        {
            try
            {
                using (Repository<TblVoucherType> repo = new Repository<TblVoucherType>())
                {
                    return repo.TblVoucherType.ToList();
                }

            }
            catch { throw; }
        }

        public List<TblVoucherType> GetVoucherTypeList(decimal voucherTypeId)
        {
            try
            {
                using (Repository<TblVoucherType> repo = new Repository<TblVoucherType>())
                {
                    return repo.TblVoucherType.Where(v => v.VoucherTypeId == voucherTypeId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblBranch> GetBranches(string branchCode = null)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.AsEnumerable().Where(b => b.BranchCode == (branchCode ?? b.BranchCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = new CommonHelper().GenerateNumber(33, branchCode);
                return voucherNo;
            }
            catch { throw; }
        }

        public List<TblAccountLedger> GetAccountLedgersByLedgerId(decimal LedgerId)
        {
            try
            {
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger
                        .Where(al => al.LedgerId == LedgerId)
                        .ToList();
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblVoucherMaster AddVoucherMaster(ERPContext context, TblCashPaymentMaster cashPaymentMaster, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {
                
                //using (ERPContext context = new ERPContext())
                //{
                var _voucherMaster = new TblVoucherMaster();
                _voucherMaster.BranchCode = cashPaymentMaster.BranchCode;
                _voucherMaster.BranchName = branch.BranchName;
                _voucherMaster.VoucherDate = cashPaymentMaster.CashPaymentDate;
                _voucherMaster.VoucherTypeIdMain = voucherTypeId;
                _voucherMaster.VoucherTypeIdSub = 37;
                _voucherMaster.VoucherNo = cashPaymentMaster.VoucherNo;
                _voucherMaster.Amount = cashPaymentMaster.TotalAmount;
                _voucherMaster.PaymentType = "Cash";
                _voucherMaster.Narration = "Cash Receipt";
                _voucherMaster.ServerDate = DateTime.Now;
                _voucherMaster.UserId = cashPaymentMaster.UserId;
                _voucherMaster.UserName = cashPaymentMaster.UserName;
                _voucherMaster.EmployeeId = -1;

                context.TblVoucherMaster.Add(_voucherMaster);
                if (context.SaveChanges() > 0)
                {
                    return _voucherMaster;
                }

                return null;
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblCashPaymentMaster cashPaymentMaster, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _voucheraccountLedger, decimal? productRate, bool isFromCashDetials = true)
        {
            try
            {
                var _voucherDetail = new TblVoucherDetail();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = cashPaymentMaster.BranchCode;
                _voucherDetail.BranchName = cashPaymentMaster.BranchName;
                if (isFromCashDetials)
                {
                    _voucherDetail.FromLedgerId = cashPaymentMaster.FromLedgerId;
                    _voucherDetail.FromLedgerCode = cashPaymentMaster.FromLedgerCode;
                    _voucherDetail.FromLedgerName = cashPaymentMaster.FromLedgerName;
                }
                //To ledger  clarifiaction on selecion of product

                _voucherDetail.ToLedgerId = _voucheraccountLedger.LedgerId;
                _voucherDetail.ToLedgerCode = _voucheraccountLedger.LedgerCode;
                _voucherDetail.ToLedgerName = _voucheraccountLedger.LedgerName;
                _voucherDetail.Amount = productRate;
                _voucherDetail.TransactionType = "Debit";
                _voucherDetail.CostCenter = cashPaymentMaster.BranchCode;
                _voucherDetail.ServerDate = DateTime.Now;
                _voucherDetail.Narration = $"Cash Receipt {_voucheraccountLedger.LedgerName} A /c: {_voucherDetail.TransactionType}";

                context.TblVoucherDetail.Add(_voucherDetail);
                if (context.SaveChanges() > 0)
                    return _voucherDetail;

              
                return null;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public TblVoucherDetail AddVoucherDetails(ERPContext context, TblCashPaymentMaster cashPaymentMaster, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, bool isFromCashDetials = true)
        //{
        //    try
        //    {
        //        var _voucherDetail = new TblVoucherDetail();
        //        _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
        //        _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
        //        _voucherDetail.BranchId = _branch.BranchId;
        //        _voucherDetail.BranchCode = cashPaymentMaster.BranchCode;
        //        _voucherDetail.BranchName = cashPaymentMaster.BranchName;
        //        if (isFromCashDetials)
        //        {
        //            _voucherDetail.FromLedgerId = cashPaymentMaster.FromLedgerId;
        //            _voucherDetail.FromLedgerCode = cashPaymentMaster.FromLedgerCode;
        //            _voucherDetail.FromLedgerName = cashPaymentMaster.FromLedgerName;
        //        }
        //        //To ledger  clarifiaction on selecion of product

        //        _voucherDetail.ToLedgerId = _accountLedger.LedgerId;
        //        _voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
        //        _voucherDetail.ToLedgerName = _accountLedger.LedgerName;
        //        _voucherDetail.Amount = productRate;
        //        _voucherDetail.TransactionType = _accountLedger.CrOrDr;
        //        _voucherDetail.CostCenter = _accountLedger.BranchCode;
        //        _voucherDetail.ServerDate = DateTime.Now;
        //        _voucherDetail.Narration = $"Cash Receipt {_accountLedger.LedgerName} A /c: {_voucherDetail.TransactionType}";

        //        context.TblVoucherDetail.Add(_voucherDetail);
        //        if (context.SaveChanges() > 0)
        //            return _voucherDetail;

        //        #region comment
        //        //var _voucherDetail = new TblVoucherDetail();
        //        //_voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
        //        //_voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
        //        //_voucherDetail.BranchId = _branch.BranchId;
        //        //_voucherDetail.BranchCode = invoice.BranchCode;
        //        //_voucherDetail.BranchName = invoice.BranchName;
        //        //_voucherDetail.FromLedgerId = invoice.LedgerId;
        //        //_voucherDetail.FromLedgerCode = invoice.LedgerCode;
        //        //_voucherDetail.FromLedgerName = invoice.LedgerName;
        //        ////To ledger  clarifiaction on selecion of product
        //        //_voucherDetail.ToLedgerId = _accountLedger.LedgerId;
        //        //_voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
        //        //_voucherDetail.ToLedgerName = _accountLedger.LedgerName;
        //        //_voucherDetail.Amount = invdtl.Rate;
        //        //_voucherDetail.TransactionType = _accountLedger.CrOrDr;
        //        //_voucherDetail.CostCenter = _accountLedger.BranchCode;
        //        //_voucherDetail.ServerDate = DateTime.Now;
        //        //_voucherDetail.Narration = "Sales Invoice Product group A/c:" + _voucherDetail.TransactionType;

        //        //repo.TblVoucherDetail.Add(_voucherDetail);
        //        //repo.SaveChanges();
        //        #endregion
        //        return null;
        //        // }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context, TblVoucherDetail _voucherDetail, DateTime? invoiceDate)
        {
            try
            {
                var _accountLedgerTransactions = new TblAccountLedgerTransactions();
                _accountLedgerTransactions.VoucherDetailId = _voucherDetail.VoucherDetailId;
                _accountLedgerTransactions.LedgerId = _voucherDetail.ToLedgerId;
                _accountLedgerTransactions.LedgerCode = _voucherDetail.ToLedgerCode;
                _accountLedgerTransactions.LedgerName = _voucherDetail.ToLedgerName;
                _accountLedgerTransactions.BranchId = _voucherDetail.BranchId;
                _accountLedgerTransactions.BranchCode = _voucherDetail.BranchCode;
                _accountLedgerTransactions.BranchName = _voucherDetail.BranchName;
                _accountLedgerTransactions.TransactionDate = invoiceDate;
                _accountLedgerTransactions.TransactionType = _voucherDetail.TransactionType;
                _accountLedgerTransactions.VoucherAmount = _voucherDetail.Amount;

                if (_accountLedgerTransactions.TransactionType.Equals("dedit", StringComparison.OrdinalIgnoreCase))
                {
                    _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
                }
                else if (_accountLedgerTransactions.TransactionType.Equals("credit", StringComparison.OrdinalIgnoreCase))
                {
                    _accountLedgerTransactions.CreditAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.DebitAmount = Convert.ToDecimal("0.00");
                }

                context.TblAccountLedgerTransactions.Add(_accountLedgerTransactions);
                if (context.SaveChanges() > 0)
                    return _accountLedgerTransactions;


                return null;
                //  }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RegisterCashPayment(TblCashPaymentMaster cashPaymentMaster, List<TblCashPaymentDetails> cashPaymentDetails)
        {
            try
            {
                using (ERPContext repo = new ERPContext())
                {
                    using (var dbTransaction = repo.Database.BeginTransaction())
                    {
                        try
                        {
                            //add voucher typedetails
                            var _branch = GetBranches(cashPaymentMaster.BranchCode).ToArray().FirstOrDefault();

                            var _accountLedger = GetAccountLedgersCode(cashPaymentMaster.FromLedgerCode).ToArray().FirstOrDefault();
                            var _cashpayAccountLedger= GetAccountLedgerList().Where(x=>x.LedgerId==175).FirstOrDefault();
                            var _vouchertType = GetVoucherTypeList(33).ToArray().FirstOrDefault();

                            #region Add voucher master record
                            var _voucherMaster = AddVoucherMaster(repo, cashPaymentMaster, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                            #endregion


                            cashPaymentMaster.CashPaymentVchNo = _voucherMaster.VoucherMasterId.ToString();
                            cashPaymentMaster.ServerDate = DateTime.Now;
                            cashPaymentMaster.BranchId = _branch.BranchId;
                            cashPaymentMaster.BranchName = _branch.BranchName;
                            cashPaymentMaster.FromLedgerId = _cashpayAccountLedger.LedgerId;
                            cashPaymentMaster.FromLedgerName = _cashpayAccountLedger.LedgerName;
                            cashPaymentMaster.FromLedgerCode = _cashpayAccountLedger.LedgerCode;
                            cashPaymentMaster.EmployeeId = _voucherMaster.EmployeeId;
                            repo.TblCashPaymentMaster.Add(cashPaymentMaster);
                            repo.SaveChanges();

                            foreach (var cashDtl in cashPaymentDetails)
                            {
                                var _cashDtlLedger = GetAccountLedgerList().Where(x => x.LedgerCode == cashDtl.ToLedgerCode).FirstOrDefault();
                                var _voucheraccountLedger = GetAccountLedgersCode(cashDtl.ToLedgerCode).ToArray().FirstOrDefault();

                                #region CashPaymentDetail
                                cashDtl.CashPaymentMasterId = cashPaymentMaster.CashPaymentMasterId;
                                cashDtl.CashPaymentDetailsDate = cashPaymentMaster.CashPaymentDate;
                                cashDtl.ToLedgerId = _cashDtlLedger.LedgerId;
                                repo.TblCashPaymentDetails.Add(cashDtl);
                                repo.SaveChanges();
                                #region Add voucher Details
                                var _voucherDetail = AddVoucherDetails(repo, cashPaymentMaster, _branch, _voucherMaster, _voucheraccountLedger, cashDtl.Amount);
                                #endregion
                                #endregion


                                #region Add Account Ledger Transaction

                                AddAccountLedgerTransactions(repo, _voucherDetail, cashPaymentMaster.CashPaymentDate);
                                #endregion
                            }

                            _accountLedger = GetAccountLedgers(cashPaymentMaster.FromLedgerCode).ToArray().FirstOrDefault();
                            AddVoucherDetails(repo, cashPaymentMaster, _branch, _voucherMaster, _accountLedger, cashPaymentMaster.TotalAmount, false);


                            dbTransaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            dbTransaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static TblCashPaymentMaster RegisterCashPayment(TblCashPaymentMaster cashPaymentMaster)
        //{
        //    using(Repository<TblCashPaymentMaster> repo=new Repository<TblCashPaymentMaster>())
        //    {
        //        using(var transaction = repo.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var voucherType = CashPaymentHelper.GetVoucherType().Where(vt => vt.VoucherTypeName == "Cash Payment").FirstOrDefault();
        //                var voucherTypeSub = CashPaymentHelper.GetVoucherType().Where(vt => vt.VoucherTypeName == "Cash").FirstOrDefault();
        //                var accountledger = new CashPaymentHelper().GetAccountLedgerList().Where(al => al.LedgerCode == "100").FirstOrDefault();
        //                TblVoucherMaster voucherMaster = new TblVoucherMaster();
        //                voucherMaster.BranchCode = cashPaymentMaster.BranchCode;
        //                voucherMaster.BranchName = cashPaymentMaster.BranchName;
        //                voucherMaster.VoucherDate = cashPaymentMaster.CashPaymentDate;
        //                voucherMaster.VoucherTypeIdMain = voucherType.VoucherTypeId;
        //                voucherMaster.VoucherTypeIdSub = voucherTypeSub.VoucherTypeId;
        //                voucherMaster.VoucherNo = cashPaymentMaster.VoucherNo;
        //                voucherMaster.Amount = cashPaymentMaster.TotalAmount;
        //                voucherMaster.PaymentType = voucherTypeSub.VoucherTypeName;
        //                voucherMaster.Narration = voucherTypeSub.TypeOfVoucher;
        //                voucherMaster.ServerDate = DateTime.Now;

        //                repo.TblVoucherMaster.Add(voucherMaster);

        //                cashPaymentMaster.CashPaymentVchNo= Convert.ToString(voucherMaster.VoucherMasterId);
        //                cashPaymentMaster.FromLedgerId = accountledger.LedgerId;
        //                cashPaymentMaster.FromLedgerCode = accountledger.LedgerCode;
        //                cashPaymentMaster.FromLedgerName = accountledger.LedgerName;
        //                cashPaymentMaster.ServerDate= DateTime.Now;
        //                repo.TblCashPaymentMaster.Add(cashPaymentMaster);


        //                foreach (var item in cashPaymentMaster.CashPaymentDetails)
        //                {
        //                    var toLedger = new CashPaymentHelper().GetAccountLedgerList().Where(al => al.LedgerCode == item.ToLedgerCode).FirstOrDefault();
        //                    item.CashPaymentMasterId = cashPaymentMaster.CashPaymentMasterId;
        //                    item.CashPaymentDetailsDate = DateTime.Now;
        //                    item.ToLedgerId = toLedger.LedgerId;
        //                    repo.TblCashPaymentDetails.Add(item);
        //                }

        //                TblCashPaymentDetails cashPaymentDetails1 = new TblCashPaymentDetails();
        //                TblVoucherDetail voucherDetail = new TblVoucherDetail();
        //                List<TblCashPaymentDetails> cashDetails = new List<TblCashPaymentDetails>();
        //                bool isdebit = true;
        //                foreach (var item in cashDetails)
        //                {
        //                    voucherDetail.VoucherMasterId = voucherMaster.VoucherMasterId;
        //                    voucherDetail.VoucherDetailDate = DateTime.Now;
        //                    voucherDetail.BranchId = cashPaymentMaster.BranchId;
        //                    voucherDetail.BranchCode = cashPaymentMaster.BranchCode;
        //                    voucherDetail.BranchName = cashPaymentMaster.BranchName;
        //                    voucherDetail.FromLedgerCode = cashPaymentMaster.FromLedgerCode;
        //                    voucherDetail.FromLedgerId = cashPaymentMaster.FromLedgerId;
        //                    voucherDetail.FromLedgerName = cashPaymentMaster.FromLedgerName;
        //                    voucherDetail.ToLedgerCode = cashPaymentDetails1.ToLedgerCode;
        //                    voucherDetail.ToLedgerId = cashPaymentDetails1.ToLedgerId;
        //                    voucherDetail.ToLedgerName = cashPaymentDetails1.ToLedgerName;
        //                    voucherDetail.Amount = cashPaymentDetails1.Amount;
        //                    voucherDetail.Narration = voucherType.VoucherTypeName;
        //                    if (isdebit)
        //                    {
        //                        voucherDetail.TransactionType = "Debit";
        //                        isdebit = false;
        //                    }
        //                    else
        //                    {
        //                        voucherDetail.TransactionType = "Credit";
        //                        isdebit = true;
        //                    }
        //                    repo.TblVoucherDetail.Add(voucherDetail);
        //                }


        //                repo.SaveChanges();

        //                transaction.Commit();

        //                return cashPaymentMaster;
        //            }
        //            catch
        //            {
        //                transaction.Rollback();
        //                throw;
        //            }

        //        }
        //    }
        //}
    }
}

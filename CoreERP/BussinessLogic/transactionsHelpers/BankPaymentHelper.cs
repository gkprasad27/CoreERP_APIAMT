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
    public class BankPaymentHelper
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

        public static List<TblBankPaymentMaster> GetBankPayments()
        {
            try
            {
                using (Repository<TblBankPaymentMaster> repo = new Repository<TblBankPaymentMaster>())
                {
                    return repo.TblBankPaymentMaster.ToList();
                }

            }
            catch { throw; }
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

        public List<TblAccountLedger> GetAccountLedgerList()
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

        public string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = new CommonHelper().GenerateNumber(31, branchCode);
                return voucherNo;
            }
            catch { throw; }
        }

        public List<TblBankPaymentMaster> GetBankPaymentMasters(SearchCriteria searchCriteria)
        {
            try
            {

                using (Repository<TblBankPaymentMaster> repo = new Repository<TblBankPaymentMaster>())
                {
                    List<TblBankPaymentMaster> _bankpaymentMasterList = null;


                    _bankpaymentMasterList = repo.TblBankPaymentMaster.AsEnumerable()
                              .Where(cp =>
                                         DateTime.Parse(cp.BankPaymentDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.BankPaymentDate).Value.ToShortDateString())
                                       && DateTime.Parse(cp.BankPaymentDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.BankPaymentDate).Value.ToShortDateString())
                                 )
                               .ToList();

                    if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo))
                        _bankpaymentMasterList = _bankpaymentMasterList.Where(x => x.VoucherNo == searchCriteria.InvoiceNo).ToList();


                    return _bankpaymentMasterList;
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
        public TblVoucherMaster AddVoucherMaster(ERPContext context, TblBankPaymentMaster bankPaymentMaster, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {


                var _voucherMaster = new TblVoucherMaster();
                _voucherMaster.BranchCode = bankPaymentMaster.BranchCode;
                _voucherMaster.BranchName = branch.BranchName;
                _voucherMaster.VoucherDate = bankPaymentMaster.BankPaymentDate;
                _voucherMaster.VoucherTypeIdMain = voucherTypeId;
                _voucherMaster.VoucherTypeIdSub = 37;
                _voucherMaster.VoucherNo = bankPaymentMaster.VoucherNo;
                _voucherMaster.Amount = bankPaymentMaster.TotalAmount;
                _voucherMaster.PaymentType = "Bank";
                _voucherMaster.Narration = "Bank Payment";
                _voucherMaster.ServerDate = DateTime.Now;
                _voucherMaster.UserId = bankPaymentMaster.UserId;
                _voucherMaster.UserName = bankPaymentMaster.UserName;
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

        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblBankPaymentMaster bankPaymentMaster, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, decimal? ledgerId, string ledgerCode, bool isFromCashDetials = true)
        {
            try
            {
                var _voucherDetail = new TblVoucherDetail();
                var ledgerName = GetAccountLedgerList().Where(al => al.LedgerCode == ledgerCode).FirstOrDefault();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = bankPaymentMaster.BranchCode;
                _voucherDetail.BranchName = bankPaymentMaster.BranchName;
                if (isFromCashDetials==true)
                {
                    _voucherDetail.FromLedgerId = bankPaymentMaster.BankLedgerId;
                    _voucherDetail.FromLedgerCode = bankPaymentMaster.BankLedgerCode;
                    _voucherDetail.FromLedgerName = bankPaymentMaster.BankLedgerName;
                    _voucherDetail.ToLedgerId = ledgerId;
                    _voucherDetail.ToLedgerCode = ledgerCode;
                    _voucherDetail.ToLedgerName = ledgerName.LedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Debit";
                    _voucherDetail.CostCenter = bankPaymentMaster.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Bank Payment";
                }
                //To ledger  clarifiaction on selecion of product
                else
                {

                    _voucherDetail.FromLedgerId = bankPaymentMaster.BankLedgerId;
                    _voucherDetail.FromLedgerCode = bankPaymentMaster.BankLedgerCode;
                    _voucherDetail.FromLedgerName = bankPaymentMaster.BankLedgerName;
                    _voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                    _voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                    _voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Credit";
                    _voucherDetail.CostCenter = _accountLedger.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = $"Bank Payment";
                }
                

                context.TblVoucherDetail.Add(_voucherDetail);
                if (context.SaveChanges() > 0)
                    return _voucherDetail;

                #region comment
                //var _voucherDetail = new TblVoucherDetail();
                //_voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                //_voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                //_voucherDetail.BranchId = _branch.BranchId;
                //_voucherDetail.BranchCode = invoice.BranchCode;
                //_voucherDetail.BranchName = invoice.BranchName;
                //_voucherDetail.FromLedgerId = invoice.LedgerId;
                //_voucherDetail.FromLedgerCode = invoice.LedgerCode;
                //_voucherDetail.FromLedgerName = invoice.LedgerName;
                ////To ledger  clarifiaction on selecion of product
                //_voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                //_voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                //_voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                //_voucherDetail.Amount = invdtl.Rate;
                //_voucherDetail.TransactionType = _accountLedger.CrOrDr;
                //_voucherDetail.CostCenter = _accountLedger.BranchCode;
                //_voucherDetail.ServerDate = DateTime.Now;
                //_voucherDetail.Narration = "Sales Invoice Product group A/c:" + _voucherDetail.TransactionType;

                //repo.TblVoucherDetail.Add(_voucherDetail);
                //repo.SaveChanges();
                #endregion
                return null;
                // }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context,TblBankPaymentMaster bankPaymentMaster, TblVoucherDetail _voucherDetail, DateTime? invoiceDate,bool isdebit=true)
        {
            try
            {
                var _accountLedgerTransactions = new TblAccountLedgerTransactions();
                _accountLedgerTransactions.VoucherDetailId = _voucherDetail.VoucherDetailId;
                
                _accountLedgerTransactions.BranchId = _voucherDetail.BranchId;
                _accountLedgerTransactions.BranchCode = _voucherDetail.BranchCode;
                _accountLedgerTransactions.BranchName = _voucherDetail.BranchName;
                _accountLedgerTransactions.TransactionDate = invoiceDate;
                _accountLedgerTransactions.TransactionType = _voucherDetail.TransactionType;
                _accountLedgerTransactions.VoucherAmount = _voucherDetail.Amount;
                if (isdebit == false)
                {
                    _accountLedgerTransactions.LedgerId = _voucherDetail.ToLedgerId;
                    _accountLedgerTransactions.LedgerCode = _voucherDetail.ToLedgerCode;
                    _accountLedgerTransactions.LedgerName = _voucherDetail.ToLedgerName;
                    _accountLedgerTransactions.TransactionType = _voucherDetail.TransactionType;
                    _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
                }
                else
                {
                    _accountLedgerTransactions.LedgerId = bankPaymentMaster.BankLedgerId;
                    _accountLedgerTransactions.LedgerCode = bankPaymentMaster.BankLedgerCode;
                    _accountLedgerTransactions.LedgerName = bankPaymentMaster.BankLedgerName;
                    _accountLedgerTransactions.TransactionType = "Credit";
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

        public bool RegisterBankPayment(TblBankPaymentMaster bankPaymentMaster, List<TblBankPaymentDetails> bankPaymentDetails)
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
                            var _branch = GetBranches(bankPaymentMaster.BranchCode).ToArray().FirstOrDefault();

                            var _accountLedger = GetAccountLedgersCode(bankPaymentMaster.BankLedgerCode).ToArray().FirstOrDefault();
                            var _cashpayAccountLedger = GetAccountLedgerList().Where(x => x.LedgerId == 175).FirstOrDefault();
                            var _vouchertType = GetVoucherTypeList(31).ToArray().FirstOrDefault();

                            #region Add voucher master record
                            var _voucherMaster = AddVoucherMaster(repo, bankPaymentMaster, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                            #endregion


                            bankPaymentMaster.BankPaymentVchNo = _voucherMaster.VoucherMasterId.ToString();
                            bankPaymentMaster.ServerDate = DateTime.Now;
                            bankPaymentMaster.BranchId = _branch.BranchId;
                            bankPaymentMaster.BranchName = _branch.BranchName;
                            bankPaymentMaster.BankLedgerId = _cashpayAccountLedger.LedgerId;
                            bankPaymentMaster.BankLedgerName = _cashpayAccountLedger.LedgerName;
                            bankPaymentMaster.BankLedgerCode = _cashpayAccountLedger.LedgerCode;
                            bankPaymentMaster.EmployeeId = _voucherMaster.EmployeeId;
                            repo.TblBankPaymentMaster.Add(bankPaymentMaster);
                            repo.SaveChanges();

                            foreach (var bankDtl in bankPaymentDetails)
                            {
                                //   _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.SalesAccount).FirstOrDefault();

                                #region Add voucher Details
                                var _voucherDetail = AddVoucherDetails(repo, bankPaymentMaster, _branch, _voucherMaster, _accountLedger, bankDtl.Amount,bankDtl.ToLedgerId,bankDtl.ToLedgerCode);
                                var _cashDtlLedger = GetAccountLedgerList().Where(x => x.LedgerCode == bankDtl.ToLedgerCode).FirstOrDefault();
                                #endregion

                                #region BankPaymentDetail
                                bankDtl.BankPaymentMasterId = bankPaymentMaster.BankPaymentMasterId;
                                bankDtl.BankPaymentDetailsDate = bankPaymentMaster.BankPaymentDate;
                                bankDtl.ToLedgerId = _cashDtlLedger.LedgerId;
                                repo.TblBankPaymentDetails.Add(bankDtl);
                                repo.SaveChanges();

                                #endregion

                                #region Add Account Ledger Transaction

                                AddAccountLedgerTransactions(repo, bankPaymentMaster, _voucherDetail, bankPaymentMaster.BankPaymentDate);
                                #endregion
                                AddVoucherDetails(repo, bankPaymentMaster, _branch, _voucherMaster, _accountLedger, bankDtl.Amount, bankDtl.ToLedgerId, bankDtl.ToLedgerCode, false);
                                AddAccountLedgerTransactions(repo, bankPaymentMaster, _voucherDetail, bankPaymentMaster.BankPaymentDate,false);
                            }

                            _accountLedger = GetAccountLedgers(bankPaymentMaster.BankLedgerCode).ToArray().FirstOrDefault();
                            //AddVoucherDetails(repo, bankPaymentMaster, _branch, _voucherMaster, _accountLedger, bankPaymentMaster.TotalAmount, false);


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
    }
}

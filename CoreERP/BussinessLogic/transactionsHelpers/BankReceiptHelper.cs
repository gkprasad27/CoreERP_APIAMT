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
    public class BankReceiptHelper
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

        public static List<TblBankReceiptMaster> GetBankReceipts()
        {
            try
            {
                using (Repository<TblBankReceiptMaster> repo = new Repository<TblBankReceiptMaster>())
                {
                    return repo.TblBankReceiptMaster.ToList();
                }

            }
            catch { throw; }
        }

        public static List<TblAccountLedger> GetAccountLedgers(string ledegerCode=null)
        {
            try
            {
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger.Where(acl=> acl.LedgerCode.Contains(ledegerCode ?? acl.LedgerCode)).ToList();
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

        public List<TblBankReceiptMaster> GetBankReceiptMasters(SearchCriteria searchCriteria)
        {
            try
            {

                using (Repository<TblBankReceiptMaster> repo = new Repository<TblBankReceiptMaster>())
                {
                    List<TblBankReceiptMaster> _bankreceiptMasterList = null;


                    _bankreceiptMasterList = repo.TblBankReceiptMaster.AsEnumerable()
                              .Where(cp =>
                                         DateTime.Parse(cp.BankReceiptDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.BankReceiptDate).Value.ToShortDateString())
                                       && DateTime.Parse(cp.BankReceiptDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.BankReceiptDate).Value.ToShortDateString())
                                 )
                               .ToList();

                    if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo))
                        _bankreceiptMasterList = _bankreceiptMasterList.Where(x => x.VoucherNo == searchCriteria.InvoiceNo).ToList();


                    return _bankreceiptMasterList;
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
                
                string sufix = string.Empty, prefix = string.Empty;
                var voucherNo = new CommonHelper().GenerateNumber(30, branchCode);

                return voucherNo;
            }
            catch { throw; }
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
        public TblVoucherMaster AddVoucherMaster(ERPContext context, TblBankReceiptMaster bankReceiptMaster, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {


                var _voucherMaster = new TblVoucherMaster();
                _voucherMaster.BranchCode = bankReceiptMaster.BranchCode;
                _voucherMaster.BranchName = branch.BranchName;
                _voucherMaster.VoucherDate = bankReceiptMaster.BankReceiptDate;
                _voucherMaster.VoucherTypeIdMain = voucherTypeId;
                _voucherMaster.VoucherTypeIdSub = 37;
                _voucherMaster.VoucherNo = bankReceiptMaster.VoucherNo;
                _voucherMaster.Amount = bankReceiptMaster.TotalAmount;
                _voucherMaster.PaymentType = "Cheque";
                _voucherMaster.Narration = "Bank Receipt";
                _voucherMaster.ServerDate = DateTime.Now;
                _voucherMaster.UserId = bankReceiptMaster.UserId;
                _voucherMaster.UserName = bankReceiptMaster.UserName;
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

        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblBankReceiptMaster bankReceiptMaster, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, bool isFromCashDetials = true)
        {
            try
            {
                var _voucherDetail = new TblVoucherDetail();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = bankReceiptMaster.BranchCode;
                _voucherDetail.BranchName = bankReceiptMaster.BranchName;
                if (isFromCashDetials)
                {
                    _voucherDetail.FromLedgerId = bankReceiptMaster.BankLedgerId;
                    _voucherDetail.FromLedgerCode = bankReceiptMaster.BankLedgerCode;
                    _voucherDetail.FromLedgerName = bankReceiptMaster.BankLedgerName;
                }
                //To ledger  clarifiaction on selecion of product

                _voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                _voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                _voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                _voucherDetail.Amount = productRate;
                _voucherDetail.TransactionType = _accountLedger.CrOrDr;
                _voucherDetail.CostCenter = _accountLedger.BranchCode;
                _voucherDetail.ServerDate = DateTime.Now;
                _voucherDetail.Narration = $"Bank Receipt {_accountLedger.LedgerName} A /c: {_voucherDetail.TransactionType}";

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

        public bool RegisterBankReceipt(TblBankReceiptMaster bankReceiptMaster, List<TblBankReceiptDetails> bankReceiptDetails)
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
                            var _branch = GetBranches(bankReceiptMaster.BranchCode).ToArray().FirstOrDefault();

                            var _accountLedger = GetAccountLedgersCode(bankReceiptMaster.BankLedgerCode).ToArray().FirstOrDefault();
                            var _cashpayAccountLedger = GetAccountLedgerList().Where(x => x.LedgerId == 175).FirstOrDefault();
                            var _vouchertType = GetVoucherTypeList(30).ToArray().FirstOrDefault();

                            #region Add voucher master record
                            var _voucherMaster = AddVoucherMaster(repo, bankReceiptMaster, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                            #endregion


                            bankReceiptMaster.BankReceiptVchNo = _voucherMaster.VoucherMasterId.ToString();
                            bankReceiptMaster.ServerDate = DateTime.Now;
                            bankReceiptMaster.BranchId = _branch.BranchId;
                            bankReceiptMaster.BranchName = _branch.BranchName;
                            bankReceiptMaster.BankLedgerId = _cashpayAccountLedger.LedgerId;
                            bankReceiptMaster.BankLedgerName = _cashpayAccountLedger.LedgerName;
                            bankReceiptMaster.BankLedgerCode = _cashpayAccountLedger.LedgerCode;
                            repo.TblBankReceiptMaster.Add(bankReceiptMaster);
                            repo.SaveChanges();

                            foreach (var bankDtl in bankReceiptDetails)
                            {
                                //   _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.SalesAccount).FirstOrDefault();

                                #region Add voucher Details
                                var _voucherDetail = AddVoucherDetails(repo, bankReceiptMaster, _branch, _voucherMaster, _accountLedger, bankDtl.Amount);
                                var _cashDtlLedger = GetAccountLedgerList().Where(x => x.LedgerCode == bankDtl.ToLedgerCode).FirstOrDefault();
                                #endregion

                                #region BankReceiptDetail
                                bankDtl.BankReceiptMasterId = bankReceiptMaster.BankReceiptMasterId;
                                bankDtl.BankReceiptDetailsDate = bankReceiptMaster.BankReceiptDate;
                                bankDtl.ToLedgerId = _cashDtlLedger.LedgerId;
                                repo.TblBankReceiptDetails.Add(bankDtl);
                                repo.SaveChanges();

                                #endregion

                                #region Add Account Ledger Transaction

                                AddAccountLedgerTransactions(repo, _voucherDetail, bankReceiptMaster.BankReceiptDate);
                                #endregion
                            }

                            _accountLedger = GetAccountLedgers(bankReceiptMaster.BankLedgerCode).ToArray().FirstOrDefault();
                            AddVoucherDetails(repo, bankReceiptMaster, _branch, _voucherMaster, _accountLedger, bankReceiptMaster.TotalAmount, false);


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

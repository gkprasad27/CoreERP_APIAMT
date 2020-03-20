using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.transactionsHelpers
{
    public class CashReceiptHelper
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

        public static List<TblCashReceiptMaster> GetCashReceipts()
        {
            try
            {
                using (Repository<TblCashReceiptMaster> repo = new Repository<TblCashReceiptMaster>())
                {
                    return repo.TblCashReceiptMaster.ToList();
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
                var voucherNo = new CommonHelper().GenerateNumber(34, branchCode);
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
        public TblVoucherMaster AddVoucherMaster(ERPContext context, TblCashReceiptMaster cashReceiptMaster, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {

                
                var _voucherMaster = new TblVoucherMaster();
                _voucherMaster.BranchCode = cashReceiptMaster.BranchCode;
                _voucherMaster.BranchName = branch.BranchName;
                _voucherMaster.VoucherDate = cashReceiptMaster.CashReceiptDate;
                _voucherMaster.VoucherTypeIdMain = voucherTypeId;
                _voucherMaster.VoucherTypeIdSub = 37;
                _voucherMaster.VoucherNo = cashReceiptMaster.VoucherNo;
                _voucherMaster.Amount = cashReceiptMaster.TotalAmount;
                _voucherMaster.PaymentType = "Cash";
                _voucherMaster.Narration = "Cash Receipt";
                _voucherMaster.ServerDate = DateTime.Now;
                _voucherMaster.UserId = cashReceiptMaster.UserId;
                _voucherMaster.UserName = cashReceiptMaster.UserName;
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

        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblCashReceiptMaster cashReceiptMaster, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, bool isFromCashDetials = true)
        {
            try
            {
                var _voucherDetail = new TblVoucherDetail();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = cashReceiptMaster.BranchCode;
                _voucherDetail.BranchName = cashReceiptMaster.BranchName;
                if (isFromCashDetials)
                {
                    _voucherDetail.FromLedgerId = cashReceiptMaster.FromLedgerId;
                    _voucherDetail.FromLedgerCode = cashReceiptMaster.FromLedgerCode;
                    _voucherDetail.FromLedgerName = cashReceiptMaster.FromLedgerName;
                }
                //To ledger  clarifiaction on selecion of product

                _voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                _voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                _voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                _voucherDetail.Amount = productRate;
                _voucherDetail.TransactionType = _accountLedger.CrOrDr;
                _voucherDetail.CostCenter = _accountLedger.BranchCode;
                _voucherDetail.ServerDate = DateTime.Now;
                _voucherDetail.Narration = $"Cash Receipt {_accountLedger.LedgerName} A /c: {_voucherDetail.TransactionType}";

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
        public bool RegisterCashReceipt(TblCashReceiptMaster cashReceiptMaster, List<TblCashReceiptDetails> cashReceiptDetails)
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
                            var _branch = GetBranches(cashReceiptMaster.BranchCode).ToArray().FirstOrDefault();

                            var _accountLedger = GetAccountLedgersCode(cashReceiptMaster.FromLedgerCode).ToArray().FirstOrDefault();
                            var _cashpayAccountLedger = GetAccountLedgerList().Where(x => x.LedgerId == 175).FirstOrDefault();
                            var _vouchertType = GetVoucherTypeList(34).ToArray().FirstOrDefault();

                            #region Add voucher master record
                            var _voucherMaster = AddVoucherMaster(repo, cashReceiptMaster, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                            #endregion


                            cashReceiptMaster.CashReceiptVchNo = _voucherMaster.VoucherMasterId.ToString();
                            cashReceiptMaster.ServerDate = DateTime.Now;
                            cashReceiptMaster.BranchId = _branch.BranchId;
                            cashReceiptMaster.BranchName = _branch.BranchName;
                            cashReceiptMaster.FromLedgerId = _cashpayAccountLedger.LedgerId;
                            cashReceiptMaster.FromLedgerName = _cashpayAccountLedger.LedgerName;
                            cashReceiptMaster.FromLedgerCode = _cashpayAccountLedger.LedgerCode;
                            repo.TblCashReceiptMaster.Add(cashReceiptMaster);
                            repo.SaveChanges();

                            foreach (var cashDtl in cashReceiptDetails)
                            {
                                //   _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.SalesAccount).FirstOrDefault();

                                #region Add voucher Details
                                var _voucherDetail = AddVoucherDetails(repo, cashReceiptMaster, _branch, _voucherMaster, _accountLedger, cashDtl.Amount);
                                var _cashDtlLedger = GetAccountLedgerList().Where(x => x.LedgerCode == cashDtl.ToLedgerCode).FirstOrDefault();
                                #endregion

                                #region CashReceiptDetail
                                cashDtl.CashReceiptMasterId = cashReceiptMaster.CashReceiptMasterId;
                                cashDtl.CashReceiptDetailsDate = cashReceiptMaster.CashReceiptDate;
                                cashDtl.ToLedgerId = _cashDtlLedger.LedgerId;
                                repo.TblCashReceiptDetails.Add(cashDtl);
                                repo.SaveChanges();

                                #endregion

                                #region Add Account Ledger Transaction

                                AddAccountLedgerTransactions(repo, _voucherDetail, cashReceiptMaster.CashReceiptDate);
                                #endregion
                            }

                            _accountLedger = GetAccountLedgers(cashReceiptMaster.FromLedgerCode).ToArray().FirstOrDefault();
                            AddVoucherDetails(repo, cashReceiptMaster, _branch, _voucherMaster, _accountLedger, cashReceiptMaster.TotalAmount, false);


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

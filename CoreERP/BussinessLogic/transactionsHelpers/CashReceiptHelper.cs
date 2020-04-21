using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
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
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<TblCashReceiptMaster> GetCashReceipts()
        {
            try
            {
                using Repository<TblCashReceiptMaster> repo = new Repository<TblCashReceiptMaster>();
                return repo.TblCashReceiptMaster.ToList();

            }
            catch { throw; }
        }

        public List<TblAccountLedger> GetAccountLedgers(string ledegerCode)
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                return repo.TblAccountLedger.Where(acl => acl.LedgerCode.Contains(ledegerCode ?? acl.LedgerCode)).OrderBy(x=>x.LedgerCode).ToList();

            }
            catch { throw; }
        }

        public static List<TblAccountLedger> GetAccountLedgerByName(string ledegerName)
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                return repo.TblAccountLedger.Where(acl => acl.LedgerName.Contains(ledegerName)).ToList();

            }
            catch { throw; }
        }

        public List<TblAccountLedger> GetAccountLedgerList()
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                return repo.TblAccountLedger.ToList();
            }
            catch { throw; }
        }
        public static List<TblVoucherMaster> GetVoucherMasters()
        {
            try
            {
                using Repository<TblVoucherMaster> repo = new Repository<TblVoucherMaster>();
                return repo.TblVoucherMaster.ToList();

            }
            catch { throw; }
        }

        public static List<TblVoucherType> GetVoucherType()
        {
            try
            {
                using Repository<TblVoucherType> repo = new Repository<TblVoucherType>();
                return repo.TblVoucherType.ToList();

            }
            catch { throw; }
        }

        //public string GetVoucherNo(string branchCode)
        //{
        //    try
        //    {
        //        var voucherNo = new CommonHelper().GenerateNumber(34, branchCode);
        //        return voucherNo;
        //    }
        //    catch { throw; }
        //}

        public string GetVoucherNo(string branchCode, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                string suffix = string.Empty, prefix = string.Empty, billno = string.Empty;
                TblCashReceiptMaster _cashReceiptMaster = null;
                using (Repository<TblCashReceiptMaster> _repo = new Repository<TblCashReceiptMaster>())
                {
                    _cashReceiptMaster = _repo.TblCashReceiptMaster.Where(x => x.BranchCode == branchCode).OrderByDescending(x => x.ServerDate).FirstOrDefault();

                    if (_cashReceiptMaster != null)
                    {
                        var invSplit = _cashReceiptMaster.VoucherNo.Split('-');
                        billno = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1]) + 1}-{invSplit[2]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(34, branchCode, out prefix, out suffix);
                        if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                        {
                            errorMessage = $"No prefix and suffix confugured for branch code: {branchCode} ";
                            return billno = string.Empty;
                        }

                        billno = $"{prefix}-1-{suffix}";
                    }
                }

                if (string.IsNullOrEmpty(billno))
                {
                    errorMessage = "CashReceipt no not gererated please enter manully.";
                }

                return billno;
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
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.AsEnumerable().Where(b => b.BranchCode == (branchCode ?? b.BranchCode)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblCashReceiptMaster> GetCashReceiptMasters(VoucherNoSearchCriteria searchCriteria,string branchCode)
        {
            try
            {
                searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;

                using Repository<TblCashReceiptMaster> repo = new Repository<TblCashReceiptMaster>();
                List<TblCashReceiptMaster> _cashreceiptMasterList = null;

                if (searchCriteria.Role == 1)
                {
                    _cashreceiptMasterList = repo.TblCashReceiptMaster.AsEnumerable()
                          .Where(cr =>
                                     DateTime.Parse(cr.CashReceiptDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cr.CashReceiptDate).Value.ToShortDateString())
                                   && DateTime.Parse(cr.CashReceiptDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cr.CashReceiptDate).Value.ToShortDateString()))
                           .ToList();
                }
                else
                {
                    _cashreceiptMasterList = repo.TblCashReceiptMaster.AsEnumerable()
                          .Where(cr =>
                                     DateTime.Parse(cr.CashReceiptDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cr.CashReceiptDate).Value.ToShortDateString())
                                   && DateTime.Parse(cr.CashReceiptDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cr.CashReceiptDate).Value.ToShortDateString())
                                    && cr.BranchCode == branchCode)
                           .ToList();
                }
                    

                if (!string.IsNullOrEmpty(searchCriteria.VoucherNo))
                    _cashreceiptMasterList = _cashreceiptMasterList.Where(x => x.VoucherNo == searchCriteria.VoucherNo).ToList();


                return _cashreceiptMasterList;
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
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                return repo.TblAccountLedger
.Where(al => al.LedgerName.ToLower().Contains((ledgerName ?? al.LedgerName).ToLower())
&& al.LedgerCode == (ledgercode ?? al.LedgerCode)
)
.ToList();
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
                using Repository<TblVoucherType> repo = new Repository<TblVoucherType>();
                return repo.TblVoucherType.Where(v => v.VoucherTypeId == voucherTypeId).ToList();
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

                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(cashReceiptMaster.UserId ?? 0, null));
                var user = context.TblUserNew.Where(x => x.UserName == cashReceiptMaster.UserName).FirstOrDefault();
                var _voucherMaster = new TblVoucherMaster
                {
                    BranchCode = cashReceiptMaster.BranchCode,
                    BranchName = branch.BranchName,
                    VoucherDate = cashReceiptMaster.CashReceiptDate,
                    VoucherTypeIdMain = voucherTypeId,
                    VoucherTypeIdSub = 37,
                    VoucherNo = cashReceiptMaster.VoucherNo,
                    Amount = cashReceiptMaster.TotalAmount,
                    PaymentType = "Cash",
                    Narration = "Cash Receipt",
                    ServerDate = DateTime.Now,
                    UserId = cashReceiptMaster.UserId,
                    UserName = cashReceiptMaster.UserName,
                    EmployeeId = user.EmployeeId,
                    ShiftId=shifId
                };

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

        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblCashReceiptMaster cashReceiptMaster, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, decimal? ledgerId,string ledgerCode ,bool isFromCashDetials = true)
        {
            try
            {
                var _voucherDetail = new TblVoucherDetail();
                var ledgerName = GetAccountLedgerList().Where(al => al.LedgerCode == ledgerCode).FirstOrDefault();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = cashReceiptMaster.BranchCode;
                _voucherDetail.BranchName = cashReceiptMaster.BranchName;
               
                if (isFromCashDetials==true)
                {
                    _voucherDetail.FromLedgerId = cashReceiptMaster.FromLedgerId;
                    _voucherDetail.FromLedgerCode = cashReceiptMaster.FromLedgerCode;
                    _voucherDetail.FromLedgerName = cashReceiptMaster.FromLedgerName;
                    _voucherDetail.ToLedgerId = ledgerId;
                    _voucherDetail.ToLedgerCode =ledgerCode;
                    _voucherDetail.ToLedgerName = ledgerName.LedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Credit";
                    _voucherDetail.CostCenter = _branch.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Cash Receipt";
                }
                else
                {
                    _voucherDetail.FromLedgerId = ledgerId;
                    _voucherDetail.FromLedgerCode = ledgerCode;
                    _voucherDetail.FromLedgerName = ledgerName.LedgerName;
                    _voucherDetail.ToLedgerId = cashReceiptMaster.FromLedgerId;
                    _voucherDetail.ToLedgerCode = cashReceiptMaster.FromLedgerCode;
                    _voucherDetail.ToLedgerName = cashReceiptMaster.FromLedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Debit";
                    _voucherDetail.CostCenter = _branch.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Cash Receipt";
                }
                //To ledger  clarifiaction on selecion of product

                //_voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                //_voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                //_voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                //_voucherDetail.Amount = productRate;
                //_voucherDetail.TransactionType = _accountLedger.CrOrDr;
                //_voucherDetail.CostCenter = _accountLedger.BranchCode;
                //_voucherDetail.ServerDate = DateTime.Now;
                //_voucherDetail.Narration = "Cash Receipt";

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

        public TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context,TblCashReceiptMaster cashReceiptMaster, TblVoucherDetail _voucherDetail, DateTime? invoiceDate,bool isdebit=false)
        {
            try
            {
                var _accountLedgerTransactions = new TblAccountLedgerTransactions
                {
                    VoucherDetailId = _voucherDetail.VoucherDetailId,

                    BranchId = _voucherDetail.BranchId,
                    BranchCode = _voucherDetail.BranchCode,
                    BranchName = _voucherDetail.BranchName,
                    TransactionDate = invoiceDate,

                    VoucherAmount = _voucherDetail.Amount
                };
                if (isdebit==true)
                {
                    _accountLedgerTransactions.LedgerId = cashReceiptMaster.FromLedgerId;
                    _accountLedgerTransactions.LedgerCode = cashReceiptMaster.FromLedgerCode;
                    _accountLedgerTransactions.LedgerName = cashReceiptMaster.FromLedgerName;
                    _accountLedgerTransactions.TransactionType ="Debit";
                    _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
                  
                }
                else
                {
                    _accountLedgerTransactions.LedgerId = _voucherDetail.ToLedgerId;
                    _accountLedgerTransactions.LedgerCode = _voucherDetail.ToLedgerCode;
                    _accountLedgerTransactions.LedgerName = _voucherDetail.ToLedgerName;
                    _accountLedgerTransactions.TransactionType = _voucherDetail.TransactionType;
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
                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(cashReceiptMaster.UserId ?? 0, null));
                using ERPContext repo = new ERPContext();
                using var dbTransaction = repo.Database.BeginTransaction();
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
                    cashReceiptMaster.EmployeeId = _voucherMaster.EmployeeId;
                    cashReceiptMaster.ShiftId = shifId;
                    repo.TblCashReceiptMaster.Add(cashReceiptMaster);
                    repo.SaveChanges();

                    foreach (var cashDtl in cashReceiptDetails)
                    {
                        //   _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.SalesAccount).FirstOrDefault();
                        var _cashDtlLedger = GetAccountLedgerList().Where(x => x.LedgerCode == cashDtl.ToLedgerCode).FirstOrDefault();


                        #region CashReceiptDetail
                        cashDtl.CashReceiptMasterId = cashReceiptMaster.CashReceiptMasterId;
                        cashDtl.CashReceiptDetailsDate = cashReceiptMaster.CashReceiptDate;
                        cashDtl.ToLedgerId = _cashDtlLedger.LedgerId;
                        repo.TblCashReceiptDetails.Add(cashDtl);
                        repo.SaveChanges();

                        #endregion

                        #region Add voucher Details
                        var _voucherDetail = AddVoucherDetails(repo, cashReceiptMaster, _branch, _voucherMaster, _accountLedger, cashDtl.Amount, cashDtl.ToLedgerId, cashDtl.ToLedgerCode);

                        #endregion

                        #region Add Account Ledger Transaction

                        AddAccountLedgerTransactions(repo, cashReceiptMaster, _voucherDetail, cashReceiptMaster.CashReceiptDate);
                        #endregion
                        _accountLedger = GetAccountLedgers(cashReceiptMaster.FromLedgerCode).ToArray().FirstOrDefault();
                        AddVoucherDetails(repo, cashReceiptMaster, _branch, _voucherMaster, _accountLedger, cashDtl.Amount, cashDtl.ToLedgerId, cashDtl.ToLedgerCode, false);
                        AddAccountLedgerTransactions(repo, cashReceiptMaster, _voucherDetail, cashReceiptMaster.CashReceiptDate, true);
                    }

                    //_accountLedger = GetAccountLedgers(cashReceiptMaster.FromLedgerCode).ToArray().FirstOrDefault();
                    //AddVoucherDetails(repo, cashReceiptMaster, _branch, _voucherMaster, _accountLedger, cashReceiptMaster.TotalAmount,cashReceiptDetails[].ToLedgerId,cashReceiptDetails[].ToLedgerCode ,false);


                    dbTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public List<TblCashReceiptDetails> GetCashReceiptDetails(decimal id)
        {
            try
            {
                using Repository<TblCashPaymentDetails> repo = new Repository<TblCashPaymentDetails>();

                //var cashPaymentDetails = GetCashReceipts().Where(c => c.VoucherNo == invoiceNo).FirstOrDefault();
                return repo.TblCashReceiptDetails.Where(x => x.CashReceiptMasterId == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

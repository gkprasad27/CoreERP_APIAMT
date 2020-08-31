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
    public class CashPaymentHelper
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

        public static List<TblCashPaymentMaster> GetCashPayments()
        {
            try
            {
                using Repository<TblCashPaymentMaster> repo = new Repository<TblCashPaymentMaster>();
                return repo.TblCashPaymentMaster.ToList();

            }
            catch { throw; }
        }

        public List<TblCashPaymentMaster> GetCashPaymentMasters(VoucherNoSearchCriteria searchCriteria, string branchCode)
        {
            try
            {
                if (string.IsNullOrEmpty(searchCriteria.VoucherNo) && string.IsNullOrEmpty(searchCriteria.BranchCode))
                {
                    searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                    searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;
                }
                using Repository<TblCashPaymentMaster> repo = new Repository<TblCashPaymentMaster>();
                List<TblCashPaymentMaster> _cashpaymentMasterList = null;
                if (searchCriteria.Role == 1 || searchCriteria.Role == 3 || searchCriteria.Role == 89)
                {
                    _cashpaymentMasterList = repo.TblCashPaymentMaster.AsEnumerable()
                          .Where(cp =>
                                     DateTime.Parse(cp.CashPaymentDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.CashPaymentDate).Value.ToShortDateString())
                                   && DateTime.Parse(cp.CashPaymentDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.CashPaymentDate).Value.ToShortDateString()))
                           .ToList();
                }
                else
                {
                    _cashpaymentMasterList = repo.TblCashPaymentMaster.AsEnumerable()
                                              .Where(cp =>
                                                         DateTime.Parse(cp.CashPaymentDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.CashPaymentDate).Value.ToShortDateString())
                                                       && DateTime.Parse(cp.CashPaymentDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.CashPaymentDate).Value.ToShortDateString())
                                                       && cp.BranchCode == branchCode)
                                               .ToList();

                }

                if (!string.IsNullOrEmpty(searchCriteria.VoucherNo))
                    _cashpaymentMasterList = _cashpaymentMasterList.Where(x => x.VoucherNo == searchCriteria.VoucherNo).ToList();

                if (!string.IsNullOrEmpty(searchCriteria.BranchCode))
                    _cashpaymentMasterList = _cashpaymentMasterList.Where(x => x.BranchCode == searchCriteria.BranchCode).ToList();

                return _cashpaymentMasterList.OrderByDescending(cp => cp.ServerDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<TblCashPaymentDetails> GetCashpaymentDetails(decimal id)
        {
            try
            {

                using Repository<TblCashPaymentDetails> repo = new Repository<TblCashPaymentDetails>();
                return repo.TblCashPaymentDetails.Where(x => x.CashPaymentMasterId == id).ToList();
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
                return repo.TblAccountLedger.Where(al => al.LedgerName.ToLower().Contains((ledgerName ?? al.LedgerName).ToLower())&& al.LedgerCode == (ledgercode ?? al.LedgerCode)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblAccountLedger> GetAccountLedgers(string ledegerCode)
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                return repo.TblAccountLedger.Where(acl => acl.LedgerCode.Contains(ledegerCode)).OrderBy(x=>x.LedgerCode).ToList();

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

        public  List<TblAccountLedger> GetAccountLedgerList()
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
        //public string GetVoucherNo(string branchCode)
        //{
        //    try
        //    {
        //        var voucherNo = new CommonHelper().GenerateNumber(33, branchCode);
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
                TblCashPaymentMaster _cashPaymentMaster = null;
                using (Repository<TblCashPaymentMaster> _repo = new Repository<TblCashPaymentMaster>())
                {
                    _cashPaymentMaster = _repo.TblCashPaymentMaster.Where(x => x.BranchCode == branchCode).OrderByDescending(x => x.ServerDate).FirstOrDefault();

                    if (_cashPaymentMaster != null)
                    {
                        var invSplit = _cashPaymentMaster.VoucherNo.Split('-');
                        billno = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1]) + 1}-{invSplit[2]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(33, branchCode, out prefix, out suffix);
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
                    errorMessage = "CashPayment no not gererated please enter manully.";
                }

                return billno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblAccountLedger> GetAccountLedgersByLedgerId(decimal LedgerId)
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                return repo.TblAccountLedger
.Where(al => al.LedgerId == LedgerId)
.ToList();
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
                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(cashPaymentMaster.UserId ?? 0, null));
                var user = context.TblUserNew.Where(x => x.UserName == cashPaymentMaster.UserName).FirstOrDefault();
                var _voucherMaster = new TblVoucherMaster
                {
                    BranchCode = cashPaymentMaster.BranchCode,
                    BranchName = branch.BranchName,
                    VoucherDate = cashPaymentMaster.CashPaymentDate,
                    VoucherTypeIdMain = voucherTypeId,
                    VoucherTypeIdSub = 37,
                    VoucherNo = cashPaymentMaster.VoucherNo,
                    Amount = cashPaymentMaster.TotalAmount,
                    PaymentType = "Cash",
                    Narration = "Cash Receipt",
                    ServerDate = DateTime.Now,
                    UserId = cashPaymentMaster.UserId,
                    UserName = cashPaymentMaster.UserName,
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

        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblCashPaymentMaster cashPaymentMaster, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, decimal? ledgerId, string ledgerCode, bool isFromCashDetials = true)
        {
            try
            {
                var _voucherDetail = new TblVoucherDetail();
                var ledgerName = GetAccountLedgerList().Where(al => al.LedgerCode == ledgerCode).FirstOrDefault();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = cashPaymentMaster.BranchCode;
                _voucherDetail.BranchName = cashPaymentMaster.BranchName;

                if (isFromCashDetials == true)
                {
                    _voucherDetail.FromLedgerId = cashPaymentMaster.FromLedgerId;
                    _voucherDetail.FromLedgerCode = cashPaymentMaster.FromLedgerCode;
                    _voucherDetail.FromLedgerName = cashPaymentMaster.FromLedgerName;
                    _voucherDetail.ToLedgerId = ledgerId;
                    _voucherDetail.ToLedgerCode = ledgerCode;
                    _voucherDetail.ToLedgerName = ledgerName.LedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Debit";
                    _voucherDetail.CostCenter = _branch.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Cash Payment";
                }
                else
                {
                    _voucherDetail.FromLedgerId = ledgerId;
                    _voucherDetail.FromLedgerCode = ledgerCode;
                    _voucherDetail.FromLedgerName = ledgerName.LedgerName;
                    _voucherDetail.ToLedgerId = cashPaymentMaster.FromLedgerId;
                    _voucherDetail.ToLedgerCode = cashPaymentMaster.FromLedgerCode;
                    _voucherDetail.ToLedgerName = cashPaymentMaster.FromLedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Credit";
                    _voucherDetail.CostCenter = _branch.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Cash Payment";
                }
             

                context.TblVoucherDetail.Add(_voucherDetail);
                if (context.SaveChanges() > 0)
                    return _voucherDetail;

              
                return null;
                // }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context, TblCashPaymentMaster cashPaymentMaster, TblVoucherDetail _voucherDetail, DateTime? invoiceDate, bool isdebit = false)
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
                if (isdebit == true)
                {
                    _accountLedgerTransactions.LedgerId = cashPaymentMaster.FromLedgerId;
                    _accountLedgerTransactions.LedgerCode = cashPaymentMaster.FromLedgerCode;
                    _accountLedgerTransactions.LedgerName = cashPaymentMaster.FromLedgerName;
                    _accountLedgerTransactions.TransactionType = "Credit";
                    _accountLedgerTransactions.CreditAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.DebitAmount = Convert.ToDecimal("0.00");
                   

                }
                else
                {
                    _accountLedgerTransactions.LedgerId = _voucherDetail.ToLedgerId;
                    _accountLedgerTransactions.LedgerCode = _voucherDetail.ToLedgerCode; 
                    _accountLedgerTransactions.LedgerName = _voucherDetail.ToLedgerName;
                    _accountLedgerTransactions.TransactionType = "Debit";
                    _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
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
                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(cashPaymentMaster.UserId??0, null));
                using ERPContext repo = new ERPContext();
                using var dbTransaction = repo.Database.BeginTransaction();
                try
                {
                    //add voucher typedetails

                    var _branch = GetBranches(cashPaymentMaster.BranchCode).ToArray().FirstOrDefault();

                    var _accountLedger = GetAccountLedgersCode(cashPaymentMaster.FromLedgerCode).ToArray().FirstOrDefault();
                    var _cashpayAccountLedger = GetAccountLedgerList().Where(x => x.LedgerId == 175).FirstOrDefault();
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
                    cashPaymentMaster.ShiftId = shifId;
                    repo.TblCashPaymentMaster.Add(cashPaymentMaster);
                    repo.SaveChanges();

                    foreach (var cashDtl in cashPaymentDetails)
                    {
                        //   _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.SalesAccount).FirstOrDefault();
                        var _cashDtlLedger = GetAccountLedgerList().Where(x => x.LedgerCode == cashDtl.ToLedgerCode).FirstOrDefault();


                        #region CashPaymentDetail
                        cashDtl.CashPaymentMasterId = cashPaymentMaster.CashPaymentMasterId;
                        cashDtl.CashPaymentDetailsDate = cashPaymentMaster.CashPaymentDate;
                        cashDtl.ToLedgerId = _cashDtlLedger.LedgerId;
                        repo.TblCashPaymentDetails.Add(cashDtl);
                        repo.SaveChanges();

                        #endregion

                        #region Add voucher Details
                        var _voucherDetail = AddVoucherDetails(repo, cashPaymentMaster, _branch, _voucherMaster, _accountLedger, cashDtl.Amount, cashDtl.ToLedgerId, cashDtl.ToLedgerCode);

                        #endregion

                        #region Add Account Ledger Transaction

                        AddAccountLedgerTransactions(repo, cashPaymentMaster, _voucherDetail, cashPaymentMaster.CashPaymentDate);
                        #endregion
                        _accountLedger = GetAccountLedgers(cashPaymentMaster.FromLedgerCode).ToArray().FirstOrDefault();
                        _voucherDetail= AddVoucherDetails(repo, cashPaymentMaster, _branch, _voucherMaster, _accountLedger, cashDtl.Amount, cashDtl.ToLedgerId, cashDtl.ToLedgerCode, false);
                        AddAccountLedgerTransactions(repo, cashPaymentMaster, _voucherDetail, cashPaymentMaster.CashPaymentDate, true);
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

      
    }
}

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
    public class BankReceiptHelper
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

        public static List<TblBankReceiptMaster> GetBankReceipts()
        {
            try
            {
                using Repository<TblBankReceiptMaster> repo = new Repository<TblBankReceiptMaster>();
                return repo.TblBankReceiptMaster.ToList();

            }
            catch { throw; }
        }

        public List<TblAccountLedger> GetAccountLedgers(string ledegerCode=null)
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

        public List<TblBankReceiptMaster> GetBankReceiptMasters(VoucherNoSearchCriteria searchCriteria, string branchCode)
        {
            try
            {
                if (string.IsNullOrEmpty(searchCriteria.VoucherNo) && string.IsNullOrEmpty(searchCriteria.BranchCode))
                {
                    searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                    searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;
                }

                using Repository<TblBankReceiptMaster> repo = new Repository<TblBankReceiptMaster>();
                List<TblBankReceiptMaster> _bankreceiptMasterList = null;
                if (searchCriteria.Role == 1 || searchCriteria.Role == 3 || searchCriteria.Role == 89)
                {
                    _bankreceiptMasterList = repo.TblBankReceiptMaster.AsEnumerable()
                                             .Where(br =>
                                                        DateTime.Parse(br.BankReceiptDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? br.BankReceiptDate).Value.ToShortDateString())
                                                      && DateTime.Parse(br.BankReceiptDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? br.BankReceiptDate).Value.ToShortDateString()))
                                              .ToList();
                }
                else
                {
                    _bankreceiptMasterList = repo.TblBankReceiptMaster.AsEnumerable()
                                              .Where(br =>
                                                         DateTime.Parse(br.BankReceiptDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? br.BankReceiptDate).Value.ToShortDateString())
                                                       && DateTime.Parse(br.BankReceiptDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? br.BankReceiptDate).Value.ToShortDateString())
                                                       && br.BranchCode == branchCode)
                                               .ToList();
                }


                if (!string.IsNullOrEmpty(searchCriteria.VoucherNo))
                    _bankreceiptMasterList = _bankreceiptMasterList.Where(x => x.VoucherNo == searchCriteria.VoucherNo).ToList();


                if (!string.IsNullOrEmpty(searchCriteria.BranchCode))
                    _bankreceiptMasterList = _bankreceiptMasterList.Where(x => x.BranchCode == searchCriteria.BranchCode).ToList();


                return _bankreceiptMasterList.OrderByDescending(x => x.ServerDate).ToList();
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

        //        string sufix = string.Empty, prefix = string.Empty;
        //        var voucherNo = new CommonHelper().GenerateNumber(30, branchCode);

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
                TblBankReceiptMaster _bankReceiptMaster = null;
                using (Repository<TblBankReceiptMaster> _repo = new Repository<TblBankReceiptMaster>())
                {
                    _bankReceiptMaster = _repo.TblBankReceiptMaster.Where(x => x.BranchCode == branchCode).OrderByDescending(x => x.ServerDate).FirstOrDefault();

                    if (_bankReceiptMaster != null)
                    {
                        var invSplit = _bankReceiptMaster.VoucherNo.Split('-');
                        billno = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1]) + 1}-{invSplit[2]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(30, branchCode, out prefix, out suffix);
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
                    errorMessage = "BankReceipt no not gererated please enter manully.";
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
        public TblVoucherMaster AddVoucherMaster(ERPContext context, TblBankReceiptMaster bankReceiptMaster, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {

                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(bankReceiptMaster.UserId ?? 0, null));
                var user = context.TblUserNew.Where(x => x.UserName == bankReceiptMaster.UserName).FirstOrDefault();
                var _voucherMaster = new TblVoucherMaster
                {
                    BranchCode = bankReceiptMaster.BranchCode,
                    BranchName = branch.BranchName,
                    VoucherDate = bankReceiptMaster.BankReceiptDate,
                    VoucherTypeIdMain = voucherTypeId,
                    VoucherTypeIdSub = 37,
                    VoucherNo = bankReceiptMaster.VoucherNo,
                    Amount = bankReceiptMaster.TotalAmount,
                    PaymentType = "Cheque",
                    Narration = "Bank Receipt",
                    ServerDate = DateTime.Now,
                    UserId = bankReceiptMaster.UserId,
                    UserName = bankReceiptMaster.UserName,
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

        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblBankReceiptMaster bankReceiptMaster, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, decimal? ledgerId, string ledgerCode, bool isFromCashDetials = true)
        {
            try
            {
                var _voucherDetail = new TblVoucherDetail();
                var ledgerName = GetAccountLedgerList().Where(al => al.LedgerCode == ledgerCode).FirstOrDefault();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = bankReceiptMaster.BranchCode;
                _voucherDetail.BranchName = bankReceiptMaster.BranchName;
                if (isFromCashDetials == true)
                {
                    _voucherDetail.FromLedgerId = ledgerName.LedgerId;
                    _voucherDetail.FromLedgerCode = ledgerCode;
                    _voucherDetail.FromLedgerName = ledgerName.LedgerName;
                    _voucherDetail.ToLedgerId = bankReceiptMaster.BankLedgerId;
                    _voucherDetail.ToLedgerCode = bankReceiptMaster.BankLedgerCode;
                    _voucherDetail.ToLedgerName = bankReceiptMaster.BankLedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Debit";
                    _voucherDetail.CostCenter = bankReceiptMaster.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Bank Receipt Detail";
                }
                //To ledger  clarifiaction on selecion of product
                else
                {
                    _voucherDetail.FromLedgerId = bankReceiptMaster.BankLedgerId;
                    _voucherDetail.FromLedgerCode = bankReceiptMaster.BankLedgerCode;
                    _voucherDetail.FromLedgerName = bankReceiptMaster.BankLedgerName;
                    _voucherDetail.ToLedgerId = ledgerName.LedgerId;
                    _voucherDetail.ToLedgerCode = ledgerCode;
                    _voucherDetail.ToLedgerName = ledgerName.LedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Credit";
                    _voucherDetail.CostCenter = bankReceiptMaster.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Bank Receipt Detail";
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

        public TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context, TblBankReceiptMaster bankReceiptMaster, TblVoucherDetail _voucherDetail, DateTime? invoiceDate,bool isdebit=true)
        {
            try
            {
                var _accountLedgerTransactions = new TblAccountLedgerTransactions
                {
                    BranchId = _voucherDetail.BranchId,
                    BranchCode = _voucherDetail.BranchCode,
                    BranchName = _voucherDetail.BranchName,
                    TransactionDate = invoiceDate,
                    // _accountLedgerTransactions.TransactionType = _voucherDetail.TransactionType;
                    VoucherAmount = _voucherDetail.Amount
                };
                if (isdebit == true)
                {
                    _accountLedgerTransactions.VoucherDetailId = _voucherDetail.VoucherDetailId;
                    _accountLedgerTransactions.LedgerId = bankReceiptMaster.BankLedgerId;
                    _accountLedgerTransactions.LedgerCode = bankReceiptMaster.BankLedgerCode;
                    _accountLedgerTransactions.LedgerName = bankReceiptMaster.BankLedgerName;
                    _accountLedgerTransactions.TransactionType = "Debit";
                    _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
                }
                else
                {
                    _accountLedgerTransactions.VoucherDetailId = _voucherDetail.VoucherDetailId;
                    _accountLedgerTransactions.LedgerId = _voucherDetail.FromLedgerId;
                    _accountLedgerTransactions.LedgerCode = _voucherDetail.FromLedgerCode;
                    _accountLedgerTransactions.LedgerName = _voucherDetail.FromLedgerName;
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

        public bool RegisterBankReceipt(TblBankReceiptMaster bankReceiptMaster, List<TblBankReceiptDetails> bankReceiptDetails)
        {
            try
            {
                using ERPContext repo = new ERPContext();
                using var dbTransaction = repo.Database.BeginTransaction();
                try
                {
                    decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(bankReceiptMaster.UserId ?? 0, null));
                    //add voucher typedetails
                    var _branch = GetBranches(bankReceiptMaster.BranchCode).ToArray().FirstOrDefault();

                    var _accountLedger = GetAccountLedgersCode(bankReceiptMaster.BankLedgerCode).ToArray().FirstOrDefault();
                    var _cashpayAccountLedger = GetAccountLedgerList().Where(x => x.LedgerCode == bankReceiptMaster.BankLedgerCode).FirstOrDefault();
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
                    bankReceiptMaster.EmployeeId = _voucherMaster.EmployeeId;
                    bankReceiptMaster.ShiftId = shifId;
                    repo.TblBankReceiptMaster.Add(bankReceiptMaster);
                    repo.SaveChanges();

                    foreach (var bankDtl in bankReceiptDetails)
                    {
                        //   _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.SalesAccount).FirstOrDefault();

                        #region Add voucher Details
                        var _voucherDetail = AddVoucherDetails(repo, bankReceiptMaster, _branch, _voucherMaster, _accountLedger, bankDtl.Amount, bankDtl.ToLedgerId, bankDtl.ToLedgerCode);
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

                        AddAccountLedgerTransactions(repo, bankReceiptMaster, _voucherDetail, bankReceiptMaster.BankReceiptDate);
                        #endregion
                        AddVoucherDetails(repo, bankReceiptMaster, _branch, _voucherMaster, _accountLedger, bankDtl.Amount, bankDtl.ToLedgerId, bankDtl.ToLedgerCode, false);
                        AddAccountLedgerTransactions(repo, bankReceiptMaster, _voucherDetail, bankReceiptMaster.BankReceiptDate, false);
                    }

                    _accountLedger = GetAccountLedgers(bankReceiptMaster.BankLedgerCode).ToArray().FirstOrDefault();
                    //AddVoucherDetails(repo, bankReceiptMaster, _branch, _voucherMaster, _accountLedger, bankReceiptMaster.TotalAmount, false);


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

        public List<TblBankReceiptMaster> GetBankReceiptMasters()
        {
            try
            {
                using Repository<TblBankReceiptMaster> repo = new Repository<TblBankReceiptMaster>();
                return repo.TblBankReceiptMaster.ToList();

            }
            catch { throw; }
        }
        public List<TblBankReceiptDetails> GetBankReceiptDetails(decimal id)
        {
            try
            {
                using Repository<TblBankReceiptDetails> repo = new Repository<TblBankReceiptDetails>();
                return repo.TblBankReceiptDetails.Where(x => x.BankReceiptMasterId == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

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
    public class JournalVoucherHelper
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

        public  List<TblJournalVoucherMaster> GetJournalVouchers()
        {
            try
            {
                using Repository<TblJournalVoucherMaster> repo = new Repository<TblJournalVoucherMaster>();
                return repo.TblJournalVoucherMaster.ToList();

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

        public static List<TblAccountLedger> GetAccountLedgers(string ledegerCode)
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                return repo.TblAccountLedger.Where(acl => acl.LedgerCode.Contains(ledegerCode)).ToList();

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

        public string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = new CommonHelper().GenerateNumber(32, branchCode);
                return voucherNo;
            }
            catch { throw; }
        }

        public List<TblJournalVoucherMaster> GetJournalVoucherMasters(VoucherNoSearchCriteria searchCriteria,string branchCode)
        {
            try
            {
                searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;

                using Repository<TblJournalVoucherMaster> repo = new Repository<TblJournalVoucherMaster>();
                List<TblJournalVoucherMaster> _journalVoucherMasterList = null;
                if (searchCriteria.Role == 1)
                {
                    _journalVoucherMasterList = repo.TblJournalVoucherMaster.AsEnumerable()
                          .Where(jv =>
                                     DateTime.Parse(jv.JournalVoucherDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? jv.JournalVoucherDate).Value.ToShortDateString())
                                   && DateTime.Parse(jv.JournalVoucherDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? jv.JournalVoucherDate).Value.ToShortDateString()))
                           .ToList();
                }
                else
                {
                    _journalVoucherMasterList = repo.TblJournalVoucherMaster.AsEnumerable()
                                             .Where(jv =>
                                                        DateTime.Parse(jv.JournalVoucherDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? jv.JournalVoucherDate).Value.ToShortDateString())
                                                      && DateTime.Parse(jv.JournalVoucherDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? jv.JournalVoucherDate).Value.ToShortDateString())
                                                      && jv.BranchCode == branchCode)
                                              .ToList();
                }


                if (!string.IsNullOrEmpty(searchCriteria.VoucherNo))
                    _journalVoucherMasterList = _journalVoucherMasterList.Where(x => x.VoucherNo == searchCriteria.VoucherNo).ToList();


                return _journalVoucherMasterList;
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

        public TblVoucherMaster AddVoucherMaster(ERPContext context, TblJournalVoucherMaster journalVoucherMaster, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {
                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(journalVoucherMaster.UserId ?? 0, null));

                var _voucherMaster = new TblVoucherMaster
                {
                    BranchCode = journalVoucherMaster.BranchCode,
                    BranchName = branch.BranchName,
                    VoucherDate = journalVoucherMaster.JournalVoucherDate,
                    VoucherTypeIdMain = voucherTypeId,
                    VoucherTypeIdSub = 6,
                    VoucherNo = journalVoucherMaster.VoucherNo,
                    Amount = journalVoucherMaster.TotalAmount,
                    PaymentType = "Journal Voucher",
                    Narration = "Journal Voucher",
                    ServerDate = DateTime.Now,
                    UserId = journalVoucherMaster.UserId,
                    UserName = journalVoucherMaster.UserName,
                    EmployeeId = -1,
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

        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblJournalVoucherMaster journalVoucherMaster, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, decimal? ledgerId, string ledgerCode, bool isFromCashDetials = true)
        {
            try
            {
                var _voucherDetail = new TblVoucherDetail();
                var ledgerName = GetAccountLedgerList().Where(al => al.LedgerCode == ledgerCode).FirstOrDefault();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = journalVoucherMaster.BranchCode;
                _voucherDetail.BranchName = journalVoucherMaster.BranchName;
                if (isFromCashDetials == true)
                {
                    _voucherDetail.FromLedgerId = journalVoucherMaster.FromLedgerId;
                    _voucherDetail.FromLedgerCode = journalVoucherMaster.FromLedgerCode;
                    _voucherDetail.FromLedgerName = journalVoucherMaster.FromLedgerName;
                    _voucherDetail.ToLedgerId = ledgerName.LedgerId;
                    _voucherDetail.ToLedgerCode = ledgerCode;
                    _voucherDetail.ToLedgerName = ledgerName.LedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Debit";
                    _voucherDetail.CostCenter = journalVoucherMaster.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Journal Voucher";
                }
                //To ledger  clarifiaction on selecion of product
                else
                {
                    _voucherDetail.FromLedgerId = ledgerName.LedgerId;
                    _voucherDetail.FromLedgerCode = ledgerCode;
                    _voucherDetail.FromLedgerName = ledgerName.LedgerName;
                    _voucherDetail.ToLedgerId = journalVoucherMaster.FromLedgerId;
                    _voucherDetail.ToLedgerCode = journalVoucherMaster.FromLedgerCode;
                    _voucherDetail.ToLedgerName = journalVoucherMaster.FromLedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = "Credit";
                    _voucherDetail.CostCenter = journalVoucherMaster.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Journal Voucher";


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

        public TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context, TblJournalVoucherMaster journalVoucherMaster, TblVoucherDetail _voucherDetail, DateTime? invoiceDate, bool isdebit = true)
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
                    _accountLedgerTransactions.LedgerId = _voucherDetail.ToLedgerId;
                    _accountLedgerTransactions.LedgerCode = _voucherDetail.ToLedgerCode;
                    _accountLedgerTransactions.LedgerName = _voucherDetail.ToLedgerName;
                    _accountLedgerTransactions.TransactionType = _voucherDetail.TransactionType;
                    _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
                }
                else
                {
                    _accountLedgerTransactions.VoucherDetailId = _voucherDetail.VoucherDetailId;
                    _accountLedgerTransactions.LedgerId = journalVoucherMaster.FromLedgerId;
                    _accountLedgerTransactions.LedgerCode = journalVoucherMaster.FromLedgerCode;
                    _accountLedgerTransactions.LedgerName = journalVoucherMaster.FromLedgerName;
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
        public bool RegisterJournalVoucher(TblJournalVoucherMaster journalVoucherMaster, List<TblJournalVoucherDetails> journalVoucherDetails)
        {
            try
            {
                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(journalVoucherMaster.UserId ?? 0, null));
                using ERPContext repo = new ERPContext();
                using var dbTransaction = repo.Database.BeginTransaction();
                try
                {
                    //add voucher typedetails
                    var _branch = GetBranches(journalVoucherMaster.BranchCode).ToArray().FirstOrDefault();

                    var _accountLedger = GetAccountLedgersCode(journalVoucherMaster.FromLedgerCode).ToArray().FirstOrDefault();
                    var _cashpayAccountLedger = GetAccountLedgerList().Where(x => x.LedgerCode == journalVoucherMaster.FromLedgerCode).FirstOrDefault();
                    var _vouchertType = GetVoucherTypeList(32).ToArray().FirstOrDefault();

                    #region Add voucher master record
                    var _voucherMaster = AddVoucherMaster(repo, journalVoucherMaster, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                    #endregion


                    journalVoucherMaster.JournalVchNo = _voucherMaster.VoucherMasterId.ToString();
                    journalVoucherMaster.ServerDate = DateTime.Now;
                    journalVoucherMaster.BranchId = _branch.BranchId;
                    journalVoucherMaster.BranchName = _branch.BranchName;
                    journalVoucherMaster.FromLedgerId = _cashpayAccountLedger.LedgerId;
                    journalVoucherMaster.FromLedgerName = _cashpayAccountLedger.LedgerName;
                    journalVoucherMaster.FromLedgerCode = _cashpayAccountLedger.LedgerCode;
                    journalVoucherMaster.EmployeeId = _voucherMaster.EmployeeId;
                    journalVoucherMaster.ShiftId = shifId;
                    repo.TblJournalVoucherMaster.Add(journalVoucherMaster);
                    repo.SaveChanges();

                    foreach (var bankDtl in journalVoucherDetails)
                    {
                        //   _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.SalesAccount).FirstOrDefault();

                        #region Add voucher Details
                        var _voucherDetail = AddVoucherDetails(repo, journalVoucherMaster, _branch, _voucherMaster, _accountLedger, bankDtl.Amount, bankDtl.ToLedgerId, bankDtl.ToLedgerCode);
                        var _cashDtlLedger = GetAccountLedgerList().Where(x => x.LedgerCode == bankDtl.ToLedgerCode).FirstOrDefault();
                        #endregion

                        #region BankReceiptDetail
                        bankDtl.JournalVoucherMasterId = journalVoucherMaster.JournalVoucherMasterId;
                        bankDtl.JournalVoucherDetailsDate = journalVoucherMaster.JournalVoucherDate;
                        bankDtl.ToLedgerId = _cashDtlLedger.LedgerId;
                        repo.TblJournalVoucherDetails.Add(bankDtl);
                        repo.SaveChanges();

                        #endregion

                        #region Add Account Ledger Transaction

                        AddAccountLedgerTransactions(repo, journalVoucherMaster, _voucherDetail, journalVoucherMaster.JournalVoucherDate);
                        #endregion
                        AddVoucherDetails(repo, journalVoucherMaster, _branch, _voucherMaster, _accountLedger, bankDtl.Amount, bankDtl.ToLedgerId, bankDtl.ToLedgerCode, false);
                        AddAccountLedgerTransactions(repo, journalVoucherMaster, _voucherDetail, journalVoucherMaster.JournalVoucherDate, false);
                    }

                    _accountLedger = GetAccountLedgers(journalVoucherMaster.FromLedgerCode).ToArray().FirstOrDefault();
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

        public List<TblJournalVoucherDetails> GetJournalVoucherDetails(decimal id)
        {
            try
            {
                using Repository<TblJournalVoucherDetails> repo = new Repository<TblJournalVoucherDetails>();
                return repo.TblJournalVoucherDetails.Where(x => x.JournalVoucherMasterId == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

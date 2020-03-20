using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
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

        public string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = new CommonHelper().GenerateNumber(33, branchCode);
                return voucherNo;
            }
            catch { throw; }
        }

        public static TblCashPaymentMaster RegisterCashPayment(TblCashPaymentMaster cashPaymentMaster)
        {
            using(Repository<TblCashPaymentMaster> repo=new Repository<TblCashPaymentMaster>())
            {
                using(var transaction = repo.Database.BeginTransaction())
                {
                    try
                    {
                        var voucherType = CashPaymentHelper.GetVoucherType().Where(vt => vt.VoucherTypeName == "Cash Payment").FirstOrDefault();
                        var voucherTypeSub = CashPaymentHelper.GetVoucherType().Where(vt => vt.VoucherTypeName == "Cash").FirstOrDefault();
                        var accountledger = new CashPaymentHelper().GetAccountLedgerList().Where(al => al.LedgerCode == "100").FirstOrDefault();
                        TblVoucherMaster voucherMaster = new TblVoucherMaster();
                        voucherMaster.BranchCode = cashPaymentMaster.BranchCode;
                        voucherMaster.BranchName = cashPaymentMaster.BranchName;
                        voucherMaster.VoucherDate = cashPaymentMaster.CashPaymentDate;
                        voucherMaster.VoucherTypeIdMain = voucherType.VoucherTypeId;
                        voucherMaster.VoucherTypeIdSub = voucherTypeSub.VoucherTypeId;
                        voucherMaster.VoucherNo = cashPaymentMaster.VoucherNo;
                        voucherMaster.Amount = cashPaymentMaster.TotalAmount;
                        voucherMaster.PaymentType = voucherTypeSub.VoucherTypeName;
                        voucherMaster.Narration = voucherTypeSub.TypeOfVoucher;
                        voucherMaster.ServerDate = DateTime.Now;

                        repo.TblVoucherMaster.Add(voucherMaster);

                        cashPaymentMaster.CashPaymentVchNo= Convert.ToString(voucherMaster.VoucherMasterId);
                        cashPaymentMaster.FromLedgerId = accountledger.LedgerId;
                        cashPaymentMaster.FromLedgerCode = accountledger.LedgerCode;
                        cashPaymentMaster.FromLedgerName = accountledger.LedgerName;
                        cashPaymentMaster.ServerDate= DateTime.Now;
                        repo.TblCashPaymentMaster.Add(cashPaymentMaster);
                       

                        foreach (var item in cashPaymentMaster.CashPaymentDetails)
                        {
                            var toLedger = new CashPaymentHelper().GetAccountLedgerList().Where(al => al.LedgerCode == item.ToLedgerCode).FirstOrDefault();
                            item.CashPaymentMasterId = cashPaymentMaster.CashPaymentMasterId;
                            item.CashPaymentDetailsDate = DateTime.Now;
                            item.ToLedgerId = toLedger.LedgerId;
                            repo.TblCashPaymentDetails.Add(item);
                        }
                        
                        TblCashPaymentDetails cashPaymentDetails1 = new TblCashPaymentDetails();
                        TblVoucherDetail voucherDetail = new TblVoucherDetail();
                        List<TblCashPaymentDetails> cashDetails = new List<TblCashPaymentDetails>();
                        bool isdebit = true;
                        foreach (var item in cashDetails)
                        {
                            voucherDetail.VoucherMasterId = voucherMaster.VoucherMasterId;
                            voucherDetail.VoucherDetailDate = DateTime.Now;
                            voucherDetail.BranchId = cashPaymentMaster.BranchId;
                            voucherDetail.BranchCode = cashPaymentMaster.BranchCode;
                            voucherDetail.BranchName = cashPaymentMaster.BranchName;
                            voucherDetail.FromLedgerCode = cashPaymentMaster.FromLedgerCode;
                            voucherDetail.FromLedgerId = cashPaymentMaster.FromLedgerId;
                            voucherDetail.FromLedgerName = cashPaymentMaster.FromLedgerName;
                            voucherDetail.ToLedgerCode = cashPaymentDetails1.ToLedgerCode;
                            voucherDetail.ToLedgerId = cashPaymentDetails1.ToLedgerId;
                            voucherDetail.ToLedgerName = cashPaymentDetails1.ToLedgerName;
                            voucherDetail.Amount = cashPaymentDetails1.Amount;
                            voucherDetail.Narration = voucherType.VoucherTypeName;
                            if (isdebit)
                            {
                                voucherDetail.TransactionType = "Debit";
                                isdebit = false;
                            }
                            else
                            {
                                voucherDetail.TransactionType = "Credit";
                                isdebit = true;
                            }
                            repo.TblVoucherDetail.Add(voucherDetail);
                        }


                        repo.SaveChanges();

                        transaction.Commit();

                        return cashPaymentMaster;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                        
                }
            }
        }
    }
}

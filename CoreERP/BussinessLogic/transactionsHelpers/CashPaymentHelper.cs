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
        public static List<Branches> GetBranchesList()
        {
            try
            {
                using (Repository<Branches> repo = new Repository<Branches>())
                {
                    return repo.Branches.Where(m => m.Active == "Y").ToList();
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

        public static List<TblAccountLedger> GetAccountLedgers()
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

        public static string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = CashPaymentHelper.GetCashPayments().Where(b => b.BranchCode == branchCode).OrderByDescending(x => x.CashPaymentMasterId).FirstOrDefault();
                if (voucherNo != null)
                {
                    string[] splitString = voucherNo.VoucherNo.Split('-');
                    var noRange = splitString[1];
                    if (noRange.Length > 0)
                    {
                        noRange =(Convert.ToInt32(noRange) + 1).ToString();
                    }

                    return splitString[0]+"-"+noRange+"-" + splitString[2];
                }

                return "CP-1-"+ branchCode;
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

                        repo.TblCashPaymentMaster.Add(cashPaymentMaster);
                        repo.SaveChanges();

                        foreach( var item in cashPaymentMaster.CashPaymentDetails)
                        {
                            TblCashPaymentDetails cashPaymentDetails = new TblCashPaymentDetails();
                            cashPaymentDetails.CashPaymentMasterId = cashPaymentMaster.CashPaymentMasterId;
                            cashPaymentDetails.CashPaymentDetailsDate = DateTime.Now;
                            repo.TblCashPaymentDetails.Add(cashPaymentDetails);
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

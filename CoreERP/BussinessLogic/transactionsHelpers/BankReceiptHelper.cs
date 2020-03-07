using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.transactionsHelpers
{
    public class BankReceiptHelper
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
                var voucherNo = BankReceiptHelper.GetBankReceipts().Where(b => b.BranchCode == branchCode).OrderByDescending(x => x.BankReceiptMasterId).FirstOrDefault();
                if (voucherNo != null)
                {
                    string[] splitString = voucherNo.VoucherNo.Split('-');
                    var noRange = splitString[1];
                    if (noRange.Length > 0)
                    {
                        noRange = (Convert.ToInt32(noRange) + 1).ToString();
                    }

                    return splitString[0] + "-" + noRange + "-" + splitString[2];
                }

                return "BR-1-" + branchCode;
            }
            catch { throw; }
        }
    }
}

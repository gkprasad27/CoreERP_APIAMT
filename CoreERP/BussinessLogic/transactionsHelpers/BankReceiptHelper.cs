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

        public string GetVoucherNo(string branchCode)
        {
            try
            {
                
                string sufix = string.Empty, prefix = string.Empty;
                var voucherNo = new CommonHelper().GetSuffixPrefix(30, branchCode, out prefix, out sufix);

                if (voucherNo != null)
                {
                    string[] splitString = voucherNo.Split('-');
                     voucherNo = splitString[1];

                    voucherNo = (Convert.ToInt32(voucherNo) + 1).ToString();

                    voucherNo = prefix + "-" + (Convert.ToInt64(voucherNo) +1) + "-" + sufix;
                }
                else
                {
                    voucherNo = prefix + "-1-" + sufix;
                }


                new CommonHelper().UpdateInvoiceNumber(30, branchCode, voucherNo);

                return voucherNo;
            }
            catch { throw; }
        }
    }
}

using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.transactionsHelpers
{
    public class BankPaymentHelper
    {
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
        public static List<TblBankPaymentMaster> GetBankPayments()
        {
            try
            {
                using (Repository<TblBankPaymentMaster> repo = new Repository<TblBankPaymentMaster>())
                {
                    return repo.TblBankPaymentMaster.ToList();
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

                return new CommonHelper().GenerateNumber(31, branchCode);
                //string sufix = string.Empty, prefix = string.Empty;
                //var voucherNo = new CommonHelper().GetSuffixPrefix(33, branchCode, out prefix, out sufix);

                //if (voucherNo != null)
                //{
                //    string[] splitString = voucherNo.Split('-');
                //    voucherNo = splitString[1];

                //    voucherNo = (Convert.ToInt32(voucherNo) + 1).ToString();

                //    voucherNo = prefix + "-" + (Convert.ToInt64(voucherNo) + 1) + "-" + sufix;
                //}
                //else
                //{
                //    voucherNo = prefix + "-1-" + sufix;
                //}


                //new CommonHelper().UpdateInvoiceNumber(33, branchCode, voucherNo);

                //return voucherNo;
            }
            catch { throw; }
        }
    }
}

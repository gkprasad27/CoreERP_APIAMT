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
                var voucherNo = new CommonHelper().GenerateNumber(34, branchCode);
                return voucherNo;
            }
            catch { throw; }
        }

      
    }
}

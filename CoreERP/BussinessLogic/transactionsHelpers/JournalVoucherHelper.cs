using CoreERP.BussinessLogic.Common;
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
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblAccountLedger> GetAccountLedgerList()
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

        public string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = new CommonHelper().GenerateNumber(32, branchCode);
                return voucherNo;
            }
            catch { throw; }
        }

        public List<TblJournalVoucherMaster> GetJournalVoucherMasters(SearchCriteria searchCriteria)
        {
            try
            {

                using (Repository<TblJournalVoucherMaster> repo = new Repository<TblJournalVoucherMaster>())
                {
                    List<TblJournalVoucherMaster> _journalVoucherMasterList = null;


                    _journalVoucherMasterList = repo.TblJournalVoucherMaster.AsEnumerable()
                              .Where(cp =>
                                         DateTime.Parse(cp.JournalVoucherDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.JournalVoucherDate).Value.ToShortDateString())
                                       && DateTime.Parse(cp.JournalVoucherDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.JournalVoucherDate).Value.ToShortDateString())
                                 )
                               .ToList();

                    if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo))
                        _journalVoucherMasterList = _journalVoucherMasterList.Where(x => x.VoucherNo == searchCriteria.InvoiceNo).ToList();


                    return _journalVoucherMasterList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

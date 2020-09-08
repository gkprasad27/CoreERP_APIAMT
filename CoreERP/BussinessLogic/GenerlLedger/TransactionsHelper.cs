using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class TransactionsHelper
    {
        #region VoucherNumber & TransactionType

        public string GetVoucherNumber(string voucherType)
        {
            var voucerTypeNoseries = CommonHelper.GetVoucherNo(voucherType, out var startNumber, out var endNumber);

            while (true)
            {


                if (this.IsVoucherNumberExists(voucerTypeNoseries.Suffix + "-" + voucerTypeNoseries.LastNumber, voucherType))
                {
                    voucerTypeNoseries.LastNumber += 1;
                    if (voucerTypeNoseries.LastNumber > endNumber)
                        throw new Exception("No series is ended.");

                    continue;
                }
                if (voucerTypeNoseries.LastNumber == 0)
                    voucerTypeNoseries.LastNumber = startNumber;
                break;
            }

            using Repository<TblAssignmentVoucherSeriestoVoucherType> repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>();
            repo.TblAssignmentVoucherSeriestoVoucherType.Update(voucerTypeNoseries);
            repo.SaveChanges();

            return voucerTypeNoseries.Suffix + "-" + voucerTypeNoseries.LastNumber;
        }

        public bool IsVoucherNumberExists(string voucherNo, string voucherType)
        {
            switch (voucherType)
            {
                case "501":
                case "502":
                case "401":
                case "402":
                    {
                        using var repo = new Repository<TblCashBankMaster>();
                        return repo.TblCashBankMaster.Any(v => v.VoucherNumber == voucherNo);
                    }
                case "301":
                    {
                        using var repo = new Repository<TblJvmaster>();
                        return repo.TblJvmaster.Any(v => v.VoucherNumber == voucherNo);
                    }
                case "101":
                case "102":
                case "201":
                case "202":
                case "203":
                case "204":
                    {
                        using var repo = new Repository<TblInvoiceMemoHeader>();
                        return repo.TblInvoiceMemoHeader.Any(v => v.VoucherNumber == voucherNo);
                    }

                default:
                    return false;
            }
        }

        public List<string> GetTransactionType(string transactionName)
        {
            return AppManager.GetAppConfigValue(transactionName);
        }

        #endregion

        #region Cash Bank

        public bool AddCashBank(TblCashBankMaster cashBankMaster, List<TblCashBankDetails> cashBankDetails)
        {
            if (cashBankMaster.VoucherDate == null)
                throw new Exception("Voucher Date Canot be empty/null.");

            if (cashBankMaster.VoucherNumber == null)
                throw new Exception("Voucher Number Canot be empty/null.");

            if (this.IsVoucherNumberExists(cashBankMaster.VoucherNumber, cashBankMaster.VoucherType))
                throw new Exception("Voucher number exists.");

            cashBankMaster.VoucherDate ??= DateTime.Now;

            if (cashBankMaster.NatureofTransaction.ToUpper().Contains("RECEIPTS"))
                cashBankMaster.AccountingIndicator = CRDRINDICATORS.Debit.ToString();
            else if (cashBankMaster.NatureofTransaction.ToUpper().Contains("PAYMENT"))
                cashBankMaster.AccountingIndicator = CRDRINDICATORS.Credit.ToString();

            int lineno = 1;

            cashBankDetails.ForEach(x =>
            {
                x.VoucherNumber = cashBankMaster.VoucherNumber;
                x.VoucherDate = cashBankMaster.VoucherDate;
                x.Company = cashBankMaster.Company;
                x.Branch = cashBankMaster.Branch;
                x.PostingDate = cashBankMaster.PostingDate;
                x.LineItemNo = Convert.ToString(lineno++);
                x.AccountingIndicator = cashBankMaster.AccountingIndicator == CRDRINDICATORS.Debit.ToString() ? CRDRINDICATORS.Credit.ToString() : CRDRINDICATORS.Debit.ToString();
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                cashBankMaster.Status = "N";
                context.TblCashBankMaster.Add(cashBankMaster);
                context.SaveChanges();

                context.TblCashBankDetails.AddRange(cashBankDetails);
                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception)
            {
                dbtrans.Rollback();
                throw;
            }
        }

        public List<TblCashBankMaster> GetCashBankMasters(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblCashBankMaster>();
            return repo.TblCashBankMaster.AsEnumerable()
                .Where(x =>
                {
                    Debug.Assert(x.VoucherDate != null, "x.VoucherDate != null");
                    return x.Status == "N"
                           && x.VoucherNumber.Contains(searchCriteria.searchCriteria ?? x.VoucherNumber)
                           && Convert.ToDateTime(x.VoucherDate.Value) >=
                           Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                           && Convert.ToDateTime(x.VoucherDate.Value.ToShortDateString()) <=
                           Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                })
                .ToList();
        }

        public TblCashBankMaster GetCashBankMastersById(string voucherNumber)
        {
            using var repo = new Repository<TblCashBankMaster>();
            return repo.TblCashBankMaster
                .FirstOrDefault(x => x.VoucherNumber == voucherNumber);
        }

        public List<TblCashBankDetails> GetCashBankDetails(string voucherNumber)
        {
            using var repo = new Repository<TblCashBankDetails>();
            return repo.TblCashBankDetails.Where(cd => cd.VoucherNumber == voucherNumber).ToList();
        }

        public bool ReturnCashBank(string voucherNumber)
        {
            TblCashBankMaster cashBankMaster;
            List<TblCashBankDetails> cashBankDetails;
            using (var repo = new Repository<TblCashBankMaster>())
            {
                cashBankMaster = repo.TblCashBankMaster.FirstOrDefault(c => c.VoucherNumber == voucherNumber);
            }

            if (cashBankMaster == null)
                return false;
            using (var repo = new Repository<TblCashBankMaster>())
            {
                cashBankDetails = repo.TblCashBankDetails.Where(t => t.VoucherNumber == voucherNumber).ToList();
            }

            cashBankMaster.AccountingIndicator = cashBankMaster.AccountingIndicator == CRDRINDICATORS.Debit.ToString() ? CRDRINDICATORS.Credit.ToString() : CRDRINDICATORS.Debit.ToString();


            //deep copy 
            var cashBankMaster1 = (JObject.FromObject(cashBankMaster)).ToObject<TblCashBankMaster>();
            cashBankMaster1.VoucherNumber = $"{this.GetVoucherNumber(cashBankMaster1.VoucherType)}-R";

            cashBankDetails.ForEach(csh =>
            {
                csh.Id = 0;
                csh.AccountingIndicator = cashBankMaster.AccountingIndicator == CRDRINDICATORS.Debit.ToString() ? CRDRINDICATORS.Credit.ToString() : CRDRINDICATORS.Debit.ToString();
            });
            using (ERPContext context = new ERPContext())
            {
                using (var dbtrans = context.Database.BeginTransaction())
                {
                    try
                    {
                        cashBankMaster.Status = "Y";
                        context.TblCashBankMaster.Update(cashBankMaster);
                        context.SaveChanges();

                        cashBankMaster1.Status = "R";
                        context.TblCashBankMaster.Add(cashBankMaster1);
                        context.SaveChanges();

                        cashBankDetails.ForEach(csh => { csh.VoucherNumber = cashBankMaster1.VoucherNumber; });
                        context.TblCashBankDetails.AddRange(cashBankDetails);
                        context.SaveChanges();

                        dbtrans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbtrans.Rollback();
                        return false;
                    }
                }
            }
        }


        #endregion

        #region General Journels

        public bool AddJournal(TblJvmaster jvMaster, List<TblJvdetails> jvDetails)
        {
            if (jvMaster.VoucherDate == null)
                throw new Exception("Voucher Date Canot be empty/null.");

            if (jvMaster.VoucherNumber == null)
                throw new Exception("Voucher Number Canot be empty/null.");

            if (this.IsVoucherNumberExists(jvMaster.VoucherNumber, jvMaster.VoucherType))
                throw new Exception("Voucher number exists.");

            jvMaster.VoucherDate ??= DateTime.Now;
            jvMaster.TransactionType = "JV";

            int lineno = 1;

            jvDetails.ForEach(x =>
            {
                x.VoucherNumber = jvMaster.VoucherNumber;
                x.VoucherDate = Convert.ToString(jvMaster.VoucherDate);
                x.Company = jvMaster.Company;
                x.Branch = jvMaster.Branch;
                x.PostingDate = jvMaster.PostingDate;
                x.LineItemNo = Convert.ToString(lineno++);
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                jvMaster.Status = "N";
                context.TblJvmaster.Add(jvMaster);
                context.SaveChanges();

                context.TblJvdetails.AddRange(jvDetails);
                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception)
            {
                dbtrans.Rollback();
                throw;
            }
        }

        public List<TblJvmaster> GetJvMasters(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblJvmaster>();
            return repo.TblJvmaster.AsEnumerable()
                .Where(x =>
                {
                    Debug.Assert(x.VoucherDate != null, "x.VoucherDate != null");
                    return x.Status == "N"
                           && x.VoucherNumber.Contains(searchCriteria.searchCriteria ?? x.VoucherNumber)
                           && Convert.ToDateTime(x.VoucherDate.Value) >=
                           Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                           && Convert.ToDateTime(x.VoucherDate.Value.ToShortDateString()) <=
                           Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                })
                .ToList();
        }

        public TblJvmaster GetJvMastersById(string voucherNumber)
        {
            using var repo = new Repository<TblJvmaster>();
            return repo.TblJvmaster
                .FirstOrDefault(x => x.VoucherNumber == voucherNumber);
        }

        public List<TblJvdetails> GetJvDetails(string voucherNumber)
        {
            using var repo = new Repository<TblJvdetails>();
            return repo.TblJvdetails.Where(cd => cd.VoucherNumber == voucherNumber).ToList();
        }
        public bool RetuenJournalVoucher(string voucherNumber)
        {
            using var repo=new ERPContext();
            var jvmaster = repo.TblJvmaster.FirstOrDefault(x => x.VoucherNumber == voucherNumber);

            if (jvmaster?.Status == "Y")
                throw new Exception($"Journal voucher no {voucherNumber} already return.");

            if (jvmaster != null)
            {
                jvmaster.Status = "Y";
                repo.TblJvmaster.Update(jvmaster);
            }

            repo.SaveChanges();
            return true;
        }
        #endregion

        #region Invoices & Memos

        public List<TblInvoiceMemoHeader> GetImMasters(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblInvoiceMemoHeader>();
            return repo.TblInvoiceMemoHeader.AsEnumerable()
                .Where(x =>
                {
                    Debug.Assert(x.VoucherDate != null, "x.VoucherDate != null");
                    return x.Status == "N"
                           && x.VoucherNumber.Contains(searchCriteria.searchCriteria ?? x.VoucherNumber)
                           && Convert.ToDateTime(x.VoucherDate.Value) >=
                           Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                           && Convert.ToDateTime(x.VoucherDate.Value.ToShortDateString()) <=
                           Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                })
                .ToList();
        }

        public TblInvoiceMemoHeader GetImMastersById(string voucherNumber)
        {
            using var repo = new Repository<TblInvoiceMemoHeader>();
            return repo.TblInvoiceMemoHeader
                .FirstOrDefault(x => x.VoucherNumber == voucherNumber);
        }

        public List<TblInvoiceMemoDetails> GetImDetails(string voucherNumber)
        {
            using var repo = new Repository<TblInvoiceMemoDetails>();
            return repo.TblInvoiceMemoDetails.Where(cd => cd.VoucherNo == voucherNumber).ToList();
        }

        public bool AddInvoiceMemos(TblInvoiceMemoHeader imMaster, List<TblInvoiceMemoDetails> imDetails)
        {
            if (imMaster.VoucherDate == null)
                throw new Exception("Voucher Date Canot be empty/null.");

            if (imMaster.VoucherNumber == null)
                throw new Exception("Voucher Number Canot be empty/null.");

            if (this.IsVoucherNumberExists(imMaster.VoucherNumber, imMaster.VoucherType))
                throw new Exception("Voucher number exists.");

            imMaster.VoucherDate ??= DateTime.Now;
            if (imMaster.NatureofTransaction.ToUpper().Contains("INCOMING"))
                imMaster.AccountingIndicator = CRDRINDICATORS.Debit.ToString();
            else if (imMaster.NatureofTransaction.ToUpper().Contains("OUTGOING"))
                imMaster.AccountingIndicator = CRDRINDICATORS.Credit.ToString();

            int lineno = 1;

            imDetails.ForEach(x =>
            {
                x.VoucherNo = imMaster.VoucherNumber;
                x.VoucherDate = imMaster.VoucherDate;
                x.Company = imMaster.Company;
                x.Branch = imMaster.Branch;
                x.PostingDate = imMaster.PostingDate;
                x.LineItemNo = Convert.ToString(lineno++);
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                imMaster.Status = "N";
                context.TblInvoiceMemoHeader.Add(imMaster);
                context.SaveChanges();

                context.TblInvoiceMemoDetails.AddRange(imDetails);
                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception)
            {
                dbtrans.Rollback();
                throw;
            }
        }
        public bool ReturnInvoiceMemo(string voucherNumber)
        {
            using var repo=new ERPContext();
            var invoiceMemoHeader = repo.TblInvoiceMemoHeader.FirstOrDefault(im => im.VoucherNumber == voucherNumber);

            if (invoiceMemoHeader != null && invoiceMemoHeader.Status == "Y")
                throw new Exception($"Invoice memo no {voucherNumber} already return.");

            if (invoiceMemoHeader != null)
            {
                invoiceMemoHeader.Status = "Y";
                repo.TblInvoiceMemoHeader.Update(invoiceMemoHeader);
            }

            repo.SaveChanges();

            return true;
        }
        #endregion
    }
}

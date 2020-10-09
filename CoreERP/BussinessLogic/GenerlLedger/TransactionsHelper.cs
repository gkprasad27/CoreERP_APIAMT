using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class TransactionsHelper
    {
        #region VoucherNumber & TransactionType

        public string GetVoucherNumber(string voucherType)
        {
            var voucerTypeNoseries = CommonHelper.GetVoucherNo(voucherType, out var startNumber, out var endNumber);
            
            //if (voucerTypeNoseries.LastNumber != startNumber)
            //{
                voucerTypeNoseries.LastNumber += 1;
                if (voucerTypeNoseries.LastNumber > endNumber)
                    throw new Exception("No series is ended.");
            //}
            //else
            //{
            //    voucerTypeNoseries.LastNumber = startNumber;
            //    if (voucerTypeNoseries.LastNumber > endNumber)
            //        throw new Exception("No series is ended.");
            //}

            using var context = new ERPContext();
            context.TblAssignmentVoucherSeriestoVoucherType.UpdateRange(voucerTypeNoseries);
            context.SaveChanges();

            return voucerTypeNoseries.Suffix + "-" + voucerTypeNoseries.LastNumber;
        }

        public bool IsVoucherNumberExists(string voucherNo, string voucherType, [Optional] string screenName)
        {
            switch (screenName)
            {
                case "cashbank":
                    {
                        using var repo = new Repository<TblCashBankMaster>();
                        return repo.TblCashBankMaster.Any(v => v.VoucherNumber == voucherNo);
                    }
                case "journals":
                    {
                        using var repo = new Repository<TblJvmaster>();
                        return repo.TblJvmaster.Any(v => v.VoucherNumber == voucherNo);
                    }
                case "invoicesmemos":
                    {
                        using var repo = new Repository<TblInvoiceMemoHeader>();
                        return repo.TblInvoiceMemoHeader.Any(v => v.VoucherNumber == voucherNo);
                    }
                case "purchasesaleasset":
                    {
                        using var repo = new Repository<TblPosaleAssetInvoiceMemoHeader>();
                        return repo.TblPosaleAssetInvoiceMemoHeader.Any(v => v.VoucherNumber == voucherNo);
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

            if (this.IsVoucherNumberExists(cashBankMaster.VoucherNumber, cashBankMaster.VoucherType, "cashbank"))
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

            if (this.IsVoucherNumberExists(jvMaster.VoucherNumber, jvMaster.VoucherType, "journals"))
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
            using var repo = new ERPContext();
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

            if (this.IsVoucherNumberExists(imMaster.VoucherNumber, imMaster.VoucherType, "invoicesmemos"))
                throw new Exception("Voucher number exists.");

            //Add Duedate Based on PostingDate
            using var repo = new Repository<TblPaymentTermDetails>();
            //int ptDays =Convert.ToInt32( repo.TblPaymentTermDetails.Max(x => x.PaymentTermCode ==imMaster.Paymentterms).ToString());
            if (imMaster.Paymentterms != null)
            {
                int ptDays = Convert.ToInt32(repo.TblPaymentTermDetails.Where(x => x.PaymentTermCode == imMaster.Paymentterms).Max(y => y.Days).ToString());
                string addduedate = Convert.ToString(imMaster.PostingDate ??= DateTime.Now);
                imMaster.DueDate = DateTime.Parse(addduedate).AddDays(ptDays);
            }

            imMaster.VoucherDate ??= DateTime.Now;
            if (imMaster.NatureofTransaction.ToUpper().Contains("PURCHASE"))
                imMaster.AccountingIndicator = CRDRINDICATORS.Debit.ToString();
            else if (imMaster.NatureofTransaction.ToUpper().Contains("SALE"))
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
            using var repo = new ERPContext();
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

        #region Purchase Sale & Purchase

        public List<TblPosaleAssetInvoiceMemoHeader> GetPSIMAssetMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblPosaleAssetInvoiceMemoHeader>();
            return repo.TblPosaleAssetInvoiceMemoHeader.AsEnumerable()
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

        public TblPosaleAssetInvoiceMemoHeader GetPSIMAssetById(string voucherNumber)
        {
            using var repo = new Repository<TblPosaleAssetInvoiceMemoHeader>();
            return repo.TblPosaleAssetInvoiceMemoHeader
                .FirstOrDefault(x => x.VoucherNumber == voucherNumber);
        }

        public List<TblPosaleAssetInvoiceMemoDetails> GetPSIMAssetDetail(string voucherNumber)
        {
            using var repo = new Repository<TblPosaleAssetInvoiceMemoDetails>();
            return repo.TblPosaleAssetInvoiceMemoDetails.Where(cd => cd.VoucherNo == voucherNumber).ToList();
        }

        public bool AddPSIMAsset(TblPosaleAssetInvoiceMemoHeader assetMaster, List<TblPosaleAssetInvoiceMemoDetails> assetDetails)
        {
            if (assetMaster.VoucherDate == null)
                throw new Exception("Voucher Date Canot be empty/null.");

            if (assetMaster.VoucherNumber == null)
                throw new Exception("Voucher Number Canot be empty/null.");

            if (this.IsVoucherNumberExists(assetMaster.VoucherNumber, assetMaster.VoucherType, "receiptspayments"))
                throw new Exception("Voucher number exists.");

            assetMaster.VoucherDate ??= DateTime.Now;
            //if (imMaster.NatureofTransaction.ToUpper().Contains("INCOMING"))
            //    imMaster.AccountingIndicator = CRDRINDICATORS.Debit.ToString();
            //else if (imMaster.NatureofTransaction.ToUpper().Contains("OUTGOING"))
            //    imMaster.AccountingIndicator = CRDRINDICATORS.Credit.ToString();

            int lineno = 1;

            assetDetails.ForEach(x =>
            {
                x.VoucherNo = assetMaster.VoucherNumber;
                x.VoucherDate = assetMaster.VoucherDate;
                x.Company = assetMaster.Company;
                x.Branch = assetMaster.Branch;
                x.PostingDate = assetMaster.PostingDate;
                x.LineItemNo = Convert.ToString(lineno++);
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                assetMaster.Status = "N";
                context.TblPosaleAssetInvoiceMemoHeader.Add(assetMaster);
                context.SaveChanges();

                context.TblPosaleAssetInvoiceMemoDetails.AddRange(assetDetails);
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
        public bool ReturnPSIMAsset(string voucherNumber)
        {
            using var repo = new ERPContext();
            var invoiceMemoHeader = repo.TblPosaleAssetInvoiceMemoHeader.FirstOrDefault(im => im.VoucherNumber == voucherNumber);

            if (invoiceMemoHeader != null && invoiceMemoHeader.Status == "Y")
                throw new Exception($"Invoice memo no {voucherNumber} already return.");

            if (invoiceMemoHeader != null)
            {
                invoiceMemoHeader.Status = "Y";
                repo.TblPosaleAssetInvoiceMemoHeader.Update(invoiceMemoHeader);
            }

            repo.SaveChanges();

            return true;
        }
        #endregion

        #region Asset Transfer

        public List<TblAssetTransfer> GetAssetTransferMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblAssetTransfer>();
            return repo.TblAssetTransfer.AsEnumerable()
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

        public TblAssetTransfer GetAssetTransferById(string voucherNumber)
        {
            using var repo = new Repository<TblAssetTransfer>();
            return repo.TblAssetTransfer
                .FirstOrDefault(x => x.VoucherNumber == voucherNumber);
        }

        public List<TblAssetTransferDetails> GetAssetTransferDetail(string voucherNumber)
        {
            using var repo = new Repository<TblAssetTransferDetails>();
            return repo.TblAssetTransferDetails.Where(cd => cd.VoucherNumber == voucherNumber).ToList();
        }

        public bool AddAssetTransfer(TblAssetTransfer assettransferMaster, List<TblAssetTransferDetails> assettransferDetails)
        {
            if (assettransferMaster.VoucherDate == null)
                throw new Exception("Voucher Date Canot be empty/null.");

            if (assettransferMaster.VoucherNumber == null)
                throw new Exception("Voucher Number Canot be empty/null.");

            if (this.IsVoucherNumberExists(assettransferMaster.VoucherNumber, assettransferMaster.VoucherType))
                throw new Exception("Voucher number exists.");

            assettransferMaster.VoucherDate ??= DateTime.Now;

            int lineno = 1;

            assettransferDetails.ForEach(x =>
            {
                x.VoucherNumber = assettransferMaster.VoucherNumber;
                //x.voucherd = assettransferMaster.VoucherDate;
                //x.co = assettransferMaster.Company;
                //x.Branch = assettransferMaster.Branch;
                //x.PostingDate = assettransferMaster.PostingDate;
                //x.it = Convert.ToString(lineno++);
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                assettransferMaster.Status = "N";
                context.TblAssetTransfer.Add(assettransferMaster);
                context.SaveChanges();

                context.TblAssetTransferDetails.AddRange(assettransferDetails);
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

        public bool ReturnAssetTransfer(string voucherNumber)
        {
            using var repo = new ERPContext();
            var assettransferHeader = repo.TblAssetTransfer.FirstOrDefault(im => im.VoucherNumber == voucherNumber);

            if (assettransferHeader != null && assettransferHeader.Status == "Y")
                throw new Exception($"Invoice memo no {voucherNumber} already return.");

            if (assettransferHeader != null)
            {
                assettransferHeader.Status = "Y";
                repo.TblAssetTransfer.Update(assettransferHeader);
            }

            repo.SaveChanges();

            return true;
        }

        #endregion

        #region Party Cash Bank /Payments/Receipts

        public double CalculateDiscount(Dictionary<string,string> parameters)
        {
            double discount = 0;
            using var repo = new Repository<TblPaymentTermDetails>();
            var tabledata = repo.TblPaymentTermDetails
                .Where(x => x.PaymentTermCode == parameters["paymentterms"]);
            string dueDate = DateTime.Parse(parameters["dueDate"]).ToShortDateString();
            if (DateTime.Parse(dueDate) >= System.DateTime.Today)
            {
                foreach (var item in tabledata)
                {
                  string  postingDate = DateTime.Parse(parameters["postingDate"]).AddDays(Convert.ToInt32(item.Days)).ToShortDateString();
                    if (DateTime.Parse(postingDate) >= System.DateTime.Today)
                    {
                      return  discount = Convert.ToDouble(parameters["totalAmount"]) * Convert.ToDouble(item.Discount) / 100;
                    }

                }
            }

            return discount;
        }

        public List<TblPartyCashBankMaster> GetPaymentsReceiptsMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblPartyCashBankMaster>();
            return repo.TblPartyCashBankMaster.AsEnumerable()
                .Where(x =>
                {
                    Debug.Assert(x.VoucherDate != null, "x.VoucherDate != null");
                    return
                    x.VoucherNumber != null
                           && x.VoucherNumber.Contains(searchCriteria.searchCriteria ?? x.VoucherNumber)
                           && Convert.ToDateTime(x.VoucherDate.Value) >=
                           Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                           && Convert.ToDateTime(x.VoucherDate.Value.ToShortDateString()) <=
                           Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                })
                .ToList();
        }

        public TblPartyCashBankMaster GetPaymentsReceiptsById(string voucherNumber)
        {
            using var repo = new Repository<TblPartyCashBankMaster>();
            return repo.TblPartyCashBankMaster
                .FirstOrDefault(x => x.VoucherNumber == voucherNumber);
        }
        
        public List<TblParyCashBankDetails> GetPaymentsReceiptsDetail(string voucherNumber)
        {
            using var repo = new Repository<TblParyCashBankDetails>();
            return repo.TblParyCashBankDetails.Where(cd => cd.VoucherNumber == voucherNumber).ToList();
        }
        
        public bool AddPaymentsReceipts(TblPartyCashBankMaster cbmaster, List<TblParyCashBankDetails> pcbDetails)
        {
            if (cbmaster.VoucherDate == null)
                throw new Exception("Voucher Date Canot be empty/null.");

            if (cbmaster.VoucherNumber == null)
                throw new Exception("Voucher Number Canot be empty/null.");

            if (this.IsVoucherNumberExists(cbmaster.VoucherNumber, cbmaster.VoucherType))
                throw new Exception("Voucher number exists.");

            cbmaster.VoucherDate ??= DateTime.Now;

            int lineno = 1;

            pcbDetails.ForEach(x =>
            {
                x.VoucherNumber = cbmaster.VoucherNumber;
                x.VoucherDate = cbmaster.VoucherDate;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblPartyCashBankMaster.Add(cbmaster);
                context.SaveChanges();

                context.TblParyCashBankDetails.AddRange(pcbDetails);
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

        public bool ReturnPaymentsReceipts(string voucherNumber)
        {
            using var repo = new ERPContext();
            var cashpaymentHeader = repo.TblPartyCashBankMaster.FirstOrDefault(im => im.VoucherNumber == voucherNumber);

            if (cashpaymentHeader != null)
                throw new Exception($"Invoice memo no {voucherNumber} already return.");

            if (cashpaymentHeader != null)
            {
                repo.TblPartyCashBankMaster.Update(cashpaymentHeader);
            }

            repo.SaveChanges();

            return true;
        }

        #endregion

        public List<TblMaterialRequisitionMaster> GetMaterialRequisitionMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblMaterialRequisitionMaster>();
            return repo.TblMaterialRequisitionMaster.AsEnumerable().ToList();
            //.Where(x =>
            //{
            //    Debug.Assert(x.RequisitionNmber != null, "x.VoucherDate != null");
            //    return
            //    x.RequisitionNmber != null
            //           && x.RequisitionNmber.Contains(searchCriteria.searchCriteria ?? x.RequisitionNmber)
            //           && Convert.ToDateTime(x.RequisitionDate.Value) >=
            //           Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
            //           && Convert.ToDateTime(x.RequisitionDate.Value.ToShortDateString()) <=
            //           Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
            //})

        }
        public TblMaterialRequisitionMaster GetMaterialRequisitionMasterById(string reqno)
        {
            using var repo = new Repository<TblMaterialRequisitionMaster>();
            return repo.TblMaterialRequisitionMaster
                .FirstOrDefault(x => x.RequisitionNmber == reqno);
        }

        public List<TblMaterialRequisitionDetails> GetMaterialRequisitionDetails(string reqno)
        {
            using var repo = new Repository<TblMaterialRequisitionDetails>();
            return repo.TblMaterialRequisitionDetails.Where(cd => cd.RequisitionNumber == reqno).ToList();
        }

        public bool AddMaterialRequisition(TblMaterialRequisitionMaster mreqmaster, List<TblMaterialRequisitionDetails> mreqDetails)
        {

            int lineno = 1;

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblMaterialRequisitionMaster.Add(mreqmaster);
                context.SaveChanges();
                mreqDetails.ForEach(x =>
                {
                    x.RequisitionNumber = mreqmaster.RequisitionNmber;
                });
                context.TblMaterialRequisitionDetails.AddRange(mreqDetails);
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
        public bool ReturnMaterialRequisition(string RequisitionNumber)
        {
            using var repo = new ERPContext();
            var goodissueHeader = repo.TblMaterialRequisitionMaster.FirstOrDefault(im => im.RequisitionNmber == RequisitionNumber);

            if (goodissueHeader != null)
                throw new Exception($"Invoice memo no {RequisitionNumber} already return.");

            if (goodissueHeader != null)
            {
                repo.TblMaterialRequisitionMaster.Update(goodissueHeader);
            }

            repo.SaveChanges();

            return true;
        }
        public List<TblGoodsIssueMaster> GetGoodsIssueMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblGoodsIssueMaster>();
            return repo.TblGoodsIssueMaster.AsEnumerable().ToList();
            //.Where(x =>
            //{
            //    Debug.Assert(x.GoodsIssueId != null, "x.VoucherDate != null");
            //    return
            //    x.GoodsIssueId != null
            //           && x.GoodsIssueId.ToString().Contains(searchCriteria.searchCriteria ?? x.GoodsIssueId.ToString())
            //          //// && Convert.ToDateTime(x.RequisitionNumber.Value) >=
            //          //Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
            //           ///&& Convert.ToDateTime(x.RequisitionNumber.Value.ToShortDateString()) <=
            //           //Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
            //})

        }

        public TblGoodsIssueMaster GetGoodsIssueMasterById(int GoodsIssueId)
        {
            using var repo = new Repository<TblGoodsIssueMaster>();
            return repo.TblGoodsIssueMaster
                .FirstOrDefault(x => x.GoodsIssueId == GoodsIssueId);
        }

        public List<TblGoodsIssueDetails> GetGoodsIssueDetails(int GoodsIssueId)
        {
            using var repo = new Repository<TblGoodsIssueDetails>();
            return repo.TblGoodsIssueDetails.Where(cd => cd.GoodsIssueId == GoodsIssueId).ToList();
        }

        public bool AddGoodsIssue(TblGoodsIssueMaster gimaster, List<TblGoodsIssueDetails> gibDetails)
        {

            int lineno = 1;

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblGoodsIssueMaster.Add(gimaster);
                context.SaveChanges();
                gibDetails.ForEach(x =>
                {
                    x.GoodsIssueId = gimaster.GoodsIssueId;
                });
                context.TblGoodsIssueDetails.AddRange(gibDetails);
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

        public bool ReturnGoodsIssue(string RequisitionNumber)
        {
            using var repo = new ERPContext();
            var goodissueHeader = repo.TblGoodsIssueMaster.FirstOrDefault(im => im.RequisitionNumber == RequisitionNumber);

            if (goodissueHeader != null)
                throw new Exception($"Invoice memo no {RequisitionNumber} already return.");

            if (goodissueHeader != null)
            {
                repo.TblGoodsIssueMaster.Update(goodissueHeader);
            }

            repo.SaveChanges();

            return true;
        }

        #region BOM

        public bool AddBOM(TbBommaster bomMaster, List<TblBomDetails> bomDetails)
        {

            int lineno = 1;

            bomDetails.ForEach(x =>
            {
                x.BomKey = bomMaster.Bomnumber;
                //x.VoucherDate = bomMaster.VoucherDate;
                //x.Company = bomMaster.Company;
                //x.Branch = bomMaster.Branch;
                //x.PostingDate = bomMaster.PostingDate;
                //x.LineItemNo = Convert.ToString(lineno++);
                //x.AccountingIndicator = bomMaster.AccountingIndicator == CRDRINDICATORS.Debit.ToString() ? CRDRINDICATORS.Credit.ToString() : CRDRINDICATORS.Debit.ToString();
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TbBommaster.Add(bomMaster);
                context.SaveChanges();

                context.TblBomDetails.AddRange(bomDetails);
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

        public List<TbBommaster> GetBOMMasters(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TbBommaster>();
            return repo.TbBommaster.AsEnumerable().ToList();
                //.Where(x =>
                //{
                //    Debug.Assert(x.Bomnumber != null, "x.VoucherDate != null");
                //    return
                //    "x.Bomnumber != null"
                //    && x.Bomnumber.Contains(searchCriteria.searchCriteria ?? x.Bomnumber)
                //    //&& Convert.ToDateTime(x.date.Value) >=
                //    //Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                //    //&& Convert.ToDateTime(x.VoucherDate.Value.ToShortDateString()) <=
                //    //Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                //})
                //.ToList();
        }

        public TbBommaster GetBommasterById(string bomNumber)
        {
            using var repo = new Repository<TbBommaster>();
            return repo.TbBommaster
                .FirstOrDefault(x => x.Bomnumber == bomNumber);
        }

        public List<TblBomDetails> GetlBomDetails(string bomNumber)
        {
            using var repo = new Repository<TblBomDetails>();
            return repo.TblBomDetails.Where(cd => cd.BomKey == bomNumber).ToList();
        }

        public bool ReturnBommaster(string bomNumber)
        {
            TbBommaster bomMaster;
            List<TblBomDetails> bomDetails;
            using (var repo = new Repository<TbBommaster>())
            {
                bomMaster = repo.TbBommaster.FirstOrDefault(c => c.Bomnumber == bomNumber);
            }

            if (bomMaster == null)
                return false;
            using (var repo = new Repository<TbBommaster>())
            {
                bomDetails = repo.TblBomDetails.Where(t => t.BomKey == bomNumber).ToList();
            }

            ////bomMaster.AccountingIndicator = bomMaster.AccountingIndicator == CRDRINDICATORS.Debit.ToString() ? CRDRINDICATORS.Credit.ToString() : CRDRINDICATORS.Debit.ToString();


            ////deep copy 
            //var cashBankMaster1 = (JObject.FromObject(bomMaster)).ToObject<TbBommaster>();
            //cashBankMaster1.VoucherNumber = $"{this.GetVoucherNumber(cashBankMaster1.VoucherType)}-R";

            //bomDetails.ForEach(csh =>
            //{
            //    csh.Id = 0;
            //    csh.AccountingIndicator = bomMaster.AccountingIndicator == CRDRINDICATORS.Debit.ToString() ? CRDRINDICATORS.Credit.ToString() : CRDRINDICATORS.Debit.ToString();
            //});
            using (ERPContext context = new ERPContext())
            {
                using (var dbtrans = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.TbBommaster.Update(bomMaster);
                        context.SaveChanges();

                       // context.TblBomDetails.Add(bomDetails);
                        context.SaveChanges();

                        //bomDetails.ForEach(csh => { csh.VoucherNumber = cashBankMaster1.VoucherNumber; });
                        context.TblBomDetails.AddRange(bomDetails);
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

        #region WorkCenterCreation
        public bool AddWorkCenterCreation(TblWorkcenterMaster workCenterMaster, List<TblWorkCenterCapacity> workCenterCapacity, List<TblWorkcenterActivity> workCenterActivity)
        {
            if (workCenterMaster.WorkcenterCode == null)
                throw new Exception("WorkCenter Code Canot be empty/null.");
            
            using var repo = new Repository<TblWorkcenterMaster>();
           
            if(repo.TblWorkcenterMaster.Any(v => v.WorkcenterCode == workCenterMaster.WorkcenterCode))
                throw new Exception("Voucher number exists.");

            workCenterCapacity.ForEach(x =>
            {
                
            });

            workCenterActivity.ForEach(x =>
            {

            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblWorkcenterMaster.Add(workCenterMaster);
                context.SaveChanges();

                context.TblWorkCenterCapacity.AddRange(workCenterCapacity);
                context.SaveChanges();

                context.TblWorkcenterActivity.AddRange(workCenterActivity);
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
        #endregion
    }
}

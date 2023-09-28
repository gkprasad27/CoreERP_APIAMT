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
            if (voucerTypeNoseries != null)
            {
                voucerTypeNoseries.LastNumber += 1;

                if (voucerTypeNoseries.LastNumber > endNumber)
                    throw new Exception("No series is ended.");


                using var context = new ERPContext();
                context.TblAssignmentVoucherSeriestoVoucherType.UpdateRange(voucerTypeNoseries);
                context.SaveChanges();

                return voucerTypeNoseries.Suffix + "-" + voucerTypeNoseries.LastNumber;
            }
            else
                throw new Exception( "Please Configure Voucher Number");
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
                case "SaleOrder":
                    {
                        using var repo = new Repository<TblSaleOrderMaster>();
                        return repo.TblSaleOrderMaster.Any(v => v.PONumber == voucherNo);
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
                throw new Exception("WorkCenter Already exists.");

            workCenterCapacity.ForEach(x =>
            {
                x.WorkCenterCode = workCenterMaster.WorkcenterCode;
            });

            workCenterActivity.ForEach(x =>
            {
                x.WorkcenterCode = workCenterMaster.WorkcenterCode;
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

        #region RoutingFile
        public bool AddRoutingFile(TblRoutingMasterData routemasterdata, List<TblRoutingBasicData> routebasicdata,
            List<TblRoutingMaterialAssignment> materialassignment, List<TblRoutingActiitiesAssignment> routeactiitiesAssignments,
             List<TblRoutingToolsEqupments> toolsequpments)
        {
            if (routemasterdata.RoutingKey == null)
                throw new Exception("WorkCenter Code Canot be empty/null.");

            using var repo = new Repository<TblRoutingMasterData>();

            if (repo.TblRoutingMasterData.Any(v => v.RoutingKey == routemasterdata.RoutingKey))
                throw new Exception("RoutingKey number exists.");

            routebasicdata.ForEach(x =>
            {
                x.RoutingKey = routemasterdata.RoutingKey;
            });

            materialassignment.ForEach(x =>
            {
                x.RoutingKey = routemasterdata.RoutingKey;
            });
            routeactiitiesAssignments.ForEach(x =>
            {
                x.RoutingKey = routemasterdata.RoutingKey;
            });
            toolsequpments.ForEach(x =>
            {
                x.RoutingKey = routemasterdata.RoutingKey;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblRoutingMasterData.Add(routemasterdata);
                context.SaveChanges();

                context.TblRoutingBasicData.AddRange(routebasicdata);
                context.SaveChanges();

                context.TblRoutingMaterialAssignment.AddRange(materialassignment);
                context.SaveChanges();

                context.TblRoutingActiitiesAssignment.AddRange(routeactiitiesAssignments);
                context.SaveChanges();

                context.TblRoutingToolsEqupments.AddRange(toolsequpments);
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
        public TblRoutingMasterData GetRoutingMasterById(string id)
        {
            using var repo = new Repository<TblRoutingMasterData>();
            return repo.TblRoutingMasterData
                .FirstOrDefault(x => x.RoutingKey == id);
        }

        public List<TblRoutingBasicData> GetRoutingBasicDataDetails(string routekey)
        {
            using var repo = new Repository<TblRoutingBasicData>();
            return repo.TblRoutingBasicData.Where(cd => cd.RoutingKey == routekey).ToList();
        }
        public List<TblRoutingMaterialAssignment> GetRoutingMaterialAssignmentDetails(string routekey)
        {
            using var repo = new Repository<TblRoutingMaterialAssignment>();
            return repo.TblRoutingMaterialAssignment.Where(cd => cd.RoutingKey == routekey).ToList();
        }
        public List<TblRoutingActiitiesAssignment> GetRoutingActiitiesAssignmentDetails(string routekey)
        {
            using var repo = new Repository<TblRoutingActiitiesAssignment>();
            return repo.TblRoutingActiitiesAssignment.Where(cd => cd.RoutingKey == routekey).ToList();
        }
        public List<TblRoutingToolsEqupments> GetRoutingToolsEqupmentsDetails(string routekey)
        {
            using var repo = new Repository<TblRoutingToolsEqupments>();
            return repo.TblRoutingToolsEqupments.Where(cd => cd.RoutingKey == routekey).ToList();
        }
        #endregion

        #region Task
        public bool AddRegisterTasks(TblTaskMaster taskmasterdata, List<TblTaskResources> resourcedata)

        {
            if (taskmasterdata.TaskNumber == null)
                throw new Exception("Task Number Code Canot be empty/null.");

            using var repo = new Repository<TblTaskMaster>();

            if (repo.TblTaskMaster.Any(v => v.TaskNumber == taskmasterdata.TaskNumber))
                throw new Exception("TaskNumber number exists.");

            resourcedata.ForEach(x =>
            {
                x.TaskNumber = taskmasterdata.TaskNumber;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblTaskMaster.Add(taskmasterdata);
                context.SaveChanges();

                context.TblTaskResources.AddRange(resourcedata);
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
        public TblTaskMaster GetTaskMasterById(string id)
        {
            using var repo = new Repository<TblTaskMaster>();
            return repo.TblTaskMaster
                .FirstOrDefault(x => x.TaskNumber == id);
        }

        public List<TblTaskResources> GetTaskResourcesDataDetails(string number)
        {
            using var repo = new Repository<TblTaskResources>();
            return repo.TblTaskResources.Where(cd => cd.TaskNumber == number).ToList();
        }

        #endregion

        #region Purchase Requisition

        public List<TblPurchaseRequisitionMaster> GetPurchaseRequisitionMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblPurchaseRequisitionMaster>();
            return repo.TblPurchaseRequisitionMaster.AsEnumerable()
                .Where(x =>
                {
                    Debug.Assert(x.RequisitionDate != null, "x.RequisitionDate != null");
                    return
                    x.RequisitionNumber != null
                           && x.RequisitionNumber.Contains(searchCriteria.searchCriteria ?? x.RequisitionNumber)
                           && Convert.ToDateTime(x.RequisitionDate.Value) >=
                           Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                           && Convert.ToDateTime(x.RequisitionDate.Value.ToShortDateString()) <=
                           Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                })
                .ToList();
        }
        public bool AddPurchaseRequisitionMaster(TblPurchaseRequisitionMaster reqmasterdata, List<TblPurchaseRequisitionDetails> reqdetails)

        {
            if (reqmasterdata.RequisitionNumber == null)
                throw new Exception("Requisition Number Code Canot be empty/null.");

            using var repo = new Repository<TblPurchaseRequisitionMaster>();

            if (repo.TblPurchaseRequisitionMaster.Any(v => v.RequisitionNumber == reqmasterdata.RequisitionNumber))
                throw new Exception("Requisition Number  exists.");

            reqdetails.ForEach(x =>
            {
                x.PurchaseRequisitionNumber = reqmasterdata.RequisitionNumber;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblPurchaseRequisitionMaster.Add(reqmasterdata);
                context.SaveChanges();

                context.TblPurchaseRequisitionDetails.AddRange(reqdetails);
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
        public TblPurchaseRequisitionMaster GetPurchaseRequisitionMasterById(string id)
        {
            using var repo = new Repository<TblPurchaseRequisitionMaster>();
            return repo.TblPurchaseRequisitionMaster
                .FirstOrDefault(x => x.RequisitionNumber == id);
        }
        public List<TblPurchaseRequisitionDetails> GetPurchaseRequisitionDetails(string number)
        {
            using var repo = new Repository<TblPurchaseRequisitionDetails>();
            return repo.TblPurchaseRequisitionDetails.Where(cd => cd.PurchaseRequisitionNumber == number).ToList();
        }

        public bool ReturnPurchaseRequisition(string RequisitionNumber)
        {
            using var repo = new ERPContext();
            var preqHeader = repo.TblPurchaseRequisitionMaster.FirstOrDefault(im => im.RequisitionNumber == RequisitionNumber);

            if (preqHeader != null)
                throw new Exception($"Invoice memo no {RequisitionNumber} already return.");

            if (preqHeader != null)
            {
                repo.TblPurchaseRequisitionMaster.Update(preqHeader);
            }

            repo.SaveChanges();

            return true;
        }

        #endregion

        #region Source Supply

        public List<TblMaterialSupplierMaster> GetMaterialSupplierMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblMaterialSupplierMaster>();
            return repo.TblMaterialSupplierMaster.AsEnumerable().ToList();
        }
        public bool AddMaterialSupplierMaster(TblMaterialSupplierMaster msdata, List<TblMaterialSupplierDetails> msdetails)

        {
            if (msdata.SupplierCode == null)
                throw new Exception("Supplier Code Canot be empty/null.");

            using var repo = new Repository<TblMaterialSupplierMaster>();

            if (repo.TblMaterialSupplierMaster.Any(v => v.SupplierCode == msdata.SupplierCode))
                throw new Exception("Supplier Code  exists.");

            msdetails.ForEach(x =>
            {
                x.SupplierCode = msdata.SupplierCode;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblMaterialSupplierMaster.Add(msdata);
                context.SaveChanges();

                context.TblMaterialSupplierDetails.AddRange(msdetails);
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
        public TblMaterialSupplierMaster GetMaterialSupplierMasterById(string id)
        {
            using var repo = new Repository<TblMaterialSupplierMaster>();
            return repo.TblMaterialSupplierMaster
                .FirstOrDefault(x => x.SupplierCode == id);
        }
        public List<TblMaterialSupplierDetails> GetMaterialSupplierDetails(string number)
        {
            using var repo = new Repository<TblMaterialSupplierDetails>();
            return repo.TblMaterialSupplierDetails.Where(cd => cd.SupplierCode == number).ToList();
        }
        public bool ReturnMaterialSupplier(string code)
        {
            using var repo = new ERPContext();
            var preqHeader = repo.TblMaterialSupplierMaster.FirstOrDefault(im => im.SupplierCode == code);

            if (preqHeader != null)
                throw new Exception($"Invoice memo no {code} already return.");

            if (preqHeader != null)
            {
                repo.TblMaterialSupplierMaster.Update(preqHeader);
            }

            repo.SaveChanges();

            return true;
        }

        #endregion

        #region Quotation Supplier

        public List<TblSupplierQuotationsMaster> GetSupplierQuotationsMasterr(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblSupplierQuotationsMaster>();
            return repo.TblSupplierQuotationsMaster.AsEnumerable().ToList();
        }
        public bool AddSupplierQuotationsMaster(TblSupplierQuotationsMaster msdata, List<TblSupplierQuotationDetails> qsdetails)

        {
            if (msdata.QuotationNumber == null)
                throw new Exception("Supplier Code Canot be empty/null.");

            using var repo = new Repository<TblSupplierQuotationsMaster>();

            if (repo.TblSupplierQuotationsMaster.Any(v => v.QuotationNumber == msdata.QuotationNumber))
                throw new Exception("Quotation Number  exists.");

            qsdetails.ForEach(x =>
            {
                x.QuotationNumber = msdata.QuotationNumber;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblSupplierQuotationsMaster.Add(msdata);
                context.SaveChanges();

                context.TblSupplierQuotationDetails.AddRange(qsdetails);
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
        public TblSupplierQuotationsMaster GetSupplierQuotationsMasterById(string id)
        {
            using var repo = new Repository<TblSupplierQuotationsMaster>();
            return repo.TblSupplierQuotationsMaster
                .FirstOrDefault(x => x.QuotationNumber == id);
        }
        public List<TblSupplierQuotationDetails> GetSupplierQuotationDetails(string number)
        {
            using var repo = new Repository<TblSupplierQuotationDetails>();
            return repo.TblSupplierQuotationDetails.Where(cd => cd.QuotationNumber == number).ToList();
        }
        public bool ReturnSupplierQuotationDetails(string code)
        {
            using var repo = new ERPContext();
            var preqHeader = repo.TblSupplierQuotationsMaster.FirstOrDefault(im => im.QuotationNumber == code);

            if (preqHeader != null)
                throw new Exception($"Supplier Quotation memo no {code} already return.");

            if (preqHeader != null)
            {
                repo.TblSupplierQuotationsMaster.Update(preqHeader);
            }

            repo.SaveChanges();

            return true;
        }

        #endregion

        #region QuotationAnalysis
        public List<TblQuotationAnalysis> GetQuotationAnalysis(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblQuotationAnalysis>();
            return repo.TblQuotationAnalysis.AsEnumerable().ToList();
        }
        public bool AddQuotationAnalysis(TblQuotationAnalysis qadata, List<TblQuotationAnalysisDetails> qadetails)

        {
            if (qadata.QuotationNumber == null)
                throw new Exception("Quotation Number Code Canot be empty/null.");

            using var repo = new Repository<TblQuotationAnalysis>();

            if (repo.TblQuotationAnalysis.Any(v => v.QuotationNumber == qadata.QuotationNumber))
                throw new Exception("Quotation Number  exists.");

            qadetails.ForEach(x =>
            {
                x.QuotationNumber = qadata.QuotationNumber;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblQuotationAnalysis.Add(qadata);
                context.SaveChanges();

                context.TblQuotationAnalysisDetails.AddRange(qadetails);
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
        public TblQuotationAnalysis GetQuotationAnalysisMasterById(string id)
        {
            using var repo = new Repository<TblQuotationAnalysis>();
            return repo.TblQuotationAnalysis
                .FirstOrDefault(x => x.QuotationNumber == id);
        }
        public List<TblQuotationAnalysisDetails> GetQuotationAnalysisDetails(string number)
        {
            using var repo = new Repository<TblQuotationAnalysisDetails>();
            return repo.TblQuotationAnalysisDetails.Where(cd => cd.QuotationNumber == number).ToList();
        }
        public bool ReturnQuotationAnalysisDetails(string code)
        {
            using var repo = new ERPContext();
            var preqHeader = repo.TblQuotationAnalysis.FirstOrDefault(im => im.QuotationNumber == code);

            if (preqHeader != null)
                throw new Exception($"Analysis Quotation memo no {code} already return.");

            if (preqHeader != null)
            {
                repo.TblQuotationAnalysis.Update(preqHeader);
            }

            repo.SaveChanges();

            return true;
        }
        #endregion

        #region PurchaseOrder
        public List<TblPurchaseOrder> GetPurchaseOrder(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblPurchaseOrder>();
            return repo.TblPurchaseOrder.AsEnumerable().ToList();
        }
        public bool AddPurchaseOrder(TblPurchaseOrder podata, List<TblPurchaseOrderDetails> podetails)

        {
            if (podata.PurchaseOrderNumber == null)
                throw new Exception("PurchaseOrder NumberCanot be empty/null.");

            using var repo = new Repository<TblPurchaseOrder>();

            if (repo.TblPurchaseOrder.Any(v => v.PurchaseOrderNumber == podata.PurchaseOrderNumber))
                throw new Exception("PurchaseOrder Number exists.");

            podetails.ForEach(x =>
            {
                x.PurchaseOrderNumber = podata.PurchaseOrderNumber;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblPurchaseOrder.Add(podata);
                context.SaveChanges();

                context.TblPurchaseOrderDetails.AddRange(podetails);
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
        public TblPurchaseOrder GetPurchaseOrderMasterById(string id)
        {
            using var repo = new Repository<TblPurchaseOrder>();
            return repo.TblPurchaseOrder
                .FirstOrDefault(x => x.PurchaseOrderNumber == id);
        }
        public List<TblPurchaseOrderDetails> GetPurchaseOrderDetails(string number)
        {
            using var repo = new Repository<TblPurchaseOrderDetails>();
            return repo.TblPurchaseOrderDetails.Where(cd => cd.PurchaseOrderNumber == number).ToList();
        }
        public bool ReturnPurchaseOrderDetails(string code)
        {
            using var repo = new ERPContext();
            var poHeader = repo.TblPurchaseOrder.FirstOrDefault(im => im.PurchaseOrderNumber == code);

            if (poHeader != null)
                throw new Exception($"Analysis PurchaseOrderNumber memo no {code} already return.");

            if (poHeader != null)
            {
                repo.TblPurchaseOrder.Update(poHeader);
            }

            repo.SaveChanges();

            return true;
        }
        #endregion

        #region GoodsReceipt
        public List<TblGoodsReceiptMaster> GetGoodsReceiptMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblGoodsReceiptMaster>();
            return repo.TblGoodsReceiptMaster.AsEnumerable().ToList();
        }
        public bool AddGoodsReceipt(TblGoodsReceiptMaster grdata, List<TblGoodsReceiptDetails> grdetails)

        {
            if (grdata.PurchaseOrderNo == null)
                throw new Exception("PurchaseOrder NumberCanot be empty/null.");

            using var repo = new Repository<TblGoodsReceiptMaster>();

            if (repo.TblGoodsReceiptMaster.Any(v => v.PurchaseOrderNo == grdata.PurchaseOrderNo))
                throw new Exception("PurchaseOrder Number exists.");
            

            grdetails.ForEach(x =>
            {
                x.PurchaseOrderNo = grdata.PurchaseOrderNo;
               
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                grdata.ReceiptDate = DateTime.Now;
                context.TblGoodsReceiptMaster.Add(grdata);
                context.SaveChanges();
                foreach(var item in grdetails)
                {
                    TblLotSeries lotseries = new TblLotSeries();
                    lotseries.CurrentLot =Convert.ToInt32(item.LotNo);
                    //context.TblLotSeries.UpdateRange(lotseries);
                    //context.SaveChanges();
                }
                
                context.TblGoodsReceiptDetails.AddRange(grdetails);
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
        public TblGoodsReceiptMaster GetGoodsReceiptMasterById(string id)
        {
            using var repo = new Repository<TblGoodsReceiptMaster>();
            return repo.TblGoodsReceiptMaster
                .FirstOrDefault(x => x.PurchaseOrderNo == id);
        }
        public List<TblGoodsReceiptDetails> GetGoodsReceiptDetails(string number)
        {
            using var repo = new Repository<TblGoodsReceiptDetails>();
            return repo.TblGoodsReceiptDetails.Where(cd => cd.PurchaseOrderNo == number).ToList();
        }
        public bool ReturnGoodsReceiptMaster(string code)
        {
            using var repo = new ERPContext();
            var poHeader = repo.TblGoodsReceiptMaster.FirstOrDefault(im => im.PurchaseOrderNo == code);

            if (poHeader != null)
                throw new Exception($"Analysis PurchaseOrderNumber memo no {code} already return.");

            if (poHeader != null)
            {
                repo.TblGoodsReceiptMaster.Update(poHeader);
            }

            repo.SaveChanges();

            return true;
        }
        #endregion

        #region InspectionCheck
        public List<TblInpectionCheckMaster> GetInpectionCheckMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblInpectionCheckMaster>();
            return repo.TblInpectionCheckMaster.AsEnumerable().ToList();
        }
        public bool AddInpectionCheck(TblInpectionCheckMaster icdata, List<TblInspectionCheckDetails> icdetails)

        {
            if (icdata.InspectionCheckNo == null)
                throw new Exception("InspectionCheckNo Canot be empty/null.");

            using var repo = new Repository<TblInpectionCheckMaster>();

            if (repo.TblInpectionCheckMaster.Any(v => v.InspectionCheckNo == icdata.InspectionCheckNo))
                throw new Exception("Inspection CheckNo exists.");

            icdetails.ForEach(x =>
            {
                x.InspectionCheckNo = icdata.InspectionCheckNo;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblInpectionCheckMaster.Add(icdata);
                context.SaveChanges();

                context.TblInspectionCheckDetails.AddRange(icdetails);
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
        public TblInpectionCheckMaster GetInpectionCheckMasterById(string id)
        {
            using var repo = new Repository<TblInpectionCheckMaster>();
            return repo.TblInpectionCheckMaster
                .FirstOrDefault(x => x.InspectionCheckNo == id);
        }
        public List<TblInspectionCheckDetails> GetInspectionCheckDetails(string number)
        {
            using var repo = new Repository<TblInspectionCheckDetails>();
            return repo.TblInspectionCheckDetails.Where(cd => cd.InspectionCheckNo == number).ToList();
        }
        public bool ReturnInpectionCheckMaster(string code)
        {
            using var repo = new ERPContext();
            var poHeader = repo.TblInpectionCheckMaster.FirstOrDefault(im => im.InspectionCheckNo == code);

            if (poHeader != null)
                throw new Exception($"Analysis Inspection CheckNo memo no {code} already return.");

            if (poHeader != null)
            {
                repo.TblInpectionCheckMaster.Update(poHeader);
            }

            repo.SaveChanges();

            return true;
        }
        #endregion

        #region Invoice verification
        public List<TblInvoiceVerificationMaster> GetInvoiceVerificationMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblInvoiceVerificationMaster>();
            return repo.TblInvoiceVerificationMaster.AsEnumerable().ToList();
        }

        public bool AddInvoiceVerification(TblInvoiceVerificationMaster invoicedata, List<TblInvoiceVerificationDetails> ivdetails, List<TblInvoiceVerificationOtherExpenses> ioedetails)

        {
            if (invoicedata.PurchaseOrderNo == null)
                throw new Exception("Purchase OrderNo Canot be empty/null.");

            using var repo = new Repository<TblInvoiceVerificationMaster>();

            if (repo.TblInvoiceVerificationMaster.Any(v => v.PurchaseOrderNo == invoicedata.PurchaseOrderNo))
                throw new Exception("Purchase OrderNo  exists.");

            ivdetails.ForEach(x =>
            {
                x.PurchaseOrderNo = invoicedata.PurchaseOrderNo;
            });
            ioedetails.ForEach(x =>
            {
                x.PurchaseOrderNo = invoicedata.PurchaseOrderNo;
            });

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                context.TblInvoiceVerificationMaster.Add(invoicedata);
                context.SaveChanges();

                context.TblInvoiceVerificationDetails.AddRange(ivdetails);
                context.SaveChanges();

                context.TblInvoiceVerificationOtherExpenses.AddRange(ioedetails);
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
        public TblInvoiceVerificationMaster GetInvoiceVerificationMasterById(string id)
        {
            using var repo = new Repository<TblInvoiceVerificationMaster>();
            return repo.TblInvoiceVerificationMaster
                .FirstOrDefault(x => x.PurchaseOrderNo == id);
        }
        public List<TblInvoiceVerificationDetails> GetInvoiceVerificationDetails(string number)
        {
            using var repo = new Repository<TblInvoiceVerificationDetails>();
            return repo.TblInvoiceVerificationDetails.Where(cd => cd.PurchaseOrderNo == number).ToList();
        }
        public List<TblInvoiceVerificationOtherExpenses> GetInvoiceVerificationOtherExpensesDetails(string number)
        {
            using var repo = new Repository<TblInvoiceVerificationOtherExpenses>();
            return repo.TblInvoiceVerificationOtherExpenses.Where(cd => cd.PurchaseOrderNo == number).ToList();
        }
        public List<TblInvoiceVerificationMaster> GetInvoiceVerificationMaster()
        {
            using var repo = new Repository<TblInvoiceVerificationMaster>();
            return repo.TblInvoiceVerificationMaster.ToList();
        }
        public bool ReturnInvoiceVerification(string code)
        {
            using var repo = new ERPContext();
            var poHeader = repo.TblInvoiceVerificationMaster.FirstOrDefault(im => im.PurchaseOrderNo == code);

            if (poHeader != null)
                throw new Exception($"Analysis PurchaseOrderNo memo no {code} already return.");

            if (poHeader != null)
            {
                repo.TblInvoiceVerificationMaster.Update(poHeader);
            }

            repo.SaveChanges();

            return true;
        }
        #endregion

        #region Sale Order

        public List<TblSaleOrderMaster> GetSaleOrderMasters(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-30), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-30);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblSaleOrderMaster>();
            return repo.TblSaleOrderMaster.AsEnumerable()
                .Where(x =>
                {

                    //Debug.Assert(x.CreatedDate != null, "x.CreatedDate != null");
                 return  Convert.ToString( x.SaleOrderNo) != null
                           && Convert.ToString(x.SaleOrderNo).Contains(searchCriteria.searchCriteria ?? Convert.ToString(x.SaleOrderNo))
                           && Convert.ToDateTime(x.CreatedDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                           && Convert.ToDateTime(x.CreatedDate.Value.ToShortDateString()) <= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                }).OrderByDescending(x => x.SaleOrderNo)
                .ToList();
        }

        public TblSaleOrderMaster GetSaleOrderMastersById(int saleOrderNo)
        {
            using var repo = new Repository<TblSaleOrderMaster>();
            return repo.TblSaleOrderMaster
                .FirstOrDefault(x => x.SaleOrderNo == saleOrderNo);
        }

        public List<TblSaleOrderDetail> GetSaleOrdersDetails(int saleOrderNo)
        {
            using var repo = new Repository<TblSaleOrderDetail>();
            return repo.TblSaleOrderDetail.Where(cd => cd.SaleOrderNo == saleOrderNo).ToList();
        }
        public bool AddSaleOrder(TblSaleOrderMaster saleOrderMaster, List<TblSaleOrderDetail> saleOrderDetails)
        {
            if (saleOrderMaster.OrderDate == null)
                throw new Exception("Sale Order Date Canot be empty/null.");

            
            if (this.IsVoucherNumberExists(saleOrderMaster.PONumber, "SaleOrder"))
                throw new Exception("Po number exists.");

            saleOrderMaster.CreatedDate ??= DateTime.Now;

            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                saleOrderMaster.Status = "Created";
                context.TblSaleOrderMaster.Add(saleOrderMaster);
                context.SaveChanges();

                saleOrderDetails.ForEach(x =>
                {
                    x.SaleOrderNo = saleOrderMaster.SaleOrderNo;
                });
                context.TblSaleOrderDetail.AddRange(saleOrderDetails);
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

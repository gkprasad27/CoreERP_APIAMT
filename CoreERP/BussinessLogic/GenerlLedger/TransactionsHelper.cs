using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;

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
                throw new Exception("Please Configure Voucher Number");
        }

        public string GetSaleOrderNumber(string ProfitCenter)
        {
            using var repo = new Repository<ProfitCenters>();
            var Pcenter = repo.ProfitCenters.Where(x => x.Code == ProfitCenter).FirstOrDefault();

            //if (voucerTypeNoseries.LastNumber != startNumber)
            //{
            if (Pcenter != null)
            {
                Pcenter.SONumber = (Pcenter.SONumber + 1);

                using var context = new ERPContext();
                context.ProfitCenters.UpdateRange(Pcenter);
                context.SaveChanges();

                return Pcenter.SOPrefix + "-" + Pcenter.SONumber;
            }
            else
                throw new Exception("Please Configure SaleOrder Number");
        }

        public string GetPurchaseOrderNumber(string ProfitCenter)
        {
            using var repo = new Repository<ProfitCenters>();
            var Pcenter = repo.ProfitCenters.Where(x => x.Code == ProfitCenter).FirstOrDefault();

            //if (voucerTypeNoseries.LastNumber != startNumber)
            //{
            if (Pcenter != null)
            {
                Pcenter.PONumber = (Pcenter.PONumber + 1);

                using var context = new ERPContext();
                context.ProfitCenters.UpdateRange(Pcenter);
                context.SaveChanges();

                return Pcenter.POPrefix + "-" + Pcenter.PONumber;
            }
            else
                throw new Exception("Please Configure Purchase Order Number");
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
            using (ERPContext context = new())
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

        public double CalculateDiscount(Dictionary<string, string> parameters)
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
                    string postingDate = DateTime.Parse(parameters["postingDate"]).AddDays(Convert.ToInt32(item.Days)).ToShortDateString();
                    if (DateTime.Parse(postingDate) >= System.DateTime.Today)
                    {
                        return discount = Convert.ToDouble(parameters["totalAmount"]) * Convert.ToDouble(item.Discount) / 100;
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
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-100), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-100);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblGoodsIssueMaster>();

            var Company = repo.TblCompany.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var Employee = repo.TblEmployee.ToList();
            var FunctionalDepartment = repo.TblFunctionalDepartment.ToList();
            repo.TblGoodsIssueMaster.ToList()
                .ForEach(c =>
                {
                    c.CompanyName = Company.FirstOrDefault(l => l.CompanyCode == c.Company).CompanyName;
                    c.ProfitcenterName = profitCenters.FirstOrDefault(p => p.Code == c.ProfitCenter).Name;
                    c.DepartmentName = FunctionalDepartment.FirstOrDefault(f => f.Code == c.Department).Description;
                    c.StoresPersonName = Employee.FirstOrDefault(f => f.EmployeeCode == c.StoresPerson).EmployeeName;
                    c.ProductionPersonName = Employee.FirstOrDefault(f => f.EmployeeCode == c.ProductionPerson).EmployeeName;
                });


            return repo.TblGoodsIssueMaster.AsEnumerable().Where(x =>
            {
                Debug.Assert(x.GoodsIssueId != null, "x.VoucherDate != null");
                return
                x.GoodsIssueId != null
                       && x.GoodsIssueId.ToString().Contains(searchCriteria.searchCriteria ?? x.GoodsIssueId.ToString())
                       && Convert.ToDateTime(x.AddDate) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                && Convert.ToDateTime(x.AddDate.Value.ToShortDateString()) <= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
            }).ToList();

        }

        public List<TblProductionMaster> GetProductionIssueMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-100), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-100);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblProductionMaster>();

            var Company = repo.TblCompany.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            repo.TblProductionMaster.ToList()
                .ForEach(c =>
                {
                    c.CompanyName = Company.FirstOrDefault(l => l.CompanyCode == c.Company).CompanyName;
                    c.ProfitcenterName = profitCenters.FirstOrDefault(p => p.Code == c.ProfitCenter).Name;
                });
            return repo.TblProductionMaster.AsEnumerable()
                .Where(x =>
                {

                    //Debug.Assert(x.CreatedDate != null, "x.CreatedDate != null");
                    return Convert.ToString(x.ID) != null
                              && Convert.ToString(x.ID).Contains(searchCriteria.searchCriteria ?? Convert.ToString(x.ID))
                              && Convert.ToDateTime(x.AddDate) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                              && Convert.ToDateTime(x.AddDate.Value.ToShortDateString()) <= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                }).OrderByDescending(x => x.ID)
                .ToList();


        }

        public TblGoodsIssueMaster GetGoodsIssueMasterById(string GoodsIssueId)
        {
            using var repo = new Repository<TblGoodsIssueMaster>();
            return repo.TblGoodsIssueMaster
                .FirstOrDefault(x => x.SaleOrderNumber == GoodsIssueId);
        }

        public TblProductionMaster GetTagsIssueMasterById(string GoodsIssueId)
        {
            using var repo = new Repository<TblGoodsIssueMaster>();
            return repo.TblProductionMaster
                .FirstOrDefault(x => x.SaleOrderNumber == GoodsIssueId);
        }

        public TblInspectionCheckMaster GetQcIssueMasterById(string GoodsIssueId, string Materialcode)
        {
            using var repo = new Repository<TblInspectionCheckMaster>();
            return repo.TblInspectionCheckMaster
                .FirstOrDefault(x => x.saleOrderNumber == GoodsIssueId && x.MaterialCode == Materialcode);
        }

        public List<TblGoodsIssueDetails> GetGoodsIssueDetails(string GoodsIssueId)
        {
            using var repo = new Repository<TblGoodsIssueDetails>();

            var material = repo.TblMaterialMaster.ToList();

            repo.TblGoodsIssueDetails.ToList().ForEach(c =>
               {
                   c.MaterialName = material.FirstOrDefault(l => l.MaterialCode == c.MaterialCode)?.Description;
               });
            return repo.TblGoodsIssueDetails.Where(cd => cd.SaleOrderNumber == GoodsIssueId).ToList();

        }

        public List<TblProductionDetails> GetTagsIssueDetails(string GoodsIssueId, string Materialcode)
        {
            using var repo = new ERPContext();
            var material = new List<TblMaterialMaster>();
            var tblProduction = new List<TblProductionDetails>();

            if (!string.IsNullOrEmpty(Materialcode))
            {
                tblProduction = repo.TblProductionDetails.Where(cd => cd.SaleOrderNumber == GoodsIssueId && cd.MaterialCode == Materialcode).ToList();
                material = repo.TblMaterialMaster.Where(cd => cd.MaterialCode == Materialcode).ToList();
            }
            else
            {
                tblProduction = repo.TblProductionDetails.Where(cd => cd.SaleOrderNumber == GoodsIssueId).ToList();
                material = repo.TblMaterialMaster.ToList();
            }

            repo.TblProductionDetails.ToList().ForEach(c =>
        {
            foreach (var item in tblProduction)
            {
                c.MaterialName = material.FirstOrDefault(l => l.MaterialCode == item.MaterialCode)?.Description;
            }
        });


            return tblProduction.ToList();

        }

        public List<TblProductionStatus> GetProductionStatus(string GoodsIssueId, string Materialcode, string gstag)
        {
            using var repo = new ERPContext();
            var tblProduction = new List<TblProductionStatus>();

            tblProduction = repo.TblProductionStatus.Where(cd => cd.SaleOrderNumber == GoodsIssueId && cd.MaterialCode == Materialcode && cd.ProductionTag == gstag).ToList();

            return tblProduction.ToList();

        }

        public List<TblInspectionCheckDetails> GetQcIssueDetails(string GoodsIssueId, string Materialcode)
        {
            using var repo = new ERPContext();
            var material = new List<TblMaterialMaster>();
            var tblProduction = new List<TblInspectionCheckDetails>();

            if (!string.IsNullOrEmpty(Materialcode))
            {
                tblProduction = repo.TblInspectionCheckDetails.Where(cd => cd.saleOrderNumber == GoodsIssueId && cd.MaterialCode == Materialcode).ToList();
                material = repo.TblMaterialMaster.Where(cd => cd.MaterialCode == Materialcode).ToList();
            }
            else
            {
                tblProduction = repo.TblInspectionCheckDetails.Where(cd => cd.saleOrderNumber == GoodsIssueId).ToList();
                material = repo.TblMaterialMaster.ToList();
            }

            repo.TblInspectionCheckDetails.ToList().ForEach(c =>
            {
                foreach (var item in tblProduction)
                {
                    c.MaterialName = material.FirstOrDefault(l => l.MaterialCode == item.MaterialCode)?.Description;
                }
            });


            return tblProduction.ToList();

        }

        public List<tblQCResults> GetQcDetails(string GoodsIssueId, string Materialcode, string Type)
        {
            using var repo = new ERPContext();
            var material = new List<TblMaterialMaster>();
            var tblProduction = new List<tblQCResults>();
            var sizes = repo.TblMaterialSize.ToList();
            if (!string.IsNullOrEmpty(Materialcode))
            {
                tblProduction = repo.tblQCResults.Where(cd => cd.saleOrderNumber == GoodsIssueId && cd.MaterialCode == Materialcode && cd.Type == Type).ToList();
                material = repo.TblMaterialMaster.Where(cd => cd.MaterialCode == Materialcode).ToList();
            }
            //else
            //{
            //    tblProduction = repo.TblInspectionCheckDetails.Where(cd => cd.saleOrderNumber == GoodsIssueId).ToList();
            //    material = repo.TblMaterialMaster.ToList();
            //}

            repo.tblQCResults.ToList().ForEach(c =>
            {
                foreach (var item in tblProduction)
                {
                    c.MaterialName = material.FirstOrDefault(l => l.MaterialCode == item.MaterialCode)?.Description;

                }
                c.UOMName = sizes.FirstOrDefault(s => s.unitId == c.Uom)?.unitName;
            });


            return tblProduction.ToList();

        }

        public bool AddGoodsIssue(TblGoodsIssueMaster gimaster, List<TblGoodsIssueDetails> gibDetails)
        {

            int lineno = 1;
            using var repo = new Repository<TblPurchaseOrder>();
            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            using var repogim = new Repository<TblGoodsIssueMaster>();
            using var repogidetail = new Repository<TblGoodsIssueDetails>();
            using var tblprod = new Repository<TblGoodsIssueDetails>();
            var tblProduction = new TblProductionMaster();
            var ProductionDetails = new List<TblProductionDetails>();
            var ProductionStatus = new List<TblProductionStatus>();
            List<TblGoodsIssueDetails> goodsOrderDetailsNew;
            List<TblGoodsIssueDetails> goodsOrderDetailsExist;
            using var commitmentitem = new Repository<TblCommitmentItem>();
            var SaleOrder = repo.TblSaleOrderMaster.FirstOrDefault(im => im.SaleOrderNo == gimaster.SaleOrderNumber);
            var Purcaseorder = repo.TblPurchaseOrder.FirstOrDefault(im => im.SaleOrderNo == gimaster.SaleOrderNumber);
            var goodsreceipt = repo.TblGoodsReceiptMaster.FirstOrDefault(im => im.SaleorderNo == gimaster.SaleOrderNumber);
            try
            {
                if (repogim.TblGoodsIssueMaster.Any(v => v.SaleOrderNumber == gimaster.SaleOrderNumber))
                {
                    gimaster.Status = "Production Released";
                    context.TblGoodsIssueMaster.Update(gimaster);
                    context.SaveChanges();
                }
                else
                {
                    if (repogim.TblGoodsIssueMaster.Any(v => v.SaleOrderNumber == gimaster.SaleOrderNumber))
                    {
                        throw new Exception("Already Allocated Goods Issue for this Saleorder." + gimaster.SaleOrderNumber);
                    }
                    gimaster.Status = "Production Released";
                    context.TblGoodsIssueMaster.Add(gimaster);
                    tblProduction.Company = gimaster.Company;
                    tblProduction.SaleOrderNumber = gimaster.SaleOrderNumber;
                    tblProduction.Status = "Production Released";
                    tblProduction.ProfitCenter = gimaster.ProfitCenter;
                    context.TblProductionMaster.Add(tblProduction);

                    context.SaveChanges();
                }
                gibDetails.ForEach(x =>
                {
                    x.GoodsIssueId = gimaster.GoodsIssueId;
                    x.SaleOrderNumber = gimaster.SaleOrderNumber;
                    x.AddDate = System.DateTime.Now;
                    x.EditDate = System.DateTime.Now;
                    x.Status = "Production Released";
                });


                int tagnum = 0;
                if (tblprod.TblProductionDetails.Any())
                {
                    tagnum = tblprod.TblProductionDetails.Max(i => i.ID) + 1;
                }
                else
                    tagnum = 1;

                foreach (var item in gibDetails)
                {

                    // int qty = (item.AllocatedQTY ?? 0)-(receivedqty);
                    int qty = item.AllocatedQTY ?? 0;
                    if (qty > 0)
                    {
                        for (var i = 0; i < qty; i++)
                        {
                            ProductionDetails.Add(new TblProductionDetails { SaleOrderNumber = item.SaleOrderNumber, ProductionTag = "AMT-" + tagnum, Status = "Production Released", MaterialCode = item.MaterialCode });
                            tagnum = tagnum + 1;
                        }
                    }
                    int receivedqty = 0;
                    if (item.AllocatedQTY > 0)
                    {
                        receivedqty = Convert.ToInt16(repogidetail.TblGoodsIssueDetails.Where(y => y.SaleOrderNumber == gimaster.SaleOrderNumber && y.MaterialCode == item.MaterialCode).Sum(a => a.AllocatedQTY));
                        item.AllocatedQTY = (item.AllocatedQTY) + (receivedqty);
                    }
                    //    if (repogidetail.TblGoodsIssueDetails.Any(z => z.SaleOrderNumber == gimaster.SaleOrderNumber && z.MaterialCode==item.MaterialCode))
                    //    {
                    //        int alloqty = Convert.ToInt16(repogidetail.TblGoodsIssueDetails.Where(y => y.SaleOrderNumber == gimaster.SaleOrderNumber && y.MaterialCode == item.MaterialCode).Sum(a => a.AllocatedQTY));

                    //            int qty = item.AllocatedQTY ?? 0;
                    //        if (qty > 0)
                    //        {
                    //            for (var i = 0; i < qty; i++)
                    //            {
                    //                ProductionDetails.Add(new TblProductionDetails { SaleOrderNumber = item.SaleOrderNumber, ProductionTag = "AMT-" + tagnum, Status = "Production Released", MaterialCode = item.MaterialCode });
                    //                tagnum = tagnum + 1;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        int qty = item.AllocatedQTY ?? 0;
                    //        if (qty > 0)
                    //        {
                    //            for (var i = 0; i < qty; i++)
                    //            {
                    //                ProductionDetails.Add(new TblProductionDetails { SaleOrderNumber = item.SaleOrderNumber, ProductionTag = "AMT-" + tagnum, Status = "Production Released", MaterialCode = item.MaterialCode });
                    //                tagnum = tagnum + 1;
                    //            }
                    //        }
                    //    }

                }
                var result = commitmentitem.Where(x => x.Type.Equals("Production")).OrderBy(z => z.SortOrder);

                foreach (var resultcommitment in ProductionDetails)
                {
                    if (result.Any())
                    {
                        foreach (var commit in result)
                        {
                            ProductionStatus.Add(new TblProductionStatus { SaleOrderNumber = resultcommitment.SaleOrderNumber, ProductionTag = resultcommitment.ProductionTag, Status = "Production Released", WorkStatus = "Production Released", MaterialCode = resultcommitment.MaterialCode, TypeofWork = commit.Description });
                        }
                    }
                }
                context.TblProductionDetails.AddRange(ProductionDetails);
                context.TblProductionStatus.AddRange(ProductionStatus);
                goodsOrderDetailsExist = gibDetails.Where(x => x.Id > 0).ToList();
                goodsOrderDetailsNew = gibDetails.Where(x => x.Id == 0).ToList();

                if (goodsOrderDetailsExist.Count > 0)
                {
                    context.TblGoodsIssueDetails.UpdateRange(gibDetails);
                }
                else
                {
                    context.TblGoodsIssueDetails.AddRange(gibDetails);
                }
                SaleOrder.Status = "Production Released";
                context.TblSaleOrderMaster.Update(SaleOrder);
                if (Purcaseorder != null)
                {
                    Purcaseorder.Status = "Production Released";
                    context.TblPurchaseOrder.Update(Purcaseorder);
                }
                if (goodsreceipt != null)
                {
                    goodsreceipt.Status = "Production Released";
                    context.TblGoodsReceiptMaster.Update(goodsreceipt);
                }

                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                TblApi_Error_Log icdata = new();
                using var context1 = new ERPContext();
                icdata.ScreenName = "Goods Issue";
                icdata.ErrorID = ex.HResult.ToString();
                icdata.ErrorMessage = ex.InnerException.Message.ToString();
                context1.TblApi_Error_Log.Add(icdata);
                context1.SaveChanges();
                dbtrans.Rollback();
                throw;
            }
        }

        public bool AddProdIssue(List<TblProductionDetails> prodDetails)
        {
            if (prodDetails.Count > 0)
            {
                string masternumber = string.Empty;
                int lineno = 1;
                using var repo = new Repository<TblInspectionCheckMaster>();
                var InspectionCheckMaster = new TblInspectionCheckMaster();
                var InspectionCheckDetails = new List<TblInspectionCheckDetails>();
                var NewInspectionCheckDetails = new List<TblInspectionCheckDetails>();
                var goodsissue = new TblGoodsIssueDetails();
                var RejectionMaster = new TblRejectionMaster();
                using var context = new ERPContext();
                string saleordernumber = prodDetails.FirstOrDefault().SaleOrderNumber;
                string material = prodDetails.FirstOrDefault().MaterialCode;
                var repogim = repo.TblProductionMaster.Where(x => x.SaleOrderNumber == saleordernumber).FirstOrDefault();
                var InspectionMaster = repo.TblInspectionCheckMaster.Where(x => x.saleOrderNumber == saleordernumber && x.MaterialCode == material).FirstOrDefault();
                var SaleOrder = repo.TblSaleOrderMaster.FirstOrDefault(im => im.SaleOrderNo == saleordernumber);
                var Purcaseorder = repo.TblPurchaseOrder.FirstOrDefault(im => im.SaleOrderNo == saleordernumber);
                var goodsreceipt = repo.TblGoodsReceiptMaster.FirstOrDefault(im => im.SaleorderNo == saleordernumber);
                var Pcenter = repo.Counters.FirstOrDefault(x => x.CounterName == "QC");
                var materialmaster = repo.TblMaterialMaster.FirstOrDefault(x => x.MaterialCode == material);


                using var dbtrans = context.Database.BeginTransaction();


                try
                {
                    if (InspectionMaster != null)
                    {
                        InspectionCheckMaster.Status = "Production Started";
                        context.TblInspectionCheckMaster.Update(InspectionMaster);
                        context.SaveChanges();
                        masternumber = InspectionMaster.InspectionCheckNo;
                    }
                    else
                    {
                        if (Pcenter != null)
                        {
                            Pcenter.LastNumber = (Pcenter.LastNumber + 1);
                            context.Counters.UpdateRange(Pcenter);
                            context.SaveChanges();
                            masternumber = Pcenter.Prefix + "-" + Pcenter.LastNumber;
                        }
                        if (string.IsNullOrEmpty(InspectionCheckMaster.InspectionCheckNo))
                            InspectionCheckMaster.InspectionCheckNo = masternumber;


                        InspectionCheckMaster.Status = "Production Started";
                        InspectionCheckMaster.InspectionCheckNo = masternumber;
                        InspectionCheckMaster.saleOrderNumber = saleordernumber;
                        InspectionCheckMaster.MaterialCode = material;
                        InspectionCheckMaster.completionDate = System.DateTime.Now;
                        if (masternumber.Length > 1)
                            context.TblInspectionCheckMaster.Add(InspectionCheckMaster);
                        else
                            throw new Exception("InspectionCheckNo Not Valid. " + masternumber + " Please check .");


                        context.SaveChanges();
                    }
                    foreach (var item in prodDetails)
                    {
                        InspectionCheckDetails = repo.TblInspectionCheckDetails.Where(x => x.InspectionCheckNo == masternumber && x.productionTag == item.ProductionTag).ToList();

                        if (InspectionCheckDetails.Count == 0)
                            NewInspectionCheckDetails.Add(new TblInspectionCheckDetails { InspectionCheckNo = masternumber, Status = item.WorkStatus, MaterialCode = item.MaterialCode, productionTag = item.ProductionTag, saleOrderNumber = item.SaleOrderNumber, CompletedBy = item.AllocatedPerson, CompletionDate = item.EndDate, Description = item.Remarks });
                        else
                        {
                            InspectionCheckDetails.ForEach(x =>
                            {
                                x.Status = item.WorkStatus;
                                x.CompletedBy = item.AllocatedPerson;
                                x.CompletionDate = item.EndDate;
                                x.Description = item.Remarks;

                            });
                            context.TblInspectionCheckDetails.UpdateRange(InspectionCheckDetails);
                        }
                        goodsissue = repo.TblGoodsIssueDetails.Where(g => g.SaleOrderNumber == item.SaleOrderNumber && g.MaterialCode == item.MaterialCode).FirstOrDefault();
                        goodsissue.Status = item.WorkStatus;
                        var ProductionStatus = new TblProductionStatus();
                        ProductionStatus = repo.TblProductionStatus.Where(s => s.SaleOrderNumber == item.SaleOrderNumber && s.MaterialCode == item.MaterialCode && s.ProductionTag == item.ProductionTag && s.TypeofWork == item.TypeofWork).FirstOrDefault();
                        if (ProductionStatus != null)
                        {
                            ProductionStatus.Status = "Production Started";
                            ProductionStatus.WorkStatus = item.WorkStatus;
                            ProductionStatus.AllocatedPerson = item.AllocatedPerson;
                            ProductionStatus.Remarks = item.Remarks;
                            ProductionStatus.StartDate = item.StartDate;
                            ProductionStatus.EndDate = item.EndDate;
                            ProductionStatus.Mechine = item.Mechine;
                            context.TblProductionStatus.UpdateRange(ProductionStatus);
                        }
                        if (item.WorkStatus == "Rejected")
                        {
                            var poq = repo.TblPoQueue.FirstOrDefault(z => z.SaleOrderNo == item.SaleOrderNumber && z.MaterialCode == item.MaterialCode);
                            poq.Qty = 1;
                            poq.Status = "New";
                            context.TblPoQueue.Update(poq);

                            materialmaster.ClosingQty = ((materialmaster.ClosingQty) - 1);
                            context.TblMaterialMaster.UpdateRange(materialmaster);

                            RejectionMaster.SaleOrderNo = item.SaleOrderNumber;
                            RejectionMaster.MaterialCode = item.MaterialCode;
                            RejectionMaster.TagNo = item.ProductionTag;
                            RejectionMaster.Reason = item.Remarks;
                            context.TblRejectionMaster.Add(RejectionMaster);
                        }
                    }
                    if (NewInspectionCheckDetails.Count > 0)
                        context.TblInspectionCheckDetails.AddRange(NewInspectionCheckDetails);

                    repogim.Status = "Production Started";

                    context.TblProductionMaster.UpdateRange(repogim);
                    context.TblGoodsIssueDetails.Update(goodsissue);
                    context.TblProductionDetails.UpdateRange(prodDetails);

                    SaleOrder.Status = "Production Started";
                    context.TblSaleOrderMaster.Update(SaleOrder);
                    //if (Purcaseorder != null)
                    //{
                    //    Purcaseorder.Status = "Production Started";
                    //    context.TblPurchaseOrder.Update(Purcaseorder);
                    //}
                    if (goodsreceipt != null)
                    {
                        goodsreceipt.Status = "Production Started";
                        context.TblGoodsReceiptMaster.Update(goodsreceipt);
                    }

                    context.SaveChanges();


                    dbtrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {

                    TblApi_Error_Log icdata = new TblApi_Error_Log();
                    using var context1 = new ERPContext();
                    icdata.ScreenName = "Production Issue";
                    icdata.ErrorID = ex.HResult.ToString();
                    icdata.ErrorMessage = ex.InnerException.Message.ToString();
                    context1.TblApi_Error_Log.Add(icdata);
                    context1.SaveChanges();
                    dbtrans.Rollback();
                    throw;
                }
            }
            return true;
        }
        public bool ReturnGoodsIssue(string RequisitionNumber)
        {
            using var repo = new ERPContext();
            var goodissueHeader = repo.TblGoodsIssueMaster.FirstOrDefault(im => im.SaleOrderNumber == RequisitionNumber);

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
            using var context = new ERPContext();
            string masternumber = string.Empty;
            using var repo = new Repository<Counters>();
            var Pcenter = repo.Counters.FirstOrDefault(x => x.CounterName == "BOM");
            using var dbtrans = context.Database.BeginTransaction();
            List<TblBomDetails> prDetailsNew;
            List<TblBomDetails> prDetailsExist;

            if (repo.TbBommaster.Any(v => v.Bomnumber == bomMaster.Bomnumber))
            {
                int lineno = 1;
                bomMaster.Status = "Created";
                bomMaster.CreatedDate = System.DateTime.Now;
                context.TbBommaster.Update(bomMaster);
                context.SaveChanges();
            }
            else
            {
                if (Pcenter != null)
                {
                    Pcenter.LastNumber = (Pcenter.LastNumber + 1);
                    context.Counters.UpdateRange(Pcenter);
                    context.SaveChanges();
                    masternumber = Pcenter.Prefix + "-" + Pcenter.LastNumber;
                }

                bomMaster.Status = "Created";
                bomMaster.CreatedDate = DateTime.Now;
                bomMaster.Bomnumber = masternumber;
                if (masternumber.Length > 1)
                    context.TbBommaster.Add(bomMaster);
                else
                    throw new Exception("Bomnumber Not Valid. " + masternumber + " Please check .");


                context.SaveChanges();
            }

            if (string.IsNullOrEmpty(masternumber))
                masternumber = bomMaster.Bomnumber;


            bomDetails.ForEach(x =>
            {
                x.BomKey = masternumber;
            });

            prDetailsExist = bomDetails.Where(x => x.Id > 0).ToList();
            prDetailsNew = bomDetails.Where(x => x.Id == 0).ToList();
            try
            {
                if (prDetailsExist.Count > 0)
                {
                    context.TblBomDetails.UpdateRange(prDetailsExist);
                }
                else
                {
                    context.TblBomDetails.AddRange(prDetailsNew);
                }
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
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-100), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-100);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TbBommaster>();
            return repo.TbBommaster.AsEnumerable()
                .Where(x =>
                {

                    //Debug.Assert(x.CreatedDate != null, "x.CreatedDate != null");
                    return Convert.ToString(x.Bomnumber) != null
                              && Convert.ToString(x.Bomnumber).Contains(searchCriteria.searchCriteria ?? Convert.ToString(x.Bomnumber))
                              && Convert.ToDateTime(x.CreatedDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                              && Convert.ToDateTime(x.CreatedDate.Value.ToShortDateString()) <= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                }).OrderByDescending(x => x.Bomnumber)
                .ToList();
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

            if (repo.TblWorkcenterMaster.Any(v => v.WorkcenterCode == workCenterMaster.WorkcenterCode))
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
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-100), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-100);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblPurchaseRequisitionMaster>();

            var Company = repo.TblCompany.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var Department = repo.TblFunctionalDepartment.ToList();

            repo.TblPurchaseRequisitionMaster.ToList()
                .ForEach(c =>
                {
                    c.CompanyName = Company.FirstOrDefault(l => l.CompanyCode == c.Company).CompanyName;
                    c.ProfitcenterName = profitCenters.FirstOrDefault(p => p.Code == c.ProfitCenter).Name;
                    c.DepartmentName = Department.FirstOrDefault(m => m.Code == c.Department).Description;

                });

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
            using var repo = new Repository<TblPurchaseRequisitionMaster>();
            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            List<TblPurchaseRequisitionDetails> prDetailsNew;
            List<TblPurchaseRequisitionDetails> prDetailsExist;
            string masternumber = string.Empty;


            using var repocoun = new Repository<Counters>();
            var Pcenter = repo.Counters.FirstOrDefault(x => x.CounterName == "Master Sale Order");

            if (repo.TblPurchaseRequisitionMaster.Any(v => v.RequisitionNumber == reqmasterdata.RequisitionNumber))
            {
                reqmasterdata.Status = "MSO Created";
                reqmasterdata.EditDate = DateTime.Now;
                context.TblPurchaseRequisitionMaster.Update(reqmasterdata);
                context.SaveChanges();
            }
            else
            {
                if (Pcenter != null)
                {
                    Pcenter.LastNumber = (Pcenter.LastNumber + 1);
                    context.Counters.UpdateRange(Pcenter);
                    context.SaveChanges();
                    masternumber = Pcenter.Prefix + "-" + Pcenter.LastNumber;
                }

                reqmasterdata.Status = "MSO Created";
                reqmasterdata.AddDate = DateTime.Now;
                reqmasterdata.RequisitionNumber = masternumber;
                if (masternumber.Length > 1)
                    context.TblPurchaseRequisitionMaster.Add(reqmasterdata);
                else
                    throw new Exception("Master Sale Order Number Not Valid. " + masternumber + " Please check .");


                context.SaveChanges();
            }

            if (string.IsNullOrEmpty(masternumber))
                masternumber = reqmasterdata.RequisitionNumber;

            reqdetails.ForEach(x =>
            {
                x.PurchaseRequisitionNumber = masternumber;
            });

            prDetailsExist = reqdetails.Where(x => x.Id > 0).ToList();
            prDetailsNew = reqdetails.Where(x => x.Id == 0).ToList();

            try
            {
                if (prDetailsExist.Count > 0)
                {
                    context.TblPurchaseRequisitionDetails.UpdateRange(prDetailsExist);
                }
                else
                {
                    context.TblPurchaseRequisitionDetails.AddRange(prDetailsNew);
                }
                context.SaveChanges();
                dbtrans.Commit();
                return true;
            }
            catch (Exception ex)
            {

                TblApi_Error_Log icdata = new TblApi_Error_Log();
                using var context1 = new ERPContext();
                icdata.ScreenName = "Mastersale Order";
                icdata.ErrorID = ex.HResult.ToString();
                icdata.ErrorMessage = ex.InnerException.Message.ToString();
                context1.TblApi_Error_Log.Add(icdata);
                context1.SaveChanges();

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
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-100), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-100);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblSupplierQuotationsMaster>();
            var Company = repo.TblCompany.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var customer = repo.TblBusinessPartnerAccount.ToList();

            repo.TblSupplierQuotationsMaster.ToList()
                .ForEach(c =>
                {
                    c.CompanyName = Company.FirstOrDefault(l => l.CompanyCode == c.Company).CompanyName;
                    c.ProfitcenterName = profitCenters.FirstOrDefault(p => p.Code == c.ProfitCenter).Name;
                    c.SupplierName = customer.FirstOrDefault(m => m.Bpnumber == c.CustomerCode).Name;

                });

            return repo.TblSupplierQuotationsMaster.AsEnumerable().ToList();
        }
        public bool AddSupplierQuotationsMaster(TblSupplierQuotationsMaster msdata, List<TblSupplierQuotationDetails> qsdetails)

        {
            using var repo1 = new Repository<Counters>();
            var Pcenter = repo1.Counters.FirstOrDefault(x => x.CounterName == "Quotation");
            using var context = new ERPContext();
            using var repo = new Repository<TblSupplierQuotationsMaster>();
            using var dbtrans = context.Database.BeginTransaction();
            string masternumber = string.Empty;
            List<TblSupplierQuotationDetails> prDetailsNew;
            List<TblSupplierQuotationDetails> prDetailsExist;

            if (repo.TblSupplierQuotationsMaster.Any(v => v.QuotationNumber == msdata.QuotationNumber))
            {
                msdata.Status = "Quotation Created";
                msdata.QuotationDate = DateTime.Now;
                context.TblSupplierQuotationsMaster.Update(msdata);
                context.SaveChanges();
            }
            else
            {
                if (Pcenter != null)
                {
                    Pcenter.LastNumber = (Pcenter.LastNumber + 1);
                    context.Counters.UpdateRange(Pcenter);
                    context.SaveChanges();
                    masternumber = Pcenter.Prefix + "-" + Pcenter.LastNumber;
                }

                msdata.Status = "Created";
                msdata.QuotationDate = DateTime.Now;
                msdata.QuotationNumber = masternumber;
                if (masternumber.Length > 1)
                    context.TblSupplierQuotationsMaster.Add(msdata);
                else
                    throw new Exception("Quotation Number Not Valid. " + masternumber + " Please check .");


                context.SaveChanges();
            }

            if (string.IsNullOrEmpty(masternumber))
                masternumber = msdata.QuotationNumber;

            qsdetails.ForEach(x =>
            {
                x.QuotationNumber = masternumber;
            });

            prDetailsExist = qsdetails.Where(x => x.Id > 0).ToList();
            prDetailsNew = qsdetails.Where(x => x.Id == 0).ToList();


            try
            {
                if (prDetailsExist.Count > 0)
                {
                    context.TblSupplierQuotationDetails.UpdateRange(prDetailsExist);
                }
                else
                {
                    context.TblSupplierQuotationDetails.AddRange(prDetailsNew);
                }
                context.SaveChanges();
                dbtrans.Commit();
                return true;
            }
            catch (Exception ex)
            {

                TblApi_Error_Log icdata = new TblApi_Error_Log();
                using var context1 = new ERPContext();
                icdata.ScreenName = "Quotation";
                icdata.ErrorID = ex.HResult.ToString();
                icdata.ErrorMessage = ex.InnerException.Message.ToString();
                context1.TblApi_Error_Log.Add(icdata);
                context1.SaveChanges();

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
            catch (Exception ex)
            {

                TblApi_Error_Log icdata = new TblApi_Error_Log();
                using var context1 = new ERPContext();
                icdata.ScreenName = "Quotation";
                icdata.ErrorID = ex.HResult.ToString();
                icdata.ErrorMessage = ex.InnerException.Message.ToString();
                context1.TblApi_Error_Log.Add(icdata);
                context1.SaveChanges();

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
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-100), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-100);
            searchCriteria.ToDate ??= DateTime.Today;
            using var repo = new Repository<TblPurchaseOrder>();

            var Company = repo.TblCompany.ToList();
            var PoType = repo.TblPurchaseOrderType.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var customer = repo.TblBusinessPartnerAccount.ToList();

            repo.TblPurchaseOrder.ToList()
                .ForEach(c =>
                {
                    c.CompanyName = Company.FirstOrDefault(l => l.CompanyCode == c.Company).CompanyName;
                    c.PurchaseOrderName = PoType.FirstOrDefault(l => l.purchaseType == c.PurchaseOrderType).Description;
                    c.ProfitcenterName = profitCenters.FirstOrDefault(p => p.Code == c.ProfitCenter).Name;
                    c.SupplierName = customer.FirstOrDefault(m => m.Bpnumber == c.SupplierCode).Name;

                });

            return repo.TblPurchaseOrder.AsEnumerable()
                .Where(x =>
                {

                    //Debug.Assert(x.CreatedDate != null, "x.CreatedDate != null");
                    return Convert.ToString(x.PurchaseOrderNumber) != null
                              && Convert.ToString(x.PurchaseOrderNumber).Contains(searchCriteria.searchCriteria ?? Convert.ToString(x.PurchaseOrderNumber))
                              && Convert.ToDateTime(x.AddDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                              && Convert.ToDateTime(x.AddDate.Value.ToShortDateString()) <= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                }).OrderByDescending(x => x.Id)
                .ToList();
        }
        public bool AddPurchaseOrder(TblPurchaseOrder podata, List<TblPurchaseOrderDetails> podetails)
        {
            using var repo = new Repository<TblPurchaseOrder>();
            using var context = new ERPContext();
            List<TblPurchaseOrderDetails> poDetailsNew;
            List<TblPurchaseOrderDetails> poDetailsExist;
            int totalqty;
            totalqty = (int)podetails.Sum(a => a.Qty);
            using var dbtrans = context.Database.BeginTransaction();
            string purchaseordernumber = string.Empty;
            var Pcenter = repo.ProfitCenters.Where(x => x.Code == podata.ProfitCenter).FirstOrDefault();
            string CustPONumber;
            var SaleOrder = repo.TblSaleOrderMaster.FirstOrDefault(im => im.SaleOrderNo == podata.SaleOrderNo);
            var PRdata = repo.TblPurchaseRequisitionMaster.FirstOrDefault(im => im.RequisitionNumber == podata.SaleOrderNo);
            var Bomdata = repo.TbBommaster.FirstOrDefault(im => im.Bomnumber == podata.SaleOrderNo);
            if (SaleOrder != null)
                CustPONumber = SaleOrder.PONumber;
            else if (PRdata != null)
                CustPONumber = PRdata.RequisitionNumber;
            else
                CustPONumber = Bomdata.Bomnumber;
            try
            {
                if (repo.TblPurchaseOrder.Any(v => v.PurchaseOrderNumber == podata.PurchaseOrderNumber))
                {
                    podata.Status = "PO Created";
                    podata.EditDate = DateTime.Now;
                    podata.TotalQty = totalqty;
                    context.TblPurchaseOrder.Update(podata);
                    context.SaveChanges();
                }
                else
                {
                    if (Pcenter != null)
                    {
                        Pcenter.PONumber = (Pcenter.PONumber + 1);
                        context.ProfitCenters.UpdateRange(Pcenter);
                        context.SaveChanges();
                        purchaseordernumber = Pcenter.POPrefix + "-" + Pcenter.PONumber;
                    }

                    podata.Status = "PO Created";
                    podata.AddDate = DateTime.Now;
                    podata.PurchaseOrderNumber = purchaseordernumber;
                    podata.CustPONumber = CustPONumber;
                    podata.TotalQty = totalqty;
                    if (purchaseordernumber.Length > 1)
                        context.TblPurchaseOrder.Add(podata);
                    else
                        throw new Exception("Purchaseorder Number Not Valid. " + purchaseordernumber + " Please check .");

                    context.SaveChanges();
                }


                if (SaleOrder != null)
                {
                    SaleOrder.Status = "PO Created";
                    context.TblSaleOrderMaster.Update(SaleOrder);
                }

                if (PRdata != null)
                {
                    PRdata.Status = "PO Created";
                    context.TblPurchaseRequisitionMaster.Update(PRdata);
                }

                if (string.IsNullOrWhiteSpace(purchaseordernumber))
                    purchaseordernumber = podata.PurchaseOrderNumber;

                podetails.ForEach(x =>
                {
                    x.PurchaseOrderNumber = purchaseordernumber;
                    x.SaleOrder = podata.SaleOrderNo;
                });
                foreach (var item in podetails)
                {
                    int poqty = 0;
                    int soqty = 0;
                    int matqty = 0;
                    var sodata = repo.TblSaleOrderDetail.FirstOrDefault(im => im.SaleOrderNo == item.SaleOrder && im.MaterialCode == item.MaterialCode);
                    if (sodata != null)
                    {
                        var poq = repo.TblPoQueue.FirstOrDefault(z => z.SaleOrderNo == item.SaleOrder && z.MaterialCode == item.MaterialCode && z.Status == "New");
                        poq.Qty = Math.Abs(Convert.ToInt16(poq.Qty) - (item.Qty));
                        if (poq.Qty >= 0)
                        {
                            poq.Status = "PO Created";
                            context.TblPoQueue.Update(poq);
                        }
                        else if (poq.Qty < 0)
                        {
                            poq.Qty = 0;
                            poq.Status = "PO Created";
                            context.TblPoQueue.Update(poq);
                        }
                        else 
                        {
                            context.TblPoQueue.Update(poq);
                        }
                    }
                }

                poDetailsExist = podetails.Where(x => x.Id > 0).ToList();
                poDetailsNew = podetails.Where(x => x.Id == 0).ToList();


                if (poDetailsExist.Count > 0)
                {
                    context.TblPurchaseOrderDetails.UpdateRange(podetails);
                }
                else
                {
                    context.TblPurchaseOrderDetails.AddRange(podetails);
                }
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

        public bool SavePurchaseOrder(List<TblPurchaseOrder> podata)
        {
            using var repo = new Repository<TblPurchaseOrder>();
            using var context = new ERPContext();
            string ponumber = podata.FirstOrDefault().PurchaseOrderNumber;
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                foreach (var item in podata)
                {
                    if (repo.TblPurchaseOrder.Any(v => v.PurchaseOrderNumber == ponumber))
                    {
                        context.TblPurchaseOrder.Update(item);
                        //context.SaveChanges();
                    }
                }

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

        public bool SaveGoodsReceipt(List<TblGoodsReceiptMaster> podata)
        {
            using var repo = new Repository<TblGoodsReceiptMaster>();
            using var context = new ERPContext();
            string ponumber = podata.FirstOrDefault().PurchaseOrderNo;
            using var dbtrans = context.Database.BeginTransaction();
            try
            {
                foreach (var item in podata)
                {
                    if (repo.TblGoodsReceiptMaster.Any(v => v.PurchaseOrderNo == ponumber))
                    {
                        context.TblGoodsReceiptMaster.Update(item);
                        //context.SaveChanges();
                    }
                }

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
            var material = repo.TblMaterialMaster.ToList();

            repo.TblPurchaseOrderDetails.ToList().ForEach(c =>
            {
                c.MaterialName = material.FirstOrDefault(l => l.MaterialCode == c.MaterialCode)?.Description;
                c.AvailableQTY = Convert.ToInt32(material.FirstOrDefault(l => l.MaterialCode == c.MaterialCode)?.ClosingQty);
            });
            return repo.TblPurchaseOrderDetails.Where(cd => cd.PurchaseOrderNumber == number).ToList();
        }

        public List<TblPurchaseOrderDetails> GetPurchaseOrderDetails(string saleorder, string materialcode)
        {
            using var repo = new Repository<TblPurchaseOrderDetails>();
            var material = repo.TblMaterialMaster.ToList();

            repo.TblPurchaseOrderDetails.ToList().ForEach(c =>
            {
                c.MaterialName = material.FirstOrDefault(l => l.MaterialCode == c.MaterialCode)?.Description;
                c.AvailableQTY = Convert.ToInt32(material.FirstOrDefault(l => l.MaterialCode == c.MaterialCode)?.ClosingQty);
            });
            return repo.TblPurchaseOrderDetails.Where(cd => cd.SaleOrder == saleorder && cd.MaterialCode == materialcode).ToList();
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

            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-100), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-100);
            searchCriteria.ToDate ??= DateTime.Today;
            using var repo = new Repository<TblGoodsReceiptMaster>();

            var Company = repo.TblCompany.ToList();
            var profitCenters = repo.ProfitCenters.ToList();

            repo.TblGoodsReceiptMaster.ToList()
                .ForEach(c =>
                {
                    c.CompanyName = Company.FirstOrDefault(l => l.CompanyCode == c.Company).CompanyName;
                    c.ProfitcenterName = profitCenters.FirstOrDefault(l => l.Code == c.ProfitCenter).Name;

                });

            return repo.TblGoodsReceiptMaster.AsEnumerable()
               .Where(x =>
               {
                   return Convert.ToString(x.PurchaseOrderNo) != null
                             && Convert.ToString(x.PurchaseOrderNo).Contains(searchCriteria.searchCriteria ?? Convert.ToString(x.PurchaseOrderNo))
                             && Convert.ToDateTime(x.ReceivedDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                             && Convert.ToDateTime(x.ReceivedDate.Value.ToShortDateString()) <= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
               }).OrderByDescending(x => x.PurchaseOrderNo)
               .ToList();
        }
        public bool AddGoodsReceipt(TblGoodsReceiptMaster grdata, List<TblGoodsReceiptDetails> grdetails)
        {

            if (grdata.PurchaseOrderNo == null)
                throw new Exception("PurchaseOrder NumberCanot be empty/null.");

            int receivedqty = 0;
            int rejectedqty = 0;
            int totalqty = 0;
            int currqtyrec = 0;
            int currqtyrej = 0;
            int poqty = 0;
            int mtqty = 0;
            int mtrejqty = 0;
            int currqty = 0;
            using var repo = new Repository<TblGoodsReceiptMaster>();
            using var Material = new Repository<TblMaterialMaster>();
            using var context = new ERPContext();
            using var Matdtl = new Repository<TblGoodsReceiptDetails>();
            using var PRM = new Repository<TblPurchaseRequisitionMaster>();
            List<TblGoodsReceiptDetails> GoosQTY;

            using var dbtrans = context.Database.BeginTransaction();
            try
            {

                currqtyrec = grdetails.Sum(v => v.ReceivedQty) ?? 0;// current received qty
                currqtyrej = grdetails.Sum(v => v.RejectQty) ?? 0;//current rejected qty

                // already received qty
                GoosQTY = Matdtl.TblGoodsReceiptDetails.Where(cd => cd.PurchaseOrderNo == grdata.PurchaseOrderNo).ToList();


                if (GoosQTY.Count > 0)
                {
                    receivedqty = (GoosQTY.Sum(i => i.ReceivedQty) ?? 0);
                    rejectedqty = (GoosQTY.Sum(i => i.RejectQty) ?? 0);
                }
                //poqty
                poqty = grdetails.Sum(v => v.Qty) ?? 0;

                totalqty = (receivedqty + rejectedqty) + (currqtyrec + currqtyrej);

                var purchase = repo.TblPurchaseOrder.FirstOrDefault(im => im.PurchaseOrderNumber == grdata.PurchaseOrderNo);
                var saleorder = repo.TblSaleOrderMaster.FirstOrDefault(im => im.SaleOrderNo == purchase.SaleOrderNo);
                if (poqty == totalqty)
                {
                    if (purchase != null)
                    {
                        purchase.Status = "Material Received";
                        purchase.ReceivedDate = DateTime.Now;
                        saleorder.Status = "Material Received";
                        context.TblPurchaseOrder.Update(purchase);
                        context.TblSaleOrderMaster.Update(saleorder);
                    }

                    grdata.Status = "Material Received";
                    grdata.SaleorderNo = purchase.SaleOrderNo;
                }
                else if (totalqty < poqty)
                {
                    if (purchase != null)
                    {
                        purchase.Status = "Material Partial Received";
                        saleorder.Status = "Material Partial Received";
                        context.TblPurchaseOrder.Update(purchase);
                        context.TblSaleOrderMaster.Update(saleorder);
                    }

                    grdata.Status = "Material Partial Received";
                    grdata.SaleorderNo = purchase.SaleOrderNo;
                }
                foreach (var item in grdetails)
                {
                    item.PurchaseOrderNo = grdata.PurchaseOrderNo;
                    item.LotNo = grdata.LotNo;
                    item.SupplierRefno = grdata.SupplierReferenceNo;
                    item.VehicleNumber = grdata.VehicleNo;
                    item.ReceivedDate = grdata.ReceivedDate;
                    item.ReceivedBy = grdata.ReceivedBy;
                    item.BillAmount = grdata.TotalAmount;
                    GoosQTY = Matdtl.TblGoodsReceiptDetails.Where(cd => cd.PurchaseOrderNo == grdata.PurchaseOrderNo && cd.MaterialCode == item.MaterialCode).ToList();
                    mtqty = (GoosQTY.Sum(i => i.ReceivedQty) ?? 0);
                    mtrejqty = (GoosQTY.Sum(i => i.RejectQty) ?? 0);
                    totalqty = (mtqty + mtrejqty) + (item.ReceivedQty ?? 0 + item.RejectQty ?? 0);
                    item.InvoiceNo = grdata.SupplierReferenceNo;
                    item.InvoiceURL = grdata.InvoiceURL;
                    item.DocumentURL = grdata.DocumentURL;
                    item.SaleorderNo = purchase.SaleOrderNo;
                }
                context.TblGoodsReceiptDetails.AddRange(grdetails);
                context.SaveChanges();

                dbtrans.Commit();
            }
            catch (Exception)
            {
                dbtrans.Rollback();
                throw;
            }
            if (repo.TblGoodsReceiptMaster.Any(v => v.PurchaseOrderNo == grdata.PurchaseOrderNo))
            {
                var totalamount = repo.TblGoodsReceiptMaster.Where(v => v.PurchaseOrderNo == grdata.PurchaseOrderNo).FirstOrDefault();
                grdata.EditDate = DateTime.Now;
                grdata.TotalAmount = (totalamount.TotalAmount ?? 0) + (grdata.TotalAmount);
                context.TblGoodsReceiptMaster.Update(grdata);
                context.SaveChanges();
            }
            else
            {
                grdata.ReceiptDate = DateTime.Now;
                context.TblGoodsReceiptMaster.Add(grdata);
                context.SaveChanges();
            }
            grdetails.ForEach(x =>
            {

                var mathdr = repo.TblMaterialMaster.FirstOrDefault(im => im.MaterialCode == x.MaterialCode);

                if (Convert.ToString(mathdr.ClosingQty) == null)
                    mathdr.ClosingQty = 0;

                mathdr.ClosingQty = ((mathdr.ClosingQty ?? 0) + (x.ReceivedQty));
                context.TblMaterialMaster.Update(mathdr);

            });
            context.SaveChanges();

            return true;

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
            var material = repo.TblMaterialMaster.ToList();

            repo.TblGoodsReceiptDetails.ToList().ForEach(c =>
            {
                c.MaterialName = material.FirstOrDefault(l => l.MaterialCode == c.MaterialCode)?.Description;
            });

            return repo.TblGoodsReceiptDetails.Where(cd => cd.PurchaseOrderNo == number).OrderByDescending(x => x.ReceivedDate).ToList();

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
        public List<TblInspectionCheckMaster> GetInpectionCheckMaster(SearchCriteria searchCriteria)
        {
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-1);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblInspectionCheckMaster>();
            return repo.TblInspectionCheckMaster.AsEnumerable().ToList();
        }
        public bool AddInpectionCheck(TblInspectionCheckMaster icdata, List<TblInspectionCheckDetails> icdetails)
        {
            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            using var repo = new Repository<TblInspectionCheckMaster>();
            string masternumber = string.Empty;
            var Pcenter = repo.Counters.FirstOrDefault(x => x.CounterName == "QC");
            List<TblInspectionCheckDetails> prDetailsNew;
            List<TblInspectionCheckDetails> prDetailsExist;
            var RejectionMaster = new TblRejectionMaster();
            string Materialcode = icdetails.FirstOrDefault().MaterialCode;
            var SaleOrder = repo.TblSaleOrderMaster.FirstOrDefault(im => im.SaleOrderNo == icdata.saleOrderNumber);
            //var Purcaseorder = repo.TblPurchaseOrder.FirstOrDefault(im => im.SaleOrderNo == icdata.saleOrderNumber);
            var goodsreceipt = repo.TblGoodsReceiptMaster.FirstOrDefault(im => im.SaleorderNo == icdata.saleOrderNumber);
            var goodsissue = repo.TblGoodsIssueMaster.FirstOrDefault(im => im.SaleOrderNumber == icdata.saleOrderNumber);
            var Production = repo.TblProductionMaster.FirstOrDefault(im => im.SaleOrderNumber == icdata.saleOrderNumber);
            try
            {
                if (repo.TblInspectionCheckMaster.Any(v => v.InspectionCheckNo == icdata.InspectionCheckNo && v.MaterialCode == Materialcode))
                {
                    icdata.DrawingRevNo = "QC-F-005 Dated: 01-Apr-2018";
                    icdata.MaterialCode = Materialcode;
                    context.TblInspectionCheckMaster.Update(icdata);
                    context.SaveChanges();
                }
                else
                {
                    if (Pcenter != null)
                    {
                        Pcenter.LastNumber = (Pcenter.LastNumber + 1);
                        context.Counters.UpdateRange(Pcenter);
                        context.SaveChanges();
                        masternumber = Pcenter.Prefix + "-" + Pcenter.LastNumber;
                    }
                    icdata.DrawingRevNo = "QC-F-005 Dated: 01-Apr-2018";
                    icdata.InspectionCheckNo = masternumber;
                    icdata.MaterialCode = Materialcode;
                    if (masternumber.Length > 1)
                        context.TblInspectionCheckMaster.Add(icdata);
                    else
                        throw new Exception("Inspectioncheck Number Not Valid. " + masternumber + " Please check .");


                    context.SaveChanges();
                }

                if (string.IsNullOrEmpty(masternumber))
                    masternumber = icdata.InspectionCheckNo;


                var production = new TblProductionDetails();
                icdetails.ForEach(x =>
                {
                    production = repo.TblProductionDetails.Where(z => z.SaleOrderNumber == icdata.saleOrderNumber && z.ProductionTag == x.productionTag).FirstOrDefault();
                    x.InspectionCheckNo = icdata.InspectionCheckNo;
                    x.Status = icdata.Status;
                    x.Description = icdata.description;
                    x.InspectionType = icdata.InspectionType;
                    x.CompletionDate = icdata.completionDate;
                    x.CompletedBy = icdata.completedBy;
                    x.Status = icdata.Status;
                    x.HeatNumber = icdata.HeatNumber;
                    x.PartDrgNo = icdata.PartDrgNo;
                    x.DrawingRevNo = "QC-F-005 Dated: 01-Apr-2018";
                    production.Status = icdata.Status;
                    if (x.Status == "QC Rejected")
                    {
                        var poq = repo.TblPoQueue.FirstOrDefault(z => z.SaleOrderNo == icdata.saleOrderNumber && z.MaterialCode == icdata.MaterialCode);
                        poq.Qty = 1;
                        poq.Status = "New";
                        context.TblPoQueue.Update(poq);

                        var materialmaster = repo.TblMaterialMaster.FirstOrDefault(xx => xx.MaterialCode == x.MaterialCode);
                        materialmaster.ClosingQty = ((materialmaster.ClosingQty) - 1);
                        context.TblMaterialMaster.UpdateRange(materialmaster);

                        RejectionMaster.SaleOrderNo = x.saleOrderNumber;
                        RejectionMaster.MaterialCode = x.MaterialCode;
                        RejectionMaster.TagNo = x.productionTag;
                        RejectionMaster.Reason = x.Description;
                        context.TblRejectionMaster.Add(RejectionMaster);
                    }
                });

                context.TblProductionDetails.UpdateRange(production);


                prDetailsExist = icdetails.Where(x => x.Id > 0).ToList();
                prDetailsNew = icdetails.Where(x => x.Id == 0).ToList();
                if (prDetailsExist.Count > 0)
                {
                    context.TblInspectionCheckDetails.UpdateRange(icdetails);
                }
                else
                {
                    context.TblInspectionCheckDetails.AddRange(icdetails);
                }

                SaleOrder.Status = "QC Started";
                context.TblSaleOrderMaster.Update(SaleOrder);
                //if (Purcaseorder != null)
                //{
                //    Purcaseorder.Status = "QC Started";
                //    context.TblPurchaseOrder.Update(Purcaseorder);
                //}
                if (goodsreceipt != null)
                {
                    goodsreceipt.Status = "QC Started";
                    context.TblGoodsReceiptMaster.Update(goodsreceipt);
                }
                if (goodsissue != null)
                {
                    goodsissue.Status = "QC Started";
                    context.TblGoodsIssueMaster.Update(goodsissue);
                }
                if (Production != null)
                {
                    Production.Status = "QC Started";
                    context.TblProductionMaster.Update(Production);
                }

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
        public TblInspectionCheckMaster GetInpectionCheckMasterById(string id)
        {
            using var repo = new Repository<TblInspectionCheckMaster>();
            return repo.TblInspectionCheckMaster
                .FirstOrDefault(x => x.InspectionCheckNo == id);
        }

        public TblInspectionCheckMaster GetInpectionCheckMasterById(string materialcode, string saleorder)
        {
            using var repo = new Repository<TblInspectionCheckMaster>();
            return repo.TblInspectionCheckMaster
                .FirstOrDefault(x => x.MaterialCode == materialcode && x.saleOrderNumber == saleorder);
        }
        public List<TblInspectionCheckDetails> GetInspectionCheckDetails(string number)
        {
            using var repo = new Repository<TblInspectionCheckDetails>();
            return repo.TblInspectionCheckDetails.Where(cd => cd.InspectionCheckNo == number).ToList();
        }

        public TblInspectionCheckMaster GetInpectionCheckMaster(string saleorder)
        {
            using var repo = new Repository<TblInspectionCheckMaster>();
            return repo.TblInspectionCheckMaster
                .FirstOrDefault(x => x.saleOrderNumber == saleorder);
        }
        public List<TblInspectionCheckDetails> GetInspectionCheckDetailsBySaleorder(string saleorder)
        {
            using var repo = new Repository<TblInspectionCheckDetails>();

            var MaterialCodes = repo.TblMaterialMaster.ToList();

            repo.TblInspectionCheckDetails.ToList()
                .ForEach(c =>
                {
                    c.MaterialName = MaterialCodes.FirstOrDefault(z => z.MaterialCode == c.MaterialCode)?.Description;
                    c.hsnNo = MaterialCodes.FirstOrDefault(z => z.MaterialCode == c.MaterialCode)?.Hsnsac;

                });
            return repo.TblInspectionCheckDetails.Where(cd => cd.saleOrderNumber == saleorder).ToList();
        }

        public bool ReturnInpectionCheckMaster(string code)
        {
            using var repo = new ERPContext();
            var poHeader = repo.TblInspectionCheckMaster.FirstOrDefault(im => im.InspectionCheckNo == code);

            if (poHeader != null)
                throw new Exception($"Analysis Inspection CheckNo memo no {code} already return.");

            if (poHeader != null)
            {
                repo.TblInspectionCheckMaster.Update(poHeader);
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
            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-100), ToDate = DateTime.Today };
            searchCriteria.FromDate ??= DateTime.Today.AddDays(-100);
            searchCriteria.ToDate ??= DateTime.Today;

            using var repo = new Repository<TblSaleOrderMaster>();

            var Company = repo.TblCompany.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var customer = repo.TblBusinessPartnerAccount.ToList();

            repo.TblSaleOrderMaster.ToList()
                .ForEach(c =>
                {
                    c.CompanyName = Company.FirstOrDefault(l => l.CompanyCode == c.Company).CompanyName;
                    c.ProfitcenterName = profitCenters.FirstOrDefault(p => p.Code == c.ProfitCenter).Name;
                    c.SupplierName = customer.FirstOrDefault(m => m.Bpnumber == c.CustomerCode).Name;

                });

            return repo.TblSaleOrderMaster.AsEnumerable()
                .Where(x =>
                {

                    //Debug.Assert(x.CreatedDate != null, "x.CreatedDate != null");
                    return Convert.ToString(x.SaleOrderNo) != null
                              && Convert.ToString(x.SaleOrderNo).Contains(searchCriteria.searchCriteria ?? Convert.ToString(x.SaleOrderNo))
                              && Convert.ToDateTime(x.CreatedDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                              && Convert.ToDateTime(x.CreatedDate.Value.ToShortDateString()) <= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());
                }).OrderByDescending(x => x.Id)
                .ToList();
        }

        public TblSaleOrderMaster GetSaleOrderMastersById(string saleOrderNo)
        {
            using var repo = new Repository<TblSaleOrderMaster>();
            return repo.TblSaleOrderMaster
                .FirstOrDefault(x => x.SaleOrderNo == saleOrderNo);
        }


        public TblSaleOrderMaster GetSaleOrderMaster(string saleOrderNo)
        {
            using var repo = new Repository<TblSaleOrderMaster>();

            var Company = repo.TblCompany.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var customer = repo.TblBusinessPartnerAccount.ToList();

            repo.TblSaleOrderMaster.ToList()
                .ForEach(c =>
                {
                    c.CompanyName = Company.FirstOrDefault(l => l.CompanyCode == c.Company).CompanyName;
                    c.ProfitcenterName = profitCenters.FirstOrDefault(p => p.Code == c.ProfitCenter).Name;
                    c.SupplierName = customer.FirstOrDefault(m => m.Bpnumber == c.CustomerCode).Name;

                });
            return repo.TblSaleOrderMaster
                .FirstOrDefault(x => x.SaleOrderNo == saleOrderNo);
        }

        public tblQCMaster GetQCMaster(string MaterialCode)
        {
            using var repo = new Repository<tblQCMaster>();

            var MaterialCodes = repo.TblMaterialMaster.ToList();

            repo.tblQCMaster.ToList()
                .ForEach(c =>
                {
                    c.MaterialName = MaterialCodes.FirstOrDefault(z => z.MaterialCode == c.MaterialCode)?.Description;

                });
            return repo.tblQCMaster
                .FirstOrDefault(x => x.MaterialCode == MaterialCode);
        }

        public List<TblSaleOrderDetail> GetSaleOrdersDetails(string saleOrderNo)
        {
            using var repo = new Repository<TblSaleOrderDetail>();
            var MaterialCodes = repo.TblMaterialMaster.ToList();

            repo.TblSaleOrderDetail.ToList().ForEach(c =>
            {
                c.AvailableQTY = Convert.ToInt32(MaterialCodes.FirstOrDefault(l => l.MaterialCode == c.MaterialCode)?.ClosingQty);
                c.MaterialName = MaterialCodes.FirstOrDefault(z => z.MaterialCode == c.MaterialCode)?.Description;
            });
            return repo.TblSaleOrderDetail.Where(cd => cd.SaleOrderNo == saleOrderNo).ToList();

        }
        public bool AddSaleOrder(TblSaleOrderMaster saleOrderMaster, List<TblSaleOrderDetail> saleOrderDetails)
        {
            // string suppliername=string.Empty;
            saleOrderMaster.CreatedDate ??= DateTime.Now;
            using var repo = new Repository<TblSaleOrderMaster>();
            List<TblSaleOrderDetail> saleOrderDetailsNew;
            List<TblSaleOrderDetail> saleOrderDetailsExist;
            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();
            string SaleOrderNumber = string.Empty;
            int totalqty;
            totalqty = (int)saleOrderDetails.Sum(a => a.QTY);
            var Pcenter = repo.ProfitCenters.Where(x => x.Code == saleOrderMaster.ProfitCenter).FirstOrDefault();
            var Quotation = repo.TblSupplierQuotationsMaster.Where(x => x.QuotationNumber == saleOrderMaster.PONumber).FirstOrDefault();

            try
            {
                if (repo.TblSaleOrderMaster.Any(v => v.SaleOrderNo == saleOrderMaster.SaleOrderNo))
                {
                    saleOrderMaster.Status = "SO Created";
                    saleOrderMaster.TotalQty = totalqty;
                    //saleOrderMaster.CreatedDate = DateTime.Now;
                    // saleOrderMaster.CustomerCode = suppliername;
                    //invoiceDetails.Sum(x => x.Qty);
                    context.TblSaleOrderMaster.Update(saleOrderMaster);
                    context.SaveChanges();
                }
                else
                {
                    if (repo.TblSaleOrderMaster.Any(z => z.PONumber == saleOrderMaster.PONumber))
                    {
                        throw new Exception("PO Number Already Exist. " + saleOrderMaster.PONumber + " Please check .");
                    }

                    if (Pcenter != null)
                    {
                        Pcenter.SONumber = (Pcenter.SONumber + 1);
                        context.ProfitCenters.UpdateRange(Pcenter);
                        context.SaveChanges();
                        SaleOrderNumber = Pcenter.SOPrefix + "-" + Pcenter.SONumber;
                    }

                    saleOrderMaster.Status = "SO Created";
                    saleOrderMaster.CreatedDate = DateTime.Now;
                    saleOrderMaster.SaleOrderNo = SaleOrderNumber;
                    saleOrderMaster.TotalQty = totalqty;
                    if (SaleOrderNumber.Length > 1)
                        context.TblSaleOrderMaster.Add(saleOrderMaster);
                    else
                        throw new Exception("Saleorder Number Not Valid. " + SaleOrderNumber + " Please check .");


                    if (Quotation != null)
                    {
                        Quotation.Status = "SO Created";

                        context.TblSupplierQuotationsMaster.Update(Quotation);
                    }
                    context.SaveChanges();
                }
                if (string.IsNullOrWhiteSpace(SaleOrderNumber))
                    SaleOrderNumber = saleOrderMaster.SaleOrderNo;

                saleOrderDetails.ForEach(x =>
                {

                    x.SaleOrderNo = (SaleOrderNumber);
                });

                foreach (var item in saleOrderDetails)
                {
                    int poqty = 0;
                    int soqty = 0;
                    int matqty = 0;
                    var purchaseorder = repo.TblPurchaseOrderDetails.Where(z => z.MaterialCode == item.MaterialCode && z.Status == "PO Created").ToList();
                    var pod = repo.TblPurchaseOrderDetails.FirstOrDefault(z => z.SaleOrder == item.SaleOrderNo && z.MaterialCode == item.MaterialCode);
                    var material = repo.TblMaterialMaster.FirstOrDefault(z => z.MaterialCode == item.MaterialCode);
                    var poq = repo.TblPoQueue.FirstOrDefault(z => z.SaleOrderNo == item.SaleOrderNo && z.MaterialCode == item.MaterialCode);
                    if (pod != null)
                    {
                        pod.SOQty = item.QTY;
                        context.TblPurchaseOrderDetails.Update(pod);
                    }
                    poqty = purchaseorder.Sum(x => x.Qty);
                    soqty = saleOrderDetails.Sum(s => s.QTY);
                    if (material.ClosingQty == null)
                        material.ClosingQty = 0;

                    matqty = Convert.ToInt16(material.ClosingQty);
                    if (poq == null)
                    {
                        poq = new TblPoQueue();
                        poq.Qty = Math.Abs((matqty + poqty) - soqty);
                        poq.Status = "New";
                        poq.SaleOrderNo = item.SaleOrderNo;
                        poq.MaterialCode = item.MaterialCode;
                        context.TblPoQueue.AddRange(poq);
                    }
                    else
                    {
                        poq.Qty = Math.Abs((matqty + poqty) - soqty);
                        poq.Status = "New";
                        poq.SaleOrderNo = item.SaleOrderNo;
                        poq.MaterialCode = item.MaterialCode;
                        context.TblPoQueue.UpdateRange(poq);
                    }
                }

                saleOrderDetailsExist = saleOrderDetails.Where(x => x.ID > 0).ToList();
                saleOrderDetailsNew = saleOrderDetails.Where(x => x.ID == 0).ToList();

                if (saleOrderDetailsExist.Count > 0)
                {
                    context.TblSaleOrderDetail.UpdateRange(saleOrderDetails);
                }
                else if (saleOrderDetailsNew.Count > 0)
                {
                    context.TblSaleOrderDetail.AddRange(saleOrderDetails);
                }

                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                TblApi_Error_Log icdata = new TblApi_Error_Log();
                using var context1 = new ERPContext();
                icdata.ScreenName = "Sale Order";
                icdata.ErrorID = ex.HResult.ToString();
                icdata.ErrorMessage = ex.ToString();
                context1.TblApi_Error_Log.Add(icdata);
                context1.SaveChanges();

                dbtrans.Rollback();
                throw;
            }
        }

        public bool AddQCConfig(tblQCMaster QCMaster, List<tblQCDetails> QCDetails)
        {

            using var repo = new Repository<tblQCMaster>();
            List<tblQCDetails> QCDetailsNew;
            List<tblQCDetails> QCDetailsExist;
            using var context = new ERPContext();
            using var dbtrans = context.Database.BeginTransaction();

            try
            {
                if (repo.tblQCMaster.Any(v => v.Code == QCMaster.Code))
                {
                    context.tblQCMaster.Update(QCMaster);
                    context.SaveChanges();
                }
                else
                {
                    if (repo.tblQCMaster.Any(v => v.MaterialCode == QCMaster.MaterialCode && v.Type == QCMaster.Type))
                        throw new Exception("Material Code Already Registered " + QCMaster.MaterialCode);
                    else
                        context.tblQCMaster.Add(QCMaster);
                    context.SaveChanges();
                }

                QCDetails.ForEach(x =>
                {
                    x.Code = QCMaster.Code;
                    x.Type = QCMaster.Type;
                    x.MaterialCode = QCMaster.MaterialCode;
                });

                QCDetailsExist = QCDetails.Where(x => x.ID > 0).ToList();
                QCDetailsNew = QCDetails.Where(x => x.ID == 0).ToList();

                if (QCDetailsExist.Count > 0)
                {
                    context.tblQCDetails.UpdateRange(QCDetails);
                }
                else
                {
                    context.tblQCDetails.AddRange(QCDetails);
                }
                context.SaveChanges();

                dbtrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                TblApi_Error_Log icdata = new TblApi_Error_Log();
                using var context1 = new ERPContext();
                icdata.ScreenName = "QC Config";
                icdata.ErrorID = ex.HResult.ToString();
                if (ex.InnerException != null)
                    icdata.ErrorMessage = ex.InnerException.Message.ToString();
                else
                    icdata.ErrorMessage = ex.Message;

                context1.TblApi_Error_Log.Add(icdata);
                context1.SaveChanges();

                dbtrans.Rollback();
                throw;
            }
        }

        public bool AddQCResult(List<tblQCResults> QCResults, List<TblInspectionCheckMaster> QCMaster)
        {

            using var repo = new Repository<tblQCResults>();
            List<tblQCResults> QCDetailsNew;
            List<tblQCResults> QCDetailsExist;
            using var context = new ERPContext();

            try
            {

                foreach (var item in QCMaster)
                {
                    foreach (var item1 in QCResults)
                    {
                        item1.MaterialCode = item.MaterialCode;
                        item1.TagName = item.productionTag;
                        item1.saleOrderNumber = item.saleOrderNumber;
                        item1.Type = item.InspectionType;
                        item1.Uom = item1.UOMName;
                        if (item.Type != "edit")
                            item1.Id = 0;
                    }


                    QCDetailsExist = QCResults.Where(x => x.Id > 0).ToList();
                    QCDetailsNew = QCResults.Where(x => x.Id == 0).ToList();

                    if (QCDetailsExist.Count > 0)
                    {
                        context.tblQCResults.UpdateRange(QCDetailsExist);
                    }
                    else
                    {
                        context.tblQCResults.AddRange(QCDetailsNew);
                    }
                    using var dbtrans = context.Database.BeginTransaction();
                    context.SaveChanges();
                    dbtrans.Commit();
                    QCDetailsNew = new List<tblQCResults>();
                    QCDetailsExist = new List<tblQCResults>();
                }

                return true;
            }
            catch (Exception ex)
            {
                TblApi_Error_Log icdata = new TblApi_Error_Log();
                using var context1 = new ERPContext();
                icdata.ScreenName = "QC Results";
                icdata.ErrorID = ex.HResult.ToString();
                icdata.ErrorMessage = ex.InnerException.Message.ToString();
                context1.TblApi_Error_Log.Add(icdata);
                context1.SaveChanges();

                //dbtrans.Rollback();
                throw;
            }
        }

        #endregion

    }
}

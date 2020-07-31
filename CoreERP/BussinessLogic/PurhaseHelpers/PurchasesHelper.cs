using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.PurhaseHelpers
{
    public class PurchasesHelper
    {
        public string GeneratePurchaseInvoiceNo(string branchCode,out string errorMessage)
        {
            try
            {
                string invoiceNo = string.Empty, prefix = string.Empty, suffix = string.Empty;
                errorMessage = string.Empty;

                // var invoiceNo =new Common.CommonHelper().GenerateNumber(13, branchCode);
                TblPurchaseInvoice _purchaseInvoice = null;
                using (Repository<TblInvoiceMaster> _repo = new Repository<TblInvoiceMaster>())
                {
                    _purchaseInvoice = _repo.TblPurchaseInvoice.Where(x => x.BranchCode == branchCode).OrderByDescending(x => x.PurchaseInvId).FirstOrDefault();

                    if (_purchaseInvoice != null)
                    {
                        var invSplit = _purchaseInvoice.PurchaseInvNo.Split('-');
                        invoiceNo = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1]) + 1}-{invSplit[2]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(13, branchCode, out prefix, out suffix);
                        if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                        {
                            errorMessage = $"No prefix and suffix confugured for branch code: {branchCode} ";
                            return invoiceNo = string.Empty;
                        }

                        invoiceNo = $"{prefix}-1-{suffix}";
                    }
                }

                return invoiceNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblStateWiseGst> GetStateWiseGsts(string stateCode = null)
        {
            try
            {
                using (Repository<TblStateWiseGst> repo = new Repository<TblStateWiseGst>())
                {
                    return repo.TblStateWiseGst.Where(s => s.StateCode == (stateCode ?? s.StateCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblPurchaseInvoiceDetail GetProductDeatilsSectionRcd(string branchCode, string productCode)
        {
            try
            {
              bool  IsTaxApplicable = false;
                var _invoiceHelper = new InvoiceHelper();
                var _product =_invoiceHelper.GetProducts(productCode).FirstOrDefault();

                //check tax calculation is required or not
                if (_product.TaxapplicableOn != null)
                {
                    if (_product.TaxapplicableOn.Equals("OUTPUT", StringComparison.InvariantCultureIgnoreCase) || _product.TaxapplicableOn.Equals("NONE", StringComparison.InvariantCultureIgnoreCase))
                    {
                        IsTaxApplicable = false;
                    }
                    else
                    {
                        IsTaxApplicable = true;
                    }
                }

               // var invoceDetails = new TblInvoiceDetail();
                var purchaseDetail = new TblPurchaseInvoiceDetail();

                purchaseDetail.UnitId = Convert.ToDecimal(_product.UnitId ?? 0);
                purchaseDetail.UnitName = _product.UnitName;

                purchaseDetail.TaxStructureCode = Convert.ToDecimal(_product.TaxStructureCode ?? 0);
                purchaseDetail.TaxStructureId = Convert.ToDecimal(_product.TaxStructureId ?? 0);
                purchaseDetail.TaxGroupCode = _product.TaxGroupCode;
                purchaseDetail.TaxGroupId = Convert.ToDecimal(_product.TaxGroupId ?? 0);
                //purchaseDetail.TaxGroupName = _product.TaxGroupName;
                if (_product.TaxStructureCode != null)
                {
                    if (IsTaxApplicable)
                    {
                        var taxStructure = _invoiceHelper.GetTaxStructure(Convert.ToDecimal(_product.TaxStructureCode));
                        if (taxStructure != null)
                        {
                            purchaseDetail.Sgst = taxStructure.Sgst;
                            purchaseDetail.Cgst = taxStructure.Sgst;
                            purchaseDetail.Igst = taxStructure.Igst;
                            purchaseDetail.TotalGst = taxStructure.TotalGst;
                        }
                    }
                    else
                    {
                        purchaseDetail.Sgst = 0;
                        purchaseDetail.Cgst = 0;
                        purchaseDetail.Igst = 0;
                        purchaseDetail.TotalGst = 0;
                    }
                   
                   
                }
              
                purchaseDetail.Rate = _invoiceHelper.GetProductRate(branchCode, productCode);
                purchaseDetail.HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0);
                purchaseDetail.ProductId = _product.ProductId;
                purchaseDetail.ProductCode = _product.ProductCode;
                purchaseDetail.ProductName = _product.ProductName;
                purchaseDetail.ServerDateTime = DateTime.Now;

                return purchaseDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblBranch> GetBranches(string branchCode = null)
        {
            try
            {
                return new InvoiceHelper().GetBranches(branchCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblAccountLedger GetAccountLedgers(string ledgercode)
        {
            try
            {
                return new InvoiceHelper().GetAccountLedgersByCode(ledgercode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblProduct> GetProducts(string productCode)
        {
            try
            {
                return new InvoiceHelper().GetProducts(productCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblTaxStructure GetTaxStructure(decimal taxStructureId)
        {
            try
            {
                return new InvoiceHelper().GetTaxStructure(taxStructureId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblAccountLedger> GetAccountLedgersByLedgerId(decimal ledgerId)
        {
            try
            {
                return new InvoiceHelper().GetAccountLedgersByLedgerId(ledgerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblTanks> GetTanks(string branchCode,string tankNo)
        {
            try
            {
                using(Repository<TblTanks> _repo=new Repository<TblTanks>())
                {
                    return _repo.TblTanks.AsEnumerable()
                                .Where(t => t.BranchCode == branchCode
                                        && t.TankNo.Contains(tankNo))
                                .GroupBy(x => x.TankNo)
                                .Select(grp=> grp.FirstOrDefault())
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        #region register Purchase Record
        public List<TblVoucherType> GetVoucherType(decimal voucherTypeId)
        {
            try
            {
                using (Repository<TblVoucherType> repo = new Repository<TblVoucherType>())
                {
                    //return repo.TblVoucherType.Where(v => v.VoucherTypeId == voucherTypeId).ToList();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddPurchaseRecords(IConfiguration configuration,TblPurchaseInvoice purchaseInvoice,List<TblPurchaseInvoiceDetail> purchaseInvoiceDetails,out string errorMessage)
        {
            
            try
            {
                errorMessage = string.Empty;
                decimal? _qty = null;
                TblUserNew userNew = null;
                var _productCodes = configuration.GetSection("Purchase:ProductCods")?.Value?.Split(",");
                foreach(var pdtl in purchaseInvoiceDetails)
                {
                    if (_productCodes.Count() > 0)
                    {
                        if (_productCodes.Contains(pdtl.ProductCode.ToUpper()))
                        {
                            if (pdtl.TankNo == null)
                            {
                                errorMessage = "Tank no Canot be null for product code:" + pdtl.ProductCode;
                                return false;
                            }
                        }
                    }
                }

                userNew = new UserManagmentHelper().GetUserNew(purchaseInvoice.UserId);
                purchaseInvoice.EmployeeId = userNew?.EmployeeId ?? -1;

                using (ERPContext context=new ERPContext())
                {
                    using(var dbTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(purchaseInvoice.UserId, null));
                            TblProduct _product = null;
                            TblTaxStructure _taxStructure = null;

                            //add voucher typedetails
                            var _branch = GetBranches(purchaseInvoice.BranchCode).FirstOrDefault();
                            var _accountLedger = GetAccountLedgers(purchaseInvoice.LedgerCode);
                            var _vouchertType = GetVoucherType(13).FirstOrDefault();
                            var paymentType = new Common.CommonHelper().GetPaymentType(_accountLedger.CrOrDr);
                            purchaseInvoice.PaymentMode = paymentType == null ? 0 : paymentType.PaymentTypeId;
                            purchaseInvoice.LedgerId = _accountLedger.LedgerId;
                            purchaseInvoice.BranchName = _branch.BranchName;
                            purchaseInvoice.EmployeeId = new UserManagmentHelper().GetEmployeeID(purchaseInvoice.UserName)?.EmployeeId;
                            purchaseInvoice.Discount = purchaseInvoice.Discount ?? 0;
                            purchaseInvoice.OtherAmount1 = purchaseInvoice.OtherAmount1 ?? 0;
                            purchaseInvoice.OtherAmount2 = purchaseInvoice.OtherAmount2 ?? 0;
                            purchaseInvoice.ShiftId = shifId;
                            purchaseInvoice.VoucherTypeId = 13;
                            purchaseInvoice.ServerDateTime = DateTime.Now;
                            purchaseInvoice.PurchaseInvDate = purchaseInvoice.PurchaseInvDate ?? DateTime.Now;
                            purchaseInvoice.IsPurchaseReturned = false;

                            #region Add voucher master record
                            //var _voucherMaster = AddVoucherMaster(context, purchaseInvoice, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                            #endregion

                           
                            //purchaseInvoice.VoucherNo = _voucherMaster.VoucherMasterId.ToString();
                            context.TblPurchaseInvoice.Add(purchaseInvoice);
                            context.SaveChanges();

                            foreach (var purInv in purchaseInvoiceDetails)
                            {
                                _product = GetProducts(purInv.ProductCode).FirstOrDefault();
                                _taxStructure = GetTaxStructure(Convert.ToDecimal(_product.TaxStructureCode));
                                _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.PurchaseAccount).FirstOrDefault();


                                #region InvioceDetail
                                
                                purInv.BatchNo = DateTime.Now.ToShortDateString().Replace('-', '/')+purchaseInvoice.PurchaseInvNo+purInv.ProductCode;
                                purInv.EmployeeId = purchaseInvoice.EmployeeId;
                                purInv.PurchaseDate = purchaseInvoice.PurchaseInvDate;
                                purInv.PurchaseInvId = purchaseInvoice.PurchaseInvId;
                                purInv.VoucherNo = purchaseInvoice.VoucherNo;
                                purInv.PurchaseNo = purchaseInvoice.PurchaseInvNo;
                                purInv.StateCode = purchaseInvoice.StateCode;
                                purInv.ShiftId = purchaseInvoice.ShiftId;
                                purInv.UserId = purchaseInvoice.UserId;
                                purInv.EmployeeId = -1;
                                purInv.ServerDateTime = DateTime.Now;
                                purInv.ShiftId = shifId;
                                context.TblPurchaseInvoiceDetail.Add(purInv);
                                context.SaveChanges();

                                #endregion

                                #region Add voucher Details
                                _accountLedger.CrOrDr = "Debit";
                                //var _voucherDetail = AddVoucherDetails(context, purchaseInvoice, _branch, _voucherMaster, _accountLedger, purInv.GrossAmount);
                                #endregion

                                #region Add stock transaction  and Account Ledger Transaction

                                _qty = null;
                                if (purInv.TotalLiters != null)
                                {
                                    if (purInv.TotalLiters > 0)
                                        _qty = purInv.TotalLiters;
                                }
                                
                                if (purInv.Qty != null)
                                {
                                    if (purInv.Qty > 0 && _qty== null)
                                        _qty = purInv.Qty;
                                }
                                
                                if (purInv.FQty != null)
                                {
                                    if (purInv.FQty > 0 && _qty == null)
                                        _qty = purInv.FQty;
                                }

                                AddStockInformation(context, purchaseInvoice, _branch, _product, _qty, purInv.Rate);

                                //AddAccountLedgerTransactions(context, _voucherDetail, purchaseInvoice.PurchaseInvDate);
                                #endregion
                            }

                            _accountLedger = GetAccountLedgers(purchaseInvoice.LedgerCode);
                            _accountLedger.CrOrDr = "Credit";
                            //var voucherDetail=AddVoucherDetails(context, purchaseInvoice, _branch, _voucherMaster, _accountLedger, purchaseInvoice.TotalAmount, false);
                            //AddAccountLedgerTransactions(context, voucherDetail, purchaseInvoice.PurchaseInvDate);

                            //CHech weather igs or sg ,cg st
                            var _stateWiseGsts = GetStateWiseGsts(purchaseInvoice.StateCode).FirstOrDefault();
                            if (_stateWiseGsts.Igst == 1)
                            {
                                //Add IGST record
                                var _accAL = GetAccountLedgers("243");
                                _accAL.CrOrDr= "Debit";
                               //var voucherDetailIGST= AddVoucherDetails(context, purchaseInvoice, _branch, _voucherMaster, _accAL, purchaseInvoice.TotalIgst, false);
                                //AddAccountLedgerTransactions(context, voucherDetailIGST, purchaseInvoice.PurchaseInvDate);
                            }
                            else
                            {
                                // cgst
                                var _accAL = GetAccountLedgers("240");
                                _accAL.CrOrDr = "Debit";
                                //var voucherDetailCGST = AddVoucherDetails(context, purchaseInvoice, _branch, _voucherMaster, _accAL, purchaseInvoice.TotalCgst, false);
                                //AddAccountLedgerTransactions(context, voucherDetailCGST, purchaseInvoice.PurchaseInvDate);
                                // sgst
                                _accAL = GetAccountLedgers("241");
                                _accAL.CrOrDr = "Debit";
                                //var voucherDetailSGST = AddVoucherDetails(context, purchaseInvoice, _branch, _voucherMaster, _accAL, purchaseInvoice.TotalSgst, false);
                                //AddAccountLedgerTransactions(context, voucherDetailSGST, purchaseInvoice.PurchaseInvDate);
                            }
                            dbTransaction.Commit();
                            return true;
                        }
                        catch(Exception e)
                        {
                            dbTransaction.Rollback();
                            throw e;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private TblVoucherMaster AddVoucherMaster(ERPContext context, TblPurchaseInvoice purchaseinvoice, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {
                var _voucherMaster = new TblVoucherMaster();
                _voucherMaster.BranchCode = purchaseinvoice.BranchCode;
                _voucherMaster.BranchName = branch.BranchName;
                _voucherMaster.VoucherDate = purchaseinvoice.PurchaseInvDate;
                _voucherMaster.VoucherTypeIdMain = voucherTypeId;
                _voucherMaster.VoucherTypeIdSub = 35;
                _voucherMaster.VoucherNo = purchaseinvoice.PurchaseInvNo;
                _voucherMaster.Amount = purchaseinvoice.GrandTotal;
                _voucherMaster.PaymentType = paymentType;//accountLedger.CrOrD
                _voucherMaster.Narration = "Purchase Invoice";
                _voucherMaster.ServerDate = DateTime.Now;
                _voucherMaster.UserId = purchaseinvoice.UserId;
                _voucherMaster.UserName = purchaseinvoice.UserName;
                _voucherMaster.ShiftId = purchaseinvoice.ShiftId;
                _voucherMaster.EmployeeId = purchaseinvoice.EmployeeId ?? -1;

                context.TblVoucherMaster.Add(_voucherMaster);
                if (context.SaveChanges() > 0)
                {
                    return _voucherMaster;
                }
               

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TblVoucherDetail AddVoucherDetails(ERPContext context, TblPurchaseInvoice invoice,TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, bool isFromInvoiceDetials = true)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
                var _voucherDetail = new TblVoucherDetail();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                //_voucherDetail.BranchId = _branch.Id;
                _voucherDetail.CostCenter = _voucherDetail.BranchCode = invoice.BranchCode;
                _voucherDetail.BranchName = invoice.BranchName;
                _voucherDetail.Amount = productRate;
                _voucherDetail.TransactionType = _accountLedger.CrOrDr;
                _voucherDetail.ServerDate = DateTime.Now;
                _voucherDetail.Narration = $"Purchase Invoice {_accountLedger.LedgerName} A /c: {_voucherDetail.TransactionType}";

                if (isFromInvoiceDetials)
                {
                    _voucherDetail.FromLedgerId = _accountLedger.LedgerId;
                    _voucherDetail.FromLedgerCode = _accountLedger.LedgerCode;
                    _voucherDetail.FromLedgerName = _accountLedger.LedgerName;

                    _voucherDetail.ToLedgerId = invoice.LedgerId;
                    _voucherDetail.ToLedgerCode = invoice.LedgerCode;
                    _voucherDetail.ToLedgerName = invoice.LedgerName;

                   
                }
                else
                {
                    _voucherDetail.FromLedgerId = -1;
                    _voucherDetail.FromLedgerCode = string.Empty;
                    _voucherDetail.FromLedgerName = string.Empty;

                    _voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                    _voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                    _voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                }
               

                context.TblVoucherDetail.Add(_voucherDetail);
                if (context.SaveChanges() > 0)
                    return _voucherDetail;

               
                return null;
                // }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TblStockInformation AddStockInformation(ERPContext context, TblPurchaseInvoice invoice, TblBranch _branch, TblProduct _product, decimal? qty, decimal? rate)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
                var _stockInformation = new TblStockInformation();

                //_stockInformation.BranchId = _branch.Id;
                _stockInformation.BranchCode = _branch.BranchCode;
                _stockInformation.ShiftId = invoice.ShiftId;
                _stockInformation.VoucherNo = invoice.VoucherNo;
                _stockInformation.VoucherTypeId = invoice.VoucherTypeId;
                _stockInformation.InvoiceNo = invoice.PurchaseInvNo;
                _stockInformation.ProductId = _product.ProductId;
                _stockInformation.ProductCode = _product.ProductCode;
                _stockInformation.InwardQty = qty ?? 0;
                _stockInformation.OutwardQty = 0;
                _stockInformation.Rate = rate;
                _stockInformation.UserId = invoice.UserId;

                context.TblStockInformation.Add(_stockInformation);
                if (context.SaveChanges() > 0)
                    return _stockInformation;

                #region Comment
                //var _stockInformation = new TblStockInformation();

                //_stockInformation.BranchId = _branch.BranchId;
                //_stockInformation.BranchCode = _branch.BranchCode;
                //_stockInformation.ShiftId = invoice.ShiftId;
                //_stockInformation.VoucherNo = invoice.VoucherNo;
                //_stockInformation.VoucherTypeId = invoice.VoucherTypeId;
                //_stockInformation.InvoiceNo = invoice.InvoiceNo;
                //_stockInformation.ProductId = _product.ProductId;
                //_stockInformation.ProductCode = _product.ProductCode;
                //_stockInformation.OutwardQty = invdtl.Qty > 0 ? invdtl.Qty : invdtl.FQty;
                //_stockInformation.Rate = invdtl.Rate;

                //repo.TblStockInformation.Add(_stockInformation);
                //repo.SaveChanges();
                #endregion

                return null;
                //  }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context, TblVoucherDetail _voucherDetail, DateTime? invoiceDate)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
                var _accountLedgerTransactions = new TblAccountLedgerTransactions();
                _accountLedgerTransactions.VoucherDetailId = _voucherDetail.VoucherDetailId;
                _accountLedgerTransactions.LedgerId = _voucherDetail.ToLedgerId;
                _accountLedgerTransactions.LedgerCode = _voucherDetail.ToLedgerCode;
                _accountLedgerTransactions.LedgerName = _voucherDetail.ToLedgerName;
                _accountLedgerTransactions.BranchId = _voucherDetail.BranchId;
                _accountLedgerTransactions.BranchCode = _voucherDetail.BranchCode;
                _accountLedgerTransactions.BranchName = _voucherDetail.BranchName;
                _accountLedgerTransactions.TransactionDate = invoiceDate;
                _accountLedgerTransactions.TransactionType = _voucherDetail.TransactionType;
                _accountLedgerTransactions.VoucherAmount = _voucherDetail.Amount;

                if (_accountLedgerTransactions.TransactionType.ToUpper() =="DEBIT")
                {
                    _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
                }
                else if (_accountLedgerTransactions.TransactionType.ToUpper() =="CREDIT")
                {
                    _accountLedgerTransactions.CreditAmount = _accountLedgerTransactions.VoucherAmount;
                    _accountLedgerTransactions.DebitAmount = Convert.ToDecimal("0.00");
                }

                context.TblAccountLedgerTransactions.Add(_accountLedgerTransactions);
                if (context.SaveChanges() > 0)
                    return _accountLedgerTransactions;


                return null;
                //  }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Search Purchase Records in Master Table

        public List<TblPurchaseInvoice> GetPurchaseInvoices(SearchCriteria searchCriteria, string branchCode)
        {
            try
            {
                using Repository<TblPurchaseInvoice> repo = new Repository<TblPurchaseInvoice>();
                List<TblPurchaseInvoice> _purchaseList = null;
                if (searchCriteria.Role == 1)
                {
                    if (searchCriteria.FromDate != null || searchCriteria.FromDate != null)
                    {
                        _purchaseList = repo.TblPurchaseInvoice.AsEnumerable()
                         .Where(pi =>
                                    DateTime.Parse(pi.PurchaseInvDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? pi.PurchaseInvDate).Value.ToShortDateString())
                                  && DateTime.Parse(pi.PurchaseInvDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? pi.PurchaseInvDate).Value.ToShortDateString())
                                  && pi.PurchaseInvNo.Contains(searchCriteria.InvoiceNo ?? pi.PurchaseInvNo)
                                  && !pi.IsPurchaseReturned.Value)
                          .ToList();
                    }
                    else
                    {
                        _purchaseList = repo.TblPurchaseInvoice.AsEnumerable()
                         .Where(pi =>
                                    pi.PurchaseInvDate.Value.Year == DateTime.Now.Year
                                  && pi.PurchaseInvNo.Contains(searchCriteria.InvoiceNo ?? pi.PurchaseInvNo)
                                  && !pi.IsPurchaseReturned.Value)
                          .ToList();
                    }
                }
                else
                {
                    if (searchCriteria.FromDate != null || searchCriteria.FromDate != null)
                    {
                        _purchaseList = repo.TblPurchaseInvoice.AsEnumerable()
                          .Where(pi =>
                                     DateTime.Parse(pi.PurchaseInvDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? pi.PurchaseInvDate).Value.ToShortDateString())
                                   && DateTime.Parse(pi.PurchaseInvDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? pi.PurchaseInvDate).Value.ToShortDateString())
                                   && pi.BranchCode == branchCode
                                   && !pi.IsPurchaseReturned.Value)
                           .ToList();
                    }
                    else
                    {
                        _purchaseList = repo.TblPurchaseInvoice.AsEnumerable()
                                                .Where(pi =>
                                                           pi.PurchaseInvDate.Value.Year == DateTime.Now.Year
                                                         && pi.PurchaseInvNo.Contains(searchCriteria.InvoiceNo ?? pi.PurchaseInvNo)
                                                         && pi.PurchaseInvDate.Value.Year == DateTime.Now.Year
                                                         && pi.BranchCode == branchCode
                                                         && !pi.IsPurchaseReturned.Value)
                                                 .ToList();
                    }
                }


                if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo))
                {
                    _purchaseList = _purchaseList.Where(x => x.PurchaseInvNo == searchCriteria.InvoiceNo).ToList();

                    if (_purchaseList.Count() == 0)
                        repo.TblPurchaseInvoice.AsEnumerable().Where(x => x.PurchaseInvNo == searchCriteria.InvoiceNo).ToList();
                }
                if (searchCriteria.Role != 1)
                {
                    _purchaseList = _purchaseList.Where(x => x.BranchCode == branchCode).ToList();
                }

                return _purchaseList.OrderByDescending(x => x.PurchaseInvDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public List<TblPurchaseInvoice> GetPurchaseInvoices(string branchCode,SearchCriteria searchCriteria)
        //{
        //    try
        //    {
        //        using(Repository<TblPurchaseInvoice> repo=new Repository<TblPurchaseInvoice>())
        //        {
        //            List<TblPurchaseInvoice> _purchaseList = null;



        //            _purchaseList= repo.TblPurchaseInvoice.AsEnumerable()
        //                               .Where(inv => DateTime.Parse(inv.PurchaseInvDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? inv.PurchaseInvDate).Value.ToShortDateString())
        //                                         && DateTime.Parse(inv.PurchaseInvDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? inv.PurchaseInvDate).Value.ToShortDateString())
        //                                         && !inv.IsPurchaseReturned.Value)
        //                .ToList();

        //            if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo))
        //            {
        //                _purchaseList = _purchaseList.Where(x => x.PurchaseInvNo == searchCriteria.InvoiceNo).ToList();

        //                if(_purchaseList.Count() == 0)
        //                    repo.TblPurchaseInvoice.AsEnumerable().Where(x => x.PurchaseInvNo == searchCriteria.InvoiceNo).ToList();
        //            }
        //            if(searchCriteria.Role != 1)
        //            {
        //                _purchaseList = _purchaseList.Where(x => x.BranchCode == branchCode).ToList();
        //            }

        //            return _purchaseList;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public  List<TblPurchaseInvoiceDetail> GetPurchaseInvoiceDetails(string purchaseNo)
        {
            try
            {
                using (Repository<TblPurchaseInvoice> repo = new Repository<TblPurchaseInvoice>())
                {
                   return repo.TblPurchaseInvoiceDetail.Where(x=> x.PurchaseNo == purchaseNo).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.PurhaseHelpers
{
    public class PurchasesHelper
    {
        public string GeneratePurchaseInvoiceNo(string branchCode)
        {
            try
            {
                string sufix = string.Empty, prefix = string.Empty;
                var invoiceNo =new Common.CommonHelper().GetSuffixPrefix(13, branchCode, out prefix, out sufix);
               
                if (string.IsNullOrEmpty(invoiceNo))
                {
                    invoiceNo = prefix + "-1-" + sufix;
                }

                invoiceNo = prefix+"-" + (Convert.ToInt64(invoiceNo.Split("-")[1])+1) +"-"+ sufix;

                new Common.CommonHelper().UpdateInvoiceNumber(13, branchCode, invoiceNo);

                return invoiceNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblStateWiseGst> GetStateWiseGsts(string stateId = null)
        {
            try
            {
                using (Repository<TblStateWiseGst> repo = new Repository<TblStateWiseGst>())
                {
                    return repo.TblStateWiseGst.Where(s => s.StateCode == (stateId ?? s.StateCode)).ToList();
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
                var _invoiceHelper = new InvoiceHelper();
                var _product =_invoiceHelper.GetProducts(productCode).FirstOrDefault();

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
                    var taxStructure = _invoiceHelper.GetTaxStructure(Convert.ToDecimal(_product.TaxStructureCode));
                    purchaseDetail.Sgst = taxStructure.Sgst;
                    purchaseDetail.Cgst = taxStructure.Sgst;
                    purchaseDetail.Igst = taxStructure.Igst;
                    purchaseDetail.TotalGst = taxStructure.TotalGst;

                    purchaseDetail.ServerDateTime = DateTime.Now;
                }
              
                purchaseDetail.Rate = _invoiceHelper.GetProductRate(branchCode, productCode);
               
                purchaseDetail.HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0);
                // purchaseDetail.AvailStock = Convert.ToDecimal(_invoiceHelper.GetProductQty(branchCode, productCode) ?? 0);
                // purchaseDetail.ProductCode = _product.ProductCode;
                // purchaseDetail.ProductGroupCode = Convert.ToDecimal(_product.ProductGroupCode ?? 0);
                // purchaseDetail.ProductGroupId = Convert.ToDecimal(_product.ProductGroupId ?? 0);
                purchaseDetail.ProductId = _product.ProductId;
                purchaseDetail.ProductName = _product.ProductName;

                return purchaseDetail;
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
                    return repo.TblVoucherType.Where(v => v.VoucherTypeId == voucherTypeId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddPurchaseRecords(TblPurchaseInvoice purchaseInvoice,List<TblPurchaseInvoiceDetail> purchaseInvoiceDetails)
        {
            try
            {
                using(ERPContext context=new ERPContext())
                {
                    using(var dbTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                           

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


        public TblVoucherMaster AddVoucherMaster(TblPurchaseInvoice purchaseinvoice, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {
                using (ERPContext context = new ERPContext())
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
                    _voucherMaster.EmployeeId = -1;

                    context.TblVoucherMaster.Add(_voucherMaster);
                    if (context.SaveChanges() > 0)
                    {
                        return _voucherMaster;
                    }
                    #region comment
                    //var _voucherMaster = new TblVoucherMaster();
                    //_voucherMaster.BranchCode = invoice.BranchCode;
                    //_voucherMaster.BranchName = _branch.BranchName;
                    //_voucherMaster.VoucherDate = invoice.InvoiceDate;
                    //_voucherMaster.VoucherTypeIdMain = _vouchertType.VoucherTypeId;
                    //_voucherMaster.VoucherTypeIdSub = 35;
                    //_voucherMaster.VoucherNo = invoice.InvoiceNo;
                    //_voucherMaster.Amount  = invoice.GrandTotal;
                    //_voucherMaster.PaymentType = _accountLedger.CrOrDr;
                    //_voucherMaster.Narration = "Sales Invoice";
                    //_voucherMaster.ServerDate = DateTime.Now;
                    //_voucherMaster.UserId = invoice.UserId;
                    //_voucherMaster.UserName = invoice.UserName;
                    //_voucherMaster.EmployeeId = -1;

                    //repo.TblVoucherMaster.Add(_voucherMaster);
                    //if(!(repo.SaveChanges() > 0))
                    //{
                    //    dbTransaction.Rollback();
                    //    return false;
                    //}
                    #endregion

                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblVoucherDetail AddVoucherDetails(TblPurchaseInvoice purchaseinvoice, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate)
        {
            try
            {
                using (ERPContext context = new ERPContext())
                {
                    var _voucherDetail = new TblVoucherDetail();
                    _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                    _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                    _voucherDetail.BranchId = _branch.BranchId;
                    _voucherDetail.BranchCode = purchaseinvoice.BranchCode;
                    _voucherDetail.BranchName = purchaseinvoice.BranchName;
                    _voucherDetail.FromLedgerId = purchaseinvoice.LedgerId;
                    _voucherDetail.FromLedgerCode = purchaseinvoice.LedgerCode;
                    _voucherDetail.FromLedgerName = purchaseinvoice.LedgerName;
                    //To ledger  clarifiaction on selecion of product
                    _voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                    _voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                    _voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = _accountLedger.CrOrDr;
                    _voucherDetail.CostCenter = _accountLedger.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = $"Purchase Invoice { _voucherDetail.ToLedgerName} A/c:{_voucherDetail.TransactionType}";

                    context.TblVoucherDetail.Add(_voucherDetail);
                    if (context.SaveChanges() > 0)
                        return _voucherDetail;

                    #region comment
                    //var _voucherDetail = new TblVoucherDetail();
                    //_voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                    //_voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                    //_voucherDetail.BranchId = _branch.BranchId;
                    //_voucherDetail.BranchCode = invoice.BranchCode;
                    //_voucherDetail.BranchName = invoice.BranchName;
                    //_voucherDetail.FromLedgerId = invoice.LedgerId;
                    //_voucherDetail.FromLedgerCode = invoice.LedgerCode;
                    //_voucherDetail.FromLedgerName = invoice.LedgerName;
                    ////To ledger  clarifiaction on selecion of product
                    //_voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                    //_voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                    //_voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                    //_voucherDetail.Amount = invdtl.Rate;
                    //_voucherDetail.TransactionType = _accountLedger.CrOrDr;
                    //_voucherDetail.CostCenter = _accountLedger.BranchCode;
                    //_voucherDetail.ServerDate = DateTime.Now;
                    //_voucherDetail.Narration = "Sales Invoice Product group A/c:" + _voucherDetail.TransactionType;

                    //repo.TblVoucherDetail.Add(_voucherDetail);
                    //repo.SaveChanges();
                    #endregion
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblStockInformation AddStockInformatio(TblPurchaseInvoice purchaseinvoice, TblBranch _branch, TblProduct _product, decimal? qty, decimal? rate)
        {
            try
            {
                using (ERPContext context = new ERPContext())
                {
                    var _stockInformation = new TblStockInformation();

                    _stockInformation.BranchId = _branch.BranchId;
                    _stockInformation.BranchCode = _branch.BranchCode;
                    _stockInformation.ShiftId = purchaseinvoice.ShiftId;
                    _stockInformation.VoucherNo = purchaseinvoice.VoucherNo;
                    _stockInformation.VoucherTypeId = purchaseinvoice.VoucherTypeId;
                    _stockInformation.InvoiceNo = purchaseinvoice.PurchaseInvNo;
                    _stockInformation.ProductId = _product.ProductId;
                    _stockInformation.ProductCode = _product.ProductCode;
                    _stockInformation.OutwardQty = qty;
                    _stockInformation.Rate = rate;

                    context.TblStockInformation.Add(_stockInformation);
                    if (context.SaveChanges() > 0)
                        return _stockInformation;

                 

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblAccountLedgerTransactions AddAccountLedgerTransactions(TblVoucherDetail _voucherDetail, DateTime? invoiceDate)
        {
            try
            {
                using (ERPContext context = new ERPContext())
                {
                    var _accountLedgerTransactions = new TblAccountLedgerTransactions();
                    _accountLedgerTransactions.VoucherDetailId = _voucherDetail.VoucherDetailId;
                    _accountLedgerTransactions.LedgerId = _voucherDetail.ToLedgerId;
                    _accountLedgerTransactions.LedgerCode = _voucherDetail.ToLedgerCode;
                    _accountLedgerTransactions.LedgerCode = _voucherDetail.ToLedgerName;
                    _accountLedgerTransactions.BranchId = _voucherDetail.BranchId;
                    _accountLedgerTransactions.BranchCode = _voucherDetail.BranchCode;
                    _accountLedgerTransactions.BranchName = _voucherDetail.BranchName;
                    _accountLedgerTransactions.TransactionDate = invoiceDate;
                    _accountLedgerTransactions.TransactionType = _voucherDetail.TransactionType;
                    _accountLedgerTransactions.VoucherAmount = _voucherDetail.Amount;

                    if (_accountLedgerTransactions.TransactionType.Equals("debit", StringComparison.OrdinalIgnoreCase))
                    {
                        _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
                        _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
                    }
                    else if (_accountLedgerTransactions.TransactionType.Equals("crebit", StringComparison.OrdinalIgnoreCase))
                    {
                        _accountLedgerTransactions.CreditAmount = _accountLedgerTransactions.VoucherAmount;
                        _accountLedgerTransactions.DebitAmount = Convert.ToDecimal("0.00");
                    }

                    context.TblAccountLedgerTransactions.Add(_accountLedgerTransactions);
                    if (context.SaveChanges() > 0)
                        return _accountLedgerTransactions;


                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

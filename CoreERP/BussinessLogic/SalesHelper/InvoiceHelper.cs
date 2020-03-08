using CoreERP.DataAccess;
using CoreERP.Helpers;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SalesHelper
{
    public class InvoiceHelper
    {

        public string GenerateInvoiceNo(string branchCode)
        {
            try
            {
                string invoiceNo = string.Empty, prefix = string.Empty, sufix = string.Empty;
                new Common.CommonHelper().GetSuffixPrefix(19, branchCode, out prefix, out sufix);

                using (Repository<TblInvoiceMaster> repo = new Repository<TblInvoiceMaster>())
                {
                    invoiceNo = repo.TblInvoiceMaster.Where(inv => inv.BranchCode == branchCode).OrderByDescending(i => i.ServerDateTime).FirstOrDefault()?.InvoiceNo;
                }

                if (string.IsNullOrEmpty(invoiceNo))
                {
                    return prefix + "-1-" + sufix;
                }

                return prefix + Convert.ToInt64(invoiceNo.Split("-")[2]) + sufix;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblInvoiceMaster> GetInvoiceMasters(SearchCriteria searchCriteria)
        {
            try
            {
                using(Repository<TblInvoiceMaster> repo=new Repository<TblInvoiceMaster>())
                {
                   return  repo.TblInvoiceMaster.AsEnumerable()
                              .Where(inv=> Convert.ToDateTime(inv.ServerDateTime.Value.ToShortDateString()) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                                        && Convert.ToDateTime(inv.ServerDateTime.Value.ToShortDateString()) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                                        && inv.InvoiceNo == (searchCriteria.InvoiceNo ?? inv.InvoiceNo)
                                 )
                               .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public List<TblBranch> GetBranches(string branchCode=null)
        {
            try
            {
                using (Repository<TblBranch> repo=new Repository<TblBranch>())
                {
                  return  repo.TblBranch.AsEnumerable().Where(b=> b.BranchCode == (branchCode ?? b.BranchCode)).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblAccountLedger> GetAccountLedgers(string ledgercode=null,string ledgerName=null)
        {
            try
            {
                using (Repository<TblAccountLedger> repo=new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger
                        .Where(al => al.LedgerName.ToLower().Contains((ledgerName ?? al.LedgerName).ToLower())
                         && al.LedgerCode == (ledgercode ?? al.LedgerCode))
                        .ToList();
                    //
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public decimal GetAccountBalance(string ldgerCode,string branchCode)
        {
            try
            {
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    var accountTransactions = repo.TblAccountLedgerTransactions
                                                  .Where(a => a.LedgerCode == (ldgerCode ?? a.LedgerCode)
                                                           && a.BranchCode == branchCode
                                                  ).ToList();
                 
                    decimal totalCrditAmount = accountTransactions.Sum(x => Convert.ToDecimal(x.CreditAmount ?? 0));
                    decimal totalDebittAmount = accountTransactions.Sum(x => Convert.ToDecimal(x.DebitAmount ?? 0));

                    return totalCrditAmount - totalDebittAmount;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblProduct> GetProducts(string productCode,string ProductName=null)
        {
            try
            {
                using(Repository<TblProduct> repo=new Repository<TblProduct>())
                {
                    if (!string.IsNullOrEmpty(productCode))
                    {
                        productCode= productCode.ToLower();

                        return repo.TblProduct
                                   .Where(p => p.ProductCode.ToLower().Contains(productCode))
                                   .ToList();
                    }
                    else 
                    {
                        ProductName = ProductName.ToLower();
                        return repo.TblProduct
                                  .Where(p => p.ProductName.ToLower().Contains(ProductName))
                                  .ToList();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public decimal? GetProductRate(string branchCode,string productCode)
        {
            try
            {
                decimal? _salesRate = default(decimal?);

                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    var _product = repo.TblProduct.Where(p => p.ProductCode == productCode ).FirstOrDefault();

                    var _mshrates = GetMshsdrates(branchCode,_product.ProductCode);
                    if(_mshrates != null)
                    {
                        _salesRate = _mshrates.Rate;  
                    }
                    else if (_product != null)
                        _salesRate = _product.SalesRate;
                }

                return _salesRate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal? GetProductQty(string branchCode,string productCode, string ProductId = null)
        {
            try
            {
                List<TblStockInformation> stocInfoList = null;
                using (Repository<TblStockInformation> repo=new Repository<TblStockInformation>())
                {
                   stocInfoList=  repo.TblStockInformation.Where(stock => stock.ProductCode == productCode && stock.BranchCode == branchCode).ToList();
                }

                var qty =stocInfoList.Sum(x => x.InwardQty) - stocInfoList.Sum(x => x.OutwardQty);

                if (qty > 0)
                    return qty;

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblTaxStructure GetTaxStructure(decimal taxstructureCode)
        {
            try
            {
                using (Repository<TblTaxStructure> repo=new Repository<TblTaxStructure>())
                {
                    return repo.TblTaxStructure.Where(st=> st.TaxStructureCode == taxstructureCode).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public TblInvoiceDetail GetBillingDetailsSection(string branchCode,string productCode)
        {
            try
            {
                var _product = GetProducts(productCode).FirstOrDefault();

                var invoceDetails = new TblInvoiceDetail();

                invoceDetails.UnitId =Convert.ToDecimal(_product.UnitId??0);
                invoceDetails.UnitName = _product.UnitName;
                
                invoceDetails.TaxStructureCode = Convert.ToDecimal(_product.TaxStructureCode??0);
                invoceDetails.TaxStructureId =Convert.ToDecimal(_product.TaxStructureId ?? 0);
                invoceDetails.TaxGroupCode =_product.TaxGroupCode;
                invoceDetails.TaxGroupId = Convert.ToDecimal(_product.TaxGroupId??0);
                invoceDetails.TaxGroupName = _product.TaxGroupName;
               
                invoceDetails.Rate = GetProductRate(branchCode,productCode);
                invoceDetails.Qty =Convert.ToDecimal(GetProductQty(branchCode,productCode) ?? 0);
                invoceDetails.HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0);
                
                invoceDetails.ProductCode = _product.ProductCode;
                invoceDetails.ProductGroupCode =Convert.ToDecimal(_product.ProductGroupCode??0);
                invoceDetails.ProductGroupId =Convert.ToDecimal(_product.ProductGroupId??0);
                invoceDetails.ProductId = _product.ProductId;
                invoceDetails.ProductName = _product.ProductName;
                if (_product.TaxStructureCode != null)
                {
                    var taxStructure = GetTaxStructure(Convert.ToDecimal(_product.TaxStructureCode));
                    invoceDetails.Sgst = taxStructure.Sgst;
                    invoceDetails.Cgst = taxStructure.Sgst;
                    invoceDetails.Igst = taxStructure.Igst;
                    invoceDetails.TotalGst = taxStructure.TotalGst;
               
                invoceDetails.ServerDateTime = DateTime.Now;
                }

                return invoceDetails;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private TblMshsdrates GetMshsdrates(string branchCode,string productCode)
        {
            try
            {
                using (Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>())
                {
                    return repo.TblMshsdrates.Where(x => x.ProductCode == productCode && x.BranchCode == branchCode).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblMemberMaster> GetMembers(decimal? memberCode=null,string memberName=null)
        {
            try
            {
                using (Repository<TblMemberMaster> repo = new Repository<TblMemberMaster>())
                {

                    return repo.TblMemberMaster
                         .Where(m => m.MemberName.Contains(memberName) 
                                  && m.MemberCode == (memberCode ?? m.MemberCode)
                                  && m.IsActive == 1)
                         .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool RegisterBill(TblInvoiceMaster invoice, List<TblInvoiceDetail> invoiceDetails)
        {
            try
            {
                invoice.IsSalesReturned = false;
                invoice.IsManualEntry = false;

                using (Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>())
                {
                    //  using (var dbTransaction = repo.Database.BeginTransaction())
                    // {
                    //add voucher typedetails
                    var _branch = GetBranches(invoice.BranchCode).ToArray().FirstOrDefault();
                    var _accountLedger = GetAccountLedgers(invoice.LedgerCode).ToArray().FirstOrDefault();
                    var _vouchertType = GetVoucherType(19).ToArray().FirstOrDefault();

                    #region Add voucher master record
                    var _voucherMaster = AddVoucherMaster(invoice, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                    #endregion


                    invoice.VoucherNo = _voucherMaster.VoucherMasterId.ToString();
                    invoice.VoucherTypeId = 19;

                    invoice.ServerDateTime = DateTime.Now;
                    repo.TblInvoiceMaster.Add(invoice);
                    repo.SaveChanges();

                    foreach (var invdtl in invoiceDetails)
                    {
                        var _product = GetProducts(invdtl.ProductCode).FirstOrDefault();
                        //_accountLedger = GetAccountLedgers(_product.SalesAccount.ToString()).FirstOrDefault();


                        #region Add voucher Details
                        var _voucherDetail = AddVoucherDetails(invoice, _branch, _voucherMaster, _accountLedger, invdtl.Rate);

                        #endregion

                        #region InvioceDetail
                        invdtl.InvoiceMasterId = invoice.InvoiceMasterId;
                        invdtl.VoucherNo = invoice.VoucherNo;
                        invdtl.InvoiceNo = invoice.InvoiceNo;
                        invdtl.StateCode = invoice.StateCode;
                        invdtl.ShiftId = invoice.ShiftId;
                        invdtl.UserId = invoice.UserId;
                        invdtl.EmployeeId = -1;

                        invdtl.ServerDateTime = DateTime.Now;

                        repo.TblInvoiceDetail.Add(invdtl);
                        repo.SaveChanges();

                        #endregion

                        #region Add stock transaction in Stock Information
                        var _stockInformation = AddStockInformatio(invoice, _branch, _product, invdtl.Qty > 0 ? invdtl.Qty : invdtl.FQty, invdtl.Rate);

                        #endregion

                        #region Account Ledger Transaction
                        var _accountLedgerTransactions = AddAccountLedgerTransactions(_voucherDetail, invoice.InvoiceDate);

                        #endregion

                        // repo.TblInvoiceDetail.Add(invdtl);
                        // if (repo.SaveChanges() > 0)
                        {
                            //_stockInformation = new TblStockInformation();
                            //_stockInformation.BranchCode = invoice.BranchCode;
                            //// stockInformation.BranchId = ;
                            //_stockInformation.UserId = invoice.UserId;
                            //_stockInformation.ShiftId = invoice.ShiftId;
                            //_stockInformation.TransactionDate = DateTime.Now;
                            //_stockInformation.ShiftId = invoice.ShiftId;
                            //_stockInformation.VoucherTypeId = invoice.VoucherTypeId;
                            //_stockInformation.VoucherNo = invdtl.VoucherNo;
                            //_stockInformation.InvoiceNo = invoice.InvoiceNo;
                            //_stockInformation.ProductId = invdtl.ProductId;
                            //_stockInformation.ProductCode = invdtl.ProductCode;
                            //_stockInformation.Rate = invdtl.Rate;

                            //_stockInformation.OutwardQty = invdtl.Qty ?? invdtl.FQty;

                            //repo.TblStockInformation.Add(_stockInformation);

                            //repo.SaveChanges();
                        }
                        //else
                        //{
                        //    dbTransaction.Rollback();
                        //}
                    }
                    // }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
       

         /*************************   Helper methods For invoice*******************************************/

        public List<TblVoucherType> GetVoucherType(decimal voucherTypeId)
        {
            try
            {
                using(Repository<TblVoucherType> repo=new Repository<TblVoucherType>())
                {
                    return repo.TblVoucherType.Where(v => v.VoucherTypeId == voucherTypeId).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public TblVoucherMaster AddVoucherMaster(TblInvoiceMaster invoice,TblBranch branch,decimal? voucherTypeId,string paymentType)
        {
            try
            {
                using (ERPContext context = new ERPContext())
                {
                    var _voucherMaster = new TblVoucherMaster();
                    _voucherMaster.BranchCode = invoice.BranchCode;
                    _voucherMaster.BranchName = branch.BranchName;
                    _voucherMaster.VoucherDate = invoice.InvoiceDate;
                    _voucherMaster.VoucherTypeIdMain = voucherTypeId;
                    _voucherMaster.VoucherTypeIdSub = 35;
                    _voucherMaster.VoucherNo = invoice.InvoiceNo;
                    _voucherMaster.Amount = invoice.GrandTotal;
                    _voucherMaster.PaymentType = paymentType;//accountLedger.CrOrD
                    _voucherMaster.Narration = "Sales Invoice";
                    _voucherMaster.ServerDate = DateTime.Now;
                    _voucherMaster.UserId = invoice.UserId;
                    _voucherMaster.UserName = invoice.UserName;
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

        public TblVoucherDetail AddVoucherDetails(TblInvoiceMaster invoice,TblBranch _branch,TblVoucherMaster _voucherMaster,TblAccountLedger _accountLedger,decimal? productRate)
        {
            try
            {
                using(ERPContext context=new ERPContext())
                {
                    var _voucherDetail = new TblVoucherDetail();
                    _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                    _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                    _voucherDetail.BranchId = _branch.BranchId;
                    _voucherDetail.BranchCode = invoice.BranchCode;
                    _voucherDetail.BranchName = invoice.BranchName;
                    _voucherDetail.FromLedgerId = invoice.LedgerId;
                    _voucherDetail.FromLedgerCode = invoice.LedgerCode;
                    _voucherDetail.FromLedgerName = invoice.LedgerName;
                    //To ledger  clarifiaction on selecion of product
                    _voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                    _voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                    _voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                    _voucherDetail.Amount = productRate;
                    _voucherDetail.TransactionType = _accountLedger.CrOrDr;
                    _voucherDetail.CostCenter = _accountLedger.BranchCode;
                    _voucherDetail.ServerDate = DateTime.Now;
                    _voucherDetail.Narration = "Sales Invoice Product group A/c:" + _voucherDetail.TransactionType;

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

        public TblStockInformation AddStockInformatio(TblInvoiceMaster invoice,TblBranch _branch,TblProduct _product,decimal? qty,decimal? rate)
        {
            try
            {
                using(ERPContext context=new ERPContext())
                {
                    var _stockInformation = new TblStockInformation();

                    _stockInformation.BranchId = _branch.BranchId;
                    _stockInformation.BranchCode = _branch.BranchCode;
                    _stockInformation.ShiftId = invoice.ShiftId;
                    _stockInformation.VoucherNo = invoice.VoucherNo;
                    _stockInformation.VoucherTypeId = invoice.VoucherTypeId;
                    _stockInformation.InvoiceNo = invoice.InvoiceNo;
                    _stockInformation.ProductId = _product.ProductId;
                    _stockInformation.ProductCode = _product.ProductCode;
                    _stockInformation.OutwardQty = qty;
                    _stockInformation.Rate = rate;

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
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public TblAccountLedgerTransactions AddAccountLedgerTransactions(TblVoucherDetail _voucherDetail,DateTime? invoiceDate)
        {
            try 
            {
                using(ERPContext context=new ERPContext())
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

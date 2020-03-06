using CoreERP.DataAccess;
using CoreERP.Helpers;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SalesHelper
{
    public class InvoiceHelper
    {
        //public List<TblAccountLedger> GetMembers(string ledgercode=null,string ledgerName=null)
        //{
        //    try
        //    {
        //        using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
        //        {
        //            return repo.TblAccountLedger
        //                       .AsEnumerable()
        //                       .Where(al => al.LedgerCode == (ledgercode ?? al.LedgerCode)
        //                                 && al.LedgerName.ToLower().Contains((ledgerName ?? al.LedgerName).ToLower())
        //                       )
        //                       .ToList();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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
                TblStockInformation stockInformation = null;
                using (Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>())
                {
                    using (var dbTransaction = repo.Database.BeginTransaction())
                    {
                        repo.TblInvoiceMaster.Add(invoice);
                        repo.SaveChanges();

                        foreach (var invdtl in invoiceDetails)
                        {
                            repo.TblInvoiceDetail.Add(invdtl);
                            if (repo.SaveChanges() > 0)
                            {
                                stockInformation = new TblStockInformation();
                                stockInformation.BranchCode = invoice.BranchCode;
                               // stockInformation.BranchId = ;
                                stockInformation.UserId = invoice.UserId;
                                stockInformation.ShiftId = invoice.ShiftId;
                                stockInformation.TransactionDate = DateTime.Now;
                                stockInformation.ShiftId = invoice.ShiftId;
                                stockInformation.VoucherTypeId = invoice.VoucherTypeId;
                                stockInformation.VoucherNo = invdtl.VoucherNo;
                                stockInformation.InvoiceNo = invoice.InvoiceNo;
                                stockInformation.ProductId = invdtl.ProductId;
                                stockInformation.ProductCode = invdtl.ProductCode;
                                stockInformation.Rate = invdtl.Rate;

                                stockInformation.OutwardQty = invdtl.Qty ?? invdtl.FQty;

                                repo.TblStockInformation.Add(stockInformation);

                                repo.SaveChanges();
                            }
                            else
                            {
                                dbTransaction.Rollback();
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}

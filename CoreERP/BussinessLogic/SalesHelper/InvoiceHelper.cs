using CoreERP.Controllers.masters;
using CoreERP.DataAccess;
using CoreERP.Helpers;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SalesHelper
{
    public class InvoiceHelper
    {
        public List<TblPumps> GetPumps(string pumpNo,string branchCode)
        {
            try
            {
                using(Repository<TblPumps> repo=new Repository<TblPumps>())
                {
                    return repo.TblPumps
                                .Where(p=> p.BranchCode == branchCode && p.PumpNo.ToString().Contains(pumpNo))
                                .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<TblStateWiseGst> GetStateWiseGsts(string stateId=null)
        {
            try
            {
                using (Repository<TblStateWiseGst> repo=new Repository<TblStateWiseGst>())
                {
                    return repo.TblStateWiseGst.Where(s => s.StateCode == (stateId ?? s.StateCode)).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateInvoiceNo(string branchCode)
        {
            try
            {
                return new Common.CommonHelper().GenerateNumber(19, branchCode);
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
                //searchCriteria.FromDate = Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString());
                //searchCriteria.ToDate = Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());

                using (Repository<TblInvoiceMaster> repo=new Repository<TblInvoiceMaster>())
                {
                    List<TblInvoiceMaster> _invoiceMasterList = null;


                    _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                              .Where(inv=>
                                         DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                       && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                      
                                       &&  !inv.IsSalesReturned.Value
                                 )
                               .ToList();

                    if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo))
                        _invoiceMasterList = _invoiceMasterList.Where(x=> x.InvoiceNo == searchCriteria.InvoiceNo).ToList();

                    // && inv.InvoiceNo == (searchCriteria.InvoiceNo ?? inv.InvoiceNo)

                    return _invoiceMasterList;
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
                ledgercode = ledgercode?.ToLower();
                using (Repository<TblAccountLedger> repo=new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger
                        .Where(al => al.LedgerName.ToLower().Contains((ledgerName ?? al.LedgerName).ToLower())
                         && al.LedgerCode.ToLower().Contains((ledgercode ?? al.LedgerCode.ToLower()))
                         )
                        .OrderBy(o=> o.LedgerCode)
                        .ToList();
                    //
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblAccountLedger> GetAccountLedgersByLedgerId(decimal LedgerId)
        {
            try
            {
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger
                        .Where(al => al.LedgerId == LedgerId)
                        .ToList();
                    //
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal GetAccountBalance(string ldgerCode)
        {
            try
            {
               
                TblOpeningBalance _OpeningBalance = null;
                using (Repository<TblOpeningBalance> repo = new Repository<TblOpeningBalance>())
                {
                    _OpeningBalance = repo.TblOpeningBalance.Where(a => a.LedgerCode == ldgerCode ).FirstOrDefault();
                }
                //select * from tbl_OpeningBalance where ledgercode=2030 -- 230270

                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    var accountTransactions = (from atl in repo.TblAccountLedgerTransactions
                                               join vd in repo.TblVoucherDetail on atl.VoucherDetailId equals vd.VoucherDetailId
                                               join vm in repo.TblVoucherMaster  on vd.VoucherMasterId equals vm.VoucherMasterId
                                               where !(EF.Functions.Like(vm.VoucherNo, "OP%TKL"))
                                                  && atl.LedgerCode == ldgerCode
                                               select atl).ToList();
                 
                    decimal totalCrditAmount = accountTransactions.Sum(x => Convert.ToDecimal(x.CreditAmount ?? 0));
                    decimal totalDebittAmount = accountTransactions.Sum(x => Convert.ToDecimal(x.DebitAmount ?? 0));

                    return  _OpeningBalance.Amount +(totalCrditAmount - totalDebittAmount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblProduct> GetProducts(string productCode,string ProductName)
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

        public List<TblProduct> GetProducts(string productCode)
        {
            try
            {
                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                   
                        productCode = productCode.ToLower();

                        return repo.TblProduct
                                   .Where(p => p.ProductCode.ToLower() == productCode.ToLower())
                                   .ToList();
                   
                }
            }
            catch (Exception ex)
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
        public TblTaxStructure GetTaxStructureByTaxStuctId(decimal taxStructureId)
        {
            try
            {
                using (Repository<TblTaxStructure> repo = new Repository<TblTaxStructure>())
                {
                    return repo.TblTaxStructure.Where(st => st.TaxStructureId == taxStructureId).FirstOrDefault();
                }
            }
            catch (Exception ex)
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
                invoceDetails.AvailStock =Convert.ToDecimal(GetProductQty(branchCode,productCode) ?? 0);
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
        public List<TblMemberMaster> GetMembers(string memberName=null)
        {
            try
            {
              return  new MemberHelper().GetMembersByName(memberName);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblVehicle> GetVehicles(string vechileRegno,string memberCode)
        {
            try
            {
                return new VechileMasterHelper().GetVehicles(vechileRegno,Convert.ToDecimal(memberCode));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblInvoiceDetail> GetInvoiceDetails(string invoiceNo)
        {
            try
            {
                using (Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>())
                {
                    return repo.TblInvoiceDetail.Where(x => x.InvoiceNo == invoiceNo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*************************   Helper methods For invoice*******************************************/
        public bool RegisterBill(TblInvoiceMaster invoice, List<TblInvoiceDetail> invoiceDetails)
        {
            try
            {
                invoice.IsSalesReturned = false;
                invoice.IsManualEntry = false;
                TblTaxStructure _taxStructure = null;
                TblProduct _product = null;
                using (ERPContext repo = new ERPContext())
                {
                    using (var dbTransaction = repo.Database.BeginTransaction())
                    {
                        try
                        {
                            //add voucher typedetails
                            var _branch = GetBranches(invoice.BranchCode).ToArray().FirstOrDefault();

                            var _accountLedger = GetAccountLedgers(invoice.LedgerCode).ToArray().FirstOrDefault();
                            var _vouchertType = GetVoucherType(19).FirstOrDefault();

                            #region Add voucher master record
                            var _voucherMaster = AddVoucherMaster(repo, invoice, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                            #endregion

                            
                            invoice.VoucherNo = _voucherMaster.VoucherMasterId.ToString();
                            invoice.BranchName = _branch.BranchName;
                            invoice.VoucherTypeId = 19;
                            invoice.ServerDateTime = DateTime.Now;
                            repo.TblInvoiceMaster.Add(invoice);
                            repo.SaveChanges();

                            foreach (var invdtl in invoiceDetails)
                            {
                                _product = GetProducts(invdtl.ProductCode).FirstOrDefault();
                                _taxStructure = GetTaxStructure(Convert.ToDecimal(_product.TaxStructureId));
                                _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.SalesAccount).FirstOrDefault();
                               
                                #region Add voucher Details
                                var _voucherDetail = AddVoucherDetails(repo, invoice, _branch, _voucherMaster, _accountLedger, invdtl.Rate);
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

                                invdtl.PumpId = invdtl.PumpId ?? -1;
                                invdtl.PumpNo = invdtl.PumpNo ?? -1;
                                invdtl.SlipNo = invdtl.SlipNo ?? -1;

                                repo.TblInvoiceDetail.Add(invdtl);
                                repo.SaveChanges();

                                #endregion

                                #region Add stock transaction  and Account Ledger Transaction
                                AddStockInformation(repo, invoice, _branch, _product, invdtl.Qty > 0 ? invdtl.Qty : invdtl.FQty, invdtl.Rate);

                                AddAccountLedgerTransactions(repo, _voucherDetail, invoice.InvoiceDate);
                                #endregion
                            }

                            _accountLedger = GetAccountLedgers(invoice.LedgerCode).ToArray().FirstOrDefault();
                            AddVoucherDetails(repo, invoice, _branch, _voucherMaster, _accountLedger, invoice.GrandTotal, false);

                            //CHech weather igs or sg ,cg st
                            var _stateWiseGsts = GetStateWiseGsts(invoice.StateCode).FirstOrDefault();
                            if (_stateWiseGsts.Igst == 1)
                            {
                                //Add IGST record
                                var _accAL = GetAccountLedgers("243").ToArray().FirstOrDefault();
                                AddVoucherDetails(repo, invoice, _branch, _voucherMaster, _accAL, invoice.TotalAmount, false);

                            }
                            else
                            {
                                // sgst
                                var _accAL = GetAccountLedgers("240").ToArray().FirstOrDefault();
                                AddVoucherDetails(repo, invoice, _branch, _voucherMaster, _accAL, invoice.TotalAmount, false);
                                // sgst
                                _accAL = GetAccountLedgers("241").ToArray().FirstOrDefault();
                                AddVoucherDetails(repo, invoice, _branch, _voucherMaster, _accAL, invoice.TotalAmount, false);
                            }

                            dbTransaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            dbTransaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public TblVoucherMaster AddVoucherMaster(ERPContext context,TblInvoiceMaster invoice,TblBranch branch,decimal? voucherTypeId,string paymentType)
        {
            try
            {
                //using (ERPContext context = new ERPContext())
                //{
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
               // }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblInvoiceMaster invoice, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, bool isFromInvoiceDetials = true)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
                var _voucherDetail = new TblVoucherDetail();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = invoice.BranchCode;
                _voucherDetail.BranchName = invoice.BranchName;
                if (isFromInvoiceDetials)
                {
                    _voucherDetail.FromLedgerId = invoice.LedgerId;
                    _voucherDetail.FromLedgerCode = invoice.LedgerCode;
                    _voucherDetail.FromLedgerName = invoice.LedgerName;
                }
                //To ledger  clarifiaction on selecion of product

                _voucherDetail.ToLedgerId = _accountLedger.LedgerId;
                _voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
                _voucherDetail.ToLedgerName = _accountLedger.LedgerName;
                _voucherDetail.Amount = productRate;
                _voucherDetail.TransactionType = _accountLedger.CrOrDr;
                _voucherDetail.CostCenter = _accountLedger.BranchCode;
                _voucherDetail.ServerDate = DateTime.Now;
                _voucherDetail.Narration = $"Sales Invoice {_accountLedger.LedgerName} A /c: {_voucherDetail.TransactionType}";

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
                // }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblStockInformation AddStockInformation(ERPContext context,TblInvoiceMaster invoice,TblBranch _branch,TblProduct _product,decimal? qty,decimal? rate)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
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
              //  }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context,TblVoucherDetail _voucherDetail,DateTime? invoiceDate)
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

                    if (_accountLedgerTransactions.TransactionType.Equals("dedit", StringComparison.OrdinalIgnoreCase))
                    {
                        _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
                        _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
                    }
                    else if (_accountLedgerTransactions.TransactionType.Equals("credit", StringComparison.OrdinalIgnoreCase))
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Controllers.masters;
using CoreERP.DataAccess;
using CoreERP.Helpers;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using CoreERP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NuGet.Packaging.Signing;
using System.Xml.Linq;
using CoreERP.Models;
using CoreERP.Helpers.SharedModels;
using CoreERP.BussinessLogic.GenerlLedger;

namespace CoreERP.BussinessLogic.SalesHelper
{
    public class InvoiceHelper
    {
        private WebProxy objProxy1 = null;
        //to get the invoice Master data while page load
        public List<TblInvoiceMaster> GetInvoiceList(int? role, string branchCode, DateTime? fromDate = null, DateTime? toDate = null, string invoiceNo = null)
        {
            try
            {

                using (Repository<TblInvoiceMaster> repo = new Repository<TblInvoiceMaster>())
                {
                    List<TblInvoiceMaster> _invoiceMasterList = null;
                    if (role.Value == 1)
                    {
                        //_invoicemasterlist = repo.tblinvoicemaster.asenumerable()
                        //          .where(inv =>
                        //                   inv.invoicedate >= convert.todatetime(datetime.now.date.tostring("yyyy/mm/dd"))
                        //                   && !inv.issalesreturned.value
                        //             )
                        //           .tolist();

                        if (fromDate != null && toDate != null)
                        {
                            _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                                                                .Where(inv =>
                                                                            inv.InvoiceDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"))
                                                                         && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((fromDate).Value.ToShortDateString())
                                                                         && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) <= DateTime.Parse((toDate).Value.ToShortDateString())
                                                                         && inv.InvoiceNo.Contains(invoiceNo ?? inv.InvoiceNo)
                                                                         && !inv.IsSalesReturned.Value
                                                                   )
                                                                 .ToList();
                        }
                        else
                        {
                            _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable().Where(inv => inv.InvoiceNo.Contains(invoiceNo ?? inv.InvoiceNo)
                                                                                                && !inv.IsSalesReturned.Value
                                                                                                && inv.InvoiceDate.Value.Year == DateTime.Now.Year
                                                                                              )
                                                                                            .ToList();
                        }


                    }
                    else
                    {
                        if (fromDate != null && toDate != null)
                        {
                            _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                                                                .Where(inv => inv.InvoiceDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"))
                                                                         && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((fromDate).Value.ToShortDateString())
                                                                         && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) <= DateTime.Parse((toDate).Value.ToShortDateString())
                                                                         && inv.InvoiceNo.Contains(invoiceNo ?? inv.InvoiceNo)
                                                                         && !inv.IsSalesReturned.Value
                                                                   )
                                                                 .ToList();
                        }
                        else
                        {
                            _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable().Where(inv => inv.InvoiceNo.Contains(invoiceNo ?? inv.InvoiceNo)
                                                                                                && !inv.IsSalesReturned.Value
                                                                                                && inv.InvoiceDate.Value.Year == DateTime.Now.Year
                                                                                              )
                                                                                            .ToList();
                        }
                    }


                    return _invoiceMasterList.OrderByDescending(x => x.InvoiceDate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public List<TblPumps> GetPumps(string pumpNo,string branchCode,string productCode)
        //{
        //    try
        //    {
        //        productCode = productCode?.ToLower();
        //        using (Repository<TblPumps> repo=new Repository<TblPumps>())
        //        {
        //            return repo.TblPumps
        //                        .Where(p=> p.BranchCode == branchCode 
        //                                && p.PumpNo.ToString().Contains(pumpNo)
        //                                && p.ProductCode.ToLower() == (productCode ?? p.ProductCode.ToLower())
        //                                && p.IsWorking == 1)
        //                        .ToList();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<TblPumps> GetPumpsDropDown(string branchCode, string productCode)
        //{
        //    try
        //    {
        //        using Repository<TblPumps> repo = new Repository<TblPumps>();
        //        return repo.TblPumps.Where(p=>p.BranchCode==branchCode && p.ProductCode==productCode && p.IsWorking == 1).ToList();
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

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
        public string GenerateInvoiceNo(out string errorMessage)
        {
            try
            {
                using var context = new ERPContext();
                errorMessage = string.Empty;
                string suffix = string.Empty, prefix = string.Empty, billno = string.Empty;
                using var repo = new Repository<Counters>();
                var Pcenter = repo.Counters.FirstOrDefault(x => x.CounterName == "Sales Invoice");

                if (Pcenter != null)
                {
                    Pcenter.LastNumber = (Pcenter.LastNumber + 1);
                    context.Counters.UpdateRange(Pcenter);
                    context.SaveChanges();
                    billno = Pcenter.Prefix + "-" + Pcenter.LastNumber;
                }

                //TblInvoiceMaster _invoiceMaster = null;
                //using (Repository<TblInvoiceMaster> _repo = new Repository<TblInvoiceMaster>())
                //{
                //    _invoiceMaster= _repo.TblInvoiceMaster.OrderByDescending(x => x.ServerDateTime).FirstOrDefault();

                //    if(_invoiceMaster != null)
                //    {
                //        var invSplit = _invoiceMaster.InvoiceNo.Split('-');
                //        billno = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1])+1}-{invSplit[2]}";
                //    }
                //    else
                //    {
                //       // new Common.CommonHelper().GetSuffixPrefix(19, branchCode, out prefix, out suffix);
                //        if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                //        {
                //            errorMessage = $"No prefix and suffix confugured. ";
                //            return billno = string.Empty;
                //        }

                //        billno = $"{prefix}-1-{suffix}";
                //    }
                //}

                if (string.IsNullOrEmpty(billno))
                {
                    errorMessage = "Invoice no not gererated please enter manully.";
                }

                return billno;
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

                using (Repository<TblInvoiceMaster> repo = new Repository<TblInvoiceMaster>())
                {
                    List<TblInvoiceMaster> _invoiceMasterList = null;
                    if (searchCriteria.Role == 1 || searchCriteria.Role == 3 || searchCriteria.Role == 89)
                    {
                        //searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                        //searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;

                        if (searchCriteria.FromDate == null)
                        {
                            searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                            searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;
                            _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                                .Where(inv =>
                                     DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                   && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString()))
                                .ToList();
                            //_invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                            //     .Where(inv =>
                            //                 DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString())
                            //              && !inv.IsSalesReturned.Value
                            //        )
                            //      .ToList();
                        }
                        else
                        {
                            _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                             .Where(inv =>
                                        DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString())
                                        >= DateTime.Parse((searchCriteria.FromDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                      && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString())
                                        <= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                      && !inv.IsSalesReturned.Value
                                )
                              .ToList();
                        }
                    }
                    else
                    {
                        if (searchCriteria.FromDate == null)
                        {
                            searchCriteria ??= new SearchCriteria() { FromDate = DateTime.Today.AddDays(-10000), ToDate = DateTime.Today };
                            searchCriteria.FromDate ??= DateTime.Today.AddDays(-10000);
                            searchCriteria.ToDate ??= DateTime.Today;
                            // searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                            // searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;
                        }

                        var customer = repo.TblBusinessPartnerAccount.ToList();

                        repo.TblInvoiceMaster.ToList()
                            .ForEach(c =>
                            {
                                c.CustName = customer.FirstOrDefault(m => m.Bpnumber == c.CustomerName).Name;

                            });

                        _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                          .Where(inv =>
                                     DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                   && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                    && inv.Company.ToString().Contains(searchCriteria.CompanyCode ?? inv.Company.ToString())
                             )
                           .ToList();
                    }
                    //if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo)) 
                    //{
                    //    _invoiceMasterList = _invoiceMasterList.Where(x => x.InvoiceNo == searchCriteria.InvoiceNo).ToList();
                    //    if (_invoiceMasterList.Count() == 0)
                    //        _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable().Where(i=> i.InvoiceNo.Contains(searchCriteria.InvoiceNo)).ToList();
                    //}

                    // && inv.InvoiceNo == (searchCriteria.InvoiceNo ?? inv.InvoiceNo)

                    return _invoiceMasterList.OrderByDescending(x => x.InvoiceMasterId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<TblInvoiceMaster> GetInvoiceMasters(SearchCriteria searchCriteria, string branchCode)
        {
            try
            {

                using (Repository<TblInvoiceMaster> repo = new Repository<TblInvoiceMaster>())
                {
                    List<TblInvoiceMaster> _invoiceMasterList = null;
                    if (searchCriteria.Role == 1 || searchCriteria.Role == 3 || searchCriteria.Role == 89)
                    {
                        //searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                        //searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;

                        if (searchCriteria.FromDate == null)
                        {
                            searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                            searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;
                            _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                                .Where(inv =>
                                     DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                   && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString()))
                                .ToList();
                            //_invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                            //     .Where(inv =>
                            //                 DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString())
                            //              && !inv.IsSalesReturned.Value
                            //        )
                            //      .ToList();
                        }
                        else
                        {
                            _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                             .Where(inv =>
                                        DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString())
                                        >= DateTime.Parse((searchCriteria.FromDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                      && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString())
                                        <= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                      && !inv.IsSalesReturned.Value
                                )
                              .ToList();
                        }
                    }
                    else
                    {
                        if (searchCriteria.FromDate == null)
                        {
                            searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                            searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;
                        }
                        _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable()
                          .Where(inv =>
                                     DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                   && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                   && !inv.IsSalesReturned.Value
                             )
                           .ToList();
                    }
                    //if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo)) 
                    //{
                    //    _invoiceMasterList = _invoiceMasterList.Where(x => x.InvoiceNo == searchCriteria.InvoiceNo).ToList();
                    //    if (_invoiceMasterList.Count() == 0)
                    //        _invoiceMasterList = repo.TblInvoiceMaster.AsEnumerable().Where(i=> i.InvoiceNo.Contains(searchCriteria.InvoiceNo)).ToList();
                    //}

                    // && inv.InvoiceNo == (searchCriteria.InvoiceNo ?? inv.InvoiceNo)

                    return _invoiceMasterList.OrderByDescending(x => x.InvoiceDate).ToList();
                }
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
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.AsEnumerable().Where(b => b.BranchCode == (branchCode ?? b.BranchCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<TblAccountLedger> GetAccountLedgers(string ledgercode=null,string ledgerName=null)
        //{
        //    try
        //    {
        //        ledgercode = ledgercode?.ToLower();
        //        using (Repository<TblAccountLedger> repo=new Repository<TblAccountLedger>())
        //        {
        //            var _member = GetMembersByCode(ledgercode);
        //            if (_member != null)
        //            {
        //                var result = (from al in repo.TblAccountLedger
        //                              join m in repo.TblMemberMaster on al.LedgerCode equals m.MemberCode.ToString()
        //                              where (al.LedgerName.ToLower().Contains((ledgerName ?? al.LedgerName).ToLower()) && al.LedgerCode.ToLower().Contains((ledgercode ?? al.LedgerCode.ToLower()))
        //                              && m.IsActive == 1 && al.AccountGroupId == 7580 || al.AccountGroupId == 573 || al.AccountGroupId == 7577 || al.AccountGroupId == 7576 || al.AccountGroupId == 7039
        //                              || al.AccountGroupId == 7586)
        //                              select al).ToList();
        //                return result;
        //            }
        //            else
        //            {
        //                var result= repo.TblAccountLedger
        //                .Where(al => al.LedgerName.ToLower().Contains((ledgerName ?? al.LedgerName).ToLower())
        //                 && al.LedgerCode.ToLower().Contains((ledgercode ?? al.LedgerCode.ToLower())) && al.AccountGroupId==7580 || al.AccountGroupId==573
        //                || al.AccountGroupId == 7577 || al.AccountGroupId == 7576 || al.AccountGroupId == 7586 || al.AccountGroupId == 7039).OrderBy(o => o.LedgerCode).ToList();
        //                return result;
        //            }

        //            //return repo.TblAccountLedger
        //            //    .Where(al => al.LedgerName.ToLower().Contains((ledgerName ?? al.LedgerName).ToLower())
        //            //     && al.LedgerCode.ToLower().Contains((ledgercode ?? al.LedgerCode.ToLower()))
        //            //     )
        //            //    .OrderBy(o => o.LedgerCode)
        //            //    .ToList();
        //            //
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public TblAccountLedger GetAccountLedgersByCode(string ledgercode)
        {
            try
            {
                ledgercode = ledgercode?.ToLower();
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger
                        .Where(al => al.LedgerCode == ledgercode)
                        .OrderBy(o => o.LedgerCode)
                        .FirstOrDefault();
                    //
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblInvoiceMaster GetCustomerGstNum(string phonenum)
        {
            try
            {
                using (Repository<TblInvoiceMaster> repo = new Repository<TblInvoiceMaster>())
                {
                    return repo.TblInvoiceMaster
                        .Where(al => al.Mobile == phonenum)
                        .OrderBy(o => o.LedgerCode)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblAccountLedger GetAccountLedgersByAccountGroupId(string ledgercode, int groupId)
        {
            try
            {
                ledgercode = ledgercode?.ToLower();
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger
                        .Where(al => al.LedgerCode == ledgercode && al.AccountGroupId == groupId)
                        .OrderBy(o => o.LedgerCode)
                        .FirstOrDefault();
                    //
                }
            }
            catch (Exception ex)
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
        //public decimal GetAccountBalance(string ldgerCode)
        //{
        //    try
        //    {

        //        TblOpeningBalance _OpeningBalance = null;
        //        using (Repository<TblOpeningBalance> repo = new Repository<TblOpeningBalance>())
        //        {
        //            _OpeningBalance = repo.TblOpeningBalance.Where(a => a.LedgerCode == ldgerCode ).FirstOrDefault();
        //        }

        //        //if (_OpeningBalance == null)
        //        //    return 0;


        //        //select * from tbl_OpeningBalance where ledgercode=2030 -- 230270

        //        using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
        //        {
        //            var accountTransactions = (from atl in repo.TblAccountLedgerTransactions
        //                                       join vd in repo.TblVoucherDetail on atl.VoucherDetailId equals vd.VoucherDetailId
        //                                       join vm in repo.TblVoucherMaster  on vd.VoucherMasterId equals vm.VoucherMasterId
        //                                       where !(EF.Functions.Like(vm.VoucherNo, "OP%TKL"))
        //                                          && atl.LedgerCode == ldgerCode
        //                                       select atl).ToList();

        //            decimal totalCrditAmount = accountTransactions.Sum(x => Convert.ToDecimal(x.CreditAmount ?? 0));
        //            decimal totalDebittAmount = accountTransactions.Sum(x => Convert.ToDecimal(x.DebitAmount ?? 0));
        //            decimal _value;
        //            if (_OpeningBalance == null)
        //            {
        //                _value = 0 + (totalCrditAmount - totalDebittAmount);

        //            }
        //            else if(_OpeningBalance.PaymentTypeId==1)
        //            {
        //                 _value = _OpeningBalance.Amount + (totalCrditAmount - totalDebittAmount);

        //            }
        //            else
        //            {
        //                _value = (totalCrditAmount - totalDebittAmount) - _OpeningBalance.Amount;
        //            }

        //            if (_value != 0)
        //            {
        //                return _value;
        //            }

        //            return 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<TblProduct> GetProducts(string productCode,string ProductName)
        //{
        //    try
        //    {
        //        using(Repository<TblProduct> repo=new Repository<TblProduct>())
        //        {
        //            if (!string.IsNullOrEmpty(productCode))
        //            {
        //                productCode= productCode.ToLower();

        //                return repo.TblProduct
        //                           .Where(p => p.ProductCode.ToLower().Contains(productCode))
        //                           .ToList();
        //            }
        //            else 
        //            {
        //                ProductName = ProductName.ToLower();
        //                return repo.TblProduct
        //                          .Where(p => p.ProductName.ToLower().Contains(ProductName))
        //                          .ToList();
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<TblPumps> GetPumpID(int pumpNo,string branchCode)
        //{
        //    try
        //    {
        //        using (Repository<TblPumps> repo = new Repository<TblPumps>())
        //        {
        //                return repo.TblPumps
        //                           .Where(p => p.PumpNo==pumpNo && p.BranchCode==branchCode)
        //                           .ToList();
        //            }
        //        }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<TblProduct> GetProducts(string productCode)
        //{
        //    try
        //    {
        //        using (Repository<TblProduct> repo = new Repository<TblProduct>())
        //        {

        //                productCode = productCode.ToLower();

        //                return repo.TblProduct
        //                           .Where(p => p.ProductCode.ToLower() == productCode.ToLower())
        //                           .ToList();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public decimal? GetProductRate(string branchCode,string productCode)
        //{
        //    try
        //    {
        //        decimal? _salesRate = default(decimal?);

        //        using (Repository<TblProduct> repo = new Repository<TblProduct>())
        //        {
        //            var _product = repo.TblProduct.Where(p => p.ProductCode == productCode ).FirstOrDefault();

        //            var _mshrates = GetMshsdrates(branchCode,_product.ProductCode);
        //            if(_mshrates != null)
        //            {
        //                _salesRate = _mshrates.Rate;  
        //            }
        //            else if (_product != null)
        //                _salesRate = _product.SalesRate;
        //        }

        //        return _salesRate;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public decimal? GetProductQty(string branchCode, string productCode, string ProductId = null)
        {
            try
            {
                List<TblStockInformation> stocInfoList = null;
                using (Repository<TblStockInformation> repo = new Repository<TblStockInformation>())
                {
                    stocInfoList = repo.TblStockInformation.Where(stock => stock.ProductCode == productCode && stock.Branch == branchCode).ToList();
                }

                var qty = stocInfoList.Sum(x => x.InwardQty) - stocInfoList.Sum(x => x.OutwardQty);

                if (qty > 0)
                    return qty;

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public TblTaxStructure GetTaxStructure(decimal taxstructureCode)
        //{
        //    try
        //    {
        //        using (Repository<TblTaxStructure> repo=new Repository<TblTaxStructure>())
        //        {
        //            return repo.TblTaxStructure.Where(st=> st.TaxStructureCode == taxstructureCode).FirstOrDefault();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public TblTaxStructure GetTaxStructureByTaxStuctId(decimal taxStructureId)
        //{
        //    try
        //    {
        //        using (Repository<TblTaxStructure> repo = new Repository<TblTaxStructure>())
        //        {
        //            return repo.TblTaxStructure.Where(st => st.TaxStructureId == taxStructureId).FirstOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public TblInvoiceDetail GetBillingDetailsSection(string branchCode,string productCode, IConfiguration configuration=null)
        //{
        //    try
        //    {
        //        bool IsTaxApplicable = false;
        //        var _product = GetProducts(productCode).FirstOrDefault();

        //        var invoceDetails = new TblInvoiceDetail();
        //        if(_product == null)
        //        {
        //            return invoceDetails;
        //        }

        //        //check tax calculation is required or not
        //        if (_product.TaxapplicableOn != null)
        //        {
        //            if (_product.TaxapplicableOn.Equals("INPUT", StringComparison.InvariantCultureIgnoreCase) || _product.TaxapplicableOn.Equals("NONE", StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                IsTaxApplicable = false;
        //            }
        //            else
        //            {
        //                IsTaxApplicable = true;
        //            }
        //        }

        //        invoceDetails.UnitId = Convert.ToDecimal(_product.UnitId ?? 0);
        //        invoceDetails.UnitName = _product.UnitName;

        //        invoceDetails.TaxStructureCode = Convert.ToDecimal(_product.TaxStructureCode ?? 0);
        //        invoceDetails.TaxStructureId = Convert.ToDecimal(_product.TaxStructureId ?? 0);
        //        invoceDetails.TaxGroupCode = _product.TaxGroupCode;
        //        invoceDetails.TaxGroupId = Convert.ToDecimal(_product.TaxGroupId ?? 0);
        //        invoceDetails.TaxGroupName = _product.TaxGroupName;
        //        invoceDetails.Rate = GetProductRate(branchCode, productCode);

        //        invoceDetails.HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0);
        //        invoceDetails.ProductCode = _product.ProductCode;
        //        invoceDetails.ProductGroupCode = Convert.ToDecimal(_product.ProductGroupCode ?? 0);
        //        invoceDetails.ProductGroupId = Convert.ToDecimal(_product.ProductGroupId ?? 0);
        //        invoceDetails.ProductId = _product.ProductId;
        //        invoceDetails.ProductName = _product.ProductName;
        //        invoceDetails.ServerDateTime = DateTime.Now;
        //        if (_product.TaxStructureCode != null)
        //        {
        //            if (IsTaxApplicable)
        //            {
        //                var taxStructure = GetTaxStructure(Convert.ToDecimal(_product.TaxStructureCode));
        //                if (taxStructure != null)
        //                {
        //                    invoceDetails.Sgst = taxStructure.Sgst;
        //                    invoceDetails.Cgst = taxStructure.Sgst;
        //                    invoceDetails.Igst = taxStructure.Igst;
        //                    invoceDetails.TotalGst = taxStructure.TotalGst;
        //                }
        //            }
        //            else
        //            {
        //                invoceDetails.Sgst = 0;
        //                invoceDetails.Cgst = 0;
        //                invoceDetails.Igst = 0;
        //                invoceDetails.TotalGst = 0;
        //            }
        //        }

        //        try
        //        {
        //            string _ChildBranches = string.Empty;

        //            //to get data from child branch
        //            string _productCodes = configuration.GetSection("ProductCods").Value;
        //            if (!string.IsNullOrEmpty(_productCodes))
        //            {
        //                if (!_productCodes.ToUpper().Contains(productCode.ToUpper()))
        //                {
        //                    _ChildBranches = configuration.GetSection("ChildBranches:" + branchCode).Value;
        //                }
        //            }

        //            if(string.IsNullOrEmpty(_ChildBranches))
        //              invoceDetails.AvailStock = Convert.ToDecimal(GetProductQty(branchCode, productCode) ?? 0);
        //            else
        //                invoceDetails.AvailStock = Convert.ToDecimal(GetProductQty(_ChildBranches, productCode) ?? 0);
        //        }
        //        catch { }
        //        return invoceDetails;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //private TblMshsdrates GetMshsdrates(string branchCode,string productCode)
        //{
        //    try
        //    {
        //        using (Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>())
        //        {
        //            return repo.TblMshsdrates.Where(x => x.ProductCode == productCode && x.BranchCode == branchCode).FirstOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<TblMemberMaster> GetMembers(string memberName=null)
        //{
        //    try
        //    {
        //      return  new MemberHelper().GetMembersByName(memberName);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public TblMemberMaster GetMembersByCode(string memberCode)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(memberCode))
        //            return new MemberHelper().GetMembersByCode(Convert.ToDecimal(memberCode));

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<TblVehicle> GetVehicles(String vechileRegno,string memberCode)
        //{
        //    try
        //    {
        //        return new VechileMasterHelper().GetVehicles(vechileRegno,Convert.ToDecimal(memberCode)).Where(x=>x.IsValid == 1).ToList();
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public TblInvoiceMaster GetInvoiceMaster(string invoiceNo)
        {
            try
            {
                using var repo = new Repository<TblBusinessPartnerAccount>();
                var customer = repo.TblBusinessPartnerAccount.ToList();

                var invoice = repo.TblInvoiceMaster.FirstOrDefault(x => x.InvoiceNo == invoiceNo);

                var saleorder = repo.TblSaleOrderMaster.FirstOrDefault(d => d.SaleOrderNo == invoice.SaleOrderNo);

                repo.TblInvoiceMaster.ToList()
                    .ForEach(c =>
                    {
                        c.poNo = saleorder.PONumber;
                        c.poDate = saleorder.PODate;
                        c.dateOfSupply = saleorder.DateofSupply;
                        c.CustName = customer.FirstOrDefault(z => z.Bpnumber == c.CustomerName)?.Name;
                    });

                return repo.TblInvoiceMaster
                    .FirstOrDefault(x => x.InvoiceNo == invoiceNo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TblInvoiceMaster> GetInvoiceList(string companycode)
        {
            try
            {


                using var repo = new Repository<TblInvoiceMaster>();
                return repo.TblInvoiceMaster.ToList().Where(x => x.Status != "Dispatched" && x.Company == companycode);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TblInvoiceMaster> GetInvoiceData(string saleorder)
        {
            try
            {


                using var repo = new Repository<TblInvoiceMaster>();
                return repo.TblInvoiceMaster.ToList().Where(x => x.Status != "Dispatched" && x.SaleOrderNo == saleorder);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblInvoiceMaster GetInvoiceMasterbysaeorder(string saleorder)
        {
            try
            {
                using var repo = new Repository<TblBusinessPartnerAccount>();
                var customer = repo.TblBusinessPartnerAccount.ToList();

                repo.TblInvoiceMaster.ToList()
                    .ForEach(c =>
                    {

                        c.CustName = customer.FirstOrDefault(z => z.Bpnumber == c.CustomerName)?.Name;

                    });

                return repo.TblInvoiceMaster
                    .FirstOrDefault(x => x.SaleOrderNo == saleorder);

                //return repo.TblInvoiceMaster
                //    .FirstOrDefault(x => x.SaleOrderNo == saleorder && x.Status.Contains("Dispatched"));

            }
            catch (Exception ex)
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
                    var materialtype = repo.TblMaterialMaster.ToList();
                    var HSCCODE = repo.TblHsnsac.ToList();
                    var unit = repo.TblUnit.ToList();

                    repo.TblInvoiceDetail.ToList()
                    .ForEach(c =>
                    {
                        c.MaterialName = materialtype.FirstOrDefault(z => z.MaterialCode == c.Bomkey)?.Description;
                        c.HsnNo = HSCCODE.FirstOrDefault(z => z.Code == c.HsnNo)?.Description;
                        c.uom = unit.FirstOrDefault(z => Convert.ToString(z.UnitId) == c.uom)?.UnitName;
                    });

                    return repo.TblInvoiceDetail.Where(x => x.InvoiceNo == invoiceNo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblInvoiceDetail> GetInvoiceDetailsAmrit(string invoiceNo)
        {
            try
            {
                using (Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>())
                {
                    var materialtype = repo.TblMaterialMaster.ToList();
                    var HSCCODE = repo.TblHsnsac.ToList();
                    var unit = repo.TblUnit.ToList();

                    repo.TblInvoiceDetail.ToList()
                    .ForEach(c =>
                    {
                        c.MaterialName = materialtype.FirstOrDefault(z => z.MaterialCode == c.MaterialCode)?.Description;
                        c.HsnNo = HSCCODE.FirstOrDefault(z => z.Code == c.HsnNo)?.Description;
                        c.uom = unit.FirstOrDefault(z => Convert.ToString(z.UnitId) == c.uom)?.UnitName;
                    });

                    return repo.TblInvoiceDetail.Where(x => x.InvoiceNo == invoiceNo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<TblInvoiceDetail> GetInvoiceDetailsbysaleorder(string saleorder)
        {
            try
            {
                using (Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>())
                {
                    return repo.TblInvoiceDetail.Where(x => x.Saleorder == saleorder).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblInvoiceDetail> GetInvoiceDetailList(string TagName)
        {
            try
            {
                using (Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>())
                {
                    return repo.TblInvoiceDetail.Where(x => x.TagName.Contains(TagName) && x.Status.Contains("Dispatched")).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*************************   Helper methods For invoice*******************************************/

        public bool IsInvoiceNoExists(string invoiceNo)
        {
            try
            {
                using (Repository<TblInvoiceMaster> _repo = new Repository<TblInvoiceMaster>())
                {
                    return _repo.TblInvoiceMaster.Where(inv => inv.InvoiceNo == invoiceNo).Count() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RegisterBill(IConfiguration configuration, TblInvoiceMaster invoice, List<TblInvoiceDetail> invoiceDetails, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                using var repo1 = new Repository<TblInvoiceMaster>();
                var SaleOrder = repo1.TblSaleOrderMaster.FirstOrDefault(im => im.SaleOrderNo == invoice.SaleOrderNo && im.Company == invoice.Company);
                var Inspection = repo1.TblInspectionCheckMaster.FirstOrDefault(im => im.saleOrderNumber == invoice.SaleOrderNo && im.Company == invoice.Company);
                var InvoiceHist = repo1.TblInvoiceDetail.Where(im => im.Saleorder == invoice.SaleOrderNo);
                var customer = repo1.TblBusinessPartnerAccount.FirstOrDefault(x => x.Bpnumber == invoice.CustomerName);
                var InvoiceMemoHeader = new TblInvoiceMemoHeader();
                var InvoiceMemoDetails = new List<TblInvoiceMemoDetails>();
                using (ERPContext repo = new ERPContext())
                {
                    using (var dbTransaction = repo.Database.BeginTransaction())
                    {
                        try
                        {
                            int histinvqty = 0;
                            if (histinvqty != null)
                                histinvqty = Convert.ToInt16(InvoiceHist.Sum(x => x.Qty));

                            int sqty = 0;
                            int invqty = 0;
                            string message = null;
                            sqty = SaleOrder.TotalQty;
                            invqty = (Convert.ToInt16(invoiceDetails.Sum(x => x.Qty))) + (histinvqty);
                            if (sqty == invqty)
                                message = "Invoice Generated";
                            else
                                message = "Invoice Partially Generated";

                            var invoice_No = invoice.InvoiceNo;
                            if (string.IsNullOrEmpty(invoice_No))
                                invoice_No = GenerateInvoiceNo(out errorMessage);

                            if (!string.IsNullOrEmpty(invoice_No))
                                invoice.InvoiceNo = invoice_No;

                            invoice.ServerDateTime = DateTime.Now;
                            invoice.InvoiceQty = invoiceDetails.Count();
                            invoice.PONumber = SaleOrder.PONumber;
                            invoice.Status = message;
                            repo.TblInvoiceMaster.Add(invoice);
                            repo.SaveChanges();
                            var SaleOrderDetails = new TblSaleOrderDetail();
                            var materialmaster = new TblMaterialMaster();
                            foreach (var invdtl in invoiceDetails)
                            {
                                //var SaleOrderDetails = new TblSaleOrderDetail();
                                //var inspection = new TblInspectionCheckDetails();
                                if (invoice.Company == "1000")
                                {
                                    SaleOrderDetails = repo.TblSaleOrderDetail.FirstOrDefault(im => im.SaleOrderNo == invdtl.Saleorder && im.MaterialCode == invdtl.Bomkey);
                                    materialmaster = repo.TblMaterialMaster.FirstOrDefault(xx => xx.MaterialCode == invdtl.Bomkey);
                                    invdtl.HsnNo = materialmaster.Hsnsac;
                                    invdtl.uom = materialmaster.Uom;
                                }
                                else
                                {
                                    SaleOrderDetails = repo.TblSaleOrderDetail.FirstOrDefault(im => im.SaleOrderNo == invdtl.Saleorder && im.MaterialCode == invdtl.MaterialCode);
                                    materialmaster = repo.TblMaterialMaster.FirstOrDefault(xx => xx.MaterialCode == invdtl.MaterialCode);
                                    invdtl.HsnNo = materialmaster.Hsnsac;
                                    invdtl.uom = materialmaster.Uom;
                                }
                                var inspection = repo.TblInspectionCheckDetails.FirstOrDefault(x => x.productionTag == invdtl.TagName);
                                #region InvioceDetail
                                invdtl.Qty = 1;
                                invdtl.Status = message;
                                invdtl.InvoiceNo = invoice.InvoiceNo;
                                invdtl.InvoiceDate = invoice.InvoiceDate;
                                invdtl.ServerDateTime = DateTime.Now;
                                invdtl.UserId = invoice.UserId;
                                repo.TblInvoiceDetail.Add(invdtl);

                                inspection.Status = message;
                                repo.TblInspectionCheckDetails.UpdateRange(inspection);

                                SaleOrderDetails.Status = message;
                                repo.TblSaleOrderDetail.UpdateRange(SaleOrderDetails);


                                materialmaster.OpeningQty = ((materialmaster.OpeningQty) - 1);
                                materialmaster.EditDate = System.DateTime.Now;
                                repo.TblMaterialMaster.UpdateRange(materialmaster);

                                repo.SaveChanges();

                                #endregion

                            }
                            TransactionsHelper transactionsHelper = new TransactionsHelper();
                            string vouchernumber = transactionsHelper.GetVoucherNumber("IN");
                            //foreach (var commit in result)
                            //{
                            //InvoiceMemoHeader.Add(new TblInvoiceMemoHeader { Company = grdata.Company, VoucherClass = "02",VoucherType="BD",VoucherDate=System.DateTime.Now,PostingDate = System.DateTime.Now,VoucherNumber= vouchernumber,TransactionType="Invoice",NatureofTransaction="Purchase",Bpcategory="200",PartyAccount= grdata.SupplierCode,AccountingIndicator= CRDRINDICATORS.Debit.ToString(), ReferenceNumber=grdata.SupplierReferenceNo,ReferenceDate=grdata.ReceivedDate,PartyInvoiceNo=grdata.SupplierReferenceNo, TotalAmount=grdata.TotalAmount, Status = "N", SaleOrderNo=grdata.SaleorderNo });
                            InvoiceMemoHeader.Company = invoice.Company;
                            InvoiceMemoHeader.VoucherClass = "02";
                            InvoiceMemoHeader.VoucherType = "IN";
                            InvoiceMemoHeader.VoucherDate = System.DateTime.Now;
                            InvoiceMemoHeader.PostingDate = System.DateTime.Now;
                            InvoiceMemoHeader.VoucherNumber = vouchernumber;
                            InvoiceMemoHeader.TransactionType = "Invoice";
                            InvoiceMemoHeader.NatureofTransaction = "Sales";
                            InvoiceMemoHeader.Bpcategory = "100";
                            InvoiceMemoHeader.PartyAccount = invoice.CustomerName;
                            InvoiceMemoHeader.AccountingIndicator = CRDRINDICATORS.Credit.ToString();
                            InvoiceMemoHeader.ReferenceNumber = invoice.InvoiceNo;
                            InvoiceMemoHeader.ReferenceDate = invoice.InvoiceDate;
                            InvoiceMemoHeader.PartyInvoiceNo = invoice.PONumber;
                            InvoiceMemoHeader.TotalAmount = invoice.GrandTotal;
                            InvoiceMemoHeader.Status = "N";
                            InvoiceMemoHeader.SaleOrderNo = invoice.SaleOrderNo;
                            //}

                            repo.TblInvoiceMemoHeader.AddRange(InvoiceMemoHeader);
                            int lineitem = 0;
                            foreach (var item in invoiceDetails)
                            {
                                lineitem = (lineitem + 1);
                                InvoiceMemoDetails.Add(new TblInvoiceMemoDetails { Company = invoice.Company, VoucherNo = vouchernumber, VoucherDate = System.DateTime.Now, PostingDate = System.DateTime.Now, LineItemNo = lineitem.ToString(), Glaccount = "250000", Amount = item.GrossAmount, TaxCode = item.TaxStructureId, Cgstamount = item.cgstcode, Igstamount = item.Igst, Sgstamount = item.Sgst, Hsnsac = item.HsnNo, OrderNo = item.InvoiceNo, AccountingIndicator = CRDRINDICATORS.Credit.ToString(), Status = "N" });
                            }
                            repo.TblInvoiceMemoDetails.AddRange(InvoiceMemoDetails);
                            repo.SaveChanges();

                            SaleOrder.Status = message;
                            repo.TblSaleOrderMaster.Update(SaleOrder);
                            if (Inspection != null)
                            {
                                Inspection.Status = message;
                                Inspection.Company = SaleOrder.Company;
                                repo.TblInspectionCheckMaster.Update(Inspection);
                            }

                            if (customer != null)
                            {
                                customer.ClosingBalance = (Convert.ToInt32(customer.ClosingBalance) + (Convert.ToInt32(invoice.GrandTotal)));
                                repo.TblBusinessPartnerAccount.Update(customer);
                            }
                            repo.SaveChanges();
                            dbTransaction.Commit();
                            // Call SMS notification here
                            FastSMSService smsService = new FastSMSService();

                            // You will need the SO number and vendor details here
                            string customerCode = invoice.CustomerName;

                            var Name = repo.TblBusinessPartnerAccount
                                .Where(bp => bp.Bpnumber == customerCode)
                                .Select(bp => bp.Name)
                                .FirstOrDefault();

                            string soNumber = invoice.InvoiceNo;
                            string vendorName = Name;
                            string vendorMobile;
                            if (invoice.Company == "2000")
                            {
                                vendorMobile = "9666756333";
                                smsService.AmritSI(vendorMobile, soNumber, vendorName, invoice.Company);
                            }
                            else
                            {
                                vendorMobile = "9704288499";
                                smsService.SendSOCreationMessage(vendorMobile, soNumber, vendorName, invoice.Company);
                            }

                            
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

        public bool SwapOrder(IConfiguration configuration, TblOrderSwap invoice, List<TblOrderSwapDetails> invoiceDetails, string SaleOrderNumber, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                using var repo1 = new Repository<TblInvoiceMaster>();
                var SaleOrder = repo1.TblSaleOrderMaster.FirstOrDefault(im => im.SaleOrderNo == invoice.ToSaleOrder && im.Company == invoice.Company);
                var Inspection = repo1.TblInspectionCheckMaster.FirstOrDefault(im => im.saleOrderNumber == invoice.FromSaleOrder && im.Company == invoice.Company);
                var tblProduction = new TblProductionMaster();
                var customer = repo1.TblBusinessPartnerAccount.FirstOrDefault(x => x.Bpnumber == SaleOrder.CustomerCode);
                var GoodsIssue = repo1.TblGoodsIssueMaster.FirstOrDefault(x => x.SaleOrderNumber == invoice.FromSaleOrder);
                var InvoiceMemoHeader = new TblInvoiceMemoHeader();
                var GoodsIssueDetails = new List<TblGoodsIssueDetails>();
                var GoodsIssueD = new TblGoodsIssueDetails();
                var ProductionD = new TblProductionDetails();
                var ProductionDetails = new List<TblProductionDetails>();
                var ProductionStatus = new List<TblProductionStatus>();
                var ProductionS = new TblProductionStatus();
                using (ERPContext repo = new ERPContext())
                {
                    using (var dbTransaction = repo.Database.BeginTransaction())
                    {
                        try
                        {
                            TblGoodsIssueMaster GoodsIssueMaster = new TblGoodsIssueMaster();
                            GoodsIssueMaster.Company = GoodsIssue.Company;
                            GoodsIssueMaster.ProfitCenter = GoodsIssue.ProfitCenter;
                            GoodsIssueMaster.StoresPerson = GoodsIssue.StoresPerson;
                            GoodsIssueMaster.Department = GoodsIssue.Department;
                            GoodsIssueMaster.SaleOrderNumber = invoice.ToSaleOrder;
                            GoodsIssueMaster.ProductionPerson = GoodsIssue.ProductionPerson;
                            GoodsIssueMaster.Status = GoodsIssue.Status;
                            GoodsIssueMaster.SaleOrder = GoodsIssue.SaleOrder;
                            GoodsIssueMaster.CustomerCode = SaleOrder.CustomerCode;
                            repo.TblGoodsIssueMaster.Add(GoodsIssueMaster);


                            tblProduction.Company = GoodsIssue.Company;
                            tblProduction.SaleOrderNumber = invoice.ToSaleOrder;
                            tblProduction.Status = GoodsIssue.Status; ;
                            tblProduction.ProfitCenter = GoodsIssue.ProfitCenter;
                            tblProduction.CustomerCode = SaleOrder.CustomerCode;
                            repo.TblProductionMaster.Add(tblProduction);
                            repo.SaveChanges();

                            foreach (var item in invoiceDetails)
                            {
                                GoodsIssueDetails.Add(new TblGoodsIssueDetails { Qty = item.Qty, AllocatedQTY = item.AllocatedQty, MaterialCode = item.MaterialCode, SaleOrderNumber = invoice.ToSaleOrder, Status = GoodsIssue.Status });
                                GoodsIssueD = repo1.TblGoodsIssueDetails.FirstOrDefault(x => x.SaleOrderNumber == invoice.FromSaleOrder && x.MaterialCode == item.MaterialCode);
                                GoodsIssueD.AllocatedQTY = (Convert.ToInt32(GoodsIssueD.AllocatedQTY) - (Convert.ToInt32(item.AllocatedQty)));
                                GoodsIssueD.Qty = (Convert.ToInt32(GoodsIssueD.Qty) - (Convert.ToInt32(item.Qty)));
                            }
                            repo.TblGoodsIssueDetails.AddRange(GoodsIssueDetails);
                            // repo.SaveChanges();

                            repo.TblGoodsIssueDetails.UpdateRange(GoodsIssueD);
                            // repo.SaveChanges();

                            foreach (var invdtl in invoiceDetails)
                            {
                                ProductionD = repo1.TblProductionDetails.FirstOrDefault(x => x.SaleOrderNumber == invoice.FromSaleOrder && x.MaterialCode == invdtl.MaterialCode && x.ProductionTag == invdtl.ProductionTag);
                                ProductionDetails.Add(new TblProductionDetails { SaleOrderNumber = invoice.FromSaleOrder, ProductionTag = ProductionD.ProductionTag, Status = ProductionD.Status, MaterialCode = ProductionD.MaterialCode, ProductionPlanDate = ProductionD.ProductionPlanDate, ProductionTargetDate = ProductionD.ProductionTargetDate });
                                repo.TblProductionDetails.AddRange(ProductionDetails);

                                repo.TblProductionDetails.Remove(ProductionD);
                                // repo.SaveChanges();

                            }
                            foreach (var commit in invoiceDetails)
                            {
                                ProductionS = repo1.TblProductionStatus.FirstOrDefault(x => x.SaleOrderNumber == invoice.FromSaleOrder && x.MaterialCode == commit.MaterialCode && x.ProductionTag == commit.ProductionTag);
                                ProductionStatus.Add(new TblProductionStatus { SaleOrderNumber = ProductionS.SaleOrderNumber, ProductionTag = ProductionS.ProductionTag, Status = ProductionS.Status, WorkStatus = ProductionS.Status, MaterialCode = ProductionS.MaterialCode, TypeofWork = ProductionS.TypeofWork });
                                repo.TblProductionStatus.AddRange(ProductionStatus);

                                repo.TblProductionStatus.Remove(ProductionS);
                            }

                            repo.SaveChanges();
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
        //public List<TblVoucherType> GetVoucherType(decimal voucherTypeId)
        //{
        //    try
        //    {
        //        using(Repository<TblVoucherType> repo=new Repository<TblVoucherType>())
        //        {
        //            return repo.TblVoucherType.Where(v => v.VoucherTypeId == voucherTypeId).ToList();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public TblVoucherMaster AddVoucherMaster(ERPContext context,TblInvoiceMaster invoice,TblBranch branch,decimal? voucherTypeId,string paymentType)
        //{
        //    try
        //    {
        //        //using (ERPContext context = new ERPContext())
        //        //{
        //            var _voucherMaster = new TblVoucherMaster();
        //            _voucherMaster.BranchCode = invoice.BranchCode;
        //            _voucherMaster.BranchName = branch.BranchName;
        //            _voucherMaster.VoucherDate = invoice.InvoiceDate;
        //            _voucherMaster.VoucherTypeIdMain = voucherTypeId;
        //            _voucherMaster.VoucherTypeIdSub = 35;
        //            _voucherMaster.VoucherNo = invoice.InvoiceNo;
        //            _voucherMaster.Amount = invoice.GrandTotal;
        //            _voucherMaster.PaymentType = paymentType;//accountLedger.CrOrD
        //            _voucherMaster.Narration = "Sales Invoice";
        //            _voucherMaster.ServerDate = DateTime.Now;
        //            _voucherMaster.UserId = invoice.UserId;
        //            _voucherMaster.UserName = invoice.UserName;
        //            _voucherMaster.ShiftId = invoice.ShiftId;
        //            _voucherMaster.EmployeeId = invoice.EmployeeId;

        //            context.TblVoucherMaster.Add(_voucherMaster);
        //            if (context.SaveChanges() > 0)
        //            {
        //                return _voucherMaster;
        //            }

        //            return null;
        //       // }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public TblVoucherDetail AddVoucherDetails(ERPContext context, TblInvoiceMaster invoice, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? totalAmount,string transactionType, bool isFromInvoiceDetials = true)
        //{
        //    try
        //    {
        //        //using(ERPContext context=new ERPContext())
        //        //{
        //        var _voucherDetail = new TblVoucherDetail();
        //        _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
        //        _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
        //        _voucherDetail.BranchId = _branch.BranchId;
        //        _voucherDetail.BranchCode = invoice.BranchCode;
        //        _voucherDetail.BranchName = invoice.BranchName;

        //        _voucherDetail.Amount = totalAmount;  // wihtout tax
        //        _voucherDetail.TransactionType = transactionType; /*_accountLedger.CrOrDr;*/
        //        _voucherDetail.CostCenter = _voucherDetail.BranchCode;
        //        _voucherDetail.ServerDate = DateTime.Now;
        //        _voucherDetail.Narration = $"Sales Invoice {_accountLedger.LedgerName} A /c: {_voucherDetail.TransactionType}";


        //        if (isFromInvoiceDetials)
        //        {
        //            _voucherDetail.FromLedgerId = invoice.LedgerId;
        //            _voucherDetail.FromLedgerCode = invoice.LedgerCode;
        //            _voucherDetail.FromLedgerName = invoice.LedgerName;
        //        }
        //        //To ledger  clarifiaction on selecion of product

        //        _voucherDetail.ToLedgerId = _accountLedger.LedgerId;
        //        _voucherDetail.ToLedgerCode = _accountLedger.LedgerCode;
        //        _voucherDetail.ToLedgerName = _accountLedger.LedgerName;

        //        context.TblVoucherDetail.Add(_voucherDetail);
        //        if (context.SaveChanges() > 0)
        //            return _voucherDetail;


        //        return null;
        //        // }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public TblStockInformation AddStockInformation(IConfiguration configuration,ERPContext context,TblInvoiceMaster invoice,TblBranch _branch,TblProduct _product,decimal? qty,decimal? rate)
        //{
        //    try
        //    {
        //        string _ChildBranches = string.Empty;
        //        var _stockInformation = new TblStockInformation();

        //        string _productCodes = configuration.GetSection("ProductCods").Value;
        //        if (!string.IsNullOrEmpty(_productCodes))
        //        {
        //            if (!_productCodes.ToUpper().Contains(_product.ProductCode.ToUpper()))
        //            {
        //                _ChildBranches = configuration.GetSection("ChildBranches:" + _branch.BranchCode).Value;
        //            }
        //        }

        //        if (!string.IsNullOrEmpty(_ChildBranches))
        //        {
        //            var branch = GetBranches(_ChildBranches).FirstOrDefault();
        //            _stockInformation.BranchId = branch.BranchId;
        //            _stockInformation.BranchCode = branch.BranchCode;
        //        }
        //        else
        //        {
        //            _stockInformation.BranchId = _branch.BranchId;
        //            _stockInformation.BranchCode = _branch.BranchCode;
        //        }
        //        _stockInformation.ShiftId = invoice.ShiftId;
        //        _stockInformation.VoucherNo = invoice.VoucherNo;
        //        _stockInformation.VoucherTypeId = invoice.VoucherTypeId;
        //        _stockInformation.InvoiceNo = invoice.InvoiceNo;
        //        _stockInformation.ProductId = _product.ProductId;
        //        _stockInformation.ProductCode = _product.ProductCode;
        //        _stockInformation.OutwardQty = qty;
        //        _stockInformation.InwardQty = 0;
        //        _stockInformation.Rate = rate;
        //        _stockInformation.UserId = invoice.UserId;
        //        _stockInformation.TransactionDate = invoice.InvoiceDate;

        //        context.TblStockInformation.Add(_stockInformation);
        //        if (context.SaveChanges() > 0)
        //            return _stockInformation;


        //        return null;
        //        //  }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context,TblVoucherDetail _voucherDetail,DateTime? invoiceDate)
        //{
        //    try
        //    {
        //        //using(ERPContext context=new ERPContext())
        //        //{
        //        var _accountLedgerTransactions = new TblAccountLedgerTransactions();
        //        _accountLedgerTransactions.VoucherDetailId = _voucherDetail.VoucherDetailId;
        //        _accountLedgerTransactions.LedgerId = _voucherDetail.ToLedgerId;
        //        _accountLedgerTransactions.LedgerCode = _voucherDetail.ToLedgerCode;
        //        _accountLedgerTransactions.LedgerName = _voucherDetail.ToLedgerName;
        //        _accountLedgerTransactions.BranchId = _voucherDetail.BranchId;
        //        _accountLedgerTransactions.BranchCode = _voucherDetail.BranchCode;
        //        _accountLedgerTransactions.BranchName = _voucherDetail.BranchName;
        //        _accountLedgerTransactions.TransactionDate = invoiceDate;
        //        _accountLedgerTransactions.TransactionType = _voucherDetail.TransactionType;
        //        _accountLedgerTransactions.VoucherAmount = _voucherDetail.Amount;

        //        if (_accountLedgerTransactions.TransactionType.ToUpper().Equals("DEBIT", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            _accountLedgerTransactions.CreditAmount = Convert.ToDecimal("0.00");
        //            _accountLedgerTransactions.DebitAmount = _accountLedgerTransactions.VoucherAmount;
        //        }
        //        else if (_accountLedgerTransactions.TransactionType.ToUpper().Equals("CREDIT", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            _accountLedgerTransactions.DebitAmount = Convert.ToDecimal("0.00");
        //            _accountLedgerTransactions.CreditAmount = _accountLedgerTransactions.VoucherAmount;
        //        }

        //        context.TblAccountLedgerTransactions.Add(_accountLedgerTransactions);
        //        if (context.SaveChanges() > 0)
        //            return _accountLedgerTransactions;


        //        return null;
        //        //  }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public Smsstatus AddSmsStatus(ERPContext context, TblInvoiceMaster invoice, decimal invRate, decimal invQty, decimal invAmount, string SmsResult, string advanceMobile)
        {
            try
            {
                var _smsStatus = new Smsstatus();
                _smsStatus.InvoiceNo = invoice.InvoiceNo;
                _smsStatus.InvoiceDate = invoice.InvoiceDate;
                // _smsStatus.Branch = invoice.BranchName;
                if (invoice.Mobile == null)
                {
                    _smsStatus.Mobile = advanceMobile;
                }
                else
                {
                    _smsStatus.Mobile = invoice.Mobile;
                }
                if (invoice.VehicleRegNo == null)
                {
                    _smsStatus.VehicleRegNo = "";
                }
                else
                {
                    _smsStatus.VehicleRegNo = invoice.VehicleRegNo;
                }
                _smsStatus.Price = invRate;
                _smsStatus.Qty = invQty;
                _smsStatus.Amount = invAmount;
                if (SmsResult != null)
                {
                    _smsStatus.Status = 1;
                    _smsStatus.SmsReturnId = SmsResult;
                }
                else
                {
                    _smsStatus.Status = -1;
                    _smsStatus.SmsReturnId = "-1";
                }

                context.Smsstatus.Add(_smsStatus);
                if (context.SaveChanges() > 0)
                {
                    return _smsStatus;
                }

                return null;


            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        // validation 
        public int NoOfrecordsAllowed(IConfiguration configuration, string branchCode)
        {
            var _branchList = configuration.GetSection("InvoiceRecordsCount:3").Value;
            if (_branchList.Split(",").Contains(branchCode))
                return 3;

            return 6;
        }

        public string SendSMS(string User, string password, string sid, string Mobile_Number, string Message, string Mtype, string DR)
        {
            string stringpost = null;
            //stringpost = "username=" + User + "&password=" + password + "&senderid=" + sid + "&to_numbers=" + Mobile_Number + "&message=" + Message + "&api_key=" + "oRRS4csr7iUmU5uKdayEffnSdtHgoMrUozc7xSPxd4rSOH3tY7"
            //    + "&unicode=" + 0 + "&dlrurl=" + "https://en31t2u38ozab.x.pipedream.net&ref_id=A1B2C3";

            stringpost = "to_numbers=" + Mobile_Number + "&message=" + Message + "&senderid=" + sid + "&api_key=" + "oRRS4csr7iUmU5uKdayEffnSdtHgoMrUozc7xSPxd4rSOH3tY7" + "&template_id=" + 112233445566778899 + "&pe_id=" + 112233445566778899;

            //+"&MType=" + Mtype + "&DR=" + DR

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync("https://api.salesquared.io/sendsms/v1?to_numbers=" + Mobile_Number + "&message=" + Message + "&senderid=KDLOMA&api_key=oRRS4csr7iUmU5uKdayEffnSdtHgoMrUozc7xSPxd4rSOH3tY7&template_id=1407161855329747010&pe_id=1401377320000013424").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;

                        // by calling .Result you are synchronously reading the result
                        stringResult = responseContent.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode == true)
                        {
                            stringResult = "Success";
                        }
                    }
                    return stringResult;
                }
                //string stringResult = null;

                ////objWebRequest = (HttpWebRequest)WebRequest.Create("http://www.smscountry.com/SMSCwebservice_bulk.aspx");
                ////objWebRequest = (HttpWebRequest)WebRequest.Create("http://new.smsdaddy.in/webapi.php");
                ////objWebRequest = (HttpWebRequest)WebRequest.Create("https://api.salesquared.io/sendsms/v1");


                //objWebRequest.Method = "GET";

                //if ((objProxy1 != null))
                //{
                //    objWebRequest.Proxy = objProxy1;
                //}


                //// Use below code if you want to SETUP PROXY.
                ////Parameters to pass: 1. ProxyAddress 2. Port
                ////You can find both the parameters in Connection settings of your internet explorer.

                ////WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
                ////myProxy.BypassProxyOnLocal = true;
                ////wrGETURL.Proxy = myProxy;

                //objWebRequest.ContentType = "application/x-www-form-urlencoded";

                //objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                //objStreamWriter.Write(stringpost);
                //objStreamWriter.Flush();
                //objStreamWriter.Close();

                //objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                //objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                //stringResult = objStreamReader.ReadToEnd();

                //objStreamReader.Close();
                //return stringResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }

        }
    }
}

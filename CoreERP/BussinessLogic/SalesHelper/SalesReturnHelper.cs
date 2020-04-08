using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CoreERP.BussinessLogic.SalesHelper
{
    public class SalesReturnHelper
    {
        public string GenerateSalesReturnInvoiceNo(string branchCode,out string errorMessage)
        {
            try
            {
                string invoiceNo = string.Empty, prefix = string.Empty, suffix = string.Empty;
                errorMessage = string.Empty;
                //return new Common.CommonHelper().GenerateNumber(20, branchCode);
                TblInvoiceMasterReturn _invoiceMasterReturn = null;

                using (Repository<TblInvoiceMaster> _repo = new Repository<TblInvoiceMaster>())
                {
                    _invoiceMasterReturn = _repo.TblInvoiceMasterReturn.Where(x => x.BranchCode == branchCode).OrderByDescending(x => x.InvoiceMasterReturnId).FirstOrDefault();

                    if (_invoiceMasterReturn != null)
                    {
                        var invSplit = _invoiceMasterReturn.InvoiceReturnNo.Split('-');
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

        #region Search sals return records
        public List<TblInvoiceMasterReturn> GetInvoiceMasterReturns(SearchCriteria searchCriteria)
        {
            try
            {
                using Repository<TblInvoiceMasterReturn> repo = new Repository<TblInvoiceMasterReturn>();
                List<TblInvoiceMasterReturn> _invoiceMasterReturnList = null;


                _invoiceMasterReturnList = repo.TblInvoiceMasterReturn.AsEnumerable()
                          .Where(inv =>
                                     DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? inv.InvoiceDate).Value.ToShortDateString())
                                   && DateTime.Parse(inv.InvoiceDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? inv.InvoiceDate).Value.ToShortDateString())
                             )
                           .ToList();

                if (!string.IsNullOrEmpty(searchCriteria.InvoiceNo))
                    _invoiceMasterReturnList = _invoiceMasterReturnList.Where(x => x.InvoiceReturnNo == searchCriteria.InvoiceNo).ToList();

                return _invoiceMasterReturnList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<TblInvoiceReturnDetail> GetInvoiceDetails(string invoiceNo)
        {
            try
            {
                using Repository<TblInvoiceReturnDetail> repo = new Repository<TblInvoiceReturnDetail>();
                return repo.TblInvoiceReturnDetail.Where(x => x.InvoiceReturnNo == invoiceNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public TblInvoiceMaster GetInvoiceMaster(decimal invoiceMasterId)
        {
            try
            {
                using Repository<TblInvoiceMaster> repo = new Repository<TblInvoiceMaster>();
                return repo.TblInvoiceMaster.Where(x => x.InvoiceMasterId == invoiceMasterId).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblInvoiceDetail> GetInvoiceDetail(decimal invoiceMasterId)
        {
            try
            {
                using Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>();
                return repo.TblInvoiceDetail.Where(x => x.InvoiceMasterId == invoiceMasterId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Sales return records
        public TblInvoiceMasterReturn RegisterInvoiceReturns(string invoiceReturnNo,decimal invoiceMasterId,out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                string _invoiceMasterDetailsjson = string.Empty;
                TblTaxStructure _taxStructure = null;
                TblProduct _product = null;
                TblInvoiceMasterReturn invoiceMasterReturn = null;
                List<TblInvoiceReturnDetail> invoiceReturnDetailList = null;
                TblInvoiceMaster invoice = GetInvoiceMaster(invoiceMasterId);
                List<TblInvoiceDetail> invoiceDetails = GetInvoiceDetail(invoiceMasterId);


                if (invoice.IsSalesReturned.Value)
                {
                    errorMessage = $"Sales no:{invoice.InvoiceNo} is already return.";
                    return null;
                }

                
                invoice.IsSalesReturned = true;
                invoice.IsManualEntry = false;

                var _invoiceMasterjson = JsonConvert.SerializeObject(invoice);
                invoiceMasterReturn = (JsonConvert.DeserializeObject<TblInvoiceMasterReturn>(_invoiceMasterjson));
                //details section
                invoiceReturnDetailList = new List<TblInvoiceReturnDetail>();
                foreach (var invd in invoiceDetails)
                {
                    _invoiceMasterDetailsjson = JsonConvert.SerializeObject(invd);
                    invoiceReturnDetailList.Add(JsonConvert.DeserializeObject<TblInvoiceReturnDetail>(_invoiceMasterDetailsjson));
                }

                using ERPContext repo = new ERPContext();
                using var dbTransaction = repo.Database.BeginTransaction();
                try
                {
                    //update invoice master table;
                    repo.TblInvoiceMaster.Update(invoice);
                    repo.SaveChanges();


                    //add voucher typedetails
                    var _invoiceHelper = new InvoiceHelper();
                    var _branch = _invoiceHelper.GetBranches(invoice.BranchCode).ToArray().FirstOrDefault();

                    var _accountLedger = _invoiceHelper.GetAccountLedgers(invoice.LedgerCode).ToArray().FirstOrDefault();
                    var _vouchertType = GetVoucherType(20).FirstOrDefault();

                    #region Add voucher master record
                    invoiceMasterReturn.InvoiceReturnNo = invoiceReturnNo;
                    var _voucherMaster = AddVoucherMaster(repo, invoiceMasterReturn, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                    #endregion

                    invoiceMasterReturn.VoucherNo = _voucherMaster.VoucherMasterId.ToString();
                    invoiceMasterReturn.InvoiceReturnDate = DateTime.Now;
                    invoiceMasterReturn.ServerDateTime = DateTime.Now;
                    repo.TblInvoiceMasterReturn.Add(invoiceMasterReturn);
                    repo.SaveChanges();

                    foreach (var invdtl in invoiceReturnDetailList)
                    {
                        _product = _invoiceHelper.GetProducts(invdtl.ProductCode).FirstOrDefault();
                        _taxStructure = _invoiceHelper.GetTaxStructure(invdtl.TaxStructureId);
                        _accountLedger = _invoiceHelper.GetAccountLedgersByLedgerId((decimal)_taxStructure.SalesAccount).FirstOrDefault();

                        #region Add voucher Details
                        var _voucherDetail = AddVoucherDetails(repo, invoiceMasterReturn, _branch, _voucherMaster, _accountLedger, invdtl.Rate);
                        #endregion

                        #region InvioceDetail

                        invdtl.InvoiceMasterReturnId = invoiceMasterReturn.InvoiceMasterReturnId;
                        invdtl.InvoiceReturnNo = invoice.InvoiceNo;
                        invdtl.InvoiceReturnDate = DateTime.Now;
                        invdtl.VoucherNo = invoiceMasterReturn.VoucherNo;
                        invdtl.StateCode = invoice.StateCode;
                        invdtl.ShiftId = invoice.ShiftId;
                        invdtl.UserId = invoice.UserId;

                        invdtl.EmployeeId = -1;
                        invdtl.ServerDateTime = DateTime.Now;

                        repo.TblInvoiceReturnDetail.Add(invdtl);
                        repo.SaveChanges();

                        #endregion

                        #region Add stock transaction  and Account Ledger Transaction
                        AddStockInformation(repo, invoiceMasterReturn, _branch, _product, invdtl.Qty > 0 ? invdtl.Qty : invdtl.FQty, invdtl.Rate);

                        AddAccountLedgerTransactions(repo, _voucherDetail, invoice.InvoiceDate);
                        #endregion
                    }

                    _accountLedger = _invoiceHelper.GetAccountLedgers(invoice.LedgerCode).ToArray().FirstOrDefault();
                    AddVoucherDetails(repo, invoiceMasterReturn, _branch, _voucherMaster, _accountLedger, invoice.GrandTotal, false);

                    //CHech weather igs or sg ,cg st
                    var _stateWiseGsts = _invoiceHelper.GetStateWiseGsts(invoice.StateCode).FirstOrDefault();
                    if (_stateWiseGsts.Igst == 1)
                    {
                        //Add IGST record
                        var _accAL = _invoiceHelper.GetAccountLedgers("243").ToArray().FirstOrDefault();
                        AddVoucherDetails(repo, invoiceMasterReturn, _branch, _voucherMaster, _accAL, invoice.TotalAmount, false);

                    }
                    else
                    {
                        // sgst
                        var _accAL = _invoiceHelper.GetAccountLedgers("240").ToArray().FirstOrDefault();
                        AddVoucherDetails(repo, invoiceMasterReturn, _branch, _voucherMaster, _accAL, invoice.TotalAmount, false);
                        // sgst
                        _accAL = _invoiceHelper.GetAccountLedgers("241").ToArray().FirstOrDefault();
                        AddVoucherDetails(repo, invoiceMasterReturn, _branch, _voucherMaster, _accAL, invoice.TotalAmount, false);
                    }

                    dbTransaction.Commit();
                    return invoiceMasterReturn;
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw ex;
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
                using Repository<TblVoucherType> repo = new Repository<TblVoucherType>();
                return repo.TblVoucherType.Where(v => v.VoucherTypeId == voucherTypeId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblVoucherMaster AddVoucherMaster(ERPContext context, TblInvoiceMasterReturn invoiceReturn, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {
                var _voucherMaster = new TblVoucherMaster
                {
                    BranchCode = invoiceReturn.BranchCode,
                    BranchName = branch.BranchName,
                    VoucherDate = invoiceReturn.InvoiceDate,
                    VoucherTypeIdMain = voucherTypeId,
                    VoucherTypeIdSub = 35,
                    VoucherNo = invoiceReturn.InvoiceReturnNo,
                    Amount = invoiceReturn.GrandTotal,
                    PaymentType = paymentType,//accountLedger.CrOrD
                    Narration = "Sales Invoice Return",
                    ServerDate = DateTime.Now,
                    UserId = invoiceReturn.UserId,
                    UserName = invoiceReturn.UserName,
                    EmployeeId = -1
                };

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
        public TblVoucherDetail AddVoucherDetails(ERPContext context, TblInvoiceMasterReturn invoiceReturn, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, bool isFromInvoiceDetials = true)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
                var _voucherDetail = new TblVoucherDetail
                {
                    VoucherMasterId = _voucherMaster.VoucherMasterId,
                    VoucherDetailDate = _voucherMaster.VoucherDate,
                    BranchId = _branch.BranchId,
                    BranchCode = invoiceReturn.BranchCode,
                    BranchName = invoiceReturn.BranchName
                };
                if (isFromInvoiceDetials)
                {
                    _voucherDetail.FromLedgerId = invoiceReturn.LedgerId;
                    _voucherDetail.FromLedgerCode = invoiceReturn.LedgerCode;
                    _voucherDetail.FromLedgerName = invoiceReturn.LedgerName;
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

              
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblStockInformation AddStockInformation(ERPContext context, TblInvoiceMasterReturn invoiceReturn, TblBranch _branch, TblProduct _product, decimal? qty, decimal? rate)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
                var _stockInformation = new TblStockInformation
                {
                    BranchId = _branch.BranchId,
                    BranchCode = _branch.BranchCode,
                    ShiftId = invoiceReturn.ShiftId,
                    VoucherNo = invoiceReturn.VoucherNo,
                    VoucherTypeId = invoiceReturn.VoucherTypeId,
                    InvoiceNo = invoiceReturn.InvoiceReturnNo,
                    ProductId = _product.ProductId,
                    ProductCode = _product.ProductCode,
                    OutwardQty = qty,
                    Rate = rate
                };

                context.TblStockInformation.Add(_stockInformation);
                if (context.SaveChanges() > 0)
                    return _stockInformation;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblAccountLedgerTransactions AddAccountLedgerTransactions(ERPContext context, TblVoucherDetail _voucherDetail, DateTime? invoiceDate)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
                var _accountLedgerTransactions = new TblAccountLedgerTransactions
                {
                    VoucherDetailId = _voucherDetail.VoucherDetailId,
                    LedgerId = _voucherDetail.ToLedgerId,
                    LedgerCode = _voucherDetail.ToLedgerCode,
                    LedgerName = _voucherDetail.ToLedgerName,
                    BranchId = _voucherDetail.BranchId,
                    BranchCode = _voucherDetail.BranchCode,
                    BranchName = _voucherDetail.BranchName,
                    TransactionDate = invoiceDate,
                    TransactionType = _voucherDetail.TransactionType,
                    VoucherAmount = _voucherDetail.Amount
                };

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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

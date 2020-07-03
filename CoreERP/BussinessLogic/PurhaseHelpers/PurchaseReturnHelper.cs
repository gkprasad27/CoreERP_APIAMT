using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.PurhaseHelpers
{
    public class PurchaseReturnHelper
    {
        public string GeneratePurchaseReturnInvNo(string branchCode, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                string suffix = string.Empty, prefix = string.Empty, billno = string.Empty;
                TblPurchaseReturn _purchaseReturn = null;
                using (Repository<TblInvoiceMaster> _repo = new Repository<TblInvoiceMaster>())
                {
                    _purchaseReturn = _repo.TblPurchaseReturn.Where(x => x.BranchCode == branchCode).OrderByDescending(x => x.PurchaseMasterInvId).FirstOrDefault();

                    if (_purchaseReturn != null)
                    {
                        var invSplit = _purchaseReturn.PurchaseReturnInvNo.Split('-');
                        billno = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1]) + 1}-{invSplit[2]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(14, branchCode, out prefix, out suffix);
                        if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                        {
                            errorMessage = $"No prefix and suffix confugured for branch code: {branchCode} ";
                            return billno = string.Empty;
                        }

                        billno = $"{prefix}-1-{suffix}";
                    }
                }

                if (string.IsNullOrEmpty(billno))
                {
                    errorMessage = "Purchase invoice no not gererated please enter manully.";
                }

                return billno;
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
                return BrancheHelper.GetBranches().Where(x=> x.BranchCode == branchCode).ToList();
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

        
        #region register Purchase Record
        public TblPurchaseReturn AddPurchaseReturns(string purchaseReturnInvNo,decimal? purchaseInvID,out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                decimal? _qty = null;
                string _purchaseDetailsjson = string.Empty;
                TblPurchaseInvoice purchaseInvoice = null;
                List<TblPurchaseInvoiceDetail> purchaseInvoiceDetails = null;
                TblPurchaseReturn purchaseReturn = null;
                TblPurchaseReturnDetails purchaseReturnDetails = null;
                List <TblPurchaseReturnDetails> _purchaseReturnDtl=new List<TblPurchaseReturnDetails>();
               
                
                using (ERPContext context = new ERPContext())
                {
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            purchaseInvoice = context.TblPurchaseInvoice.Where(p=>p.PurchaseInvId == purchaseInvID).FirstOrDefault();
                            if (purchaseInvoice == null)
                            {
                                return null;
                            }

                            if (purchaseInvoice.IsPurchaseReturned == true)
                            {
                                errorMessage = $"Purchase No: {purchaseInvoice.PurchaseInvNo} is already return.";
                                return null;
                            }

                            var _purchaseInvoicejson = JsonConvert.SerializeObject(purchaseInvoice);
                            purchaseReturn = (JsonConvert.DeserializeObject<TblPurchaseReturn>(_purchaseInvoicejson));
                            //set purchase return no & Date
                            
                            purchaseReturn.PurchaseMasterInvId = purchaseInvID;
                            purchaseReturn.PurchaseReturnInvNo = purchaseReturnInvNo;
                            purchaseReturn.PurchaseReturnInvDate = DateTime.Now;

                            //details section
                            purchaseInvoiceDetails = context.TblPurchaseInvoiceDetail.Where(pd=> pd.PurchaseInvId == purchaseInvID).ToList();
                            foreach (var purchaseDtl in purchaseInvoiceDetails)
                            {
                                _purchaseDetailsjson = JsonConvert.SerializeObject(purchaseDtl);
                                purchaseReturnDetails = JsonConvert.DeserializeObject<TblPurchaseReturnDetails>(_purchaseDetailsjson);
                                
                                _purchaseReturnDtl.Add(purchaseReturnDetails);
                            }

                            decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(purchaseReturn.UserId, null));
                            TblProduct _product = null;
                            TblTaxStructure _taxStructure = null;

                            //update purchase master table
                            var _purchaseMaster = context.TblPurchaseInvoice.Where(p=> p.PurchaseInvNo == purchaseReturn.PurchaseInvNo).FirstOrDefault();
                            _purchaseMaster.IsPurchaseReturned = true;
                            context.TblPurchaseInvoice.Update(_purchaseMaster);
                            context.SaveChanges();
                            
                            //add voucher typedetails
                            var _branch = GetBranches(purchaseReturn.BranchCode).FirstOrDefault();
                            var _accountLedger = GetAccountLedgers(purchaseReturn.LedgerCode);
                            var _vouchertType = GetVoucherType(14).FirstOrDefault();

                            #region Add voucher master record
                            var _voucherMaster = AddVoucherMaster(context, purchaseReturn, _branch, _vouchertType.VoucherTypeId, _accountLedger.CrOrDr);
                            #endregion

                            purchaseReturn.ShiftId = shifId;
                            purchaseReturn.VoucherNo = _voucherMaster.VoucherMasterId.ToString();
                            purchaseReturn.VoucherTypeId = 14;
                            purchaseReturn.BranchCode = _branch.BranchCode;
                            purchaseReturn.BranchName = _branch.BranchName;
                            purchaseReturn.ServerDateTime = DateTime.Now;
                            context.TblPurchaseReturn.Add(purchaseReturn);
                            context.SaveChanges();

                            foreach (var purReturnInv in _purchaseReturnDtl)
                            {
                                
                                _product = GetProducts(purReturnInv.ProductCode).FirstOrDefault();
                                _taxStructure = GetTaxStructure(Convert.ToDecimal(_product.TaxStructureCode));
                                _accountLedger = GetAccountLedgersByLedgerId((decimal)_taxStructure.PurchaseAccount).FirstOrDefault();

                                

                                #region InvioceDetail
                                purReturnInv.PurchaseReturnId = purchaseReturn.PurchaseReturnId;
                                purReturnInv.PurchaseReturnNo = purchaseReturn.PurchaseReturnInvNo;
                                purReturnInv.PurchaseReturnDate = DateTime.Now;

                                purReturnInv.VoucherNo = purchaseReturn.VoucherNo;
                                purReturnInv.StateCode = purchaseReturn.StateCode;
                                purReturnInv.ShiftId = purchaseReturn.ShiftId;
                                purReturnInv.UserId = purchaseReturn.UserId;
                                purReturnInv.EmployeeId =purchaseReturn.EmployeeId;
                                purReturnInv.ServerDateTime = DateTime.Now;
                                purReturnInv.ShiftId = shifId;
                                context.TblPurchaseReturnDetails.Add(purReturnInv);
                                context.SaveChanges();

                                #endregion

                                #region Add voucher Details
                                _accountLedger.CrOrDr = "Credit";
                                var _voucherDetail = AddVoucherDetails(context, purchaseReturn, _branch, _voucherMaster, _accountLedger, purReturnInv.GrossAmount);
                                #endregion

                                #region Add stock transaction  and Account Ledger Transaction
                                _qty = null;
                                if (purReturnInv.TotalLiters != null)
                                {
                                    if (purReturnInv.TotalLiters > 0)
                                        _qty = purReturnInv.TotalLiters;
                                }

                                if (purReturnInv.Qty != null)
                                {

                                    _qty = purReturnInv.Qty;
                                }

                                if (purReturnInv.FQty != null)
                                {
                                    if (_qty != null)
                                        _qty += purReturnInv.FQty;
                                    else
                                        _qty += purReturnInv.FQty;
                                }
                                AddStockInformation(context, purchaseReturn, _branch, _product, _qty, purReturnInv.Rate);
                                AddAccountLedgerTransactions(context, _voucherDetail, purchaseReturn.PurchaseReturnInvDate);
                                #endregion
                            }

                            _accountLedger = GetAccountLedgers(purchaseReturn.LedgerCode);
                            _accountLedger.CrOrDr = "Debit";
                            var voucherDetail= AddVoucherDetails(context, purchaseReturn, _branch, _voucherMaster, _accountLedger, purchaseReturn.TotalAmount, false);
                            AddAccountLedgerTransactions(context, voucherDetail, purchaseInvoice.PurchaseInvDate);
                            //CHech weather igs or sg ,cg st
                            var _stateWiseGsts = GetStateWiseGsts(purchaseReturn.StateCode).FirstOrDefault();
                            if (_stateWiseGsts.Igst == 1)
                            {
                                //Add IGST record
                                var _accAL = GetAccountLedgers("243");
                                _accAL.CrOrDr = "Credit";
                                var voucherDetailIGST = AddVoucherDetails(context, purchaseReturn, _branch, _voucherMaster, _accAL, purchaseReturn.TotalIgst, false);
                                AddAccountLedgerTransactions(context, voucherDetailIGST, purchaseInvoice.PurchaseInvDate);
                            }
                            else
                            {
                                //CGST
                                var _accAL = GetAccountLedgers("240");
                                _accAL.CrOrDr = "Credit";
                                var voucherDetailCGST = AddVoucherDetails(context, purchaseReturn, _branch, _voucherMaster, _accAL, purchaseReturn.TotalCgst, false);
                                AddAccountLedgerTransactions(context, voucherDetailCGST, purchaseInvoice.PurchaseInvDate);
                                // sgst
                                _accAL = GetAccountLedgers("241");
                                _accAL.CrOrDr = "Credit";
                                var voucherDetailSGST = AddVoucherDetails(context, purchaseReturn, _branch, _voucherMaster, _accAL, purchaseReturn.TotalSgst, false);
                                AddAccountLedgerTransactions(context, voucherDetailSGST, purchaseInvoice.PurchaseInvDate);

                            }

                            dbTransaction.Commit();
                            return purchaseReturn;
                        }
                        catch (Exception e)
                        {
                            dbTransaction.Rollback();
                            throw e;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TblVoucherMaster AddVoucherMaster(ERPContext context, TblPurchaseReturn purchaseReturn, TblBranch branch, decimal? voucherTypeId, string paymentType)
        {
            try
            {
                var _voucherMaster = new TblVoucherMaster();
                _voucherMaster.BranchCode = purchaseReturn.BranchCode;
                _voucherMaster.BranchName = branch.BranchName;
                _voucherMaster.VoucherDate = purchaseReturn.PurchaseInvDate;
                _voucherMaster.VoucherTypeIdMain = voucherTypeId;
                _voucherMaster.VoucherTypeIdSub = 35;
                _voucherMaster.VoucherNo = purchaseReturn.PurchaseReturnInvNo;
                _voucherMaster.Amount = purchaseReturn.GrandTotal;
                _voucherMaster.PaymentType = paymentType;//accountLedger.CrOrD
                _voucherMaster.Narration = "Purchase Return Invoice";
                _voucherMaster.ServerDate = DateTime.Now;
                _voucherMaster.UserId = purchaseReturn.UserId;
                _voucherMaster.UserName = purchaseReturn.UserName;
                _voucherMaster.EmployeeId = -1;

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
        private TblVoucherDetail AddVoucherDetails(ERPContext context, TblPurchaseReturn purchaseReturn, TblBranch _branch, TblVoucherMaster _voucherMaster, TblAccountLedger _accountLedger, decimal? productRate, bool isFromInvoiceDetials = true)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
                var _voucherDetail = new TblVoucherDetail();
                _voucherDetail.VoucherMasterId = _voucherMaster.VoucherMasterId;
                _voucherDetail.VoucherDetailDate = _voucherMaster.VoucherDate;
                _voucherDetail.BranchId = _branch.BranchId;
                _voucherDetail.BranchCode = purchaseReturn.BranchCode;
                _voucherDetail.BranchName = purchaseReturn.BranchName;
                _voucherDetail.Amount = productRate;
                _voucherDetail.TransactionType = _accountLedger.CrOrDr;
                _voucherDetail.CostCenter = _voucherDetail.BranchCode;
                _voucherDetail.ServerDate = DateTime.Now;
                _voucherDetail.Narration = $"Purchase Return Invoice {_accountLedger.LedgerName} A /c: {_voucherDetail.TransactionType}";

                if (isFromInvoiceDetials)
                {
                    _voucherDetail.FromLedgerId = _accountLedger.LedgerId;
                    _voucherDetail.FromLedgerCode = _accountLedger.LedgerCode;
                    _voucherDetail.FromLedgerName = _accountLedger.LedgerName;

                    _voucherDetail.ToLedgerId = purchaseReturn.LedgerId;
                    _voucherDetail.ToLedgerCode = purchaseReturn.LedgerCode;
                    _voucherDetail.ToLedgerName = purchaseReturn.LedgerName;

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

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TblStockInformation AddStockInformation(ERPContext context, TblPurchaseReturn purchaseReturn, TblBranch _branch, TblProduct _product, decimal? qty, decimal? rate)
        {
            try
            {
                //using(ERPContext context=new ERPContext())
                //{
                var _stockInformation = new TblStockInformation();

                _stockInformation.BranchId = _branch.BranchId;
                _stockInformation.BranchCode = _branch.BranchCode;
                _stockInformation.ShiftId = purchaseReturn.ShiftId;
                _stockInformation.VoucherNo = purchaseReturn.VoucherNo;
                _stockInformation.VoucherTypeId = purchaseReturn.VoucherTypeId;
                _stockInformation.InvoiceNo = purchaseReturn.PurchaseReturnInvNo;
                _stockInformation.ProductId = _product.ProductId;
                _stockInformation.ProductCode = _product.ProductCode;
                _stockInformation.InwardQty = 0;
                _stockInformation.OutwardQty = qty;
                _stockInformation.Rate = rate;
                _stockInformation.UserId = purchaseReturn.UserId;
                _stockInformation.TransactionDate =DateTime.Now;

                context.TblStockInformation.Add(_stockInformation);
                if (context.SaveChanges() > 0)
                    return _stockInformation;


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

                if (_accountLedgerTransactions.TransactionType.Equals("debit", StringComparison.OrdinalIgnoreCase))
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

        #region Search Purchase Return
        public List<TblPurchaseReturn> GetPurchaseReturns(string branchCode, SearchCriteria searchCriteria)
        {
            try
            {
                using (Repository<TblPurchaseReturn> repo = new Repository<TblPurchaseReturn>())
                {
                    List<TblPurchaseReturn> _purchaseList = null;
                    if (searchCriteria.Role != 1)
                    {
                        if (searchCriteria.FromDate != null && searchCriteria.ToDate != null)
                        {

                            _purchaseList = repo.TblPurchaseReturn.AsEnumerable()
                                                .Where(pur => DateTime.Parse(pur.PurchaseInvDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate).Value.ToShortDateString())
                                                         && DateTime.Parse(pur.PurchaseInvDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate).Value.ToShortDateString())
                                                         && pur.PurchaseInvNo.Contains(searchCriteria.InvoiceNo ?? pur.PurchaseInvNo))
                                                .ToList();
                        }
                        else
                        {
                            _purchaseList = repo.TblPurchaseReturn.AsEnumerable().Where(pur => pur.PurchaseInvNo.Contains(searchCriteria.InvoiceNo ?? pur.PurchaseInvNo)
                                                                                            && pur.PurchaseReturnInvDate.Value.Year == DateTime.Now.Year).ToList();
                        }
                    }
                    else
                    {
                        if (searchCriteria.FromDate != null && searchCriteria.ToDate != null)
                        {
                            _purchaseList = repo.TblPurchaseReturn.AsEnumerable()
                                                .Where(pur => DateTime.Parse(pur.PurchaseReturnInvDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate).Value.ToShortDateString())
                                                         && DateTime.Parse(pur.PurchaseReturnInvDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate).Value.ToShortDateString())
                                                         && pur.PurchaseInvNo.Contains(searchCriteria.InvoiceNo ?? pur.PurchaseInvNo))
                                                .ToList();
                        }
                        else
                            _purchaseList = repo.TblPurchaseReturn.AsEnumerable()
                                                .Where(pur =>pur.PurchaseInvNo.Contains(searchCriteria.InvoiceNo ?? pur.PurchaseInvNo)
                                                          && pur.PurchaseReturnInvDate.Value.Year == DateTime.Now.Year).ToList();
                    }
                   
                    return _purchaseList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblPurchaseReturnDetails> GetPurchaseReturnsDetails(decimal purchaseReturnId)
        {
            try
            {
                using (Repository<TblPurchaseInvoice> repo = new Repository<TblPurchaseInvoice>())
                {
                    return repo.TblPurchaseReturnDetails.Where(x => x.PurchaseReturnId == purchaseReturnId).ToList();
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

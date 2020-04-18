using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CoreERP.BussinessLogic.TransactionsHelpers
{
    public class StockreceiptHelpers
    {
        string receipno = null;
        public  List<TblOperatorStockReceipt> GetStockreceiptList()
        {
            try
            {
                using Repository<TblOperatorStockReceipt> repo = new Repository<TblOperatorStockReceipt>();
                return repo.TblOperatorStockReceipt.ToList();
            }
            catch { throw; }
        }

        public string Getbranchcodes(string codes)
        {
            try
            {
                string name = null;
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    var code = repo.TblBranch.Where(x => x.BranchCode == (codes)).FirstOrDefault();
                    var data= repo.TblBranch
                          .Where(x => (x.SubBranchof == Convert.ToDecimal(codes)))
                          .ToList();
                    foreach (var item in data)
                    {
                        name = item.BranchCode + "-" + item.BranchName;
                    }
                    return name;
                }
            }
            catch { throw; }
        }
        public List<TblBranch> GetBranchesListforStockreceipt()
        {
            try
            {
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.AsEnumerable().Where(b => b.SubBranchof != -1).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal? GetSuffixPrefix(decimal? voucherTypeid, string branchCode, out string preFix, out string suffix)
        {
            preFix = string.Empty;
            suffix = string.Empty;
            try
            {
                using Repository<TblSuffixPrefix> repo = new Repository<TblSuffixPrefix>();
                var _suffixPrefix = repo.TblSuffixPrefix
                                        .Where(s => s.VoucherTypeId == voucherTypeid && s.BranchCode == branchCode)
                                        .FirstOrDefault();

                preFix = _suffixPrefix?.Prefix;
                suffix = _suffixPrefix?.Suffix;

                return _suffixPrefix?.StartIndex;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GenerateNumber(decimal? voucherTypeid, string branchCode)
        {
            try
            {
                string prefix = string.Empty, sufix = string.Empty;
                var _number = GetSuffixPrefix(voucherTypeid, branchCode, out prefix, out sufix);

                if (string.IsNullOrEmpty(prefix))
                {
                    return null;
                }

                if (_number == null)
                {
                    _number = 1;
                }
                else
                {
                    _number += 1;// prefix + "-" + (_number + 1) + "-" + sufix;
                }

                UpdateInvoiceNumber(voucherTypeid, branchCode, _number);
                return $"{prefix}/{_number}-{sufix}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateInvoiceNumber(decimal? voucherTypeid, string branchCode, decimal? invoieNumber)
        {
            using Repository<TblSuffixPrefix> repo = new Repository<TblSuffixPrefix>();
            var _suffixPrefix = repo.TblSuffixPrefix.Where(s => s.VoucherTypeId == voucherTypeid && s.BranchCode == branchCode).FirstOrDefault();

            _suffixPrefix.StartIndex = invoieNumber;
            repo.TblSuffixPrefix.Update(_suffixPrefix);
            repo.SaveChanges();
        }
        public string GetReceiptNo(string branchCode)
        {

            try
            {
                return  GenerateNumber(42, branchCode);
               
            }
            catch { throw; }
        }

        public TblProduct Geproduct(string productCode)
        {
            try
            {
                return new InvoiceHelper().GetProducts(productCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal GetProductQty(string branchCode, string productCode)
        {
            try
            {
                var data = new InvoiceHelper().GetProductQty(branchCode, productCode);
                return (decimal)data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal? GetProductRate(string branchCode, string productCode)
        {
            try
            {
                decimal? _salesRate = default;

                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    var _product = repo.TblProduct.Where(p => p.ProductCode == productCode).FirstOrDefault();

                    var _mshrates = GetMshsdrates(branchCode, _product.ProductCode);
                    if (_mshrates != null)
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
        private TblMshsdrates GetMshsdrates(string branchCode, string productCode)
        {
            try
            {
                using Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>();
                return repo.TblMshsdrates.Where(x => x.ProductCode == productCode && x.BranchCode == branchCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TblOperatorStockReceiptDetail GetOpStockIssuesDetailsection(string productCode, string branchCode)
        {
            try
            {
                var _product = Geproduct(productCode);

                using Repository<TblProduct> repo = new Repository<TblProduct>();
                var date = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
                //var date = DateTime.Now.ToString();
                var receiptno = repo.TblSuffixPrefix.Where(x => x.BranchCode == branchCode && x.VoucherTypeId == 42).FirstOrDefault();
                var operatorStockreceiptDetail = new TblOperatorStockReceiptDetail
                {
                    BatchNo = date + "-" + receiptno.Prefix + "-" + receiptno.StartIndex + "-" + receiptno.Suffix + "-" + "-" + _product.ProductCode,
                    //var receiptno = new CommonHelper().GenerateNumber(42, branchCode);
                    //operatorStockreceiptDetail.BatchNo = date + "-" + receiptno + "-" + _product.ProductCode;
                    Qty = 0,
                    GrossAmount = 0,
                    Rate = GetProductRate(branchCode, productCode),
                    AvailStock = GetProductQty(branchCode, productCode),
                    HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0),
                    ProductCode = _product.ProductCode,
                    ProductName = _product.ProductName,
                    UnitName = _product.UnitName
                };

                return operatorStockreceiptDetail;
            }
            catch { throw; }
        }

        public List<TblBranch> GetBranches(string branchCode = null)
        {
            try
            {
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.AsEnumerable().Where(b => b.BranchCode == (branchCode ?? b.BranchCode)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblOperatorStockReceipt> GetStockreceiptslist(string code)
        {
            try
            {
                using Repository<TblOperatorStockReceipt> repo = new Repository<TblOperatorStockReceipt>();
                return repo.TblOperatorStockReceipt.Where(x => x.ReceiptNo == code).ToList();

            }
            catch { throw; }
        }

        public bool RegisterStockreceipts(TblOperatorStockReceipt stockreceipt, List<TblOperatorStockReceiptDetail> stockreceiptDetails)
        {
            try
            {
                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(stockreceipt.UserId, null));

                using (Repository<TblOperatorStockReceipt> repo = new Repository<TblOperatorStockReceipt>())
                {
                    //add voucher typedetails
                    var yourString = stockreceipt.ToBranchCode;
                    string str = yourString;
                    string ext = str.Substring(0, str.LastIndexOf('-') + 0);
                    var _branch = GetBranches(stockreceipt.FromBranchCode).ToArray().FirstOrDefault();
                    var _tobranch = GetBranches(ext).ToArray().FirstOrDefault();
                    stockreceipt.FromBranchCode = _branch.BranchCode;
                    stockreceipt.FromBranchName = _branch.BranchName;
                    stockreceipt.ToBranchCode = str.Substring(0, str.LastIndexOf('-') + 0); 
                    stockreceipt.ToBranchName = _tobranch.BranchName;
                    stockreceipt.ServerDateTime = DateTime.Now;
                    stockreceipt.ReceiptDate = stockreceipt.ReceiptDate;
                    stockreceipt.ReceiptNo = stockreceipt.ReceiptNo;
                    if(shifId == 0)
                    {
                        stockreceipt.ShiftId =0;
                    }
                    else
                    {
                        stockreceipt.ShiftId = shifId;
                    }
                    
                    stockreceipt.UserId = stockreceipt.UserId;
                    stockreceipt.UserName = stockreceipt.UserName;
                    stockreceipt.EmployeeId = -1;
                    stockreceipt.Remarks = stockreceipt.Remarks;
                    repo.TblOperatorStockReceipt.Add(stockreceipt);
                    repo.SaveChanges();
                    foreach (var invdtl in stockreceiptDetails)
                    {
                        int i = 0;
                        var _product = new InvoiceHelper().GetProducts(invdtl.ProductCode).FirstOrDefault();
                        int[] array = new int[] {Convert.ToInt32(stockreceipt.FromBranchCode), Convert.ToInt32(ext)};
                        foreach (var item in array)
                        {
                            TblStockInformation stockinformation = new TblStockInformation();
                            i = item;
                            stockinformation.BranchCode =Convert.ToString(i);
                            var _branchcode = GetBranches(Convert.ToString(i)).ToArray().FirstOrDefault();
                            //(stockreceipt.FromBranchCode)==null ? stockreceipt.FromBranchCode : ext;
                            stockinformation.BranchId = _branchcode.BranchId;
                            
                            if (shifId == 0)
                            {
                                stockinformation.ShiftId = 0;
                            }
                            else
                            {
                                stockinformation.ShiftId = shifId;
                            }
                            stockinformation.UserId = stockreceipt.UserId;
                            stockinformation.TransactionDate = DateTime.Now;
                            stockinformation.VoucherTypeId = 43;
                            stockinformation.InvoiceNo = stockreceipt.ReceiptNo;
                            stockinformation.ProductId = _product.ProductId;
                            stockinformation.ProductCode = invdtl.ProductCode;
                            stockinformation.Rate = invdtl.Rate;
                            if ((item) == Convert.ToInt32(stockreceipt.FromBranchCode))
                            {
                                stockinformation.InwardQty = invdtl.Qty;
                                stockinformation.OutwardQty = 0;
                            }
                            else
                            {
                                stockinformation.InwardQty = 0;
                                stockinformation.OutwardQty = invdtl.Qty;
                            }
                            repo.TblStockInformation.Add(stockinformation);
                            repo.SaveChanges();
                        }
                        //TblStockInformation stockinformation = new TblStockInformation();
                        //stockinformation.BranchCode
                        //#region StockIssueDetails
                        var operatorStockreceiptId = GetStockreceiptslist(stockreceipt.ReceiptNo).FirstOrDefault();
                        #region StockIssueDetails
                        invdtl.OperatorStockReceiptId = operatorStockreceiptId.OperatorStockReceiptId;
                        invdtl.ReceiptNo = stockreceipt.ReceiptNo;
                        invdtl.ReceiptDate = DateTime.Now;
                        invdtl.ProductId = _product.ProductId;
                        invdtl.ProductCode = invdtl.ProductCode;
                        invdtl.ProductName = invdtl.ProductName;
                        invdtl.HsnNo = invdtl.HsnNo;
                        invdtl.Rate = invdtl.Rate;
                        invdtl.Qty = invdtl.Qty;
                        invdtl.BatchNo = invdtl.BatchNo;
                        invdtl.UnitId = Convert.ToDecimal(_product.UnitId);
                        invdtl.UnitName = invdtl.UnitName;
                        invdtl.ProductGroupId = Convert.ToDecimal(_product.ProductGroupId);
                        invdtl.ProductGroupCode = Convert.ToDecimal(_product.ProductGroupCode);
                        invdtl.TaxGroupId = Convert.ToDecimal(_product.TaxGroupId);
                        invdtl.TaxGroupCode = _product.TaxGroupCode;
                        invdtl.TaxGroupName = _product.TaxGroupName;
                        invdtl.TaxStructureId = Convert.ToDecimal(_product.TaxStructureId);
                        invdtl.TaxStructureCode = Convert.ToDecimal(_product.TaxStructureCode);
                        invdtl.Cgst = Convert.ToDecimal(_product.Cgst);
                        invdtl.Igst = Convert.ToDecimal(_product.Igst);
                        invdtl.Sgst = Convert.ToDecimal(_product.Sgst);
                        invdtl.TotalGst = Convert.ToDecimal(_product.TotalGst);
                        invdtl.GrossAmount = Convert.ToDecimal(invdtl.GrossAmount);
                        invdtl.AvailStock = Convert.ToDecimal(invdtl.AvailStock);
                        repo.TblOperatorStockReceiptDetail.Add(invdtl);
                        repo.SaveChanges();
                        #endregion
                        {

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
        //Searchcode

        public List<TblOperatorStockReceipt> GetStockissuesMasters(VoucherNoSearchCriteria searchCriteria, string branchCode)
        {
            try
            {

                using (Repository<TblOperatorStockReceipt> repo = new Repository<TblOperatorStockReceipt>())
                {
                    List<TblOperatorStockReceipt> _stockreceiptMasterList = null;

                    if (searchCriteria.Role == 1)
                    {
                        _stockreceiptMasterList = repo.TblOperatorStockReceipt.AsEnumerable()
                              .Where(cp =>
                                         DateTime.Parse(cp.ReceiptDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.ReceiptDate).Value.ToShortDateString())
                                       && DateTime.Parse(cp.ReceiptDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.ReceiptDate).Value.ToShortDateString())
                                 )
                               .ToList();
                    }
                    else
                    {
                        _stockreceiptMasterList = repo.TblOperatorStockReceipt.AsEnumerable()
                            .Where(cp =>
                                        DateTime.Parse(cp.ReceiptDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.ReceiptDate).Value.ToShortDateString())
                                      && DateTime.Parse(cp.ReceiptDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.ReceiptDate).Value.ToShortDateString())
                                 && cp.FromBranchCode == branchCode)
                              .ToList();
                    }

                    if (!string.IsNullOrEmpty(searchCriteria.receiptNo))
                        _stockreceiptMasterList = GetStockreceiptList().Where(x => x.ReceiptNo == searchCriteria.receiptNo).ToList();


                    return _stockreceiptMasterList.OrderByDescending(x => x.ReceiptDate).ToList();
                    //_stockreceiptMasterList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //to get the invoice Master data while page load
        public List<TblOperatorStockReceipt> GetInvoiceList(int? role, string branchCode)
        {
            try
            {

                using (Repository<TblOperatorStockReceipt> repo = new Repository<TblOperatorStockReceipt>())
                {
                    List<TblOperatorStockReceipt> _invoiceMasterList = null;
                    if (role == 1)
                    {
                        _invoiceMasterList = repo.TblOperatorStockReceipt.AsEnumerable()
                                  .Where(inv =>
                                           inv.ReceiptDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"))
                                     )
                                   .ToList();
                    }
                    else
                    {
                        _invoiceMasterList = repo.TblOperatorStockReceipt.AsEnumerable()
                                                         .Where(inv =>
                                                                  inv.FromBranchCode == branchCode
                                                                  && inv.ReceiptDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"))
                                                            )
                                                          .ToList();
                    }

                    return _invoiceMasterList.OrderByDescending(x => x.ReceiptDate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public List<TblOperatorStockReceipt> GetStockissuesMasters(VoucherNoSearchCriteria searchCriteria)
        //{
        //    try
        //    {
        //        searchCriteria.FromDate = Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString());
        //        searchCriteria.ToDate = Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());

        //        using (Repository<TblOperatorStockReceipt> repo = new Repository<TblOperatorStockReceipt>())
        //        {
        //            return repo.TblOperatorStockReceipt.AsEnumerable()
        //                       .Where(inv => Convert.ToDateTime(inv.ReceiptDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
        //                                && Convert.ToDateTime(inv.ReceiptDate.Value.ToShortDateString()) >= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString())
        //                                && inv.ReceiptNo == (searchCriteria.InvoiceNo ?? inv.ReceiptNo)
        //                          )
        //                        .ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public List<TblOperatorStockReceiptDetail> StockreceiptDeatils(decimal receptno)
        {
            try
            {
                using Repository<TblOperatorStockReceiptDetail> repo = new Repository<TblOperatorStockReceiptDetail>();
                return repo.TblOperatorStockReceiptDetail.Where(x => x.OperatorStockReceiptId == receptno).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

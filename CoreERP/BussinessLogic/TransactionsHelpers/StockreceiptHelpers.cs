using CoreERP.BussinessLogic.Common;
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
        public  List<TblOperatorStockReceipt> GetStockreceiptList()
        {
            try
            {
                using Repository<TblOperatorStockReceipt> repo = new Repository<TblOperatorStockReceipt>();
                return repo.TblOperatorStockReceipt.ToList();
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

        public string GetReceiptNo(string branchCode)
        {

            try
            {
                return new CommonHelper().GenerateNumber(42, branchCode);
               
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
                //invoice.IsSalesReturned = false;
                //invoice.IsManualEntry = false;
                using (Repository<TblOperatorStockReceipt> repo = new Repository<TblOperatorStockReceipt>())
                {
                    //add voucher typedetails
                    var shiftid = repo.TblShift.Where(x => x.UserId == stockreceipt.UserId).FirstOrDefault();
                    var _branch = GetBranches(stockreceipt.FromBranchCode).ToArray().FirstOrDefault();
                    var _tobranch = GetBranches(stockreceipt.ToBranchCode).ToArray().FirstOrDefault();
                    stockreceipt.FromBranchCode = _branch.BranchCode;
                    stockreceipt.FromBranchName = _branch.BranchName;
                    stockreceipt.ToBranchCode = stockreceipt.ToBranchCode;
                    stockreceipt.ToBranchName = _tobranch.BranchName;
                    stockreceipt.ServerDateTime = DateTime.Now;
                    stockreceipt.ReceiptDate = stockreceipt.ReceiptDate;
                    stockreceipt.ReceiptNo = stockreceipt.ReceiptNo;
                    if(shiftid==null)
                    {
                        stockreceipt.ShiftId =2;
                    }
                    else
                    {
                        stockreceipt.ShiftId = shiftid.ShiftId;
                    }
                    
                    stockreceipt.UserId = stockreceipt.UserId;
                    stockreceipt.UserName = stockreceipt.UserName;
                    stockreceipt.EmployeeId = -1;
                    stockreceipt.Remarks = stockreceipt.Remarks;
                    repo.TblOperatorStockReceipt.Add(stockreceipt);
                    repo.SaveChanges();
                    foreach (var invdtl in stockreceiptDetails)
                    {
                        var _product = new InvoiceHelper().GetProducts(invdtl.ProductCode).FirstOrDefault();
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
        public List<TblOperatorStockReceipt> GetStockissuesMasters(SearchCriteria searchCriteria)
        {
            try
            {
                searchCriteria.FromDate = Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString());
                searchCriteria.ToDate = Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());

                using Repository<TblOperatorStockReceipt> repo = new Repository<TblOperatorStockReceipt>();
                return repo.TblOperatorStockReceipt.AsEnumerable()
.Where(inv => Convert.ToDateTime(inv.ReceiptDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
&& Convert.ToDateTime(inv.ReceiptDate.Value.ToShortDateString()) >= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString())
&& inv.ReceiptNo == (searchCriteria.InvoiceNo ?? inv.ReceiptNo)
)
.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<TblOperatorStockReceiptDetail> StockreceiptDeatils(string receptno)
        {
            try
            {
                using Repository<TblOperatorStockReceiptDetail> repo = new Repository<TblOperatorStockReceiptDetail>();
                return repo.TblOperatorStockReceiptDetail.Where(x => x.ReceiptNo == receptno).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

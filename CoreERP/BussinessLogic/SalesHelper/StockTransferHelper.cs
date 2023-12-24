using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;

namespace CoreERP.BussinessLogic.SalesHelper
{
    public class StockTransferHelper
    {
        //public string GenerateStockTranfNo(string branchCode,out string errorMessage)
        //{
        //    try
        //    {
        //        string stockTransferNo = string.Empty, prefix = string.Empty, suffix = string.Empty;
        //        decimal _no=0;
        //        errorMessage = string.Empty;
        //        // return new Common.CommonHelper().GenerateNumber(29, branchCode);
        //        TblStockTransferMaster _stockTransferMaster = null;
        //        using (Repository<TblInvoiceMaster> _repo = new Repository<TblInvoiceMaster>())
        //        {
        //            _stockTransferMaster = _repo.TblStockTransferMaster.Where(x => x.FromBranchCode == branchCode).OrderByDescending(x => x.StockTransferMasterId).FirstOrDefault();

        //            if (_stockTransferMaster != null)
        //            {
        //               var invSplit = System.Text.RegularExpressions.Regex.Split(_stockTransferMaster.StockTransferNo, @"(-)|(/)");
        //                prefix = invSplit[0];
        //                _no = Convert.ToDecimal(invSplit[2]);
        //                suffix = invSplit[4];
                     
        //                stockTransferNo = $"{prefix}{invSplit[1]}{ _no + 1}{invSplit[3]}{suffix}";
        //            }
        //            else
        //            {
        //                new Common.CommonHelper().GetSuffixPrefix(29, branchCode, out prefix, out suffix);
        //                if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
        //                {
        //                    errorMessage = $"No prefix and suffix confugured for branch code: {branchCode} ";
        //                    return stockTransferNo = string.Empty;
        //                }

        //                stockTransferNo = $"{prefix}-1-{suffix}";
        //            }
        //        }

        //        return stockTransferNo;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<TblProduct> GetProducts(string productCode,string productName)
        //{
        //    try
        //    {
        //        productCode = string.IsNullOrEmpty(productCode) ? null: productCode.ToLower();
        //        productName = string.IsNullOrEmpty(productName) ? null : productName.ToLower();

        //        using Repository<TblProduct> repo = new Repository<TblProduct>();
        //        return repo.TblProduct
        //                    .Where(p => (productCode != null ? p.ProductCode.ToLower().Contains(productCode) : true)
        //                            && (productName != null ? p.ProductName.ToLower().Contains(productName) : true))
        //                    .ToList();
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public TblProduct GetProducts(string productCode)
        //{
        //    try
        //    {
        //        return new InvoiceHelper().GetProducts(productCode).FirstOrDefault();
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public decimal? GetProductRate(string branchCode,string productCode)
        //{
        //    try
        //    {
        //        return new InvoiceHelper().GetProductRate(branchCode, productCode);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public decimal? GetProductQty(string branchCode, string productCode)
        {
            try
            {
                return new InvoiceHelper().GetProductQty(branchCode, productCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public TblStockTransferDetail GetStockTransferDetailsSection(string branchCode, string productCode)
        //{
        //    try
        //    {
        //        var _product =GetProducts(productCode);
        //        if (_product == null)
        //            return null;
        //        var _stockTransferDetail = new TblStockTransferDetail
        //        {
        //            ProductId = _product.ProductId,
        //            ProductCode = _product.ProductCode,
        //            ProductName = _product.ProductName,
        //            HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0),
        //            Rate = GetProductRate(branchCode, productCode),
        //            ProductGroupId = Convert.ToDecimal(_product.ProductGroupId ?? 0),
        //            ProductGroupCode = Convert.ToDecimal(_product.ProductGroupCode ?? 0),
        //            UnitId = Convert.ToDecimal(_product.UnitId ?? 0),
        //            UnitName = _product.UnitName,
        //            AvailStock = Convert.ToDecimal(GetProductQty(branchCode, productCode) ?? 0)
        //        };


        //        return _stockTransferDetail;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<TblStockTransferMaster> GetStockTransferMasters(string branhCode,SearchCriteria searchCriteria)
        //{
        //    try
        //    {
        //        List<TblStockTransferMaster> stockTransferList = null;
        //        if (searchCriteria.Role == 1 || searchCriteria.Role == 3 || searchCriteria.Role == 89)
        //        {
        //            using (Repository<TblStockTransferMaster> repo = new Repository<TblStockTransferMaster>())
        //            {

        //                if (searchCriteria.FromDate != null && searchCriteria.ToDate !=null)
        //                {
        //                    stockTransferList = repo.TblStockTransferMaster
        //                                            .AsEnumerable()
        //                                            .Where(x => DateTime.Parse(x.StockTransferDate.Value.ToShortDateString()) >= DateTime.Parse(searchCriteria.FromDate.Value.ToShortDateString())
        //                                                     && DateTime.Parse(x.StockTransferDate.Value.ToShortDateString()) <= DateTime.Parse(searchCriteria.ToDate.Value.ToShortDateString())
        //                                                     && x.StockTransferNo == (searchCriteria.InvoiceNo ?? x.StockTransferNo)).ToList();
        //                }
        //                else
        //                {
        //                    stockTransferList = repo.TblStockTransferMaster.AsEnumerable().Where(x => x.StockTransferNo == (searchCriteria.InvoiceNo ?? x.StockTransferNo)).ToList();
        //                }
        //            }
        //        }
        //        else
        //        {


                   

        //            using (Repository<TblStockTransferMaster> repo = new Repository<TblStockTransferMaster>())
        //            {
        //                if (searchCriteria.FromDate != null && searchCriteria.ToDate != null)
        //                {
        //                    stockTransferList = repo.TblStockTransferMaster
        //                                            .AsEnumerable()
        //                                            .Where(x => DateTime.Parse(x.StockTransferDate.Value.ToShortDateString()) >= DateTime.Parse(searchCriteria.FromDate.Value.ToShortDateString())
        //                                                     && DateTime.Parse(x.StockTransferDate.Value.ToShortDateString()) <= DateTime.Parse(searchCriteria.ToDate.Value.ToShortDateString())
        //                                                     && x.StockTransferNo == (searchCriteria.InvoiceNo ?? x.StockTransferNo)
        //                                                     && x.FromBranchCode == branhCode || x.ToBranchCode==branhCode).ToList();
        //                }
        //                else
        //                {
        //                    stockTransferList = repo.TblStockTransferMaster.AsEnumerable()
        //                                                                   .Where(x => x.StockTransferNo == (searchCriteria.InvoiceNo ?? x.StockTransferNo)
        //                                                                            && x.FromBranchCode == branhCode || x.ToBranchCode == branhCode).ToList();
        //                }
        //            }
        //        }
        //        return stockTransferList;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<TblStockTransferDetail > GetStockTransferDetailRecords(string stocktransferMasterId)
        //{
        //    try
        //    {
        //        using Repository<TblStockTransferMaster> repo = new Repository<TblStockTransferMaster>();
        //        return repo.TblStockTransferDetail
        //                    .AsEnumerable()
        //                    .Where(x => x.StockTransferMasterId == Convert.ToDecimal(stocktransferMasterId))
        //                    .ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public TblBranch GetBranch(string branchCode)
        {
            return new InvoiceHelper().GetBranches(branchCode).FirstOrDefault();
        }

        #region Register StockTransfer
        //public bool AddStockTransfer(TblStockTransferMaster stockTransferMaster,List<TblStockTransferDetail> stockTransferDetails)
        //{
        //    try
        //    {
        //        decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(Convert.ToDecimal(stockTransferMaster.UserId ?? 0), null));
        //        var _user = new UserManagmentHelper().GetEmployeeID(stockTransferMaster.UserName);

        //        using ERPContext context = new ERPContext();
        //        using var dbTransaction = context.Database.BeginTransaction();
        //        try
        //        {
                    
        //            stockTransferMaster.ShiftId = shifId;
        //            stockTransferMaster.EmployeeId = _user?.EmployeeId;

        //             var _stockTransferMaster = AddStockTransferMaster(context, stockTransferMaster);
        //            foreach (var stockdetail in stockTransferDetails)
        //            {
        //                AddStockTransferDetail(context, stockdetail, _stockTransferMaster);
        //                AddStockInformation(context, stockdetail, _stockTransferMaster, _stockTransferMaster.FromBranchCode, true);
        //                AddStockInformation(context, stockdetail, _stockTransferMaster, _stockTransferMaster.ToBranchCode, false);
        //            }

        //            dbTransaction.Commit();
        //            return true;
        //        }
        //        catch (Exception e)
        //        {
        //            dbTransaction.Rollback();
        //            throw e;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //private TblStockTransferMaster AddStockTransferMaster(ERPContext context, TblStockTransferMaster stockTransferMaster)
        //{
        //    try
        //    {
        //        stockTransferMaster.FromBranchName = GetBranch(stockTransferMaster.FromBranchCode)?.BranchName;
        //        stockTransferMaster.ToBranchName = GetBranch(stockTransferMaster.ToBranchCode)?.BranchName;
        //        context.TblStockTransferMaster.Add(stockTransferMaster);
        //        if (context.SaveChanges() > 0)
        //            return stockTransferMaster;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //private TblStockTransferDetail AddStockTransferDetail(ERPContext context,TblStockTransferDetail stockTransferDetail,TblStockTransferMaster stockTransferMaster)
        //{
        //    try
        //    {
        //        stockTransferDetail.StockTransferDetailId = null;
        //        stockTransferDetail.StockTransferMasterId = stockTransferMaster.StockTransferMasterId;
        //        stockTransferDetail.StockTransferDetailsDate = stockTransferMaster.StockTransferDate;
        //        context.TblStockTransferDetail.Add(stockTransferDetail);
        //        if (context.SaveChanges() > 0)
        //            return stockTransferDetail;

        //        return null;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //private TblStockInformation AddStockInformation(ERPContext context, TblStockTransferDetail stockTransferDetail, TblStockTransferMaster stockTransfertMaster, string branchCode, bool isFromBranch, decimal? voucherTypeID = 29)
        //{
        //    try
        //    {
        //        TblStockInformation stockInformation = new TblStockInformation();
        //          try { stockInformation.BranchId = Convert.ToDecimal(branchCode ?? "0"); } catch { };
        //        stockInformation.BranchCode = branchCode;
        //        stockInformation.UserId = stockTransfertMaster.UserId;
        //        stockInformation.ShiftId = stockTransfertMaster.ShiftId;
        //        stockInformation.TransactionDate = stockTransfertMaster.StockTransferDate;
        //        stockInformation.VoucherNo = string.Empty;
        //        stockInformation.VoucherTypeId = voucherTypeID;
        //        stockInformation.InvoiceNo = stockTransfertMaster.StockTransferNo;
        //        stockInformation.ProductId = stockTransferDetail.ProductId;
        //        stockInformation.ProductCode = stockTransferDetail.ProductCode;
        //        stockInformation.Rate = stockTransferDetail.Rate;
               
        //        if (isFromBranch)
        //            stockInformation.OutwardQty = stockTransferDetail.FQty > 0 ? stockTransferDetail.FQty : stockTransferDetail.Qty;
        //        else
        //            stockInformation.InwardQty = stockTransferDetail.FQty > 0 ? stockTransferDetail.FQty : stockTransferDetail.Qty;

        //        stockInformation.OutwardQty = stockInformation.OutwardQty ?? 0;
        //        stockInformation.InwardQty = stockInformation.InwardQty ?? 0;

        //        context.TblStockInformation.Add(stockInformation);
        //        if (context.SaveChanges() > 0)
        //            return stockInformation;

        //        return null;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion

    }
}

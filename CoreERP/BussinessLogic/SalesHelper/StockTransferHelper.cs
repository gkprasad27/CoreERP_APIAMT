using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;

namespace CoreERP.BussinessLogic.SalesHelper
{
    public class StockTransferHelper
    {
        public string GenerateStockTranfNo(string branchCode)
        {
            try
            {
               return new Common.CommonHelper().GenerateNumber(29, branchCode);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblProduct> GetProducts(string productCode,string productName)
        {
            try
            {
                productCode = string.IsNullOrEmpty(productCode) ? null: productCode.ToLower();
                productName = string.IsNullOrEmpty(productName) ? null : productName.ToLower();

                using Repository<TblProduct> repo = new Repository<TblProduct>();
                return repo.TblProduct
.Where(p => (productCode != null ? p.ProductCode.ToLower().Contains(productCode) : true)
&& (productName != null ? p.ProductName.ToLower().Contains(productName) : true))
.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public TblProduct GetProducts(string productCode)
        {
            try
            {
                return new InvoiceHelper().GetProducts(productCode).FirstOrDefault();
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
                return new InvoiceHelper().GetProductRate(branchCode, productCode);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
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
        public TblStockTransferDetail GetStockTransferDetailsSection(string branchCode, string productCode)
        {
            try
            {
                var _product =GetProducts(productCode);
                if (_product == null)
                    return null;
                var _stockTransferDetail = new TblStockTransferDetail
                {
                    ProductId = _product.ProductId,
                    ProductCode = _product.ProductCode,
                    ProductName = _product.ProductName,
                    HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0),
                    Rate = GetProductRate(branchCode, productCode),
                    ProductGroupId = Convert.ToDecimal(_product.ProductGroupId ?? 0),
                    ProductGroupCode = Convert.ToDecimal(_product.ProductGroupCode ?? 0),
                    UnitId = Convert.ToDecimal(_product.UnitId ?? 0),
                    UnitName = _product.UnitName,
                    AvailStock = Convert.ToDecimal(GetProductQty(branchCode, productCode) ?? 0)
                };


                return _stockTransferDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblStockTransferMaster> GetStockTransferMasters(string branhCode,SearchCriteria searchCriteria)
        {
            try
            {
                using Repository<TblStockTransferMaster> repo = new Repository<TblStockTransferMaster>();
                return repo.TblStockTransferMaster
                            .AsEnumerable()
                            .Where(x =>
                                        DateTime.Parse(x.StockTransferDate.Value.ToShortDateString()) >= DateTime.Parse(searchCriteria.FromDate.Value.ToShortDateString())
                                     && DateTime.Parse(x.StockTransferDate.Value.ToShortDateString()) <= DateTime.Parse(searchCriteria.ToDate.Value.ToShortDateString())
                                     //&& Convert.ToDateTime(x.StockTransferDate.Value.ToString("dd/MM/yyyy")) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToString("dd/MM/yyyy"))
                                     && x.StockTransferNo == (searchCriteria.InvoiceNo ?? x.StockTransferNo)
                                     && x.FromBranchCode == branhCode
                                     )
                            .ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblStockTransferDetail > GetStockTransferDetailRecords(string stocktransferMasterId)
        {
            try
            {
                using Repository<TblStockTransferMaster> repo = new Repository<TblStockTransferMaster>();
                return repo.TblStockTransferDetail
                            .AsEnumerable()
                            .Where(x => x.StockTransferMasterId == Convert.ToDecimal(stocktransferMasterId))
                            .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblBranch GetBranch(string branchCode)
        {
            return new InvoiceHelper().GetBranches(branchCode).FirstOrDefault();
        }

        #region Register StockTransfer
        public bool AddStockTransfer(TblStockTransferMaster stockTransferMaster,List<TblStockTransferDetail> stockTransferDetails)
        {
            try
            {

                using ERPContext context = new ERPContext();
                using var dbTransaction = context.Database.BeginTransaction();
                try
                {
                    var _stockTransferMaster = AddStockTransferMaster(context, stockTransferMaster);
                    foreach (var stockdetail in stockTransferDetails)
                    {
                        AddStockTransferDetail(context, stockdetail, _stockTransferMaster);
                        AddStockInformation(context, stockdetail, _stockTransferMaster, _stockTransferMaster.FromBranchCode, true);
                        AddStockInformation(context, stockdetail, _stockTransferMaster, _stockTransferMaster.ToBranchCode, false);
                    }

                    dbTransaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    dbTransaction.Rollback();
                    throw e;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private TblStockTransferMaster AddStockTransferMaster(ERPContext context, TblStockTransferMaster stockTransferMaster)
        {
            try
            {
                stockTransferMaster.FromBranchName = GetBranch(stockTransferMaster.FromBranchCode)?.BranchName;
                stockTransferMaster.ToBranchName = GetBranch(stockTransferMaster.ToBranchCode)?.BranchName;
                context.TblStockTransferMaster.Add(stockTransferMaster);
                if (context.SaveChanges() > 0)
                    return stockTransferMaster;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TblStockTransferDetail AddStockTransferDetail(ERPContext context,TblStockTransferDetail stockTransferDetail,TblStockTransferMaster stockTransferMaster)
        {
            try
            {
                stockTransferDetail.StockTransferDetailId = null;
                stockTransferDetail.StockTransferMasterId = stockTransferMaster.StockTransferMasterId;
                stockTransferDetail.StockTransferDetailsDate = stockTransferMaster.StockTransferDate;
                context.TblStockTransferDetail.Add(stockTransferDetail);
                if (context.SaveChanges() > 0)
                    return stockTransferDetail;

                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private TblStockInformation AddStockInformation(ERPContext context, TblStockTransferDetail stockTransferDetail, TblStockTransferMaster stockTransfertMaster, string branchCode, bool isFromBranch, decimal? voucherTypeID = 29)
        {
            try
            {
                TblStockInformation stockInformation = new TblStockInformation();
                  try { stockInformation.BranchId = Convert.ToDecimal(branchCode ?? "0"); } catch { };
                stockInformation.BranchCode = branchCode;
                stockInformation.UserId = stockTransfertMaster.UserId;
                stockInformation.ShiftId = stockTransfertMaster.ShiftId;
                stockInformation.TransactionDate = stockTransfertMaster.StockTransferDate;
                stockInformation.VoucherNo = string.Empty;
                stockInformation.VoucherTypeId = voucherTypeID;
                stockInformation.InvoiceNo = stockTransfertMaster.StockTransferNo;
                stockInformation.ProductId = stockTransferDetail.ProductId;
                stockInformation.ProductCode = stockTransferDetail.ProductCode;
                stockInformation.Rate = stockTransferDetail.Rate;
                if (isFromBranch)
                    stockInformation.OutwardQty = stockTransferDetail.FQty > 0 ? stockTransferDetail.FQty : stockTransferDetail.Qty;
                else
                    stockInformation.InwardQty = stockTransferDetail.FQty > 0 ? stockTransferDetail.FQty : stockTransferDetail.Qty;

                stockInformation.OutwardQty = stockInformation.OutwardQty ?? 0;
                stockInformation.InwardQty = stockInformation.InwardQty ?? 0;

                context.TblStockInformation.Add(stockInformation);
                if (context.SaveChanges() > 0)
                    return stockInformation;

                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}

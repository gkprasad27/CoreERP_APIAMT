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
    public class StockshortHelpers
    {
        public  List<TblStockshortMaster> GetStockshortsList()
        {
            try
            {
                using Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>();
                return repo.TblStockshortMaster.ToList();
            }
            catch { throw; }
        }


        
        public List<TblBranch> GetBranches()
        {
            try
            {
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CostCenters> GetCostCenters()
        {
            try
            {
                using Repository<CostCenters> repo = new Repository<CostCenters>();
                return repo.CostCenters.ToList();
            }
            catch { throw; }
        }

        
        public string GetstockshortVoucherNo(string branchCode)
        {

            try
            {
                return new CommonHelper().GenerateNumber(44, branchCode);
            }
            catch { throw; }
        }

       


        public TblStockshortDetails GetOpStockShortDetailsection(string productCode, string branchCode)
        {
            try
            {
                var _product = Geproduct(productCode);

                using Repository<TblProduct> repo = new Repository<TblProduct>();
                var date = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
                //var date = DateTime.Now.ToString();
                var issueno = new CommonHelper().GenerateNumber(44, branchCode);
                var operatorStockIssuesDetail = new TblStockshortDetails
                {
                    BatchNo = 0,
                    //date + "-" + issueno + "-" + _product.ProductCode;
                    Qty = 0,
                    TotalAmount = 0,
                    Rate = GetProductRate(branchCode, productCode),
                    //operatorStockIssuesDetail.AvailStock = GetProductQty(branchCode, productCode);
                    HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0),
                    ProductCode = _product.ProductCode,
                    ProductName = _product.ProductName,
                    UnitName = _product.UnitName
                };

                return operatorStockIssuesDetail;
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
        //public decimal GetProductQty(string branchCode, string productCode)
        //{
        //    try
        //    {
        //        var data = new InvoiceHelper().GetProductQty(branchCode, productCode);
        //        return (decimal)data;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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
        public List<TblStockshortMaster> GetStockshortlist(string code)
        {
            try
            {
                using Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>();
                return repo.TblStockshortMaster.Where(x => x.StockshortNo == code).ToList();

            }
            catch { throw; }
        }

        public bool RegisterStockshort(TblStockshortMaster stockshort, List<TblStockshortDetails> stockshortDetails)
        {
            try
            {
                //invoice.IsSalesReturned = false;
                //invoice.IsManualEntry = false;
                using (Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>())
                {
                    //add voucher typedetails
                    var user = repo.TblUser.Where(x => x.UserName == stockshort.UserName).FirstOrDefault();
                    var shift = repo.TblShift.Where(x => x.UserId == user.UserId).FirstOrDefault();
                    var _branch = GetBranches(stockshort.BranchCode).ToArray().FirstOrDefault();
                    var shiftid = repo.TblShift.Where(x => x.UserId == stockshort.UserId).FirstOrDefault();
                    stockshort.BranchCode = _branch.BranchCode;
                    stockshort.BranchName = _branch.BranchName;
                    stockshort.ServerDate = DateTime.Now;
                    stockshort.StockshortDate = stockshort.StockshortDate;
                    stockshort.StockshortNo = stockshort.StockshortNo;
                    stockshort.ShiftId = shift.ShiftId;
                    stockshort.UserId = user.UserId;
                    stockshort.UserName = stockshort.UserName;
                    stockshort.EmployeeId = -1;
                    stockshort.Narration = stockshort.Narration;
                    repo.TblStockshortMaster.Add(stockshort);
                    repo.SaveChanges();
                    foreach (var stockshorts in stockshortDetails)
                    {
                        var _product = new InvoiceHelper().GetProducts(stockshorts.ProductCode).FirstOrDefault();
                        var operatorStockshortId = GetStockshortlist(stockshort.StockshortNo).FirstOrDefault();
                        #region StockIssueDetails
                        stockshorts.StockshortMasterId = operatorStockshortId.StockshortMasterId;

                        stockshorts.StockshortDetailsDate = DateTime.Now;
                        stockshorts.ProductId = _product.ProductId;
                        stockshorts.ProductCode = stockshorts.ProductCode;
                        stockshorts.ProductName = stockshorts.ProductName;
                        stockshorts.HsnNo = stockshorts.HsnNo;
                        stockshorts.Rate = stockshorts.Rate;
                        stockshorts.Qty = stockshorts.Qty;
                        stockshorts.BatchNo = stockshorts.BatchNo;
                        stockshorts.UnitId = Convert.ToDecimal(_product.UnitId);
                        stockshorts.UnitName = stockshorts.UnitName;
                        stockshorts.TotalAmount = Convert.ToDecimal(stockshorts.TotalAmount);
                        repo.TblStockshortDetails.Add(stockshorts);
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
        public List<TblStockshortMaster> GetStockshortsList(SearchCriteria searchCriteria)
        {
            try
            {
                searchCriteria.FromDate = Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString());
                searchCriteria.ToDate = Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());

                using Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>();
                return repo.TblStockshortMaster.AsEnumerable()
.Where(inv => Convert.ToDateTime(inv.StockshortDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
&& Convert.ToDateTime(inv.StockshortDate.Value.ToShortDateString()) >= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString())
&& inv.StockshortNo == (searchCriteria.InvoiceNo ?? inv.StockshortNo)
)
.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<TblStockshortDetails> StockshortsDeatilList(string shortno)
        {
            try
            {
                using Repository<TblStockshortDetails> repo = new Repository<TblStockshortDetails>();
                var shorno = repo.TblStockshortMaster.Where(x => x.StockshortNo == shortno).FirstOrDefault();
                return repo.TblStockshortDetails.Where(x => x.StockshortMasterId == shorno.StockshortMasterId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

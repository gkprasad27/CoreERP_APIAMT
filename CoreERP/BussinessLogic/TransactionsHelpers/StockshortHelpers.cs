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
                using (Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>())
                {
                    return repo.TblStockshortMaster.ToList();
                }
            }
            catch { throw; }
        }


        
        public List<TblBranch> GetBranches()
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.ToList();
                }
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
                using (Repository<CostCenters> repo = new Repository<CostCenters>())
                {
                    return repo.CostCenters.ToList();
                }
            }
            catch { throw; }
        }

        public string GetstockshortVoucherNo(string branchCode, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                string suffix = string.Empty, prefix = string.Empty, billno = string.Empty;
                TblStockshortMaster _receiptNo = null;
                using (Repository<TblStockshortMaster> _repo = new Repository<TblStockshortMaster>())
                {
                    _receiptNo = _repo.TblStockshortMaster.Where(x => x.BranchCode == branchCode).OrderByDescending(x => x.StockshortDate).FirstOrDefault();

                    if (_receiptNo != null)
                    {
                        var invSplit = _receiptNo.StockshortNo.Split('/');
                        var invNo = invSplit[1].Split('-');
                        billno = $"{invSplit[0]}/{Convert.ToDecimal(invNo[0]) + 1}-{invNo[1]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(44, branchCode, out prefix, out suffix);
                        if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                        {
                            errorMessage = $"No prefix and suffix confugured for branch code: {branchCode} ";
                            return billno = string.Empty;
                        }

                        billno = $"{prefix}/1-{suffix}";
                    }
                }

                if (string.IsNullOrEmpty(billno))
                {
                    errorMessage = "stockshort no not gererated please enter manully.";
                }

                return billno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public string GetstockshortVoucherNo(string branchCode)
        //{

        //    try
        //    {
        //        return new CommonHelper().GenerateNumber(44, branchCode);
        //    }
        //    catch { throw; }
        //}




        public TblStockshortDetails GetOpStockShortDetailsection(string productCode, string branchCode)
        {
            try
            {
                var _product = Geproduct(productCode);

                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    var date = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
                    //var date = DateTime.Now.ToString();
                    var issueno = new CommonHelper().GenerateNumber(44, branchCode);
                    var operatorStockIssuesDetail = new TblStockshortDetails();
                    operatorStockIssuesDetail.BatchNo = 0;
                    //date + "-" + issueno + "-" + _product.ProductCode;
                    operatorStockIssuesDetail.Qty = 0;
                    operatorStockIssuesDetail.TotalAmount = 0;
                    operatorStockIssuesDetail.Rate = GetProductRate(branchCode, productCode);
                    //operatorStockIssuesDetail.AvailStock = GetProductQty(branchCode, productCode);
                    operatorStockIssuesDetail.HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0);
                    operatorStockIssuesDetail.ProductCode = _product.ProductCode;
                    operatorStockIssuesDetail.ProductName = _product.ProductName;
                    operatorStockIssuesDetail.UnitName = _product.UnitName;

                    return operatorStockIssuesDetail;

                }
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
                decimal? _salesRate = default(decimal?);

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

       
        public List<TblStockshortMaster> GetStockshortlist(string code)
        {
            try
            {
                using (Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>())
                {
                    return repo.TblStockshortMaster.Where(x => x.StockshortNo == code).ToList();
                }

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
                    stockshort.ShiftId = shiftid.ShiftId;
                    stockshort.UserId = user.UserId;
                    stockshort.UserName = stockshort.UserName;
                    stockshort.EmployeeId = user.EmployeeId;
                    stockshort.CostCenter = stockshort.CostCenter;
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
        public List<TblStockshortMaster> GetStockshortsList(VoucherNoSearchCriteria searchCriteria,string branchCode)
        {
            try
            {

                using (Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>())
                {
                    List<TblStockshortMaster> _stockshortMasterList = null;
                    if (searchCriteria.Role == 1)
                    {

                        _stockshortMasterList = repo.TblStockshortMaster.AsEnumerable()
                              .Where(cp =>
                                         DateTime.Parse(cp.StockshortDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.StockshortDate).Value.ToShortDateString())
                                       && DateTime.Parse(cp.StockshortDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.StockshortDate).Value.ToShortDateString())
                               )
                               .ToList();
                    }
                    else
                    {
                        _stockshortMasterList = repo.TblStockshortMaster.AsEnumerable()
                              .Where(cp =>
                                         DateTime.Parse(cp.StockshortDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.StockshortDate).Value.ToShortDateString())
                                       && DateTime.Parse(cp.StockshortDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.StockshortDate).Value.ToShortDateString())
                                && cp.BranchCode == branchCode)
                               .ToList();
                    }
                    if (!string.IsNullOrEmpty(searchCriteria.StockshortNo))
                        _stockshortMasterList = GetStockshortsList().Where(x => x.StockshortNo == searchCriteria.StockshortNo).ToList();


                    return _stockshortMasterList.OrderByDescending(x => x.StockshortDate).ToList();
                    ;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<TblStockshortMaster> GetInvoiceList(int? role, string branchCode)
        {
            try
            {

                using (Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>())
                {
                    List<TblStockshortMaster> _stockshortMasterList = null;
                    if (role == 1)
                    {
                        _stockshortMasterList = repo.TblStockshortMaster.AsEnumerable()
                                  .Where(inv =>
                                           inv.StockshortDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"))
                                     )
                                   .ToList();
                    }
                    else
                    {
                        _stockshortMasterList = repo.TblStockshortMaster.AsEnumerable()
                                                         .Where(inv =>
                                                                  inv.BranchCode == branchCode
                                                                  && inv.StockshortDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"))
                                                            )
                                                          .ToList();
                    }

                    return _stockshortMasterList.OrderByDescending(x => x.StockshortDate).ToList();
                }
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
                using (Repository<TblStockshortDetails> repo = new Repository<TblStockshortDetails>())
                {
                    return repo.TblStockshortDetails.Where(x => x.StockshortMasterId ==Convert.ToDecimal(shortno)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

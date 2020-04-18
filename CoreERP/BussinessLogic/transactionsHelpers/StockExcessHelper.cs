using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.transactionsHelpers
{
    public class StockExcessHelper
    {
        public List<TblBranch> GetBranchesList()
        {
            try
            {
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<CostCenters> GetCostCentersList()
        {
            try
            {
                using Repository<CostCenters> repo = new Repository<CostCenters>();
                return repo.CostCenters.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public decimal? GetStockSuffixPrefix(decimal? voucherTypeid, string branchCode, out string preFix, out string suffix)
        {
            preFix = string.Empty;
            suffix = string.Empty;

            using Repository<TblSuffixPrefix> repo = new Repository<TblSuffixPrefix>();
            var _suffixPrefix = repo.TblSuffixPrefix
.Where(s => s.VoucherTypeId == voucherTypeid && s.BranchCode == branchCode)
.FirstOrDefault();

            preFix = _suffixPrefix?.Prefix;
            suffix = _suffixPrefix?.Suffix;

            return _suffixPrefix.StartIndex;
        }
        public string GenerateStockENumber(decimal? voucherTypeid, string branchCode)
        {
            try
            {
                string prefix = string.Empty, sufix = string.Empty;
                var _number = GetStockSuffixPrefix(voucherTypeid, branchCode, out prefix, out sufix);

                if (_number == null)
                {
                    _number = 1;
                }
                else
                {
                    _number += 1;// prefix + "/" + (_number + 1) + "-" + sufix;
                }

                UpdateStockENumber(voucherTypeid, branchCode, _number);
                return $"{prefix}/{_number}-{sufix}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateStockENumber(decimal? voucherTypeid, string branchCode, decimal? invoieNumber)
        {
            using Repository<TblSuffixPrefix> repo = new Repository<TblSuffixPrefix>();
            var _suffixPrefix = repo.TblSuffixPrefix.Where(s => s.VoucherTypeId == voucherTypeid && s.BranchCode == branchCode).FirstOrDefault();

            _suffixPrefix.StartIndex = invoieNumber;
            repo.TblSuffixPrefix.Update(_suffixPrefix);
            repo.SaveChanges();
        }

        public string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = new StockExcessHelper().GenerateStockENumber(45, branchCode);
                return voucherNo;
            }
            catch { throw; }
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

        public TblProduct Getproduct(string productCode)
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

        public TblStockshortDetails GetOpStockShortDetailsection(string productCode, string branchCode)
        {
            try
            {
                var _product = Getproduct(productCode);

                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    var date = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
                    //var date = DateTime.Now.ToString();
                    var issueno = new StockExcessHelper().GenerateStockENumber(45, branchCode);
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

        public List<TblStockExcessMaster> GetStockexcesslist(string code)
        {
            try
            {
                using (Repository<TblStockExcessMaster> repo = new Repository<TblStockExcessMaster>())
                {
                    return repo.TblStockExcessMaster.Where(x => x.StockExcessNo == code).ToList();
                }

            }
            catch { throw; }
        }

        public TblBranch GetBranch(string branchCode)
        {
            return new InvoiceHelper().GetBranches(branchCode).FirstOrDefault();
        }
        public bool RegisterStocksexcess(TblStockExcessMaster stockexcessMaster, List<TblStockExcessDetails> stockexcessDetails)
        {
            try
            {
                using ERPContext context = new ERPContext();
                using var dbTransaction = context.Database.BeginTransaction();
                try
                {
                    var _stockexcessMaster = AddStockExcessMaster(context, stockexcessMaster);
                    foreach (var stockexcessdetail in stockexcessDetails)
                    {
                        AddStockExcessDetail(context, stockexcessdetail, _stockexcessMaster);
                        AddStockInformation(context, stockexcessdetail, _stockexcessMaster);
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
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private TblStockExcessMaster AddStockExcessMaster(ERPContext context, TblStockExcessMaster stockexcessMaster)
        {
            try
            {
                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(stockexcessMaster.UserId, null));
                var user = context.TblUserNew.Where(x => x.UserName == stockexcessMaster.UserName).FirstOrDefault();
                stockexcessMaster.BranchName = GetBranch(stockexcessMaster.BranchCode)?.BranchName;
                stockexcessMaster.EmployeeId = user.EmployeeId;
                stockexcessMaster.ShiftId = shifId;
                context.TblStockExcessMaster.Add(stockexcessMaster);
                if (context.SaveChanges() > 0)
                    return stockexcessMaster;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TblStockExcessDetails AddStockExcessDetail(ERPContext context, TblStockExcessDetails stockExcessDetail, TblStockExcessMaster stockExcessMaster)
        {
            try
            {
                var _product = new InvoiceHelper().GetProducts(stockExcessDetail.ProductCode).FirstOrDefault();
                stockExcessDetail.StockExcessMasterId = stockExcessMaster.StockExcessMasterId;
                stockExcessDetail.StockExcessDetailsDate = stockExcessMaster.StockExcessDate;
                stockExcessDetail.ProductId = _product.ProductId;
                stockExcessDetail.UnitId = Convert.ToDecimal(_product.UnitId);
                context.TblStockExcessDetails.Add(stockExcessDetail);
                if (context.SaveChanges() > 0)
                    return stockExcessDetail;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TblStockInformation AddStockInformation(ERPContext context, TblStockExcessDetails stockExcessDetail, TblStockExcessMaster stockExcessMaster, decimal? voucherTypeID = 45)
        {
            try
            {
                TblStockInformation stockInformation = new TblStockInformation();
                try { stockInformation.BranchId = Convert.ToDecimal(stockExcessMaster.BranchCode ?? "0"); } catch { };
                stockInformation.BranchCode = stockExcessMaster.BranchCode;
                stockInformation.UserId = stockExcessMaster.UserId;
                stockInformation.ShiftId = stockExcessMaster.ShiftId;
                stockInformation.TransactionDate = stockExcessMaster.StockExcessDate;
                stockInformation.VoucherNo = string.Empty;
                stockInformation.VoucherTypeId = voucherTypeID;
                stockInformation.InvoiceNo = stockExcessMaster.StockExcessNo;
                stockInformation.ProductId = stockExcessDetail.ProductId;
                stockInformation.ProductCode = stockExcessDetail.ProductCode;
                stockInformation.Rate = stockExcessDetail.Rate;
                stockInformation.InwardQty = stockExcessDetail.Qty;
                stockInformation.OutwardQty = 0;
                context.TblStockInformation.Add(stockInformation);
                if (context.SaveChanges() > 0)
                    return stockInformation;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblStockExcessDetails> StockexcessDeatilList(decimal id)
        {
            try
            {
                using (Repository<TblStockExcessDetails> repo = new Repository<TblStockExcessDetails>())
                {
                    return repo.TblStockExcessDetails.Where(x => x.StockExcessMasterId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblStockExcessMaster> GetStockexcessList(VoucherNoSearchCriteria searchCriteria, string branchCode)
        {
            try
            {
                searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;

                using Repository<TblStockExcessMaster> repo = new Repository<TblStockExcessMaster>();
                List<TblStockExcessMaster> _stockexcess = null;
                if (searchCriteria.Role == 1)
                {
                    _stockexcess = repo.TblStockExcessMaster.AsEnumerable()
                          .Where(se =>
                                     DateTime.Parse(se.StockExcessDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? se.StockExcessDate).Value.ToShortDateString())
                                   && DateTime.Parse(se.StockExcessDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? se.StockExcessDate).Value.ToShortDateString()))
                           .ToList();
                }
                else
                {
                    _stockexcess = repo.TblStockExcessMaster.AsEnumerable()
                                             .Where(se =>
                                                        DateTime.Parse(se.StockExcessDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? se.StockExcessDate).Value.ToShortDateString())
                                                      && DateTime.Parse(se.StockExcessDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? se.StockExcessDate).Value.ToShortDateString())
                                                      && se.BranchCode == branchCode)
                                              .ToList();
                }
                if (!string.IsNullOrEmpty(searchCriteria.VoucherNo))
                    _stockexcess = _stockexcess.Where(x => x.StockExcessNo == searchCriteria.VoucherNo).ToList();


                return _stockexcess;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

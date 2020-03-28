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
    public class StockissuesHelper
    {
        public List<TblOperatorStockIssues> GetStockissuesList()
        {
            try
            {
                using (Repository<TblOperatorStockIssues> repo = new Repository<TblOperatorStockIssues>())
                {
                    return repo.TblOperatorStockIssues.ToList();
                }
            }
            catch { throw; }
        }

        public string GetStackissueNo(string branchCode)
        {

            try
            {
                return new CommonHelper().GenerateNumber(43, branchCode);
            }
            catch { throw; }
        }

        
        public List<TblBranch> Getbranchcodes(string codes)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    var code = repo.TblBranch.Where(x => x.SubBranchof ==Convert.ToDecimal(codes)).FirstOrDefault();
                    return repo.TblBranch
                          .Where(x => (x.BranchCode==Convert.ToString(code.BranchCode)))
                          .ToList();
                }
            }
            catch { throw; }
        }
        public List<TblProduct> GetProductLists(string productcode)
        {
            try
            {
                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    return repo.TblProduct
                          .Where(x => (x.ProductCode.Contains(productcode))
                                )
                          .ToList();
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
                    return repo.TblBranch.AsEnumerable().Where(b => b.SubBranchof != -1).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblOperatorStockIssues> GetStockIssueslist( string code)
        {
            try
            {
                using (Repository<TblOperatorStockIssues> repo = new Repository<TblOperatorStockIssues>())
                {
                    return repo.TblOperatorStockIssues.Where(x => x.IssueNo == code).ToList();
                }

            }
            catch { throw; }
        }


        public TblOperatorStockIssuesDetail GetOpStockIssuesDetailsection(string productCode, string branchCode)
        {
            try
            {
                var _product = Geproduct(productCode);

                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    var date = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
                    //var date = DateTime.Now.ToString();
                    var issueno = new CommonHelper().GenerateNumber(43, branchCode);

                    var operatorStockIssuesDetail = new TblOperatorStockIssuesDetail();
                    operatorStockIssuesDetail.BatchNo = date + "-" + issueno + "-" + _product.ProductCode;
                    operatorStockIssuesDetail.Qty = 0;
                    operatorStockIssuesDetail.GrossAmount = 0;
                    operatorStockIssuesDetail.Rate = GetProductRate(branchCode, productCode);
                    operatorStockIssuesDetail.AvailStock = GetProductQty(branchCode, productCode);
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


        public bool RegisterStockissues(TblOperatorStockIssues stockissue, List<TblOperatorStockIssuesDetail> stockissueDetails)
        {
            try
            {
                //invoice.IsSalesReturned = false;
                //invoice.IsManualEntry = false;
                using (Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>())
                {
                    //add voucher typedetails
                    //userid and shiftid not saving
                    var shiftid = repo.TblShift.Where(x => x.UserId == stockissue.UserId).FirstOrDefault();
                    var _branch = GetBranches(stockissue.FromBranchCode).ToArray().FirstOrDefault();
                    var _tobranch = GetBranches(stockissue.ToBranchCode).ToArray().FirstOrDefault();
                    stockissue.FromBranchCode = _branch.BranchCode;
                    stockissue.FromBranchName = _branch.BranchName;
                    stockissue.ToBranchCode = stockissue.ToBranchCode;
                    stockissue.ToBranchName = _tobranch.BranchName;
                    stockissue.ServerDateTime = DateTime.Now;
                    stockissue.IssueDate = stockissue.IssueDate;
                    stockissue.IssueNo = stockissue.IssueNo;
                    stockissue.UserName = stockissue.UserName;
                    stockissue.ShiftId = shiftid.ShiftId;
                    stockissue.UserId = stockissue.UserId;
                    stockissue.EmployeeId = -1;
                    stockissue.Remarks = stockissue.Remarks;
                    repo.TblOperatorStockIssues.Add(stockissue);
                    repo.SaveChanges();
                    foreach (var invdtl in stockissueDetails)
                    {
                        var _product = new InvoiceHelper().GetProducts(invdtl.ProductCode).FirstOrDefault();
                        var operatorStockIssueId = GetStockIssueslist(stockissue.IssueNo).FirstOrDefault();
                        #region StockIssueDetails
                        invdtl.OperatorStockIssueId = operatorStockIssueId.OperatorStockIssueId;
                        invdtl.IssueNo = stockissue.IssueNo;
                        invdtl.IssueDate = DateTime.Now;
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
                        repo.TblOperatorStockIssuesDetail.Add(invdtl);
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
        public List<TblOperatorStockIssues> GetStockissuesMasters(SearchCriteria searchCriteria)
        {
            try
            {
                searchCriteria.FromDate = Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString());
                searchCriteria.ToDate = Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());

                using (Repository<TblOperatorStockIssues> repo = new Repository<TblOperatorStockIssues>())
                {
                    return repo.TblOperatorStockIssues.AsEnumerable()
                               .Where(inv => Convert.ToDateTime(inv.IssueDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
                                        && Convert.ToDateTime(inv.IssueDate.Value.ToShortDateString()) >= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString())
                                        && inv.IssueNo == (searchCriteria.InvoiceNo ?? inv.IssueNo)
                                  )
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<TblOperatorStockIssuesDetail> StockissuesDeatils(string issueNo)
        {
            try
            {
                using (Repository<TblOperatorStockIssuesDetail> repo = new Repository<TblOperatorStockIssuesDetail>())
                {
                    return repo.TblOperatorStockIssuesDetail.Where(x => x.IssueNo == issueNo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

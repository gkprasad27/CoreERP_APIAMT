using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.transactionsHelpers
{
    public class PurchaseRequesitionMasterHelpercs
    {
        //to get the invoice Master data while page load
        public List<PurchaseRequisitionMaster> GetPurchaseRequesitionList(int? role, string branchCode)
        {
            try
            {

                using (Repository<PurchaseRequisitionMaster> repo = new Repository<PurchaseRequisitionMaster>())
                {
                    List<PurchaseRequisitionMaster> _prMasterList = null;
                    if (role == 1)
                    {
                        _prMasterList = repo.PurchaseRequisitionMaster.AsEnumerable()
                                  .Where(inv =>
                                         (inv.Status != "Approved" || inv.Status != "Rejected")
                                                                  && inv.RequisitionDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"))
                                     //       inv.Status != "Approved" || inv.Status != "Rejected")
                                     //inv.RequisitionDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd")
                                     //&& )
                                     )
                                   .ToList();
                    }
                    else
                    {
                        _prMasterList = repo.PurchaseRequisitionMaster.AsEnumerable()
                                                         .Where(inv =>inv.Status!="Rejected" &&
                                                                  inv.Branch == branchCode && (inv.Status!= "Approved")
                                                                  && inv.RequisitionDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"))
                                                            )
                                                          .ToList();
                    }

                    return _prMasterList.OrderByDescending(x => x.RequisitionDate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<PurchaseRequisitionMaster> GetPurchaseRequisitionList()
        {
            try
            {
                using (Repository<PurchaseRequisitionMaster> repo = new Repository<PurchaseRequisitionMaster>())
                {
                    return repo.PurchaseRequisitionMaster.ToList();
                }
            }
            catch { throw; }
        }

        public string GetStackissueNo(string branchCode, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                string suffix = string.Empty, prefix = string.Empty, billno = string.Empty;
                PurchaseRequisitionMaster _receiptNo = null;
                using (Repository<PurchaseRequisitionMaster> _repo = new Repository<PurchaseRequisitionMaster>())
                {
                    _receiptNo = _repo.PurchaseRequisitionMaster.Where(x => x.Branch == branchCode).OrderByDescending(x => x.RequisitionDate).FirstOrDefault();

                    if (_receiptNo != null)
                    {
                        var invSplit = _receiptNo.RequisitionNo.Split('/');
                        var invNo = invSplit[1].Split('-');
                        billno = $"{invSplit[0]}/{Convert.ToDecimal(invNo[0]) + 1}-{invNo[1]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(54, branchCode, out prefix, out suffix);
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
                    errorMessage = "Issue no not gererated please enter manully.";
                }

                return billno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public string Getbranchcode(string codes)
        //{
        //    try
        //    {
        //        string name = null;
        //        using (Repository<TblBranch> repo = new Repository<TblBranch>())
        //        {
        //            //var code = repo.TblBranch.Where(x => x.SubBranchof == (codes)).FirstOrDefault();
        //            string strName = repo.TblBranch.Where(x => x.SubBranchof == Convert.ToDecimal(codes)).SingleOrDefault()?.BranchCode;
        //            return strName;
        //        }
        //    }
        //    catch { throw; }
        //}

        //public string Getbranchcodes(string codes)
        //{
        //    try
        //    {
        //        string name = null;
        //        using (Repository<TblBranch> repo = new Repository<TblBranch>())
        //        {
        //            var code = repo.TblBranch.Where(x => x.BranchCode == (codes)).FirstOrDefault();
        //            var data = repo.TblBranch
        //                  .Where(x => (x.BranchCode == Convert.ToString(code.SubBranchof)))
        //                  .ToList();
        //            foreach (var item in data)
        //            {
        //                name = item.BranchCode + "-" + item.BranchName;
        //            }
        //            return name;
        //        }
        //    }
        //    catch { throw; }
        //}

        //public List<TblBranch> GetBranches()
        //{
        //    try
        //    {
        //        using (Repository<TblBranch> repo = new Repository<TblBranch>())
        //        {
        //            return repo.TblBranch.AsEnumerable().Where(b => b.SubBranchof != -1).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<TblBranch> GettoBranches()
        //{
        //    try
        //    {
        //        using (Repository<TblBranch> repo = new Repository<TblBranch>())
        //        {
        //            return repo.TblBranch.AsEnumerable().Where(b => b.SubBranchof == -1).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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

        public List<PurchaseRequisitionMaster> GetprreqIssueslist(string code)
        {
            try
            {
                using (Repository<PurchaseRequisitionMaster> repo = new Repository<PurchaseRequisitionMaster>())
                {
                    return repo.PurchaseRequisitionMaster.Where(x => x.RequisitionNo == code).ToList();
                }

            }
            catch { throw; }
        }


        public PurchaseRequisitiondetails GetOpStockIssuesDetailsection(string productCode, string branchCode)
        {
            try
            {
                var _product = Geproduct(productCode);

                using Repository<TblProduct> repo = new Repository<TblProduct>();
                var date = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
                var receiptno = repo.TblSuffixPrefix.Where(x => x.BranchCode == branchCode && x.VoucherTypeId == 54).FirstOrDefault();
                var prreqdeatails = new PurchaseRequisitiondetails
                {
                    Qty = 0,
                    AvailbleQtyinBranch = GetProductQty(branchCode, productCode),
                    AvailbleQtyinGowdown = GetProductQty("5", productCode),
                    ApprovedQty="0",
                    ProductCode = _product.ProductCode,
                    ProductName = _product.ProductName
                };

                return prreqdeatails;
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


        public bool RegisterPurchaserequisition(PurchaseRequisitionMaster prreq, List<PurchaseRequisitiondetails> prreqDetails)
        {
            try
            {
                using ERPContext context = new ERPContext();
               // decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(prreq.UserId, null));
                using (Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>())
                {
                    //add voucher typedetails
                    
                    var _branch = GetBranches(prreq.Branch).ToArray().FirstOrDefault();
                    prreq.Branch = _branch.BranchCode;
                    prreq.RequisitionDate = prreq.RequisitionDate;
                    prreq.RequisitionNo = prreq.RequisitionNo;
                    prreq.Company = prreq.Company;
                    repo.PurchaseRequisitionMaster.Add(prreq);
                    repo.SaveChanges();
                    foreach (var invdtl in prreqDetails)
                    {
                        var _product = new InvoiceHelper().GetProducts(invdtl.ProductCode).FirstOrDefault();
                        var operatorStockIssueId = GetprreqIssueslist(prreq.RequisitionNo).FirstOrDefault();
                        int i = 0;
                        #region StockIssueDetails
                        invdtl.Purchasereqisitionid = operatorStockIssueId.Id;
                        invdtl.ProductId = _product.ProductId;
                        invdtl.ProductCode = invdtl.ProductCode;
                        invdtl.ProductName = invdtl.ProductName;
                        invdtl.Qty = invdtl.Qty;
                        invdtl.AvailbleQtyinBranch = Convert.ToDecimal(invdtl.AvailbleQtyinBranch);
                        repo.PurchaseRequisitiondetails.Add(invdtl);
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


        public List<PurchaseRequisitionMaster> GetStockissuesMasters(VoucherNoSearchCriteria searchCriteria, string branchCode)
        {
            try
            {

                using (Repository<PurchaseRequisitionMaster> repo = new Repository<PurchaseRequisitionMaster>())
                {
                    List<PurchaseRequisitionMaster> _purchaserequisitionList = null;

                    if (searchCriteria.Role == 1)
                    {
                        _purchaserequisitionList = repo.PurchaseRequisitionMaster.AsEnumerable()
                            .Where(inv =>
                                        DateTime.Parse(inv.RequisitionDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? inv.RequisitionDate).Value.ToShortDateString())
                                      && DateTime.Parse(inv.RequisitionDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? inv.RequisitionDate).Value.ToShortDateString())
                                )
                              .ToList();
                    }
                    else
                    {
                        _purchaserequisitionList = repo.PurchaseRequisitionMaster.AsEnumerable()
                            .Where(cp =>

                                       // DateTime.Parse(cp.RequisitionDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.RequisitionDate).Value.ToShortDateString())
                                     // && DateTime.Parse(cp.RequisitionDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.RequisitionDate).Value.ToShortDateString())
                                 //&&
                                 cp.Branch == branchCode)
                              .ToList();
                    }

                    if (!string.IsNullOrEmpty(searchCriteria.issueNo))
                        _purchaserequisitionList = GetPurchaseRequisitionList().Where(x => x.RequisitionNo == searchCriteria.issueNo).ToList();

                    return _purchaserequisitionList.OrderByDescending(x => x.RequisitionDate).ToList();
                    //_cashpaymentMasterList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<PurchaseRequisitiondetails> PurchaseRequisitionDeatils(string issueNo)
        {
            try
            {
                using (Repository<PurchaseRequisitiondetails> repo = new Repository<PurchaseRequisitiondetails>())
                {
                    return repo.PurchaseRequisitiondetails.Where(x => x.Purchasereqisitionid == Convert.ToDecimal(issueNo)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

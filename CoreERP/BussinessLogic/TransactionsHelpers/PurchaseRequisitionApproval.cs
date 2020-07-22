using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.transactionsHelpers
{
    public class PurchaseRequisitionApproval
    {
      
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

        public List<PurchaseRequisitiondetails> GetprreqIssuesdetailslist(string code)
        {
            try
            {
                using (Repository<PurchaseRequisitiondetails> repo = new Repository<PurchaseRequisitiondetails>())
                {
                    return repo.PurchaseRequisitiondetails.Where(x => x.Purchasereqisitionid ==Convert.ToInt32(code)).ToList();
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
        public bool RegisterPurchaserequisition(PurchaseRequisitionMaster prreq, List<PurchaseRequisitiondetails> prreqDetails)
        {
            try
            {
                string straprstatus = "Approved";
                string strrjcstatus = "Rejected";
                using ERPContext context = new ERPContext();
                using (Repository<TblInvoiceDetail> repo = new Repository<TblInvoiceDetail>())
                {
                    //+add voucher typedetails
                    foreach (var invdtl in prreqDetails)
                    {
                        var _product = new InvoiceHelper().GetProducts(invdtl.ProductCode).FirstOrDefault();
                        var operatorStockIssueId = GetprreqIssueslist(prreq.RequisitionNo).FirstOrDefault();

                        int i = 0;
                        
                        #region StockIssueDetails
                        if ((invdtl.Qty>0 && invdtl.ApprovedQty!="0")||(invdtl.Qty > 0 && invdtl.ApprovedQty == "0"))
                        {
                            invdtl.Purchasereqisitionid = operatorStockIssueId.Id;
                            invdtl.ProductId = _product.ProductId;
                            invdtl.ProductCode = invdtl.ProductCode;
                            invdtl.ProductName = invdtl.ProductName;
                            invdtl.Qty = invdtl.Qty;
                            invdtl.Status = straprstatus;
                            invdtl.AvailbleQtyinBranch = Convert.ToDecimal(invdtl.AvailbleQtyinBranch);
                            invdtl.AvailbleQtyinGowdown = Convert.ToDecimal(invdtl.AvailbleQtyinGowdown);
                            invdtl.ApprovedQty = (invdtl.ApprovedQty);
                            repo.Entry(invdtl).State = EntityState.Modified;
                            repo.PurchaseRequisitiondetails.Update(invdtl);
                            // repo.PurchaseRequisitiondetails.Update(invdtl);
                            repo.SaveChanges();
                        }
                        else
                        {
                            invdtl.Purchasereqisitionid = operatorStockIssueId.Id;
                            invdtl.ProductId = _product.ProductId;
                            invdtl.ProductCode = invdtl.ProductCode;
                            invdtl.ProductName = invdtl.ProductName;
                            invdtl.Qty = invdtl.Qty;
                            invdtl.Status = strrjcstatus;
                            invdtl.AvailbleQtyinBranch = Convert.ToDecimal(invdtl.AvailbleQtyinBranch);
                            invdtl.AvailbleQtyinGowdown = Convert.ToDecimal(invdtl.AvailbleQtyinGowdown);
                            invdtl.ApprovedQty = (invdtl.ApprovedQty);
                            repo.Entry(invdtl).State = EntityState.Modified;
                            repo.PurchaseRequisitiondetails.Update(invdtl);
                            // repo.PurchaseRequisitiondetails.Update(invdtl);
                            repo.SaveChanges();
                        }
                        var operatorreqId = GetprreqIssuesdetailslist((prreq.Id).ToString()).FirstOrDefault();
                       
                        if(operatorreqId.Purchasereqisitionid==Convert.ToDecimal(prreq.Id)&&(operatorreqId.Status==("Approved")|| operatorreqId.Status == ("Rejected")))
                        {
                            var _branch = GetBranches(prreq.Branch).ToArray().FirstOrDefault();
                            prreq.Branch = _branch.BranchCode;
                            prreq.RequisitionDate = prreq.RequisitionDate;
                            prreq.RequisitionNo = prreq.RequisitionNo;
                            prreq.Company = prreq.Company;
                            prreq.Status = straprstatus;
                            repo.PurchaseRequisitionMaster.Update(prreq);
                        }
                        if (operatorreqId.Purchasereqisitionid == Convert.ToDecimal(prreq.Id) && (operatorreqId.Status == ("Rejected") || operatorreqId.Status == ("Rejected")))
                        {
                            var _branch = GetBranches(prreq.Branch).ToArray().FirstOrDefault();
                            prreq.Branch = _branch.BranchCode;
                            prreq.RequisitionDate = prreq.RequisitionDate;
                            prreq.RequisitionNo = prreq.RequisitionNo;
                            prreq.Company = prreq.Company;
                            prreq.Status = strrjcstatus;
                            repo.PurchaseRequisitionMaster.Update(prreq);
                        }
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
    }
}

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
    public class OilconversionHelper
    {
        public  List<TblOilConversionMaster> GetOilconversionList()
        {
            try
            {
                using Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>();
                return repo.TblOilConversionMaster.ToList();
            }
            catch { throw; }
        }
        public string GetoilconversionVoucherNo(string branchCode)
        {

            try
            {
                return new CommonHelper().GenerateNumber(52, branchCode);
            }
            catch { throw; }
        }




        public TblOilConversionDetails GetoilconversionDetailsection(string productCode, string branchCode)
        {
            try
            {
                var _product = Geproduct(productCode);

                using Repository<TblProduct> repo = new Repository<TblProduct>();
                var date = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
                //var date = DateTime.Now.ToString();
                var operatoroilcnvsnsDetail = new TblOilConversionDetails();
                var oilcnvsnno = repo.TblSuffixPrefix.Where(x => x.BranchCode == branchCode && x.VoucherTypeId == 52).FirstOrDefault();
                operatoroilcnvsnsDetail.BatchNo = date + "-" + oilcnvsnno.Prefix + "-" + oilcnvsnno.StartIndex + "-" + oilcnvsnno.Suffix + "-" + "-" + _product.ProductCode;

                //var oilcnvsnno = new CommonHelper().GenerateNumber(52, branchCode);
                //operatorStockIssuesDetail.BatchNo = date + "-" + oilcnvsnno + "-" + _product.ProductCode;
                //date + "-" + issueno + "-" + _product.ProductCode;
                operatoroilcnvsnsDetail.Qty = 0;
                //operatorStockIssuesDetail.TotalAmount = 0;
                operatoroilcnvsnsDetail.Rate = GetProductRate(branchCode, productCode);
                //operatorStockIssuesDetail.AvailStock = GetProductQty(branchCode, productCode);
                operatoroilcnvsnsDetail.HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0);
                operatoroilcnvsnsDetail.ProductCode = _product.ProductCode;
                operatoroilcnvsnsDetail.ProductName = _product.ProductName;
                operatoroilcnvsnsDetail.UnitName = _product.UnitName;

                return operatoroilcnvsnsDetail;
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

        public List<TblOilConversionMaster> GetOilConversionslist(string code)
        {
            try
            {
                using Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>();
                return repo.TblOilConversionMaster.Where(x => x.OilConversionVchNo == code).ToList();

            }
            catch { throw; }
        }
        public bool RegisterBill(TblOilConversionMaster oilcnvsmaster, List<TblOilConversionDetails> oilcnvsmasterDetails)
        {
            try
            {
                //invoice.IsSalesReturned = false;
                //invoice.IsManualEntry = false;
                using (Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>())
                {
                    //add voucher typedetails
                    var user = repo.TblUser.Where(x => x.UserName == oilcnvsmaster.UserName).FirstOrDefault();
                    var shift= repo.TblShift.Where(x => x.UserId == user.UserId).FirstOrDefault();
                    var _branch = GetBranches(oilcnvsmaster.BranchCode).ToArray().FirstOrDefault();
                    oilcnvsmaster.BranchCode = _branch.BranchCode;
                    oilcnvsmaster.BranchName = _branch.BranchName;
                    oilcnvsmaster.BranchId = _branch.BranchId;
                    oilcnvsmaster.ServerDate = DateTime.Now;
                    oilcnvsmaster.OilConversionDate = oilcnvsmaster.OilConversionDate;
                    oilcnvsmaster.OilConversionVchNo = oilcnvsmaster.OilConversionVchNo;
                    oilcnvsmaster.VoucherTypeId = oilcnvsmaster.VoucherTypeId;
                    oilcnvsmaster.ShiftId = shift.ShiftId;
                    oilcnvsmaster.UserId = user.UserId;
                    oilcnvsmaster.UserName = oilcnvsmaster.UserName;
                    oilcnvsmaster.EmployeeId = -1;
                    oilcnvsmaster.Narration = oilcnvsmaster.Narration;
                    repo.TblOilConversionMaster.Add(oilcnvsmaster);
                    repo.SaveChanges();
                    foreach (var oilconversions in oilcnvsmasterDetails)
                    {
                        var _product = new InvoiceHelper().GetProducts(oilconversions.ProductCode).FirstOrDefault();

                        var oilcnvsmmstrid = GetOilConversionslist(oilcnvsmaster.OilConversionVchNo).FirstOrDefault();
                        #region StockIssueDetails
                        oilconversions.OilConversionMasterId = oilcnvsmmstrid.OilConversionMasterId;
                        oilconversions.OilConversionMasterId = oilconversions.OilConversionMasterId;
                        oilconversions.OilConversionDetailsDate = DateTime.Now;
                        oilconversions.ServerDateTime = DateTime.Now;
                        oilconversions.ProductId = _product.ProductId;
                        oilconversions.ProductCode = oilconversions.ProductCode;
                        oilconversions.ProductName = oilconversions.ProductName;
                        oilconversions.HsnNo = oilconversions.HsnNo;
                        oilconversions.Rate = oilconversions.Rate;
                        oilconversions.Qty = oilconversions.Qty;
                        oilconversions.BatchNo = oilconversions.BatchNo;
                        oilconversions.UnitId = Convert.ToDecimal(_product.UnitId);
                        oilconversions.UnitName = oilconversions.UnitName;
                        oilconversions.DamageQty = oilconversions.DamageQty;
                        oilconversions.NewQty = oilconversions.NewQty;
                        oilconversions.GrossAmount = oilconversions.GrossAmount;
                        repo.TblOilConversionDetails.Add(oilconversions);
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
        public List<TblOilConversionMaster> GetOilConversionMasters(SearchCriteria searchCriteria)
        {
            try
            {
                searchCriteria.FromDate = Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString());
                searchCriteria.ToDate = Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString());

                using Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>();
                return repo.TblOilConversionMaster.AsEnumerable()
.Where(inv => Convert.ToDateTime(inv.OilConversionDate.Value) >= Convert.ToDateTime(searchCriteria.FromDate.Value.ToShortDateString())
&& Convert.ToDateTime(inv.OilConversionDate.Value.ToShortDateString()) >= Convert.ToDateTime(searchCriteria.ToDate.Value.ToShortDateString())
&& inv.OilConversionVchNo == (searchCriteria.InvoiceNo ?? inv.OilConversionVchNo)
)
.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<TblOilConversionDetails> OilconversionsDeatilList(string vocherno)
        {
            try
            {
                using Repository<TblOilConversionDetails> repo = new Repository<TblOilConversionDetails>();
                var vocher = repo.TblOilConversionMaster.Where(x => x.OilConversionVchNo == vocherno).FirstOrDefault();
                return repo.TblOilConversionDetails.Where(x => x.OilConversionMasterId == vocher.OilConversionMasterId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

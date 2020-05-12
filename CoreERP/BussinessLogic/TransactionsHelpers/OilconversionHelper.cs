using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
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
        public List<TblOilConversionMaster> GetOilconversionList()
        {
            try
            {
                using Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>();
                return repo.TblOilConversionMaster.ToList();
            }
            catch { throw; }
        }
        public string GetoilconversionVoucherNo(string branchCode, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                string suffix = string.Empty, prefix = string.Empty, billno = string.Empty;
                TblOilConversionMaster _receiptNo = null;
                using (Repository<TblOilConversionMaster> _repo = new Repository<TblOilConversionMaster>())
                {
                    _receiptNo = _repo.TblOilConversionMaster.Where(x => x.BranchCode == branchCode).OrderByDescending(x => x.OilConversionDate).FirstOrDefault();

                    if (_receiptNo != null)
                    {
                        var invSplit = _receiptNo.OilConversionVchNo.Split('-');
                        billno = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1]) + 1}-{invSplit[2]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(52, branchCode, out prefix, out suffix);
                        if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                        {
                            errorMessage = $"No prefix and suffix confugured for branch code: {branchCode} ";
                            return billno = string.Empty;
                        }

                        billno = $"{prefix}-1-{suffix}";
                    }
                }

                if (string.IsNullOrEmpty(billno))
                {
                    errorMessage = "oilconversion no not gererated please enter manully.";
                }

                return billno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public string GetoilconversionVoucherNo(string branchCode)
        //{

        //    try
        //    {
        //        return new CommonHelper().GenerateNumber(52, branchCode);
        //    }
        //    catch { throw; }
        //}




        public TblOilConversionDetails GetoilconversionDetailsection(string productCode, string branchCode)
        {
            try
            {
                var _product = Geproduct(productCode);

                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    var date = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
                    //var date = DateTime.Now.ToString();
                    var operatorStockIssuesDetail = new TblOperatorStockIssuesDetail();
                    var operatoroilcnvsnsDetail = new TblOilConversionDetails();
                    var oilcnvsnno = repo.TblSuffixPrefix.Where(x => x.BranchCode == branchCode && x.VoucherTypeId == 52).FirstOrDefault();
                    operatoroilcnvsnsDetail.BatchNo = date + "-" + oilcnvsnno.Prefix + "-" + oilcnvsnno.StartIndex + "-" + oilcnvsnno.Suffix + "-" + "-" + _product.ProductCode;
                    operatoroilcnvsnsDetail.Qty = 0;
                    operatoroilcnvsnsDetail.Rate = GetProductRate(branchCode, productCode);
                    operatoroilcnvsnsDetail.GrossAmount = Convert.ToDecimal(GetProductQty(branchCode, productCode));
                    operatoroilcnvsnsDetail.HsnNo = Convert.ToDecimal(_product.HsnNo ?? 0);
                    operatoroilcnvsnsDetail.ProductCode = _product.ProductCode;
                    operatoroilcnvsnsDetail.ProductName = _product.ProductName;
                    operatoroilcnvsnsDetail.UnitName = _product.UnitName;

                    return operatoroilcnvsnsDetail;

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
        public decimal? GetProductQty(string branchCode, string productCode, string ProductId = null)
        {
            try
            {
                List<TblStockInformation> stocInfoList = null;
                using (Repository<TblStockInformation> repo = new Repository<TblStockInformation>())
                {
                    stocInfoList = repo.TblStockInformation.Where(stock => stock.ProductCode == productCode && stock.BranchCode == branchCode).ToList();
                }

                var qty = stocInfoList.Sum(x => x.InwardQty) - stocInfoList.Sum(x => x.OutwardQty);

                if (qty > 0)
                    return qty;

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblPackageConversion> GetPackageProductQty(string productCode = null)
        {
            try
            {
                using Repository<TblPackageConversion> repo = new Repository<TblPackageConversion>();
                return repo.TblPackageConversion.AsEnumerable().Where(b => b.InputproductCode == (productCode ?? b.InputproductCode)).ToList();
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

        public List<TblVoucherType> GetVoucherTypeList(decimal voucherTypeId)
        {
            try
            {
                using Repository<TblVoucherType> repo = new Repository<TblVoucherType>();
                return repo.TblVoucherType.Where(v => v.VoucherTypeId == voucherTypeId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Stockinformation
        private TblStockInformation AddStockInformation(ERPContext context, TblOilConversionDetails oilConversionDetail, TblOilConversionMaster oilConversionMaster, string branchCode, bool isFromBranch, decimal? voucherTypeID = 52)
        {
            try
            {
                var _productQty = GetPackageProductQty(oilConversionDetail.ProductCode).FirstOrDefault();
                TblStockInformation stockInformation = new TblStockInformation();
                try { stockInformation.BranchId = Convert.ToDecimal(branchCode ?? "0"); } catch { };
                stockInformation.BranchCode = branchCode;
                stockInformation.UserId = oilConversionMaster.UserId;
                stockInformation.ShiftId = oilConversionMaster.ShiftId;
                stockInformation.TransactionDate = oilConversionMaster.OilConversionDate;
                stockInformation.VoucherNo = oilConversionMaster.VoucherTypeId.ToString();
                stockInformation.VoucherTypeId = voucherTypeID;
                stockInformation.InvoiceNo = oilConversionMaster.OilConversionVchNo;
                stockInformation.Rate = oilConversionDetail.Rate;


                if (isFromBranch)
                {
                    stockInformation.ProductId = oilConversionDetail.ProductId;
                    stockInformation.ProductCode = oilConversionDetail.ProductCode;
                    stockInformation.OutwardQty = oilConversionDetail.Qty;
                }
                else
                {
                    var _product = new InvoiceHelper().GetProducts(_productQty.OutputproductCode).FirstOrDefault();
                    stockInformation.ProductId = _product.ProductId;
                    stockInformation.ProductCode = _productQty.OutputproductCode;
                    stockInformation.InwardQty = oilConversionDetail.Qty * _productQty.OutputQty;
                }


                stockInformation.OutwardQty = stockInformation.OutwardQty ?? 0;
                stockInformation.InwardQty = stockInformation.InwardQty ?? 0;

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
        #endregion

        public bool RegisterBill(TblOilConversionMaster oilConversionMaster, List<TblOilConversionDetails> oilConversionDetail)
        {
            try
            {
                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(Convert.ToDecimal(oilConversionMaster.UserId ?? 0), null));
                var _user = new UserManagmentHelper().GetEmployeeID(oilConversionMaster.UserName);
                var _vouchertType = GetVoucherTypeList(52).ToArray().FirstOrDefault();
                var _branch = GetBranches(oilConversionMaster.BranchCode).ToArray().FirstOrDefault();

                using ERPContext context = new ERPContext();
                using var dbTransaction = context.Database.BeginTransaction();
                try
                {
                    #region Add voucher master record
                    var _voucherMaster = AddVoucherMaster(context, oilConversionMaster, _branch, _vouchertType.VoucherTypeId);
                    #endregion

                    oilConversionMaster.VoucherTypeId = _voucherMaster.VoucherMasterId;
                    oilConversionMaster.ServerDate = DateTime.Now;
                    oilConversionMaster.BranchId = _branch.BranchId;
                    oilConversionMaster.BranchName = _branch.BranchName;
                    oilConversionMaster.EmployeeId = _voucherMaster.EmployeeId;
                    oilConversionMaster.ShiftId = shifId;
                    context.TblOilConversionMaster.Add(oilConversionMaster);
                    context.SaveChanges();

                    foreach (var oilCnvnDetail in oilConversionDetail)
                    {
                        var _product = new InvoiceHelper().GetProducts(oilCnvnDetail.ProductCode).FirstOrDefault();
                        #region oilConversionDetail
                        oilCnvnDetail.OilConversionMasterId = oilConversionMaster.OilConversionMasterId;
                        oilCnvnDetail.OilConversionDetailsDate = oilConversionMaster.OilConversionDate;
                        oilCnvnDetail.ProductId = _product.ProductId;
                        oilCnvnDetail.UnitId = _product.UnitId ?? 0;
                        oilCnvnDetail.GrossAmount = (oilCnvnDetail.Qty * oilCnvnDetail.Rate) ?? 0;
                        context.TblOilConversionDetails.Add(oilCnvnDetail);
                        context.SaveChanges();

                        #endregion
                        AddStockInformation(context, oilCnvnDetail, oilConversionMaster, oilConversionMaster.BranchCode, true);
                        AddStockInformation(context, oilCnvnDetail, oilConversionMaster, oilConversionMaster.BranchCode, false);
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

        public TblVoucherMaster AddVoucherMaster(ERPContext context, TblOilConversionMaster oilConversionMaster, TblBranch branch, decimal? voucherTypeId)
        {
            try
            {
                decimal shifId = Convert.ToDecimal(new UserManagmentHelper().GetShiftId(oilConversionMaster.UserId ?? 0, null));
                var user = context.TblUserNew.Where(x => x.UserName == oilConversionMaster.UserName).FirstOrDefault();
                var _voucherMaster = new TblVoucherMaster
                {
                    BranchCode = oilConversionMaster.BranchCode,
                    BranchName = branch.BranchName,
                    VoucherDate = oilConversionMaster.OilConversionDate,
                    VoucherTypeIdMain = voucherTypeId,
                    VoucherTypeIdSub = voucherTypeId,
                    VoucherNo = oilConversionMaster.OilConversionVchNo,
                    Amount = 0,
                    PaymentType = string.Empty,
                    ChequeNo = string.Empty,
                    Narration = "Stock Entry",
                    ServerDate = DateTime.Now,
                    UserId = oilConversionMaster.UserId,
                    UserName = oilConversionMaster.UserName,
                    EmployeeId = user.EmployeeId,
                    ShiftId = shifId
                };

                context.TblVoucherMaster.Add(_voucherMaster);
                if (context.SaveChanges() > 0)
                {
                    return _voucherMaster;
                }

                return null;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool RegisterBill(TblOilConversionMaster oilcnvsmaster, List<TblOilConversionDetails> oilcnvsmasterDetails)
        //{
        //    try
        //    {
        //        //invoice.IsSalesReturned = false;
        //        //invoice.IsManualEntry = false;
        //        using (Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>())
        //        {
        //            //add voucher typedetails
        //            var user = repo.TblUser.Where(x => x.UserName == oilcnvsmaster.UserName).FirstOrDefault();
        //            var userid = repo.TblUserNew.Where(x => x.UserName == user.UserName).FirstOrDefault();
        //            var shift= repo.TblShift.Where(x => x.UserId == userid.UserId).FirstOrDefault();
        //            var _branch = GetBranches(oilcnvsmaster.BranchCode).ToArray().FirstOrDefault();
        //            var _vouchertType = GetVoucherTypeList(52).ToArray().FirstOrDefault();
        //            TblVoucherMaster vchrmastr = new TblVoucherMaster();
        //            vchrmastr.BranchCode= _branch.BranchCode;
        //            vchrmastr.BranchName= _branch.BranchName;
        //            vchrmastr.VoucherDate = DateTime.Now;
        //            vchrmastr.VoucherTypeIdMain= 52;
        //            vchrmastr.VoucherTypeIdSub = 52;
        //            vchrmastr.VoucherNo = oilcnvsmaster.OilConversionVchNo;
        //            vchrmastr.Narration = oilcnvsmaster.Narration;
        //            vchrmastr.ServerDate = DateTime.Now;
        //            vchrmastr.ShiftId = shift.ShiftId;
        //            vchrmastr.UserId = user.UserId;
        //            vchrmastr.UserName = oilcnvsmaster.UserName;
        //            vchrmastr.EmployeeId = userid.EmployeeId;

        //            oilcnvsmaster.BranchCode = _branch.BranchCode;
        //            oilcnvsmaster.BranchName = _branch.BranchName;
        //            oilcnvsmaster.BranchId = _branch.BranchId;
        //            oilcnvsmaster.ServerDate = DateTime.Now;
        //            oilcnvsmaster.OilConversionDate = oilcnvsmaster.OilConversionDate;
        //            oilcnvsmaster.OilConversionVchNo = oilcnvsmaster.OilConversionVchNo;
        //            oilcnvsmaster.VoucherTypeId = vchrmastr.VoucherMasterId;
        //            oilcnvsmaster.ShiftId = shift.ShiftId;
        //            oilcnvsmaster.UserId = user.UserId;
        //            oilcnvsmaster.UserName = oilcnvsmaster.UserName;
        //            oilcnvsmaster.EmployeeId = userid.EmployeeId;
        //            oilcnvsmaster.Narration = oilcnvsmaster.Narration;
        //            repo.TblVoucherMaster.Add(vchrmastr);
        //            repo.TblOilConversionMaster.Add(oilcnvsmaster);
        //            repo.SaveChanges();
        //            foreach (var oilconversions in oilcnvsmasterDetails)
        //            {
        //                var _product = new InvoiceHelper().GetProducts(oilconversions.ProductCode).FirstOrDefault();
        //                var _productQty = GetProductQty(oilconversions.ProductCode).FirstOrDefault();
        //                var oilcnvsmmstrid = repo.TblOilConversionMaster.Where(stock => stock.OilConversionVchNo == oilcnvsmaster.OilConversionVchNo && (stock.UserId == user.UserId)).FirstOrDefault();
        //                int i = 0;
        //                //var _product = new InvoiceHelper().GetProducts(invdtl.ProductCode).FirstOrDefault();
        //                int[] array = new int[] { Convert.ToInt32(oilcnvsmaster.BranchCode)};
        //                foreach (var item in array)
        //                {
        //                    TblStockInformation stockinformation = new TblStockInformation();
        //                    i = item;
        //                    stockinformation.BranchCode = Convert.ToString(i);
        //                    var _branchcode = GetBranches(Convert.ToString(i)).ToArray().FirstOrDefault();
        //                    //(stockreceipt.FromBranchCode)==null ? stockreceipt.FromBranchCode : ext;
        //                    stockinformation.BranchId = _branchcode.BranchId;

        //                    if (shift.ShiftId == 0)
        //                    {
        //                        stockinformation.ShiftId = 0;
        //                    }
        //                    else
        //                    {
        //                        stockinformation.ShiftId = shift.ShiftId;
        //                    }
        //                    stockinformation.UserId = oilcnvsmaster.UserId;
        //                    stockinformation.TransactionDate = DateTime.Now;
        //                    stockinformation.VoucherNo = vchrmastr.VoucherMasterId.ToString();
        //                    stockinformation.VoucherTypeId = 52;
        //                    stockinformation.InvoiceNo = oilcnvsmaster.OilConversionVchNo;
        //                    stockinformation.ProductId = _product.ProductId;
        //                    stockinformation.ProductCode = oilconversions.ProductCode;
        //                    stockinformation.Rate = oilconversions.Rate;
        //                    if ((item) == Convert.ToInt32(oilcnvsmaster.BranchCode))
        //                    {
        //                        stockinformation.InwardQty = 0;
        //                        stockinformation.OutwardQty = oilconversions.Qty;
        //                    }
        //                    else
        //                    {
        //                        stockinformation.InwardQty = oilconversions.Qty;
        //                        stockinformation.OutwardQty = 0;
        //                    }
        //                    repo.TblStockInformation.Add(stockinformation);
        //                    repo.SaveChanges();
        //                }
        //                //var oilcnvsmmstrid = GetOilConversionslist(oilcnvsmaster.OilConversionVchNo).FirstOrDefault();
        //                #region StockIssueDetails
        //                oilconversions.OilConversionMasterId = oilcnvsmmstrid.OilConversionMasterId;
        //                oilconversions.OilConversionMasterId = oilconversions.OilConversionMasterId;
        //                oilconversions.OilConversionDetailsDate = DateTime.Now;
        //                oilconversions.ServerDateTime = DateTime.Now;
        //                oilconversions.ProductId = _product.ProductId;
        //                oilconversions.ProductCode = oilconversions.ProductCode;
        //                oilconversions.ProductName = oilconversions.ProductName;
        //                oilconversions.HsnNo = oilconversions.HsnNo;
        //                oilconversions.Rate = oilconversions.Rate;
        //                oilconversions.Qty = oilconversions.Qty;
        //                oilconversions.BatchNo = oilconversions.BatchNo;
        //                oilconversions.UnitId = Convert.ToDecimal(_product.UnitId);
        //                oilconversions.UnitName = oilconversions.UnitName;
        //                oilconversions.DamageQty = oilconversions.DamageQty;
        //                oilconversions.NewQty = oilconversions.NewQty;
        //                oilconversions.GrossAmount = oilconversions.GrossAmount;
        //                repo.TblOilConversionDetails.Add(oilconversions);
        //                repo.SaveChanges();
        //                #endregion
        //                {

        //                }
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //Searchcode
        public List<TblOilConversionMaster> GetOilConversionMasters(VoucherNoSearchCriteria searchCriteria, string branchCode)
        {
            try
            {

                using (Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>())
                {
                    List<TblOilConversionMaster> _oilconvsnMasterList = null;

                    if (searchCriteria.Role == 1)
                    {
                        _oilconvsnMasterList = repo.TblOilConversionMaster.AsEnumerable()
                              .Where(cp =>
                                         DateTime.Parse(cp.OilConversionDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.OilConversionDate).Value.ToShortDateString())
                                       && DateTime.Parse(cp.OilConversionDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.OilConversionDate).Value.ToShortDateString())
                                 )
                               .ToList();
                    }
                    else
                    {
                        _oilconvsnMasterList = repo.TblOilConversionMaster.AsEnumerable()
                                                      .Where(cp =>
                                                                 DateTime.Parse(cp.OilConversionDate.Value.ToShortDateString()) >= DateTime.Parse((searchCriteria.FromDate ?? cp.OilConversionDate).Value.ToShortDateString())
                                                               && DateTime.Parse(cp.OilConversionDate.Value.ToShortDateString()) <= DateTime.Parse((searchCriteria.ToDate ?? cp.OilConversionDate).Value.ToShortDateString())
                                                         && cp.BranchCode == branchCode)
                                                       .ToList();
                    }
                    if (!string.IsNullOrEmpty(searchCriteria.OilConversionVchNo))
                        _oilconvsnMasterList = GetOilconversionList().Where(x => x.OilConversionVchNo == searchCriteria.OilConversionVchNo).ToList();


                    return _oilconvsnMasterList.OrderByDescending(x => x.OilConversionDate).ToList();
                    ;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //to get the oilcnvsn Master data while page load
        public List<TblOilConversionMaster> GetInvoiceList(int? role, string branchCode)
        {
            try
            {

                using (Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>())
                {
                    List<TblOilConversionMaster> _oilcnvsnMasterList = null;
                    if (role == 1)
                    {
                        _oilcnvsnMasterList = repo.TblOilConversionMaster.AsEnumerable()
                                  .Where(inv =>
                                           inv.OilConversionDate >= Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd"))
                                     )
                                   .ToList();
                    }
                    else
                    {
                        _oilcnvsnMasterList = repo.TblOilConversionMaster.AsEnumerable()
                                                         .Where(inv =>
                                                                  inv.BranchCode == branchCode
                                                                  && inv.OilConversionDate >= DateTime.Parse(DateTime.Now.Date.ToString("yyyy-MM-dd"))
                                                            //Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"))
                                                            )
                                                          .ToList();
                    }

                    return _oilcnvsnMasterList.OrderByDescending(x => x.OilConversionDate).ToList();
                }
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
                using (Repository<TblOilConversionDetails> repo = new Repository<TblOilConversionDetails>())
                {
                    return repo.TblOilConversionDetails.Where(x => x.OilConversionMasterId == Convert.ToDecimal(vocherno)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

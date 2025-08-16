using CoreERP.DataAccess;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Dispatch")]
    public class DispatchController : Controller
    {
        private readonly IRepository<TblDispatch> _dispatchRepository;
        public DispatchController(IRepository<TblDispatch> DispatchRepository)
        {
            _dispatchRepository = DispatchRepository;
        }

        [HttpPost("RegisterDispatch")]
        public IActionResult RegisterDispatch([FromBody] TblDispatch dispatch)
        {
            if (dispatch == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(dispatch)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _dispatchRepository.Add(dispatch);
                if (_dispatchRepository.SaveChanges() > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dispatch };
                    // using var repo = new Repository<TblDispatch>();
                    using var repo = new ERPContext();
                    var SaleOrder = repo.TblSaleOrderMaster.FirstOrDefault(im => im.SaleOrderNo == dispatch.SaleOrder);
                    var Inspection = repo.TblInspectionCheckMaster.FirstOrDefault(im => im.saleOrderNumber == dispatch.SaleOrder);
                    var goodsreceipt = repo.TblGoodsReceiptMaster.FirstOrDefault(im => im.SaleorderNo == dispatch.SaleOrder);
                    var goodsissue = repo.TblGoodsIssueMaster.FirstOrDefault(im => im.SaleOrderNumber == dispatch.SaleOrder);
                    var Production = repo.TblProductionMaster.FirstOrDefault(im => im.SaleOrderNumber == dispatch.SaleOrder);
                    var purchase = repo.TblPurchaseOrder.FirstOrDefault(im => im.SaleOrderNo == dispatch.SaleOrder);
                    var Invoice = repo.TblInvoiceMaster.FirstOrDefault(im => im.SaleOrderNo == dispatch.SaleOrder);
                    var Invoice1 = repo.TblInvoiceMaster.Where(im => im.SaleOrderNo == dispatch.SaleOrder);
                    var InvoiceDetails = repo.TblInvoiceDetail.FirstOrDefault(im => im.Saleorder == dispatch.SaleOrder);
                    var SaleOrderDetails = repo.TblSaleOrderDetail.FirstOrDefault(im => im.SaleOrderNo == dispatch.SaleOrder && im.Billable == "Y");
                    var SaleOrderDetails1 = repo.TblSaleOrderDetail.Where(im => im.SaleOrderNo == dispatch.SaleOrder && im.Billable == "Y");
                    int sqty = 0;
                    int invqty = 0;
                    string message = null;
                    sqty = SaleOrderDetails1.Sum(x => x.QTY);
                    invqty = Convert.ToInt16(Invoice1.Sum(x => x.InvoiceQty));
                    if (sqty == invqty)
                        message = "Dispatched";
                    else
                        message = "Partially Dispatched";

                    SaleOrder.Status = message;
                    repo.TblSaleOrderMaster.Update(SaleOrder);
                    if (Inspection != null)
                    {
                        Inspection.Status = message;
                        repo.TblInspectionCheckMaster.Update(Inspection);
                    }

                    SaleOrderDetails.Status = message;
                    repo.TblSaleOrderDetail.Update(SaleOrderDetails);

                    if (goodsreceipt != null)
                    {
                        goodsreceipt.Status = message;
                        repo.TblGoodsReceiptMaster.Update(goodsreceipt);
                    }
                    if (goodsissue != null)
                    {
                        goodsissue.Status = message;
                        repo.TblGoodsIssueMaster.Update(goodsissue);
                    }
                    if (Production != null)
                    {
                        Production.Status = message;
                        repo.TblProductionMaster.Update(Production);
                    }
                    if (Invoice != null)
                    {
                        Invoice.Status = message;
                        repo.TblInvoiceMaster.Update(Invoice);
                    }
                    if (InvoiceDetails != null)
                    {
                        InvoiceDetails.Status = message;
                        repo.TblInvoiceDetail.Update(InvoiceDetails);
                    }
                    if (purchase != null)
                    {
                        purchase.Status = message;
                        repo.TblPurchaseOrder.Update(purchase);
                    }
                    repo.SaveChanges();

                }
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Recored Added Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDispatchList")]
        public IActionResult GetDispatchList()
        {
            try
            {
                var DispatchList = _dispatchRepository.GetAll(); //LanguageHelper.GetList();
                if (DispatchList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.DispatchList = DispatchList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateDispatch")]
        public IActionResult UpdateDispatch([FromBody] TblDispatch dispatch)
        {
            if (dispatch == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(dispatch)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _dispatchRepository.Update(dispatch);
                if (_dispatchRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dispatch };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteDispatch/{code}")]
        public IActionResult DeleteDispatch(int code)
        {
            try
            {
                APIResponse apiResponse;
                if (code == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });
                var record = _dispatchRepository.GetSingleOrDefault(x => x.ID.Equals(code));
                _dispatchRepository.Remove(record);
                if (_dispatchRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDispatchList/{Custcode}")]
        public async Task<IActionResult> GetDispatchList(string Custcode)
        {
            await using var repo = new Repository<TblDispatch>();

            var dispatchList = await (
                from td in repo.TblDispatch
                join so in repo.TblSaleOrderMaster
                    on td.SaleOrder equals so.SaleOrderNo into grGroup
                from gr in grGroup.DefaultIfEmpty()
                where gr == null || gr.CustomerCode == Custcode
                orderby td.ID descending
                select td
            ).ToListAsync();

            if (dispatchList.Any())
            {
                dynamic expdoObj = new ExpandoObject();
                expdoObj.DispatchList = dispatchList;

                return Ok(new APIResponse
                {
                    status = APIStatus.PASS.ToString(),
                    response = expdoObj
                });
            }

            return Ok(new APIResponse
            {
                status = APIStatus.FAIL.ToString(),
                response = "No Data Found."
            });
        }



    }
}
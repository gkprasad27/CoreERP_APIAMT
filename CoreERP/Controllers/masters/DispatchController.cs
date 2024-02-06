using CoreERP.DataAccess;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Dynamic;
using System.Linq;

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
                    var Invoice = repo.TblInvoiceMaster.FirstOrDefault(im => im.SaleOrderNo == dispatch.SaleOrder);
                    var InvoiceDetails = repo.TblInvoiceMaster.FirstOrDefault(im => im.SaleOrderNo == dispatch.SaleOrder);
                    var SaleOrderDetails = repo.TblSaleOrderDetail.FirstOrDefault(im => im.SaleOrderNo == dispatch.SaleOrder );
                    int sqty = 0;
                    int invqty = 0;
                    string message = null;
                    sqty = SaleOrder.TotalQty;
                    invqty =Convert.ToInt16(Invoice.InvoiceQty);
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
                        repo.TblInvoiceMaster.Update(InvoiceDetails);
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.PurhaseHelpers;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;
using CoreERP.BussinessLogic.SalesHelper;
using Newtonsoft.Json.Linq;
using CoreERP.Helpers.SharedModels;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Purchase/purchases")] 
    public class PurchaseController : ControllerBase
    {
        [HttpGet("GetPupms/{pumpNo}/{branchCode}")]
        public async Task<IActionResult> GetPupms(string pumpNo, string branchCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    string errorMessage = string.Empty;

                    var pumpsList = new InvoiceHelper().GetPumps(pumpNo, branchCode);

                    dynamic expando = new ExpandoObject();
                    expando.PumpsList = pumpsList.Select(x => new { ID = x.PumpId, TEXT = x.PumpNo });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GeneratePurchaseInvNo/{branchCode}")]
        public async Task<IActionResult> GeneratePurchaseInvNo(string branchCode)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;

                if (string.IsNullOrEmpty(branchCode))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });

                try
                {
                    var _purchaseInvoiceNo = new PurchasesHelper().GeneratePurchaseInvoiceNo(branchCode, out errorMessage);
                    if(string.IsNullOrEmpty(_purchaseInvoiceNo))
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });

                    dynamic expando = new ExpandoObject();
                    expando.PurchaseInvoiceNo = _purchaseInvoiceNo;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpGet("GeStateList")]
        public IActionResult GeStateList()
        {
            try
            {
                string errorMessage = string.Empty;


                dynamic expando = new ExpandoObject();
                expando.StateList = new InvoiceHelper().GetStateWiseGsts().Select(x => new { ID = x.StateCode, TEXT = x.StateName, IsDefualtSelected = (x.IsDefault == 1) });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GeSelectedState/{stateCode}")]
        public IActionResult GeStateList(string stateCode)
        {
            if (string.IsNullOrEmpty(stateCode))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            try
            {
                string errorMessage = string.Empty;

                dynamic expando = new ExpandoObject();
                expando.StateList = new InvoiceHelper().GetStateWiseGsts(stateCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCashPartyAccount/{ledgercode}")]
        public IActionResult GetCashPartyAccount(string ledgercode)
        {
            if (string.IsNullOrEmpty(ledgercode))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CashPartyAccount = new InvoiceHelper().GetAccountLedgers(ledgercode).FirstOrDefault();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetProductDeatilsSectionRcd/{branchCode}/{productCode}")]
        public async Task<IActionResult> GetProductDeatilsSectionRcd(string branchCode,string productCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.ProductDeatilsSectionRcd = new PurchasesHelper().GetProductDeatilsSectionRcd(branchCode, productCode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpPost("RegisterPurchase")]
        public async Task<IActionResult> RegisterPurchase([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                if (objData == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var _purchaseInvoiceHdr = objData["purchaseHdr"].ToObject<TblPurchaseInvoice>();
                    var _purchaseInvoiceDetail = objData["purchaseDetail"].ToObject<TblPurchaseInvoiceDetail[]>();

                    if (_purchaseInvoiceHdr == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No request records found to Save" });
                    }
                    if (_purchaseInvoiceDetail == null || _purchaseInvoiceDetail.Count() == 0)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "In request no product found in to save" });
                    }
                    if (string.IsNullOrEmpty(_purchaseInvoiceHdr.PurchaseInvNo))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Purchase Invoice no canontbe null/empty." });
                    }

                    var result = new PurchasesHelper().AddPurchaseRecords(_purchaseInvoiceHdr, _purchaseInvoiceDetail.ToList());
                    if (result)
                    {
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = _purchaseInvoiceHdr });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("GetInvoiceList/{branchCode}")]
        public async Task<IActionResult> GetInvoiceList(string branchCode,[FromBody]SearchCriteria searchCriteria)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null || string.IsNullOrEmpty(branchCode))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var invoiceMasterList = new PurchasesHelper().GetPurchaseInvoices(branchCode,searchCriteria);
                    if (invoiceMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.InvoiceList = invoiceMasterList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Purchase record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetInvoiceDeatilList/{invoiceNo}")]
        public async Task<IActionResult> GetInvoiceDeatilList(string invoiceNo)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(invoiceNo))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var invoiceMasterList = new PurchasesHelper().GetPurchaseInvoiceDetails(invoiceNo);
                    if (invoiceMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.InvoiceDetailList = invoiceMasterList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Purchase details record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
    }
}


/*
 
 api/Purchase/purchases/GeStateList
 api/Purchase/purchases/GeSelectedState/{stateCode}   -response samelike billing screen
 api/Purchase/purchases/GetCashPartyAccount/{ledgercode}     bind gsstno of purchse (tin property of response)
 api/Purchase/purchases/GetProductDeatilsSectionRcd/{branchCode}/{productCode}   whenproduct code is selected

*/



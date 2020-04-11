﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.PurhaseHelpers;
using CoreERP.Helpers.SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.purchase
{
    [Route("api/purchase/PurchaseReturn")]
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpGet("GeneratePurchaseReturnInvNo/{branchCode}")]
        public async Task<IActionResult> GeneratePurchaseReturnInvNo(string branchCode)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;

                if (string.IsNullOrEmpty(branchCode))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });

                try
                {
                    var _purchaseInvoiceNo = new PurchaseReturnHelper().GeneratePurchaseReturnInvNo(branchCode, out errorMessage);
                    if (string.IsNullOrEmpty(_purchaseInvoiceNo))
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

        [HttpPost("GetPurchaseReturns/{branchCode}")]
        public async Task<IActionResult> GetPurchaseReturns(string branchCode, [FromBody]SearchCriteria searchCriteria)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null || string.IsNullOrEmpty(branchCode))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var invoiceMasterList = new PurchaseReturnHelper().GetPurchaseReturns(branchCode, searchCriteria);
                    if (invoiceMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.InvoiceList = invoiceMasterList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Purchase return record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetInvoiceDeatilList/{purchaseReturnId}")]
        public async Task<IActionResult> GetInvoiceDeatilList(string purchaseReturnId)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(purchaseReturnId))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var invoiceMasterList = new PurchaseReturnHelper().GetPurchaseReturnsDetails(Convert.ToDecimal(purchaseReturnId));
                    if (invoiceMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.InvoiceDetailList = invoiceMasterList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No purchase return detail record found." });
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
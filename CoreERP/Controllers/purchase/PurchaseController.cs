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

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Purchase/purchases")]
    public class PurchaseController : ControllerBase
    {
        [HttpGet("GenerateInvoiceNumber/{branchCode}")]
        public async Task<IActionResult> GetVendorPaymentsList(string branchCode)
        {
            if (string.IsNullOrEmpty(branchCode))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });

            try
            {
                dynamic expando = new ExpandoObject();
                expando.PurchaseInvoiceNo = new PurchasesHelper().GeneratePurchaseInvoiceNo(branchCode);
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

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = message });
            }
        }

        [HttpGet("GetSateteList")]
        public async Task<IActionResult> GetSateteList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.SateteList = new PurchasesHelper().GetStateWiseGsts().Select(s=>new { ID=s.StateCode,TEXT=s.StateName ,IsDefualtSelected = s.IsDefault == 1});
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

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = message });
            }
        }

        [HttpGet("GetProductDeatilsSectionRcd/{branchCode}/{productCode}")]
        public async Task<IActionResult> GetProductDeatilsSectionRcd(string branchCode,string productCode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ProductDeatilsSectionRcd = new PurchasesHelper().GetProductDeatilsSectionRcd(branchCode,productCode);
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

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = message });
            }
        }
    }
}
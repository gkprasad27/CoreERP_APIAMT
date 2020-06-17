using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Helpers.SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreERP.Controllers.Sales
{
    [Route("api/transaction/SalesReturn")]
    [ApiController]
    public class SalesReturnController : BaseController
    {
        private readonly IConfiguration _configuration;
        public SalesReturnController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GenerateSalesReturnInvNo/{branchCode}")]
        public async Task<IActionResult> GetSateteList(string branchCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    string errorMessage = string.Empty;
                    string _salesReturnInvNo = new SalesReturnHelper().GenerateSalesReturnInvoiceNo(branchCode, out errorMessage);
                    if (string.IsNullOrEmpty(_salesReturnInvNo))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
                    }
                    dynamic expando = new ExpandoObject();
                    expando.SalesReturnInvNo = _salesReturnInvNo;
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
       
        [HttpPost("GetInvoiceReturnList/{branchCode}")]
        public IActionResult GetInvoiceList([FromBody]SearchCriteria searchCriteria, string branchCode)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var invoiceMasterList = new SalesReturnHelper().GetInvoiceMasterReturns(branchCode, searchCriteria);
                if (invoiceMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.InvoiceReturnList = invoiceMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetInvoiceReturnDetail/{invoiceMasterReturnId}")]
        public IActionResult GetInvoiceReturnDetail( string invoiceMasterReturnId)
        {

            if (string.IsNullOrEmpty(invoiceMasterReturnId))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var invoiceReturnDtlList = new SalesReturnHelper().GetInvoiceReturnDetail(Convert.ToDecimal(invoiceMasterReturnId));
                if (invoiceReturnDtlList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.InvoiceReturnDtlsList = invoiceReturnDtlList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("RegisterInvoiceReturn/{invoiceReturnNo}/{invoiceMasterID}")]
        public async Task<IActionResult> RegisterInvoiceReturn(string invoiceReturnNo,string invoiceMasterID)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(invoiceMasterID))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter is missing" });

                try
                {
                    if (string.IsNullOrEmpty(invoiceReturnNo))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Invoice return no can not be empty." });
                    }

                    if (string.IsNullOrEmpty(invoiceMasterID))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Invoice no can not be empty." });
                    }


                    string errorMessage = string.Empty;
                    var _invoiceMasterReturn = new SalesReturnHelper().RegisterInvoiceReturns(_configuration,invoiceReturnNo, Convert.ToDecimal(invoiceMasterID), out errorMessage);
                    if (_invoiceMasterReturn != null)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.InvoiceMasterReturn = _invoiceMasterReturn;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessage = "Sales restuen Registration Failed";
                    }
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
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
    }
}


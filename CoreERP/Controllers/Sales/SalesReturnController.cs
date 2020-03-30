using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.SalesHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.Sales
{
    [Route("api/transaction/SalesReturn")]
    [ApiController]
    public class SalesReturnController : ControllerBase
    {
        [HttpGet("GenerateSalesReturnInvNo/{branchCode}")]
        public async Task<IActionResult> GetSateteList(string branchCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.SalesReturnInvNo = new SalesReturnHelper().GenerateSalesReturnInvoiceNo(branchCode);
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

        [HttpGet("RegisterInvoiceReturn/{invoiceReturnNo}/{invoiceMasterID}")]
        public async Task<IActionResult> RegisterInvoiceReturn(string invoiceReturnNo,string invoiceMasterID)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(invoiceMasterID))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter is missing" });

                try
                {
                    string errorMessage = string.Empty;
                    var _invoiceMasterReturn = new SalesReturnHelper().RegisterInvoiceReturns(invoiceReturnNo, Convert.ToDecimal(invoiceMasterID), out errorMessage);
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

///
///api/transaction/SalesReturn/GenerateSalesReturnInvNo/{branchCode}
///RegisterInvoiceReturn/{invoiceReturnNo}/{invoiceMasterID}
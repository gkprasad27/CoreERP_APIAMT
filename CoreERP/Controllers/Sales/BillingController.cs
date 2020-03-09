using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using CoreERP.BussinessLogic.SalesHelper;
using System.Threading.Tasks;
using System.Linq;
using CoreERP.Models;
using Newtonsoft.Json.Linq;
using CoreERP.Helpers.SharedModels;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/Billing")]
    public class BillingController : ControllerBase
    {
       
        [HttpGet("GenerateBillNo/{branchCode}")]
        public async Task<IActionResult> GenerateBillNo(string branchCode)
        {
            try
            {
                string errorMessage = string.Empty;

                var billno = new InvoiceHelper().GenerateInvoiceNo(branchCode);
                if (billno != null)
                {
                    dynamic expando = new ExpandoObject();
                    expando.BillNo = billno;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GeStateList")]
        public async Task<IActionResult> GeStateList()
        {
            try
            {
                string errorMessage = string.Empty;


                dynamic expando = new ExpandoObject();
                expando.StateList = new InvoiceHelper().GetStateWiseGsts().Select(x => new { ID = x.StateCode, TEXT = x.StateName,IsDefualtSelected =(x.IsDefault ==1)  });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GeSelectedState/{stateCode}")]
        public async Task<IActionResult> GeStateList(string stateCode)
        {
            if(string.IsNullOrEmpty(stateCode))
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


        [HttpGet("GetBillingList/{branchCode}")]
        public async Task<IActionResult> GetBillingList(string branchCode)
        {
            try
            {
                var billingList = BillingHelpers.GetBillings(branchCode);
                if (billingList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.BillingList = billingList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="No billing records Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = new InvoiceHelper().GetBranches().Select(x=> new { ID=x.BranchCode ,TEXT=x.BranchName});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCashPartyAccountList")]
        public async Task<IActionResult> GetCashPartyAccountList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CashPartyAccountList = new InvoiceHelper().GetAccountLedgers(null).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCashPartyAccount/{ledgercode}")]
        public async Task<IActionResult> GetCashPartyAccount(string ledgercode)
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

        [HttpGet("GetAccountBalance/{ledgercode}/{branchCode}")]
        public async Task<IActionResult> GetAccountBalance(string ledgercode,string branchCode)
        {
            if (string.IsNullOrEmpty(ledgercode))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.AccountBalance = new InvoiceHelper().GetAccountBalance(ledgercode, branchCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetProductByProductCode/{productCode}")]
        public async Task<IActionResult> GetProductByProductCode(string productCode)
        {
            if (string.IsNullOrEmpty(productCode))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.Products = new InvoiceHelper().GetProducts(productCode,null).Select(p=>new { ID=p.ProductCode,TEXT=p.ProductCode,Name=p.ProductName});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetProductByProductName/{productName}")]
        public async Task<IActionResult> GetProductByProductName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.Products = new InvoiceHelper().GetProducts(null, productName).Select(p => new { ID = p.ProductCode, TEXT =p.ProductName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetmemberNames/{memberName}")]
        public async Task<IActionResult> GetmemberNames(string memberName)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.Members = new InvoiceHelper().GetMembers(null, memberName).Select(x=>new { ID=x.MemberCode,Text=x.MemberName,PhoneNo=x.Phone });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetBillingDetailsRcd/{productCode}/{branchCode}")]
        public async Task<IActionResult> GetBillingDetailsRcd(string productCode,string branchCode)
        {
            if (string.IsNullOrEmpty(productCode) || string.IsNullOrEmpty(branchCode))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BillingDetailsSection = new InvoiceHelper().GetBillingDetailsSection(branchCode,productCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("GetInvoiceList")]
        public async Task<IActionResult> GetInvoiceList([FromBody]SearchCriteria searchCriteria)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var invoiceMasterList = new InvoiceHelper().GetInvoiceMasters(searchCriteria);
                if (invoiceMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.InvoiceList = invoiceMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetInvoiceDeatilList/{invoiceNo}")]
        public async Task<IActionResult> GetInvoiceDeatilList(string invoiceNo)
        {

            if (string.IsNullOrEmpty(invoiceNo))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var invoiceMasterList = new InvoiceHelper().GetInvoiceDetails(invoiceNo);
                if (invoiceMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.InvoiceDetailList = invoiceMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPost("RegisterInvoice")]
        public async Task<IActionResult> RegisterBilling([FromBody]JObject objData)
        {

            if (objData == null)
                return Ok(new APIResponse() { status=APIStatus.FAIL.ToString(),response="Request is empty" });
            try
            {
                var _invoiceHdr = objData["InvoiceHdr"].ToObject<TblInvoiceMaster>();
                var _invoiceDtl = objData["InvoiceDetail"].ToObject<TblInvoiceDetail[]>();
                
                var result = new InvoiceHelper().RegisterBill(_invoiceHdr, _invoiceDtl.ToList());
               
                 //   return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        
    }
}


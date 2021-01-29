using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using CoreERP.BussinessLogic.SalesHelper;
using System.Threading.Tasks;
using System.Linq;
using CoreERP.Models;
using Newtonsoft.Json.Linq;
using CoreERP.Helpers.SharedModels;
using Microsoft.Extensions.Configuration;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/Billing")]
    public class BillingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public BillingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        [HttpPost("GetInvoiceDetails/{branchCode}")]
        public IActionResult GetInvoiceDetails([FromBody]SearchCriteria searchCriteria,string branchCode)
        {
            try
            {
                var InvoiceDetails = new InvoiceHelper().GetInvoiceList(searchCriteria.Role, branchCode,searchCriteria.FromDate,searchCriteria.ToDate,searchCriteria.InvoiceNo);
                if (InvoiceDetails.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.InvoiceList = InvoiceDetails;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Invoice records not found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPupms/{pumpNo}/{branchCode}/{productCode?}")]
        public IActionResult GetPupms(string pumpNo, string branchCode,string productCode)
        {
            try
            {
                string errorMessage = string.Empty;

                var pumpsList = new InvoiceHelper().GetPumps(pumpNo, branchCode, productCode);

                dynamic expando = new ExpandoObject();
                expando.PumpsList = pumpsList.OrderBy(x=>x.PumpNo).Select(x => new { ID = x.PumpId, TEXT = x.PumpNo });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPumps/{branchCode}/{productCode?}")]
        public IActionResult GetPumps(string branchCode, string productCode)
        {
            try
            {
                string errorMessage = string.Empty;

                var pumpsList = new InvoiceHelper().GetPumpsDropDown(branchCode, productCode);

                dynamic expando = new ExpandoObject();
                expando.PumpsList = pumpsList.OrderBy(x => x.PumpNo).Select(x => new { ID = x.PumpId, TEXT = x.PumpNo });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GenerateBillNo/{branchCode}")]
        public IActionResult GenerateBillNo(string branchCode)
        {
            try
            {
                string errorMessage = string.Empty;

                var billno = new InvoiceHelper().GenerateInvoiceNo(branchCode, out errorMessage);
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

        [HttpGet("GetBillingList/{branchCode}")]
        public IActionResult GetBillingList(string branchCode)
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

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No billing records Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBranchesList")]
        public IActionResult GetBranchesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = new InvoiceHelper().GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCashPartyAccountList/{ledgerCode?}")]
        public IActionResult GetCashPartyAccountList(string ledgerCode = null)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CashPartyAccountList = new InvoiceHelper().GetAccountLedgers(ledgerCode).OrderBy(al=> al.LedgerCode.Length).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("GetCustomerGstNumList/{phonenum?}")]
        public IActionResult GetCustomerGstNumList(string phonenum)
        {
            if (string.IsNullOrEmpty(phonenum))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CustomerGstNum = new InvoiceHelper().GetCustomerGstNum(phonenum);
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
                expando.CashPartyAccount = new InvoiceHelper().GetAccountLedgersByCode(ledgercode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountBalance/{ledgercode}")]
        public IActionResult GetAccountBalance(string ledgercode)
        {
            if (string.IsNullOrEmpty(ledgercode))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.AccountBalance = new InvoiceHelper().GetAccountBalance(ledgercode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("GetProductByProductCode")]
        public IActionResult GetProductByProductCode([FromBody]JObject objData)
        {
           // if (string.IsNullOrEmpty(productCode))
            if (objData == null)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                string productCode = objData["productCode"].ToString();
                dynamic expando = new ExpandoObject();
                expando.Products = new InvoiceHelper().GetProducts(productCode, null).OrderBy(x => x.ProductCode?.Length).Take(50).Select(p => new { ID = p.ProductCode, TEXT = p.ProductCode, Name = p.ProductName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("GetProductByProductName")]
        public IActionResult GetProductByProductName([FromBody]JObject objData)
        {
            if (objData == null)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                string productName = objData["productName"].ToString();
                dynamic expando = new ExpandoObject();
                expando.Products = new InvoiceHelper().GetProducts(null, productName).Select(p => new { ID = p.ProductCode, TEXT = p.ProductName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetmemberNames/{memberName}")]
        public IActionResult GetmemberNames(string memberName)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.Members = new InvoiceHelper().GetMembers(memberName).Select(x => new { ID = x.MemberCode, Text = x.MemberName, PhoneNo = x.Phone, GeneralNo = x.MemberCode });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetmemberNamesByCode/{memberCode}")]
        public IActionResult GetmemberNamesByCode(string memberCode)
        {
            if (string.IsNullOrEmpty(memberCode))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                var result = new InvoiceHelper().GetMembersByCode(memberCode);
                if (result != null)
                {
                    dynamic expando = new ExpandoObject();
                    expando.Members = new { result.MemberCode, result.MemberName, PhoneNo = result.Phone, GeneralNo = result.MemberCode };
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No member found for member code: " + memberCode });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetVechiels/{vechileNo}/{memberCode?}")]
        public IActionResult GetVechiels(string vechileNo, string memberCode = null)
        {
            if (string.IsNullOrEmpty(vechileNo))
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.Members = new InvoiceHelper().GetVehicles(vechileNo, memberCode).Take(100).Select(x => new { ID = x.VehicleId, Text = x.VehicleRegNo, x.MemberCode });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("GetBillingDetailsRcd")]
        public IActionResult GetBillingDetailsRcd([FromBody]JObject objData)
        {
            // string productCode, string branchCode
            if (objData == null)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                bool taxapplicableOn = false;
                string branchCode = objData["branchCode"].ToString();
                string productCode = objData["productCode"].ToString();

                dynamic expando = new ExpandoObject();
                expando.BillingDetailsSection = new InvoiceHelper().GetBillingDetailsSection(branchCode, productCode,_configuration);
                expando.TaxapplicableOn = taxapplicableOn;
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("GetInvoiceList/{branchCode}")]
        public IActionResult GetInvoiceList([FromBody]SearchCriteria searchCriteria,string branchCode)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var invoiceMasterList = new InvoiceHelper().GetInvoiceMasters(searchCriteria, branchCode);
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
        public IActionResult GetInvoiceDeatilList(string invoiceNo)
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
        public IActionResult RegisterBilling([FromBody]JObject objData)
        {

            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                string errorMessage = string.Empty;

                var _invoiceHdr = objData["InvoiceHdr"].ToObject<TblInvoiceMaster>();
                var _invoiceDtl = objData["InvoiceDetail"].ToObject<TblInvoiceDetail[]>();

                if(_invoiceHdr == null)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No request records found to Save" });
                }
               
                if (_invoiceDtl == null || _invoiceDtl.Count() == 0)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "In request no product found in to save" });
                }
               
                if (string.IsNullOrEmpty(_invoiceHdr.InvoiceNo))
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Invoice no canontbe null/empty." });
                }


                var result = new InvoiceHelper().RegisterBill(_configuration ,_invoiceHdr, _invoiceDtl.ToList(), out errorMessage);
                if (result)
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = _invoiceHdr });
                }

                if (string.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "Registration failed.";
                }
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage});
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


    }
}


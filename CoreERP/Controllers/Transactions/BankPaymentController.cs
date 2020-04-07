using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.transactionsHelpers;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;
using Newtonsoft.Json.Linq;
using CoreERP.Helpers.SharedModels;

namespace CoreERP.Controllers.Transactions
{
    [ApiController]
    [Route("api/transactions/BankPayment")]
    public class BankPaymentController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new BankPaymentHelper().GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetBankPaymentList")]
        public async Task<IActionResult> GetBankPaymentList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var bankPaymentList = BankPaymentHelper.GetBankPayments();
                    if (bankPaymentList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.BankPaymentList = bankPaymentList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetVoucherNo/{branchCode}")]
        public async Task<IActionResult> GetVoucherNo(string branchCode)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(branchCode))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new BankPaymentHelper().GetVoucherNo(branchCode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetAccountLedger")]
        public async Task<IActionResult> GetAccountLedgerList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.AccountLedgerList = new BankPaymentHelper().GetAccountLedgerList().Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetAccountLedgerList/{ledegerCode}")]
        public async Task<IActionResult> GetAccountLedgerList(string ledegerCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.AccountLedgerList = BankPaymentHelper.GetAccountLedgers(ledegerCode).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterBankPayment")]
        public async Task<IActionResult> RegisterBankPayment([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                if (objData == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var _bankpaymentHdr = objData["BankpaymentHdr"].ToObject<TblBankPaymentMaster>();
                    var _bankpaymentDtl = objData["BankpaymentDetail"].ToObject<TblBankPaymentDetails[]>();

                    var result = new BankPaymentHelper().RegisterBankPayment(_bankpaymentHdr, _bankpaymentDtl.ToList());
                    if (result)
                    {
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = _bankpaymentHdr });
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
        [HttpPost("GetBankpaymentList/{branchCode}")]
        public async Task<IActionResult> GetBankpaymentList([FromBody]VoucherNoSearchCriteria searchCriteria,string branchCode)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var bankPaymentMasterList = new BankPaymentHelper().GetBankPaymentMasters(searchCriteria,branchCode);
                    if (bankPaymentMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.BankPaymentList = bankPaymentMasterList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No BankPayment record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("GetBankPaymentMasterList/{branchCode}")]
        public IActionResult GetBankPaymentMasterList([FromBody]VoucherNoSearchCriteria searchCriteria, string branchCode)
        {
            try
            {
                var bankPaymentMasterList = new BankPaymentHelper().GetBankPaymentMasterList(searchCriteria.Role, branchCode);
                if (bankPaymentMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.bankPaymentMasterList = bankPaymentMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "BankPayment Records not found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBankPaymentDetailsList/{id}")]
        public async Task<IActionResult> GetBankPaymentDetailsList(decimal id)
        {
            var result = await Task.Run(() =>
            {
                if (id == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var bankPaymentDetailsList = new BankPaymentHelper().GetBankPaymentDetails(id);
                    if (bankPaymentDetailsList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.BankPaymentDetails = bankPaymentDetailsList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
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
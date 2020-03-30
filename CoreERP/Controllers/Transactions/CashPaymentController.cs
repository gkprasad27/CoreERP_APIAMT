using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.transactionsHelpers;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;
using CoreERP.Helpers.SharedModels;
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.Transactions
{
    [ApiController]
    [Route("api/transactions/CashPayment")]
    public class CashPaymentController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new CashPaymentHelper().GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
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
                    expando.BranchesList = new CashPaymentHelper().GetVoucherNo(branchCode);
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
                    expando.AccountLedgerList = CashPaymentHelper.GetAccountLedgers(ledegerCode).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
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
                    expando.AccountLedgerList = new CashPaymentHelper().GetAccountLedgerList().Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("GetCashpaymentList/{branchCode}")]
        public async Task<IActionResult> GetCashpaymentList([FromBody]VoucherNoSearchCriteria searchCriteria)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var cashPaymentMasterList = new CashPaymentHelper().GetCashPaymentMasters(searchCriteria);
                    if (cashPaymentMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.CashPaymentList = cashPaymentMasterList;
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

        [HttpGet("GetCashPaymentDetailsList/{id}")]
        public async Task<IActionResult> GetCashPaymentDetailsList(decimal id)
        {
            var result = await Task.Run(() =>
            {
                if (id == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var cashpaymentDetailsList = new CashPaymentHelper().GetCashpaymentDetails(id);
                    if (cashpaymentDetailsList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.CashpaymentDetails = cashpaymentDetailsList;
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

        [HttpPost("RegisterCashPayment")]
        public async Task<IActionResult> RegisterCashPayment([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                if (objData == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var _cashpaymentHdr = objData["CashpaymentHdr"].ToObject<TblCashPaymentMaster>();
                    var _cashpaymentDtl = objData["CashpaymentDetail"].ToObject<TblCashPaymentDetails[]>();

                    var result = new CashPaymentHelper().RegisterCashPayment(_cashpaymentHdr, _cashpaymentDtl.ToList());
                    if (result)
                    {
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = _cashpaymentHdr });
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
    }
}
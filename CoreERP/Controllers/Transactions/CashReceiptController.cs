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
    [Route("api/transactions/CashReceipt")]
    public class CashReceiptController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new CashReceiptHelper().GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetCashReceiptList")]
        public async Task<IActionResult> GetCashReceiptList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var cashReceiptList = CashReceiptHelper.GetCashReceipts();
                    if (cashReceiptList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.CashReceiptList = cashReceiptList;
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
                    expando.BranchesList = new CashReceiptHelper().GetVoucherNo(branchCode);
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
                    expando.AccountLedgerList = CashReceiptHelper.GetAccountLedgers(ledegerCode).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
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
                    expando.AccountLedgerList = new CashReceiptHelper().GetAccountLedgerList().Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterCashReceipt")]
        public async Task<IActionResult> RegisterCashReceipt([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                if (objData == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var _cashreceiptHdr = objData["CashreceiptHdr"].ToObject<TblCashReceiptMaster>();
                    var _cashreceiptDtl = objData["CashreceiptDetail"].ToObject<TblCashReceiptDetails[]>();

                    var result = new CashReceiptHelper().RegisterCashReceipt(_cashreceiptHdr, _cashreceiptDtl.ToList());
                    if (result)
                    {
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = _cashreceiptHdr });
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

        [HttpPost("GetCashreceiptList/{branchCode}")]
        public async Task<IActionResult> GetCashreceiptList([FromBody]VoucherNoSearchCriteria searchCriteria)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var cashReceiptMasterList = new CashReceiptHelper().GetCashReceiptMasters(searchCriteria);
                    if (cashReceiptMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.CashReceiptList = cashReceiptMasterList;
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

        [HttpGet("GetCashReceiptDetailsList/{id}")]
        public async Task<IActionResult> GetCashReceiptDetailsList(decimal id)
        {
            var result = await Task.Run(() =>
            {
                if (id == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var cashReceiptDetailsList = new CashReceiptHelper().GetCashReceiptDetails(id);
                    if (cashReceiptDetailsList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.CashReceiptDetails = cashReceiptDetailsList;
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
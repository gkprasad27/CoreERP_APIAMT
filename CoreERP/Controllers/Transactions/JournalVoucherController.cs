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
    [Route("api/transactions/JournalVoucher")]
    public class JournalVoucherController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new JournalVoucherHelper().GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
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
                    expando.AccountLedgerList = new JournalVoucherHelper().GetAccountLedgerList().Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
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
                    string errorMessage = string.Empty;
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new JournalVoucherHelper().GetVoucherNo(branchCode, out errorMessage);
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
                    expando.AccountLedgerList = new JournalVoucherHelper().GetAccountLedgers(ledegerCode).OrderBy(acl => acl.LedgerCode.Length).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetAccountLedgerListByName/{ledegerName}")]
        public async Task<IActionResult> GetAccountLedgerListByName(string ledegerName)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.AccountLedgerList = JournalVoucherHelper.GetAccountLedgerByName(ledegerName).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("GetJournalvoucherList/{branchCode}")]
        public async Task<IActionResult> GetJournalvoucherList( [FromBody]VoucherNoSearchCriteria searchCriteria,string branchCode)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var journalVoucherMasterList = new JournalVoucherHelper().GetJournalVoucherMasters(searchCriteria,branchCode);
                    if (journalVoucherMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.JournalVoucherList = journalVoucherMasterList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Journal Voucher record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterJournalVoucher")]
        public async Task<IActionResult> RegisterJournalVoucher([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                if (objData == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var _journalVoucherHdr = objData["JournalVoucherHdr"].ToObject<TblJournalVoucherMaster>();
                    var _journalVoucherDtl = objData["JournalVoucherDetail"].ToObject<TblJournalVoucherDetails[]>();

                    var result = new JournalVoucherHelper().RegisterJournalVoucher(_journalVoucherHdr, _journalVoucherDtl.ToList());
                    if (result)
                    {
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = _journalVoucherHdr });
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

        [HttpGet("GetJournalVoucherDetailsList/{id}")]
        public async Task<IActionResult> GetJournalVoucherDetailsList(decimal id)
        {
            var result = await Task.Run(() =>
            {
                if (id == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var journalVoucherDetailsList = new JournalVoucherHelper().GetJournalVoucherDetails(id);
                    if (journalVoucherDetailsList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.JournalVoucherDetails = journalVoucherDetailsList;
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
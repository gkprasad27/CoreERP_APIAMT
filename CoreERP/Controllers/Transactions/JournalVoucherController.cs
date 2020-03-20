﻿using System;
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
        }

        [HttpGet("GetAccountLedger")]
        public async Task<IActionResult> GetAccountLedgerList()
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
        }

        [HttpGet("GetVoucherNo/{branchCode}")]
        public async Task<IActionResult> GetVoucherNo(string branchCode)
        {
            if (string.IsNullOrEmpty(branchCode))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = new JournalVoucherHelper().GetVoucherNo(branchCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountLedgerList/{ledegerCode}")]
        public async Task<IActionResult> GetAccountLedgerList(string ledegerCode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.AccountLedgerList = JournalVoucherHelper.GetAccountLedgers(ledegerCode).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
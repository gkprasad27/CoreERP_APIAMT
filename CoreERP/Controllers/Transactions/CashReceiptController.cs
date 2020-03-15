﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.transactionsHelpers;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;


namespace CoreERP.Controllers.Transactions
{
    [ApiController]
    [Route("api/transactions/CashReceipt")]
    public class CashReceiptController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            //try
            //{
            //    dynamic expando = new ExpandoObject();
            //    expando.BranchesList = new CashReceiptHelper().GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
            //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            //}
            //catch (Exception ex)
            //{
            //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            //}
            return null;
        }

        [HttpGet("GetCashReceiptList")]
        public async Task<IActionResult> GetCashReceiptList()
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
        }

        [HttpGet("GetVoucherNo/{branchCode}")]
        public async Task<IActionResult> GetVoucherNo(string branchCode)
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
        }

        [HttpGet("GetAccountLedgerList/{ledegerCode}")]
        public async Task<IActionResult> GetAccountLedgerList(string ledegerCode)
        {
            //try
            //{
            //    dynamic expando = new ExpandoObject();
            //    expando.AccountLedgerList = CashReceiptHelper.GetAccountLedgers(ledegerCode).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
            //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            //}
            //catch (Exception ex)
            //{
            //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            //}
            return null;
        }
    }
}
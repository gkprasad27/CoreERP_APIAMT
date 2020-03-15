﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.transactionsHelpers;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;
using CoreERP.Helpers.SharedModels;

namespace CoreERP.Controllers.Transactions
{
    [ApiController]
    [Route("api/transactions/CashPayment")]
    public class CashPaymentController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            //try
            //{
            //    dynamic expando = new ExpandoObject();
            //    expando.BranchesList = new CashPaymentHelper().GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
            //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            //}
            //catch (Exception ex)
            //{
            //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            //}
            return null;
        }


        [HttpGet("GetVoucherNo/{branchCode}")]
        public async Task<IActionResult> GetVoucherNo(string branchCode)
        {
            if(string.IsNullOrEmpty(branchCode))
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
        }

        [HttpGet("GetAccountLedgerList/{ledegerCode}")]
        public async Task<IActionResult> GetAccountLedgerList(string ledegerCode)
        {
            //try
            //{
            //    dynamic expando = new ExpandoObject();
            //    expando.AccountLedgerList = CashPaymentHelper.GetAccountLedgers(ledegerCode).Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
            //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            //}
            //catch (Exception ex)
            //{
            //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            //}
            return null;
        }

        [HttpPost("RegisterCashPayment")]
        public async Task<IActionResult> RegisterCashPayment([FromBody]TblCashPaymentMaster cashPayment)
        {

            if (cashPayment == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(cashPayment)} cannot be null" });
            try
            {
                TblCashPaymentMaster result = CashPaymentHelper.RegisterCashPayment(cashPayment);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
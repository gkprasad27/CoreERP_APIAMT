using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GeneralLedger
{
    [Route("api/Transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        #region VoucherNumber & TransactionType

        [HttpGet("GetVoucherNumber/{voucherType}")]
        public IActionResult GetVoucherNumber(string voucherType)
        {
            try
            {
                dynamic expdoObj = new ExpandoObject();
                expdoObj.VoucherNumber = new TransactionsHelper().GetVoucherNumber(voucherType);
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTransactionTypes")]
        public IActionResult GetTransactionTypes()
        {
            try
            {
                var transactionType = new TransactionsHelper().GetTransactionType("TRANSACTIONTYPE");
                if (transactionType.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.TransactionType = transactionType.Select(v => new { id = v, text = v });
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        #endregion

        #region  Cash Bank 

        [HttpPost("GetCashBankMaster")]
        public IActionResult GetCashBankMaster([FromBody] SearchCriteria searchCriteria)
        {
            try
            {
                var cashBankMasters = new TransactionsHelper().GetCashBankMasters(searchCriteria);
                if (cashBankMasters.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CashBankMasters = cashBankMasters;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for cash bank." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCashBankDetail/{voucherNumber}")]
        public IActionResult GetCashBankDetail(string voucherNumber)
        {
            try
            {
                TransactionsHelper _Transactions = new TransactionsHelper();
                TblCashBankMaster _CashBankMasters = _Transactions.GetCashBankMastersById(voucherNumber);
                if (_CashBankMasters != null)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CashBankMasters = _CashBankMasters;
                    expdoObj.CashBankDetail = new TransactionsHelper().GetCashBankDetails(voucherNumber); ;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("AddCashBank")]
        public IActionResult AddCashBank([FromBody] JObject obj)
        {
            try
            {
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                TblCashBankMaster cashBankMaster = obj["cashbankHdr"].ToObject<TblCashBankMaster>();
                List<TblCashBankDetails> cashBankDetails = obj["cashbankDtl"].ToObject<List<TblCashBankDetails>>();

                if (new TransactionsHelper().AddCashBank(cashBankMaster, cashBankDetails))
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CashBankMaster = cashBankMaster;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpGet("ReturnCashBank/{voucherNumber}")]
        public IActionResult ReturnCashBank(string voucherNumber)
        {
            try
            {
                bool result = new TransactionsHelper().ReturnCashBank(voucherNumber);
                if (result)
                {
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = "Return Successfully..." });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "error while returning.." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        #endregion


        #region General VOucher

        [HttpGet("GetGJTransTypes")]
        public IActionResult GetGJTransTypes()
        {
            try
            {
                var transactionType = new TransactionsHelper().GetTransactionType("GJTRANSTYPE");
                if (transactionType.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.TransactionType = transactionType.Select(v => new { id = v, text = v });
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        #endregion
    }
}
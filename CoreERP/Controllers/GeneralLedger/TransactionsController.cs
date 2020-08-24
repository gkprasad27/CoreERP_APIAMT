using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.GeneralLedger
{
    [Route("api/Transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        #region  Cash Bank 
        [HttpGet("GetVoucherClassList")]
        public IActionResult GetVoucherClassList()
        {
            try
            {
                var voucherCLasses =new TransactionsHelper().GetTblVoucherclasses();
                if (voucherCLasses.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.VoucherCLassList = voucherCLasses.Select(v=> new { id=v.VoucherKey ,text=v.Description});
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
        [HttpGet("GetTransactionTypes")]
        public IActionResult GetTransactionTypes()
        {
            try
            {
                var transactionType = new TransactionsHelper().GetTransactionType();
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

        [HttpGet("GetGlaccounts")]
        public IActionResult GetGlaccounts()
        {
            try
            {
                var glAccounts = new TransactionsHelper().GetGlaccounts();
                if (glAccounts.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.TransactionType = glAccounts.Select(gl => new { id = gl, text = gl });
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

        [HttpGet("GetVoucherTypes")]
        public IActionResult GetVoucherTypes()
        {
            try
            {
                var voucherTypes = new TransactionsHelper().GetVoucherTypes();
                if (voucherTypes.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.TransactionType = voucherTypes.Select(vt => new { id = vt.VoucherTypeId, text = vt.VoucherTypeName });
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

        [HttpGet("GetNatureOfTransaction")]
        public IActionResult GetNatureOfTransaction()
        {
            try
            {
                var natrureOfTrans = new TransactionsHelper().GetNatureOfTransaction();
                if (natrureOfTrans.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.TransactionType = natrureOfTrans.Select(nt => new { id = nt, text = nt });
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

        [HttpGet("GetAccountingIndicator")]
        public IActionResult GetAccountingIndicator()
        {
            try
            {
                var accIndicator = new TransactionsHelper().GetAccountingIndicator();
                if (accIndicator.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.TransactionType = accIndicator.Select(nt => new { id = nt, text = nt });
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

        [HttpPost("GetCashBankMaster")]
        public IActionResult GetCashBankMaster([FromBody] TblCashBankMaster tblCashBankMaster)
        {
            try
            {
                var cashBankMasters = new TransactionsHelper().GetCashBankMasters(tblCashBankMaster);
                if (cashBankMasters.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CashBankMasters = cashBankMasters;
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
       
        [HttpGet("GetCashBankDetail/{voucherNo}")]
        public IActionResult GetCashBankDetail(string voucherNo)
        {
            try
            {
                var cashBankDetial = new TransactionsHelper().GetCashBankDetails(voucherNo);
                if (cashBankDetial.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CashBankDetail = cashBankDetial;
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
        public IActionResult AddCashBank([FromBody]JObject obj)
        {
            try
            {
                if(obj==null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                TblCashBankMaster cashBankMaster = obj["cashbankHdr"].ToObject<TblCashBankMaster>();
                List<TblCashBankDetails> cashBankDetails= obj["cashbankDtl"].ToObject<List<TblCashBankDetails>>();
               
                
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
        #endregion
    }
}
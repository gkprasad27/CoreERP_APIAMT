using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Helpers.SharedModels;
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
                TransactionsHelper _Transactions = new TransactionsHelper();
                TblCashBankMaster _CashBankMasters = _Transactions.GetCashBankMastersById(Convert.ToInt32(voucherNo));
                if (_CashBankMasters !=null)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CashBankMasters = _CashBankMasters;
                    expdoObj.CashBankDetail = new TransactionsHelper().GetCashBankDetails(voucherNo); ;
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

        [HttpGet("GetFunctionalDepts")]
        public IActionResult GetFunctionalDepts()
        {
            try
            {
                var _functionalDepts = CommonHelper.GetFunctionalDepts();
                if (_functionalDepts.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.FunctionalDepts = _functionalDepts.Select(t => new { id = t.Code, text = t.Description });
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

        [HttpGet("GetProfitcenters")]
        public IActionResult GetProfitcenters()
        {
            try
            {
                var _Profitcenterss = CommonHelper.GetProfitcenters();
                if (_Profitcenterss.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.Profitcenters = _Profitcenterss.Select(t => new { id = t.Code, text = t.Description });
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
        [HttpGet("GetSegments")]
        public IActionResult GetSegments()
        {
            try
            {
                var _Segments = CommonHelper.GetSegments();
                if (_Segments.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.Segments = _Segments.Select(t => new { id = t.Id, text = t.Name });
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
        [HttpGet("GetCostcenters")]
        public IActionResult GetCostcenters()
        {
            try
            {
                var _Costcenters = CommonHelper.GetCostcenters();
                if (_Costcenters.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.Costcenters = _Costcenters.Select(t => new { id = t.Code, text = t.Name });
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
        [HttpGet("GetHsnsac")]
        public IActionResult GetHsnsac()
        {
            try
            {
                var _Hsnsac = CommonHelper.GetHsnsac();
                if (_Hsnsac.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.Hsnsac = _Hsnsac.Select(t => new { id = t.Code, text = t.Description });
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
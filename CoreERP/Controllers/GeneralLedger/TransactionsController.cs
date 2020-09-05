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
                if (!transactionType.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.TransactionType = transactionType.Select(v => new { id = v, text = v });
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

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
                if (!cashBankMasters.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found for cash bank."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.CashBankMasters = cashBankMasters;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

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
                var transactions = new TransactionsHelper();
                var cashBankMasters = transactions.GetCashBankMastersById(voucherNumber);
                if (cashBankMasters == null)
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.CashBankMasters = cashBankMasters;
                expdoObj.CashBankDetail = new TransactionsHelper().GetCashBankDetails(voucherNumber);
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

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

                var cashBankMaster = obj["cashbankHdr"].ToObject<TblCashBankMaster>();
                var cashBankDetails = obj["cashbankDtl"].ToObject<List<TblCashBankDetails>>();

                if (!new TransactionsHelper().AddCashBank(cashBankMaster, cashBankDetails))
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.CashBankMaster = cashBankMaster;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

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
                var result = new TransactionsHelper().ReturnCashBank(voucherNumber);
                if (result)
                    return Ok(new APIResponse {status = APIStatus.PASS.ToString(), response = "Return Successfully..."});

                return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "error while returning cash bank.."});

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        #endregion


        #region General VOucher

        [HttpGet("GetGJTransTypes")]
        public IActionResult GetGjTransTypes()
        {
            try
            {
                var transactionType = new TransactionsHelper().GetTransactionType("GJTRANSTYPE");
                if (!transactionType.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.TransactionType = transactionType.Select(v => new { id = v, text = v });
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
       
        [HttpPost("GetJVMaster")]
        public IActionResult GetJvMaster([FromBody] SearchCriteria searchCriteria)
        {
            try
            {
                var jvMasters = new TransactionsHelper().GetJvMasters(searchCriteria);
                if (!jvMasters.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found for cash bank."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.jvMasters = jvMasters;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetJVDetail/{voucherNumber}")]
        public IActionResult GetJvDetail(string voucherNumber)
        {
            try
            {
                var transactions = new TransactionsHelper();
                var jvMasters = transactions.GetJvMastersById(voucherNumber);
                if (jvMasters == null)
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Foundfor journalvoucher."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.jvMasters = jvMasters;
                expdoObj.JvDetail = new TransactionsHelper().GetJvDetails(voucherNumber);
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("AddJournal")]
        public IActionResult AddJournal([FromBody] JObject obj)
        {
            try
            {
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                var jvMaster = obj["journalHdr"].ToObject<TblJvmaster>();
                var jvDetails = obj["journalDtl"].ToObject<List<TblJvdetails>>();

                if (!new TransactionsHelper().AddJournal(jvMaster, jvDetails))
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.jvMaster = jvMaster;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("returnJournalvoucher/{voucherNumber}")]
        public IActionResult ReturnJournalVoucher(string voucherNumber)
        {
            try
            {
                TransactionsHelper transactions = new TransactionsHelper();
                if (transactions.RetuenJournalVoucher(voucherNumber))
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = $"journal voucher - {voucherNumber} return successfully." });

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "error occure while returning journal voucher." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        #endregion

        #region Invoice & Memo

        [HttpPost("GetIMMaster")]
        public IActionResult GetImMaster([FromBody] SearchCriteria searchCriteria)
        {
            try
            {
                var imMasters = new TransactionsHelper().GetImMasters(searchCriteria);
                if (!imMasters.Any())
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for cash bank." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.imMasters = imMasters;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetIMDetail/{voucherNumber}")]
        public IActionResult GetImDetail(string voucherNumber)
        {
            try
            {
                var transactions = new TransactionsHelper();
                var imMasters = transactions.GetImMastersById(voucherNumber);
                if (imMasters == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.imMasters = imMasters;
                expdoObj.ImDetail = new TransactionsHelper().GetImDetails(voucherNumber);
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("AddInvoiceMemo")]
        public IActionResult AddInvoiceMemo([FromBody] JObject obj)
        {
            try
            {
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                var imMaster = obj["imHdr"].ToObject<TblInvoiceMemoHeader>();
                var imDetails = obj["imDtl"].ToObject<List<TblInvoiceMemoDetails>>();

                if (!new TransactionsHelper().AddInvoiceMemos(imMaster, imDetails))
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.invoi = imMaster;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("ReturnInvoiceMemo/{voucherNumber}")]
        public IActionResult ReturnInvoiceMemo(string voucherNumber)
        {
            try
            {
                TransactionsHelper transactions = new TransactionsHelper();
                if (transactions.ReturnInvoiceMemo(voucherNumber))
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = $"Invoice memo no {voucherNumber} return successfully." });

                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "error while returning invoice memo." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        #endregion
    }
}
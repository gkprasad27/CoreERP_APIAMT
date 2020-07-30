using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/gl/TaxTransaction")]
    public class TaxTransactionController : ControllerBase
    {
        [HttpPost("RegisterTaxTransaction")]
        public IActionResult RegisterTaxTransaction([FromBody]TblTaxtransactions taxtransaction)
        {
            if (taxtransaction == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                if (TaxTransactionHelper.GetList(taxtransaction.Code).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Tax Code ={taxtransaction.Code} alredy exists." });

                TblTaxtransactions result = TaxTransactionHelper.Register(taxtransaction);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTaxTransactionList")]
        public IActionResult GetTaxTransaction()
        {
            try
            {
                var taxtransactionList = TaxTransactionHelper.GetList();
                if (taxtransactionList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.TaxtransactionList = taxtransactionList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }


        [HttpPut("UpdateTaxTransaction")]
        public IActionResult UpdateTaxTransaction([FromBody] TblTaxtransactions transaction)
        {
            if (transaction == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(transaction)} cannot be null" });

            try
            {
                TblTaxtransactions result = TaxTransactionHelper.Update(transaction);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteTaxTransaction/{code}")]
        public IActionResult DeleteTaxTransaction(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                TblTaxtransactions result = TaxTransactionHelper.Delete(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/TaxTransaction")]
    public class TaxTransactionController : ControllerBase
    {
        private readonly IRepository<TblTaxtransactions> _ttranRepository;
        public TaxTransactionController(IRepository<TblTaxtransactions> ttranRepository)
        {
            _ttranRepository = ttranRepository;
        }

        [HttpPost("RegisterTaxTransaction")]
        public IActionResult RegisterTaxTransaction([FromBody] TblTaxtransactions taxtransaction)
        {
            if (taxtransaction == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                //if (TaxTransactionHelper.GetList(taxtransaction.Code).Count > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Tax Code ={taxtransaction.Code} alredy exists." });

                APIResponse apiResponse;
                _ttranRepository.Add(taxtransaction);
                if (_ttranRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = taxtransaction });
                else
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
                var taxtransactionList = CommonHelper.GetTaxTransactions();
                if (taxtransactionList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.TaxtransactionList = taxtransactionList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
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
                APIResponse apiResponse;
                _ttranRepository.Update(transaction);
                if (_ttranRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = transaction });
                else
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
                APIResponse apiResponse;
                var record = _ttranRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _ttranRepository.Remove(record);
                if (_ttranRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = record });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
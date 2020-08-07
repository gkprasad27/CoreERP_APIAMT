using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Currency")]
    public class CurrencyController : Controller
    {
        private readonly IRepository<TblCurrency> _currencyRepository;
        public CurrencyController(IRepository<TblCurrency> currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        [HttpPost("RegisterCurrency")]
        public IActionResult RegisterCurrency([FromBody]TblCurrency currency)
        {
            if (currency == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (CurrencyHelper.GetList(currency.CurrencySymbol).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"currency Code {nameof(currency.CurrencySymbol)} is already exists ,Please Use Different Code " });
                APIResponse apiResponse;
                _currencyRepository.Add(currency);
                if (_currencyRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = currency };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCurrencyList")]
        public IActionResult GetCurrencyList()
        {
            try
            {
                var currencyList = _currencyRepository.GetAll();
                if (currencyList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.currencyList = currencyList;
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

        [HttpPut("UpdateCurrency")]
        public IActionResult UpdateCurrency([FromBody] TblCurrency currency)
        {
            if (currency == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(currency)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _currencyRepository.Update(currency);
                if (_currencyRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = currency };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCurrency/{code}")]
        public IActionResult DeleteCurrencyByID(string code)
        {
            try
            {
                APIResponse apiResponse;
                if (code == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

                var record = _currencyRepository.GetSingleOrDefault(x => x.CurrencySymbol.Equals(code));
                _currencyRepository.Remove(record);
                if (_currencyRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
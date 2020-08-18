using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/Ledger")]
    public class LedgerController : ControllerBase
    {
        private readonly IRepository<Ledger> _ledgerRepository;
        public LedgerController(IRepository<Ledger> ledgerRepository)
        {
            _ledgerRepository = ledgerRepository;
        }

        [HttpPost("RegisterLedger")]
        public IActionResult RegisterLedger([FromBody]Ledger ledger)
        {
            if (ledger == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (LedgerHelper.GetList(ledger.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Ledger Code {nameof(ledger.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _ledgerRepository.Add(ledger);
                if (_ledgerRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ledger };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLedgerList")]
        public IActionResult GetLedgerList()
        {
            try
            {
                var ledgerList = _ledgerRepository.GetAll();
                if (ledgerList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ledgerList = ledgerList;
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

        [HttpPut("UpdateLedger")]
        public IActionResult UpdateLedger([FromBody] Ledger ledger)
        {
            if (ledger == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(ledger)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _ledgerRepository.Update(ledger);
                if (_ledgerRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ledger };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletLedger/{code}")]
        public IActionResult DeletLedgerByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _ledgerRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _ledgerRepository.Remove(record);
                if (_ledgerRepository.SaveChanges() > 0)
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
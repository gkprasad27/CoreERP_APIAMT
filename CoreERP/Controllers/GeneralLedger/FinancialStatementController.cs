using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/FinancialStatement")]
    public class FinancialStatementController : ControllerBase
    {
        private readonly IRepository<TblFinanceialStatement> _vcRepository;
        public FinancialStatementController(IRepository<TblFinanceialStatement> vcRepository)
        {
            _vcRepository = vcRepository;
        }

        [HttpPost("RegisterFinancestatement")]
        public IActionResult RegisterFinancestatement([FromBody] TblFinanceialStatement vcclass)
        {
            if (vcclass == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _vcRepository.Add(vcclass);
                if (_vcRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = vcclass };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetFinancialStatement")]
        public IActionResult GetFinancialStatement()
        {
            try
            {
                var vcclassList = _vcRepository.GetAll();
                if (_vcRepository.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.FSList = vcclassList;
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

        [HttpPut("UpdateFinancialStatement")]
        public IActionResult UpdateFinancialStatement([FromBody] TblFinanceialStatement vcclass)
        {
            if (vcclass == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(vcclass)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _vcRepository.Update(vcclass);
                if (_vcRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = vcclass };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteFinancialStatement/{code}")]
        public IActionResult DeleteFinancialStatement(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _vcRepository.GetSingleOrDefault(x => x.ID.Equals(code));
                _vcRepository.Remove(record);
                if (_vcRepository.SaveChanges() > 0)
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
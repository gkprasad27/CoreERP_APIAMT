using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/IncomeType")]
    public class IncomeTypeController : ControllerBase
    {
        private readonly IRepository<TblIncomeTypes> _incomeRepository;
        public IncomeTypeController(IRepository<TblIncomeTypes> incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        [HttpPost("RegisterIncomeType")]
        public IActionResult RegisterIncomeType([FromBody]TblIncomeTypes incmtype)
        {
            if (incmtype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (IncometypesHelper.GetList(incmtype.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Incometype Code {nameof(incmtype.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _incomeRepository.Add(incmtype);
                if (_incomeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = incmtype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetIncomeTypeList")]
        public IActionResult GetIncomeTypeList()
        {
            try
            {
                var incmtypeList = _incomeRepository.GetAll();
                if (incmtypeList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.incmList = incmtypeList;
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

        [HttpPut("UpdateIncomeType")]
        public IActionResult UpdateIncomeType([FromBody] TblIncomeTypes incmtype)
        {
            if (incmtype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(incmtype)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _incomeRepository.Update(incmtype);
                if (_incomeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = incmtype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteIncomeType/{code}")]
        public IActionResult DeleteIncomeTypeByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _incomeRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _incomeRepository.Remove(record);
                if (_incomeRepository.SaveChanges() > 0)
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
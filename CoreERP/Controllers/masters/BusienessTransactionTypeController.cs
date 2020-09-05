using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/BusienessTransactionType")]
    public class BusienessTransactionTypeController : ControllerBase
    {
        private readonly IRepository<TblBusinessTransactionTypes> _businessTransactionTypesRepository;
        public BusienessTransactionTypeController(IRepository<TblBusinessTransactionTypes> businessTransactionTypesRepository)
        {
            _businessTransactionTypesRepository = businessTransactionTypesRepository;
        }
        [HttpPost("RegisterBusienessTransactionType")]
        public IActionResult RegisterBusienessTransactionType([FromBody]TblBusinessTransactionTypes bttype)
        {
            if (bttype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _businessTransactionTypesRepository.Add(bttype);
                if (_businessTransactionTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bttype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBusienessTransactionTypeList")]
        public IActionResult GetBusienessTransactionTypeList()
        {
            try
            {
                var bpttList = _businessTransactionTypesRepository.GetAll();
                if (bpttList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.bpttList = bpttList;
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

        [HttpPut("UpdateBusienessTransactionType")]
        public IActionResult UpdateBusienessTransactionType([FromBody] TblBusinessTransactionTypes bttype)
        {
            if (bttype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(bttype)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _businessTransactionTypesRepository.Update(bttype);
                if (_businessTransactionTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bttype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteBusienessTransactionType/{code}")]
        public IActionResult DeleteBusienessTransactionTypebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _businessTransactionTypesRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _businessTransactionTypesRepository.Remove(record);
                if (_businessTransactionTypesRepository.SaveChanges() > 0)
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
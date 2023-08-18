using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/PurchaseRequisitionNumberRange")]
    public class PurchaseRequisitionNumberRangeController : ControllerBase
    {

        private readonly IRepository<TblPurchaseNoRange> _prnoRangeRepository;
        public PurchaseRequisitionNumberRangeController(IRepository<TblPurchaseNoRange> prnoRangeRepository)
        {
            _prnoRangeRepository = prnoRangeRepository;
        }

        [HttpPost("RegisterPurchaseRequisitionNumberRange")]
        public IActionResult RegisterPurchaseRequisitionNumberRange([FromBody] TblPurchaseNoRange norange)
        {
            if (norange == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _prnoRangeRepository.Add(norange);
                if (_prnoRangeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = norange };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchaseRequisitionNumberRangeList")]
        public IActionResult GetPurchaseRequisitionNumberRangeList()
        {
            try
            {
                var prnoList = CommonHelper.GetPrnoRange();
                if (prnoList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.prnoList = prnoList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePurchaseRequisitionNumberRange")]
        public IActionResult UpdatePurchaseRequisitionNumberRange([FromBody] TblPurchaseNoRange norange)
        {
            if (norange == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(norange)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _prnoRangeRepository.Update(norange);
                if (_prnoRangeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = norange };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePurchaseRequisitionNumberRange/{code}")]
        public IActionResult DeletePurchaseRequisitionNumberRangebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _prnoRangeRepository.GetSingleOrDefault(x => x.code.Equals(code));
                _prnoRangeRepository.Remove(record);
                if (_prnoRangeRepository.SaveChanges() > 0)
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
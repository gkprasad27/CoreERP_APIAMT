using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/PurchaseOrderNumberRange")]
    public class PurchaseOrderNumberRangeController : ControllerBase
    {
        private readonly IRepository<TblPurchaseNoRange> _purchaseNoRangeRepository;
        public PurchaseOrderNumberRangeController(IRepository<TblPurchaseNoRange> purchaseNoRangeRepository)
        {
            _purchaseNoRangeRepository = purchaseNoRangeRepository;
        }

        [HttpPost("RegisterPurchaseOrderNumberRange")]
        public IActionResult RegisterPurchaseOrderNumberRange([FromBody]TblPurchaseNoRange norange)
        {
            if (norange == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _purchaseNoRangeRepository.Add(norange);
                if (_purchaseNoRangeRepository.SaveChanges() > 0)
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

        [HttpGet("GetPurchaseOrderNumberRangeList")]
        public IActionResult GetPurchaseOrderNumberRangeList()
        {
            try
            {
                var porangeList = _purchaseNoRangeRepository.GetAll();
                if (porangeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.porangeList = porangeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePurchaseOrderNumberRange")]
        public IActionResult UpdatePurchaseOrderNumberRange([FromBody] TblPurchaseNoRange norange)
        {
            if (norange == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(norange)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _purchaseNoRangeRepository.Update(norange);
                if (_purchaseNoRangeRepository.SaveChanges() > 0)
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

        [HttpDelete("DeletePurchaseOrderNumberRange/{code}")]
        public IActionResult DeletePurchaseOrderNumberRangebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _purchaseNoRangeRepository.GetSingleOrDefault(x => x.NumberRange.Equals(code));
                _purchaseNoRangeRepository.Remove(record);
                if (_purchaseNoRangeRepository.SaveChanges() > 0)
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
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Purchaseordertype")]
    public class PurchaseordertypeController : ControllerBase
    {
        private readonly IRepository<TblPurchaseOrderType> _purchaseTypeRepository;
        public PurchaseordertypeController(IRepository<TblPurchaseOrderType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        [HttpPost("RegisterPurchaseordertype")]
        public IActionResult RegisterPurchaseordertype([FromBody] TblPurchaseOrderType ptype)
        {
            if (ptype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _purchaseTypeRepository.Add(ptype);
                if (_purchaseTypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ptype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchaseordertypeList")]
        public IActionResult GetPurchaseordertypeList()
        {
            try
            {
                var porderList = _purchaseTypeRepository.GetAll();
                if (porderList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.porderList = porderList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePurchaseordertype")]
        public IActionResult UpdatePurchaseordertype([FromBody] TblPurchaseOrderType ptype)
        {
            if (ptype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(ptype)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _purchaseTypeRepository.Update(ptype);
                if (_purchaseTypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ptype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePurchaseordertype/{code}")]
        public IActionResult DeletePurchaseordertypebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _purchaseTypeRepository.GetSingleOrDefault(x => x.PurchaseOrderType.Equals(code));
                _purchaseTypeRepository.Remove(record);
                if (_purchaseTypeRepository.SaveChanges() > 0)
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
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Purchasingtype")]
    public class PurchasingtypeController : Controller
    {
        private readonly IRepository<TblPurchaseType> _purchasetypeRepository;
        public PurchasingtypeController(IRepository<TblPurchaseType> purchasetypeRepository)
        {
            _purchasetypeRepository = purchasetypeRepository;
        }

        [HttpPost("RegisterPurchaseType")]
        public IActionResult RegisterPurchaseType([FromBody] TblPurchaseType purchaseType)
        {
            if (purchaseType == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(purchaseType)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _purchasetypeRepository.Add(purchaseType);
                if (_purchasetypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = purchaseType };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Recored Added Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchaseTypeList")]
        public IActionResult GetPurchaseTypeList()
        {
            try
            {
                var purchaseTypeList = _purchasetypeRepository.GetAll(); 
                if (purchaseTypeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.purchaseTypeList = purchaseTypeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePurchaseType")]
        public IActionResult UpdatePurchaseType([FromBody] TblPurchaseType purchaseType)
        {
            if (purchaseType == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(purchaseType)} cannot be null" });

            try
            {   
                APIResponse apiResponse;
                _purchasetypeRepository.Update(purchaseType);
                if (_purchasetypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = purchaseType };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePurchaseType/{code}")]
        public IActionResult DeletePurchaseTypeByID(string code)
        {
            try
            {
                APIResponse apiResponse;
                if (code == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });
                var record = _purchasetypeRepository.GetSingleOrDefault( x => x.PurchaseType.Equals(code));
                _purchasetypeRepository.Remove(record);
                if(_purchasetypeRepository.SaveChanges() > 0)                
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
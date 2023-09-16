using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Purchasingperson")]
    public class PurchasingpersonController : ControllerBase
    {
        private readonly IRepository<TblPurchasePerson> _purchasingpersonRepository;
        public PurchasingpersonController(IRepository<TblPurchasePerson> purchasingpersonRepository)
        {
            _purchasingpersonRepository = purchasingpersonRepository;
        }

        [HttpPost("RegisterPurchasingperson")]
        public IActionResult RegisterPurchasingperson([FromBody]TblPurchasePerson pcperson)
        {
            if (pcperson == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _purchasingpersonRepository.Add(pcperson);
                if (_purchasingpersonRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pcperson };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Purchase Person already Exist, Please use another key " + " " + (pcperson.PurchasePerson) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchasingpersonList")]
        public IActionResult GetPurchasingpersonList()
        {
            try
            {
                var pcpList = CommonHelper.GetPurchasePerson();
                if (pcpList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.pcpList = pcpList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePurchasingperson")]
        public IActionResult UpdatePurchasingperson([FromBody] TblPurchasePerson pcperson)
        {
            if (pcperson == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(pcperson)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _purchasingpersonRepository.Update(pcperson);
                if (_purchasingpersonRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pcperson };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Purchase Person already Exist, Please use another key " + " " + (pcperson.PurchasePerson) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePurchasingperson/{code}")]
        public IActionResult DeletePurchasingpersonbyId(int code)
        {
            try
            {
                if (code ==0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _purchasingpersonRepository.GetSingleOrDefault(x => x.id.Equals(code));
                _purchasingpersonRepository.Remove(record);
                if (_purchasingpersonRepository.SaveChanges() > 0)
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
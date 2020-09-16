using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;


namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Purchasinggroups")]
    public class PurchasinggroupsController : ControllerBase
    {
        private readonly IRepository<TblPurchaseGroup> _purchaseGroupRepository;
        public PurchasinggroupsController(IRepository<TblPurchaseGroup> purchaseGroupRepository)
        {
            _purchaseGroupRepository = purchaseGroupRepository;
        }

        [HttpPost("RegisterPurchasinggroups")]
        public IActionResult RegisterPurchasinggroups([FromBody]TblPurchaseGroup pcgroup)
        {
            if (pcgroup == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _purchaseGroupRepository.Add(pcgroup);
                if (_purchaseGroupRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pcgroup };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchasinggroupsList")]
        public IActionResult GetPurchasinggroupsList()
        {
            try
            {
                var pcgroupList = _purchaseGroupRepository.GetAll();
                if (pcgroupList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.PCGroupsList = pcgroupList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePurchasinggroups")]
        public IActionResult UpdatePurchasinggroups([FromBody] TblPurchaseGroup pcgroup)
        {
            if (pcgroup == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(pcgroup)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _purchaseGroupRepository.Update(pcgroup);
                if (_purchaseGroupRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pcgroup };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePurchasinggroups/{code}")]
        public IActionResult DeletePurchasinggroupsbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _purchaseGroupRepository.GetSingleOrDefault(x => x.PruchaseGroup.Equals(code));
                _purchaseGroupRepository.Remove(record);
                if (_purchaseGroupRepository.SaveChanges() > 0)
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
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/CostCenter")]
    public class CostCenterMasterController : ControllerBase
    {
        private readonly IRepository<CostCenters> _ccRepository;
        public CostCenterMasterController(IRepository<CostCenters> ccRepository)
        {
            _ccRepository = ccRepository;
        }

        [HttpGet("GetCostCenterList")]
        public IActionResult GetCostCenterList()
        {
            try
            {
                var costcenterList = CommonHelper.GetCostcenters();
                if (costcenterList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costcenterList = costcenterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterCostCenter")]
        public IActionResult RegisterCostCenter([FromBody]CostCenters costCenter)
        {
            if (costCenter == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costCenter)} cannot be null" });
            try
            {
                //if (CostCenterHelper.IsCodeExists(costCenter.Code))
                //    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"Code ={costCenter.Code} Already Exists." });

                APIResponse apiResponse;
                _ccRepository.Add(costCenter);
                if (_ccRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costCenter };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateCostCenter")]
        public IActionResult UpdateCostCenter([FromBody] CostCenters costCenter)
        {
            if (costCenter == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costCenter)} cannot be null" });
            try
            {

                APIResponse apiResponse;
                _ccRepository.Update(costCenter);
                if (_ccRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costCenter };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCostCenter/{code}")]
        public IActionResult DeleteCostCenter(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });
            try
            {
                APIResponse apiResponse;
                var record = _ccRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _ccRepository.Remove(record);
                if (_ccRepository.SaveChanges() > 0)
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

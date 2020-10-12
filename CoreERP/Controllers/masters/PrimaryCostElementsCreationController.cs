using System;
using System.Collections.Generic;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/PrimaryCostElementsCreation")]
    public class PrimaryCostElementsCreationController : ControllerBase
    {
        private readonly IRepository<TblPrimaryCostElement> _primaryCostElementRepository;
        public PrimaryCostElementsCreationController(IRepository<TblPrimaryCostElement> primaryCostElementRepository)
        {
            _primaryCostElementRepository = primaryCostElementRepository;
        }

        [HttpPost("RegisterPrimaryCostElementsCreation")]
        public IActionResult RegisterPrimaryCostElementsCreation([FromBody]TblPrimaryCostElement pcost)
        {
            if (pcost == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _primaryCostElementRepository.Add(pcost);
                if (_primaryCostElementRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pcost };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPrimaryCostElementsCreationList")]
        public IActionResult GetPrimaryCostElementsCreationList()
        {
            try
            {
                var pcostList = CommonHelper.GetPrimarycostelement();
                if (pcostList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.pcostList = pcostList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePrimaryCostElementsCreation")]
        public IActionResult UpdatePrimaryCostElementsCreation([FromBody] TblPrimaryCostElement pcost)
        {
            if (pcost == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(pcost)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _primaryCostElementRepository.Update(pcost);
                if (_primaryCostElementRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pcost };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePrimaryCostElementsCreation/{code}")]
        public IActionResult DeletePrimaryCostElementsCreationbyId(int code)
        {
            try
            {
                if (code == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _primaryCostElementRepository.GetSingleOrDefault(x => x.Id.Equals(code));
                _primaryCostElementRepository.Remove(record);
                if (_primaryCostElementRepository.SaveChanges() > 0)
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
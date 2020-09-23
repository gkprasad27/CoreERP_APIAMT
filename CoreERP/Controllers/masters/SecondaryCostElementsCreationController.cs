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
    [Route("api/SecondaryCostElementsCreation")]
    public class SecondaryCostElementsCreationController : ControllerBase
    {
        private readonly IRepository<TblSecondaryCostElement> _secondaryCostElementRepository;
        public SecondaryCostElementsCreationController(IRepository<TblSecondaryCostElement> secondaryCostElementRepository)
        {
            _secondaryCostElementRepository = secondaryCostElementRepository;
        }

        [HttpPost("RegisterSecondaryCostElementsCreation")]
        public IActionResult RegisterSecondaryCostElementsCreation([FromBody]TblSecondaryCostElement secondarycost)
        {
            if (secondarycost == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _secondaryCostElementRepository.Add(secondarycost);
                if (_secondaryCostElementRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = secondarycost };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetSecondaryCostElementsCreationList")]
        public IActionResult GetSecondaryCostElementsCreationList()
        {
            try
            {
                var secondarycostList = CommonHelper.GetSecondarycostelement();
                if (secondarycostList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.secondarycostList = secondarycostList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateSecondaryCostElementsCreation")]
        public IActionResult UpdateSecondaryCostElementsCreation([FromBody] TblSecondaryCostElement secondarycost)
        {
            if (secondarycost == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(secondarycost)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _secondaryCostElementRepository.Update(secondarycost);
                if (_secondaryCostElementRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = secondarycost };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteSecondaryCostElementsCreation/{code}")]
        public IActionResult DeleteSecondaryCostElementsCreationbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _secondaryCostElementRepository.GetSingleOrDefault(x => x.SecondaryCostCode.Equals(code));
                _secondaryCostElementRepository.Remove(record);
                if (_secondaryCostElementRepository.SaveChanges() > 0)
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
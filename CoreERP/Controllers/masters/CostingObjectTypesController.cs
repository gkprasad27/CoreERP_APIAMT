using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/CostingObjectTypes")]
    public class CostingObjectTypesController : ControllerBase
    {

        private readonly IRepository<TblCostingObjectTypes> _costingObjectTypesRepository;
        public CostingObjectTypesController(IRepository<TblCostingObjectTypes> costingObjectTypesRepository)
        {
            _costingObjectTypesRepository = costingObjectTypesRepository;
        }

        [HttpPost("RegisterCostingObjectTypes")]
        public IActionResult RegisterCostingObjectTypes([FromBody]TblCostingObjectTypes costobjecttype)
        {
            if (costobjecttype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _costingObjectTypesRepository.Add(costobjecttype);
                if (_costingObjectTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costobjecttype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCostingObjectTypesList")]
        public IActionResult GetCostingObjectTypesList()
        {
            try
            {
                var costobjtypeList = _costingObjectTypesRepository.GetAll();
                if (costobjtypeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costobjtypeList = costobjtypeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateCostingObjectTypes")]
        public IActionResult UpdateCostingObjectTypes([FromBody] TblCostingObjectTypes costobjecttype)
        {
            if (costobjecttype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costobjecttype)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _costingObjectTypesRepository.Update(costobjecttype);
                if (_costingObjectTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costobjecttype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCostingObjectTypes/{code}")]
        public IActionResult DeleteCostingObjectTypesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _costingObjectTypesRepository.GetSingleOrDefault(x => x.ObjectType.Equals(code));
                _costingObjectTypesRepository.Remove(record);
                if (_costingObjectTypesRepository.SaveChanges() > 0)
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
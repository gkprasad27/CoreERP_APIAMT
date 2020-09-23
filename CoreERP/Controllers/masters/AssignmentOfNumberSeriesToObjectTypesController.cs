using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/AssignmentOfNumberSeriesToObjectTypes")]
    public class AssignmentOfNumberSeriesToObjectTypesController : ControllerBase
    {
        private readonly IRepository<TblCostingnumberAssigntoObject> _costingnumberAssigntoObjectRepository;
        public AssignmentOfNumberSeriesToObjectTypesController(IRepository<TblCostingnumberAssigntoObject> costingnumberAssigntoObjectRepository)
        {
            _costingnumberAssigntoObjectRepository = costingnumberAssigntoObjectRepository;
        }

        [HttpPost("RegisterAssignmentOfNumberSeriesToObjectTypes")]
        public IActionResult RegisterAssignmentOfNumberSeriesToObjectTypes([FromBody]TblCostingnumberAssigntoObject costnumberobj)
        {
            if (costnumberobj == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _costingnumberAssigntoObjectRepository.Add(costnumberobj);
                if (_costingnumberAssigntoObjectRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costnumberobj };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssignmentOfNumberSeriesToObjectTypesList")]
        public IActionResult GetAssignmentOfNumberSeriesToObjectTypesList()
        {
            try
            {
                var costassnnoseriesList = CommonHelper.GetCostingnumberAssigntoObject();
                if (costassnnoseriesList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costassnnoseriesList = costassnnoseriesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }


                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAssignmentOfNumberSeriesToObjectTypes")]
        public IActionResult UpdateUpdateAssignmentOfNumberSeriesToObjectTypes([FromBody] TblCostingnumberAssigntoObject costnumberobj)
        {
            if (costnumberobj == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costnumberobj)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _costingnumberAssigntoObjectRepository.Update(costnumberobj);
                if (_costingnumberAssigntoObjectRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costnumberobj };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssignmentOfNumberSeriesToObjectTypes/{code}")]
        public IActionResult DeleteAssignmentOfNumberSeriesToObjectTypesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _costingnumberAssigntoObjectRepository.GetSingleOrDefault(x => x.ObjectType.Equals(code));
                _costingnumberAssigntoObjectRepository.Remove(record);
                if (_costingnumberAssigntoObjectRepository.SaveChanges() > 0)
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
using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/CoastingActivities")]
    public class CoastingActivitiesController : ControllerBase
    {
        private readonly IRepository<TblCostingActivity> _costingActivityRepository;
        public CoastingActivitiesController(IRepository<TblCostingActivity> costingActivityRepository)
        {
            _costingActivityRepository = costingActivityRepository;
        }

        [HttpPost("RegisterCoastingActivities")]
        public IActionResult RegisterCoastingActivities([FromBody]TblCostingActivity costactivity)
        {
            if (costactivity == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _costingActivityRepository.Add(costactivity);
                if (_costingActivityRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costactivity };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCoastingActivitiesList")]
        public IActionResult GetCoastingActivitiesList()
        {
            try
            {
                var costactiveList = CommonHelper.GetActivities();
                if (costactiveList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costactiveList = costactiveList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateCoastingActivities")]
        public IActionResult UpdateCoastingActivities([FromBody] TblCostingActivity costactivity)
        {
            if (costactivity == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costactivity)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _costingActivityRepository.Update(costactivity);
                if (_costingActivityRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costactivity };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCoastingActivities/{code}")]
        public IActionResult DeleteCoastingActivitiesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _costingActivityRepository.GetSingleOrDefault(x => x.ActivityCode.Equals(code));
                _costingActivityRepository.Remove(record);
                if (_costingActivityRepository.SaveChanges() > 0)
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
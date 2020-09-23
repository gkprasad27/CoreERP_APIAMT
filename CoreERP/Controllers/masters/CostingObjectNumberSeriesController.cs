using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/CostingObjectNumberSeries")]
    public class CostingObjectNumberSeriesController : ControllerBase
    {
        private readonly IRepository<TblCostingNumberSeries> _costingNumberSeriesRepository;
        public CostingObjectNumberSeriesController(IRepository<TblCostingNumberSeries> costingNumberSeriesRepository)
        {
            _costingNumberSeriesRepository = costingNumberSeriesRepository;
        }

        [HttpPost("RegisterCostingObjectNumberSeries")]
        public IActionResult RegisterCostingObjectNumberSeries([FromBody]TblCostingNumberSeries costnumber)
        {
            if (costnumber == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _costingNumberSeriesRepository.Add(costnumber);
                if (_costingNumberSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costnumber };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCostingObjectNumberSeriesList")]
        public IActionResult GetCostingObjectNumberSeriesList()
        {
            try
            {
                var costnoseriesList = _costingNumberSeriesRepository.GetAll();
                if (costnoseriesList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costnoseriesList = costnoseriesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }


                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateCostingObjectNumberSeries")]
        public IActionResult UpdateCostingObjectNumberSeries([FromBody] TblCostingNumberSeries costnumber)
        {
            if (costnumber == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costnumber)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _costingNumberSeriesRepository.Update(costnumber);
                if (_costingNumberSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costnumber };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCostingObjectNumberSeries/{code}")]
        public IActionResult DeleteCostingObjectNumberSeriesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _costingNumberSeriesRepository.GetSingleOrDefault(x => x.NumberObject.Equals(code));
                _costingNumberSeriesRepository.Remove(record);
                if (_costingNumberSeriesRepository.SaveChanges() > 0)
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
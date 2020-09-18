using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/MaterialNumberRangeSeries")]
    public class MaterialNumberRangeSeriesController : ControllerBase
    {

        private readonly IRepository<TblMaterialNoSeries> _materialNoSeriesRepository;
        public MaterialNumberRangeSeriesController(IRepository<TblMaterialNoSeries> materialNoSeriesRepository)
        {
            _materialNoSeriesRepository = materialNoSeriesRepository;
        }

        [HttpPost("RegisterMaterialNumberRangeSeries")]
        public IActionResult RegisterMaterialNumberRangeSeries([FromBody]TblMaterialNoSeries mseries)
        {
            if (mseries == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _materialNoSeriesRepository.Add(mseries);
                if (_materialNoSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mseries };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialNumberRangeSeriesList")]
        public IActionResult GetMaterialNumberRangeSeriesList()
        {
            try
            {
                var mnosList = _materialNoSeriesRepository.GetAll();
                if (mnosList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.mnosList = mnosList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMaterialNumberRangeSeries")]
        public IActionResult UpdateMaterialNumberRangeSeries([FromBody] TblMaterialNoSeries mseries)
        {
            if (mseries == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(mseries)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _materialNoSeriesRepository.Update(mseries);
                if (_materialNoSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mseries };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialNumberRangeSeries/{code}")]
        public IActionResult DeleteMaterialNumberRangeSeriesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _materialNoSeriesRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _materialNoSeriesRepository.Remove(record);
                if (_materialNoSeriesRepository.SaveChanges() > 0)
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
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
    [Route("api/LotSeries")]
    public class LotSeriesController : ControllerBase
    {
        private readonly IRepository<TblLotSeries> _lotSeriesRepository;
        public LotSeriesController(IRepository<TblLotSeries> lotSeriesRepository)
        {
            _lotSeriesRepository = lotSeriesRepository;
        }

        [HttpPost("RegisterLotSeries")]
        public IActionResult RegisterLotSeries([FromBody]TblLotSeries lotseries)
        {
            if (lotseries == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _lotSeriesRepository.Add(lotseries);
                if (_lotSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = lotseries };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLotSeriesList")]
        public IActionResult GetLotSeriesList()
        {
            try
            {
                var lotList = _lotSeriesRepository.GetAll();
                if (lotList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.lotList = lotList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateLotSeries")]
        public IActionResult UpdateLotSeries([FromBody] TblLotSeries lotseries)
        {
            if (lotseries == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(lotseries)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _lotSeriesRepository.Update(lotseries);
                if (_lotSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = lotseries };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteLotSeries/{code}")]
        public IActionResult DeleteLotSeriesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _lotSeriesRepository.GetSingleOrDefault(x => x.SeriesKey.Equals(code));
                _lotSeriesRepository.Remove(record);
                if (_lotSeriesRepository.SaveChanges() > 0)
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
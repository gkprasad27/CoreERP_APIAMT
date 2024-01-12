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
    [Route("api/Holiday")]
    public class HolidayMasterController : ControllerBase
    {
        private readonly IRepository<TblHoliday> _holidayRepository;

        public HolidayMasterController(IRepository<TblHoliday> holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        [HttpGet("GetHolidaysList")]
        public IActionResult GetHolidaysList()
        {
            try
            {
                var holidaysList = CommonHelper.GetHolidays();
                if (holidaysList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.holidaysList = holidaysList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterHoliday")]
        public IActionResult RegisterCompany([FromBody] TblHoliday holiday)
        {

            if (holiday == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(holiday)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _holidayRepository.Add(holiday);
                if (_holidayRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = _holidayRepository };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateHoliday")]
        public IActionResult UpdateCompany([FromBody] TblHoliday holiday)
        {

            if (holiday == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(holiday)} cannot be null" });
            try
            {
                APIResponse apiResponse;

                _holidayRepository.Update(holiday);
                if (_holidayRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = holiday };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteHoliday/{code}")]
        public IActionResult DeleteHoliday(int code)
        {
            if (code ==0)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                APIResponse apiResponse;
                var record = _holidayRepository.GetSingleOrDefault(x => x.HolidayId.Equals(code));
                _holidayRepository.Remove(record);
                if (_holidayRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
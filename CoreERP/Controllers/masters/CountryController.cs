using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Country")]
    public class CountryController : ControllerBase
    {
        private readonly IRepository<Countries> _countryRepository;
        public CountryController(IRepository<Countries> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpPost("RegisterCountry")]
        public IActionResult RegisterCountry([FromBody]Countries country)
        {
            if (country == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (CountryHelper.GetList(country.CountryCode).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"country Code {nameof(country.CountryCode)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _countryRepository.Add(country);
                if (_countryRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = country };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCountryList")]
        public IActionResult GetCountryList()
        {
            try
            {
                var countryList =CommonHelper.GetCountries();
                if (countryList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.countryList = countryList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateCountry")]
        public IActionResult UpdateCountry([FromBody] Countries country)
        {
            if (country == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(country)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _countryRepository.Update(country);
                if (_countryRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = country };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCountry/{code}")]
        public IActionResult DeleteCountryByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _countryRepository.GetSingleOrDefault(x => x.CountryCode.Equals(code));
                _countryRepository.Remove(record);
                if (_countryRepository.SaveChanges() > 0)
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
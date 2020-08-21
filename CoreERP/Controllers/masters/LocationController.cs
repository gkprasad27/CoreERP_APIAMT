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
    [Route("api/Location")]
    public class LocationController : ControllerBase
    {
        private readonly IRepository<TblPlant> _plantRepository;
        private readonly IRepository<TblLocation> _locationRepository;
        public LocationController(IRepository<TblLocation>locationRepository ,IRepository<TblPlant> plantRepository)
        {
            _locationRepository = locationRepository;
            _plantRepository = plantRepository;

        }

        [HttpPost("RegisterLocation")]
        public IActionResult RegisterLocation([FromBody]TblLocation location)
        {
            if (location == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (LocationHelper.GetList(location.LocationId).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"location Code {nameof(location.LocationId)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _locationRepository.Add(location);
                if (_locationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = location };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLocationList")]
        public IActionResult GetLocationList()
        {
            try
            {
                var locationList = CommonHelper.Getlocations();
                if (locationList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.locationList = locationList;
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

        [HttpGet("GetPlantList")]
        public IActionResult GetPlantList()
        {
            try
            {
                var plantList = _plantRepository.GetAll();
                if (plantList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.plantsList = plantList;
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

        [HttpPut("UpdateLocation")]
        public IActionResult UpdateLocation([FromBody] TblLocation loc)
        {
            if (loc == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(loc)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _locationRepository.Update(loc);
                if (_locationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = loc };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteLocation/{code}")]
        public IActionResult DeleteLocationByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _locationRepository.GetSingleOrDefault(x => x.LocationId.Equals(code));
                _locationRepository.Remove(record);
                if (_locationRepository.SaveChanges() > 0)
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
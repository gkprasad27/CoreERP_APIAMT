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
    [Route("api/Plant")]
    public class PlantController : ControllerBase
    {
        private readonly IRepository<TblPlant> _plantRepository;
        public PlantController(IRepository<TblPlant> plantRepository)
        {
            _plantRepository = plantRepository;
        }

        [HttpPost("RegisterPlant")]
        public IActionResult RegisterPlant([FromBody]TblPlant plant)
        {
            if (plant == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (PlantHelper.GetList(plant.PlantCode).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"plant Code {nameof(plant.PlantCode)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _plantRepository.Add(plant);
                if (_plantRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = plant };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPlant")]
        public IActionResult GetPlant()
        {
            try
            {
                var plantList = _plantRepository.GetAll();
                if (plantList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.plantList = plantList;
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

        [HttpPut("UpdatePlant")]
        public IActionResult UpdatePlant([FromBody] TblPlant plant)
        {
            if (plant == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(plant)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _plantRepository.Update(plant);
                if (_plantRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = plant };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePlant/{code}")]
        public IActionResult DeletePlantByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _plantRepository.GetSingleOrDefault(x => x.PlantCode.Equals(code));
                _plantRepository.Remove(record);
                if (_plantRepository.SaveChanges() > 0)
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
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IRepository<VehicleRequisition> _vehicleRepository;
        public VehicleController(IRepository<VehicleRequisition> permissionRepository)
        {
            _vehicleRepository = permissionRepository;
        }

        [HttpPost("RegistervehicleTypes")]
        public IActionResult RegistervehicleTypes([FromBody] VehicleRequisition vehicletypes)
        {
            if (vehicletypes == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _vehicleRepository.Add(vehicletypes);
                if (_vehicleRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = vehicletypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetvehicleTypesList")]
        public IActionResult GetvehicleTypesList()
        {
            try
            {
                var vehicleTypesList = _vehicleRepository.GetAll();
                if (!vehicleTypesList.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.vehicleTypesList = vehicleTypesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatevehicleTypes")]
        public IActionResult UpdatevehicleTypes([FromBody] VehicleRequisition vehicletypes)
        {
            if (vehicletypes == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(vehicletypes)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _vehicleRepository.Update(vehicletypes);
                if (_vehicleRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = vehicletypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletevehicleTypes/{code}")]
        public IActionResult DeletevehicleTypes(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _vehicleRepository.GetSingleOrDefault(x => x.Sno.Equals(code));
                _vehicleRepository.Remove(record);
                if (_vehicleRepository.SaveChanges() > 0)
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
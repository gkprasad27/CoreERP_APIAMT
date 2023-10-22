using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/PFMaster")]
    public class PFController : ControllerBase
    {
        private readonly IRepository<Pfmaster> _pfRepository;
        public PFController(IRepository<Pfmaster> pfRepository)
        {
            _pfRepository = pfRepository;
        }

        [HttpPost("RegisterpfTypes")]
        public IActionResult RegisterpfTypes([FromBody] Pfmaster pfypes)
        {
            if (pfypes == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _pfRepository.Add(pfypes);
                if (_pfRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pfypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetpfTypesList")]
        public IActionResult GetpfTypesList()
        {
            try
            {
                var PFTypesList = _pfRepository.GetAll();
                if (!PFTypesList.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.PFTypesList = PFTypesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatepfTypes")]
        public IActionResult UpdatepfTypes([FromBody] Pfmaster pfypes)
        {
            if (pfypes == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(pfypes)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _pfRepository.Update(pfypes);
                if (_pfRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pfypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletepfTypes/{code}")]
        public IActionResult DeletepfTypes(int code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _pfRepository.GetSingleOrDefault(x => x.Id.Equals(code));
                _pfRepository.Remove(record);
                if (_pfRepository.SaveChanges() > 0)
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
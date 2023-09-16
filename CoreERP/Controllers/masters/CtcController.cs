using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/CTC")]
    public class CtcController : ControllerBase
    {
        private readonly IRepository<Ctcbreakup> _ctcRepository;
        public CtcController(IRepository<Ctcbreakup> ctcRepository)
        {
            _ctcRepository = ctcRepository;
        }

        [HttpPost("RegisterctcTypes")]
        public IActionResult RegisterctcTypes([FromBody] Ctcbreakup ctcComponent)
        {
            if (ctcComponent == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _ctcRepository.Add(ctcComponent);
                if (_ctcRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ctcComponent };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetctcTypesList")]
        public IActionResult GetctcTypesList()
        {
            try
            {
                var ctcTypesList = _ctcRepository.GetAll();
                if (!ctcTypesList.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.ctcTypesList = ctcTypesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatectcTypes")]
        public IActionResult UpdatectcTypes([FromBody] Ctcbreakup ctcComponent)
        {
            if (ctcComponent == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(ctcComponent)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _ctcRepository.Update(ctcComponent);
                if (_ctcRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ctcComponent };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletectcTypes/{code}")]
        public IActionResult DeletectcTypes(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _ctcRepository.GetSingleOrDefault(x => x.Id.Equals(code));
                _ctcRepository.Remove(record);
                if (_ctcRepository.SaveChanges() > 0)
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
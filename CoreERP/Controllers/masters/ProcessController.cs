using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Process")]
    public class ProcessController : ControllerBase
    {
        private readonly IRepository<TblProcess> _processRepository;
        public ProcessController(IRepository<TblProcess> processRepository)
        {
            _processRepository = processRepository;
        }

        [HttpPost("RegisterProcess")]
        public IActionResult RegisterProcess([FromBody]TblProcess process)

        {
            if (process == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _processRepository.Add(process);
                if (_processRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = process };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetProcessList")]
        public IActionResult GetProcessList()
        {
            try
            {
                var processList = CommonHelper.GetProcess();
                if (processList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.processList = processList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateProcess")]
        public IActionResult UpdateProcess([FromBody] TblProcess process)
        {
            if (process == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(process)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _processRepository.Update(process);
                if (_processRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = process };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteProcess/{code}")]
        public IActionResult DeleteProcessbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _processRepository.GetSingleOrDefault(x => x.ProcessKey.Equals(code));
                _processRepository.Remove(record);
                if (_processRepository.SaveChanges() > 0)
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
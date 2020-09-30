using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/WorkBreakDownStructure")]
    public class WorkBreakDownStructureController : ControllerBase
    {

        private readonly IRepository<TblWbs> _WbsRepository;
        public WorkBreakDownStructureController(IRepository<TblWbs> WbsRepository)
        {
            _WbsRepository = WbsRepository;
        }

        [HttpPost("RegisterWorkBreakDownStructure")]
        public IActionResult RegisterWorkBreakDownStructure([FromBody]TblWbs wbs)
        {
            if (wbs == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _WbsRepository.Add(wbs);
                if (_WbsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = wbs };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetWorkBreakDownStructureList")]
        public IActionResult GetWorkBreakDownStructureList()
        {
            try
            {
                var wbsList = _WbsRepository.GetAll();
                if (wbsList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.wbsList = wbsList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateWorkBreakDownStructure")]
        public IActionResult UpdateWorkBreakDownStructure([FromBody] TblWbs wbs)
        {
            if (wbs == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(wbs)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _WbsRepository.Update(wbs);
                if (_WbsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = wbs };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteWorkBreakDownStructureList/{code}")]
        public IActionResult DeleteWorkBreakDownStructureListbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _WbsRepository.GetSingleOrDefault(x => x.Wbscode.Equals(code));
                _WbsRepository.Remove(record);
                if (_WbsRepository.SaveChanges() > 0)
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
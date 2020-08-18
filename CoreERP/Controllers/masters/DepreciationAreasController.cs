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
    [Route("api/DepreciationAreas")]
    public class DepreciationAreasController : ControllerBase
    {
        private readonly IRepository<TblDepreciationAreas> _depRepository;
        public DepreciationAreasController(IRepository<TblDepreciationAreas> depRepository)
        {
            _depRepository = depRepository;
        }

        [HttpPost("RegisterDepreciationAreas")]
        public IActionResult RegisterDepreciationAreas([FromBody]TblDepreciationAreas dpareas)
        {
            if (dpareas == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (DepreciationareasHelper.GetList(dpareas.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Depreciationareas Code {nameof(dpareas.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _depRepository.Add(dpareas);
                if (_depRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dpareas };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDepreciationAreasList")]
        public IActionResult GetDepreciationAreasList()
        {
            try
            {
                var dpareaList = _depRepository.GetAll();
                if (dpareaList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.dpareaList = dpareaList;
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

        [HttpPut("UpdateDepreciationAreas")]
        public IActionResult UpdateDepreciationAreas([FromBody] TblDepreciationAreas dpareas)
        {
            if (dpareas == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(dpareas)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _depRepository.Update(dpareas);
                if (_depRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dpareas };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteDepreciationAreas/{code}")]
        public IActionResult DeleteDepreciationAreasbyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _depRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _depRepository.Remove(record);
                if (_depRepository.SaveChanges() > 0)
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
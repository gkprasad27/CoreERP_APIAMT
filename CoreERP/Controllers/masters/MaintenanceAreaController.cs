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
    [Route("api/MaintenanceArea")]
    public class MaintenanceAreaController : ControllerBase
    {
        private readonly IRepository<TblMaintenancearea> _maRepository;
        public MaintenanceAreaController(IRepository<TblMaintenancearea> maRepository)
        {
            _maRepository = maRepository;
        }

        [HttpPost("RegisterMaintenanceArea")]
        public IActionResult RegisterMaintenanceArea([FromBody]TblMaintenancearea marea)
        {
            if (marea == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (MaintenanceAreaHelper.GetList(marea.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"MaintenanceArea Code {nameof(marea.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _maRepository.Add(marea);
                if (_maRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = marea };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaintenanceArea")]
        public IActionResult GetMaintenanceArea()
        {
            try
            {
                var mareaList = CommonHelper.GetMaintenance();
                if (mareaList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.mareaList = mareaList;
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

        [HttpPut("UpdateMaintenanceArea")]
        public IActionResult UpdateMaintenanceArea([FromBody] TblMaintenancearea marea)
        {
            if (marea == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(marea)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _maRepository.Update(marea);
                if (_maRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = marea };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaintenanceArea/{code}")]
        public IActionResult DeleteMaintenanceAreaByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _maRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _maRepository.Remove(record);
                if (_maRepository.SaveChanges() > 0)
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
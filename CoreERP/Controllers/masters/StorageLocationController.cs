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
    [Route("api/StorageLocation")]
    public class StorageLocationController : ControllerBase
    {
        private readonly IRepository<TblStorageLocation> _slRepository;
        public StorageLocationController(IRepository<TblStorageLocation> slRepository)
        {
            _slRepository = slRepository;
        }

        [HttpPost("RegisterStorageLocation")]
        public IActionResult RegisterStorageLocation([FromBody]TblStorageLocation stloc)
        {
            if (stloc == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (StorageLocationHelper.GetList(stloc.Code).Count() > 0)
                //    //return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"StorageLocation Code {nameof(stloc.Code)} is already exists ,Please Use Different Code " });
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"StorageLocation Code {nameof(stloc.Code)} is already exists ,Please Use Different Code " });
                APIResponse apiResponse;
                _slRepository.Add(stloc);
                if (_slRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = stloc };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStorageLocation")]
        public IActionResult GetStorageLocation()
        {
            try
            {
                var stlocList = _slRepository.GetAll();
                if (stlocList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.stlocList = stlocList;
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

        [HttpPut("UpdateStorageLocation")]
        public IActionResult UpdateStorageLocation([FromBody] TblStorageLocation stloc)
        {
            if (stloc == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(stloc)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _slRepository.Update(stloc);
                if (_slRepository != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = stloc };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteStorageLocation/{code}")]
        public IActionResult DeleteStorageLocationByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _slRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _slRepository.Remove(record);
                if (_slRepository.SaveChanges() > 0)
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
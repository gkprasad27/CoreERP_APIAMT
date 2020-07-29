using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/StorageLocation")]
    public class StorageLocationController : ControllerBase
    {
        [HttpPost("RegisterStorageLocation")]
        public IActionResult RegisterStorageLocation([FromBody]TblStorageLocation stloc)
        {
            if (stloc == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (StorageLocationHelper.GetList(stloc.Code).Count() > 0)
                    //return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"StorageLocation Code {nameof(stloc.Code)} is already exists ,Please Use Different Code " });
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"StorageLocation Code {nameof(stloc.Code)} is already exists ,Please Use Different Code " });
                var result = StorageLocationHelper.Register(stloc);
                APIResponse apiResponse;
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

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
                var stlocList = StorageLocationHelper.GetList();
                if (stlocList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.stlocList = stlocList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
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
                var rs = StorageLocationHelper.Update(stloc);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
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

                var rs = StorageLocationHelper.Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
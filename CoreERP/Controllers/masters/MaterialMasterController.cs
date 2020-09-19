using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/MaterialMaster")]
    public class MaterialMasterController : ControllerBase
    {
        private readonly IRepository<TblMaterialMaster> _materialMasterRepository;
        public MaterialMasterController(IRepository<TblMaterialMaster> materialMasterRepository)
        {
            _materialMasterRepository = materialMasterRepository;
        }

        [HttpPost("RegisterMaterialMaster")]
        public IActionResult RegisterMaterialMaster([FromBody]TblMaterialMaster mmaster)
        {
            if (mmaster == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _materialMasterRepository.Add(mmaster);
                if (_materialMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mmaster };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialMasterList")]
        public IActionResult GetMaterialMasterList()
        {
            try
            {
                var mmasterList = _materialMasterRepository.GetAll();
                if (mmasterList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.mmasterList = mmasterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMaterialMaster")]
        public IActionResult UpdateMaterialMaster([FromBody] TblMaterialMaster mmaster)
        {
            if (mmaster == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(mmaster)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _materialMasterRepository.Update(mmaster);
                if (_materialMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mmaster };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialMaster/{code}")]
        public IActionResult DeleteMaterialMasterbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _materialMasterRepository.GetSingleOrDefault(x => x.MaterialCode.Equals(code));
                _materialMasterRepository.Remove(record);
                if (_materialMasterRepository.SaveChanges() > 0)
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
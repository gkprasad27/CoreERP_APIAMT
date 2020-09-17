using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/MaterialTypes")]
    public class MaterialTypesController : ControllerBase
    {
        private readonly IRepository<TblMaterialTypes> _materialTypesRepository;
        public MaterialTypesController(IRepository<TblMaterialTypes> materialTypesRepository)
        {
            _materialTypesRepository = materialTypesRepository;
        }

        [HttpPost("RegisterMaterialTypes")]
        public IActionResult RegisterMaterialTypes([FromBody]TblMaterialTypes mtype)
        {
            if (mtype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _materialTypesRepository.Add(mtype);
                if (_materialTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mtype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialTypesList")]
        public IActionResult GetMaterialTypesList()
        {
            try
            {
                var matypeList = _materialTypesRepository.GetAll();
                if (matypeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.matypeList = matypeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMaterialTypes")]
        public IActionResult UpdateMaterialTypes([FromBody] TblMaterialTypes mtype)
        {
            if (mtype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(mtype)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _materialTypesRepository.Update(mtype);
                if (_materialTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mtype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialTypes/{code}")]
        public IActionResult DeleteMaterialTypesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _materialTypesRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _materialTypesRepository.Remove(record);
                if (_materialTypesRepository.SaveChanges() > 0)
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
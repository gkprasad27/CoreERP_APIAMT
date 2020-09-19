using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/MaterialSize")]
    public class MaterialSizeController : ControllerBase
    {
        private readonly IRepository<TblMaterialSize> _materialSizeRepository;
        public MaterialSizeController(IRepository<TblMaterialSize> materialSizeRepository)
        {
            _materialSizeRepository = materialSizeRepository;
        }

        [HttpPost("RegisterMaterialSize")]
        public IActionResult RegisterMaterialSize([FromBody]TblMaterialSize msize)
        {
            if (msize == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _materialSizeRepository.Add(msize);
                if (_materialSizeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = msize };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialSizeList")]
        public IActionResult GetMaterialSizeList()
        {
            try
            {
                var msizeList = _materialSizeRepository.GetAll();
                if (msizeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.msizeList = msizeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMaterialSize")]
        public IActionResult UpdateMaterialSize([FromBody] TblMaterialSize msize)
        {
            if (msize == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(msize)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _materialSizeRepository.Update(msize);
                if (_materialSizeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = msize };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialSize/{code}")]
        public IActionResult DeleteMaterialSizebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _materialSizeRepository.GetSingleOrDefault(x => x.Sizekey.Equals(code));
                _materialSizeRepository.Remove(record);
                if (_materialSizeRepository.SaveChanges() > 0)
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
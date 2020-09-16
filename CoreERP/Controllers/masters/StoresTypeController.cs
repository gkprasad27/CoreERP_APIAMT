using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/StoresType")]
    public class StoresTypeController : ControllerBase
    {
        private readonly IRepository<TblStoreTypes> _storeTypesRepository;
        public StoresTypeController(IRepository<TblStoreTypes> storeTypesRepository)
        {
            _storeTypesRepository = storeTypesRepository;
        }

        [HttpPost("RegisterStoresType")]
        public IActionResult RegisterStoresType([FromBody]TblStoreTypes store)
        {
            if (store == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _storeTypesRepository.Add(store);
                if (_storeTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = store };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStoresTypeList")]
        public IActionResult GetStoresTypeList()
        {
            try
            {
                var storeList = _storeTypesRepository.GetAll();
                if (storeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.storeList = storeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateStoresType")]
        public IActionResult UpdateStoresType([FromBody] TblStoreTypes store)
        {
            if (store == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(store)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _storeTypesRepository.Update(store);
                if (_storeTypesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = store };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteStoresType/{code}")]
        public IActionResult DeleteStoresTypebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _storeTypesRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _storeTypesRepository.Remove(record);
                if (_storeTypesRepository.SaveChanges() > 0)
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
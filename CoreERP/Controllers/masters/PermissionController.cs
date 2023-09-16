using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Permission")]
    public class PermissionController : ControllerBase
    {
        private readonly IRepository<PermissionRequest> _permissionRepository;
        public PermissionController(IRepository<PermissionRequest> permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        [HttpPost("RegisterpermissionTypes")]
        public IActionResult RegisterpermissionTypes([FromBody] PermissionRequest permissiontypes)
        {
            if (permissiontypes == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _permissionRepository.Add(permissiontypes);
                if (_permissionRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = permissiontypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetpermissionTypesList")]
        public IActionResult GetpermissionTypesList()
        {
            try
            {
                var permissionTypesList = _permissionRepository.GetAll();
                if (!permissionTypesList.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.permissionTypesList = permissionTypesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatepermissionTypes")]
        public IActionResult UpdatepermissionTypes([FromBody] PermissionRequest permissiontypes)
        {
            if (permissiontypes == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(permissiontypes)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _permissionRepository.Update(permissiontypes);
                if (_permissionRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = permissiontypes };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletepermissionTypes/{code}")]
        public IActionResult DeletepermissionTypes(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _permissionRepository.GetSingleOrDefault(x => x.Id.Equals(code));
                _permissionRepository.Remove(record);
                if (_permissionRepository.SaveChanges() > 0)
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
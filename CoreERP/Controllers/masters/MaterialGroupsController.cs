using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/MaterialGroups")]
    public class MaterialGroupsController : ControllerBase
    {
        private readonly IRepository<TblMaterialGroups> _materialGroupsRepository;
        public MaterialGroupsController(IRepository<TblMaterialGroups> materialGroupsRepository)
        {
           _materialGroupsRepository = materialGroupsRepository;
        }

        [HttpPost("RegisterMaterialGroups")]
        public IActionResult RegisterMaterialGroups([FromBody]TblMaterialGroups mgroup)
        {
            if (mgroup == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _materialGroupsRepository.Add(mgroup);
                if (_materialGroupsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mgroup };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialGroupsList")]
        public IActionResult GetMaterialGroupsList()
        {
            try
            {
                var magroupList = _materialGroupsRepository.GetAll();
                if (magroupList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.magroupList = magroupList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMaterialGroups")]
        public IActionResult UpdateMaterialGroups([FromBody] TblMaterialGroups mgroup)
        {
            if (mgroup == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(mgroup)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _materialGroupsRepository.Update(mgroup);
                if (_materialGroupsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mgroup };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialGroups/{code}")]
        public IActionResult DeleteMaterialGroupsbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _materialGroupsRepository.GetSingleOrDefault(x => x.groupCode.Equals(code));
                _materialGroupsRepository.Remove(record);
                if (_materialGroupsRepository.SaveChanges() > 0)
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
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/MaterialNumberAsssignment")]
    public class MaterialNumberAsssignmentController : ControllerBase
    {
        private readonly IRepository<TblMaterialNoAssignment> _materialNoAssignmentRepository;
        public MaterialNumberAsssignmentController(IRepository<TblMaterialNoAssignment> materialNoAssignmentRepository)
        {
            _materialNoAssignmentRepository = materialNoAssignmentRepository;
        }

        [HttpPost("RegisterMaterialNumberAsssignment")]
        public IActionResult RegisterMaterialNumberAsssignment([FromBody]TblMaterialNoAssignment massignmnt)
        {
            if (massignmnt == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _materialNoAssignmentRepository.Add(massignmnt);
                if (_materialNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = massignmnt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialNumberAsssignmentList")]
        public IActionResult GetMaterialNumberAsssignmentList()
        {
            try
            {
                var assgnmntList = CommonHelper.GetMaterialNoAssignment();
                if (assgnmntList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assgnmntList = assgnmntList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMaterialNumberAsssignment")]
        public IActionResult UpdateMaterialNumberAsssignment([FromBody] TblMaterialNoAssignment massignmnt)
        {
            if (massignmnt == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(massignmnt)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _materialNoAssignmentRepository.Update(massignmnt);
                if (_materialNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = massignmnt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialNumberAsssignment/{code}")]
        public IActionResult DeleteMaterialNumberAsssignmentbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _materialNoAssignmentRepository.GetSingleOrDefault(x => x.NumberRange.Equals(code));
                _materialNoAssignmentRepository.Remove(record);
                if (_materialNoAssignmentRepository.SaveChanges() > 0)
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
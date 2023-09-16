using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/MaterialRequisitionNoteAssignment")]
    public class MaterialRequisitionNoteAssignmentController : ControllerBase
    {
        private readonly IRepository<TblMrnnoAssignment> _materialNoAssignmentRepository;
        public MaterialRequisitionNoteAssignmentController(IRepository<TblMrnnoAssignment> materialNoAssignmentRepository)
        {
            _materialNoAssignmentRepository = materialNoAssignmentRepository;
        }

        [HttpPost("RegisterMaterialRequisitionNoteAssignment")]
        public IActionResult RegisterMaterialRequisitionNoteAssignment([FromBody]TblMrnnoAssignment assgnmnt)
        {
            if (assgnmnt == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _materialNoAssignmentRepository.Add(assgnmnt);
                if (_materialNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assgnmnt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "MRN already Exist, Please use another key " + " " + (assgnmnt.Mrnseries) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialRequisitionNoteAssignmentList")]
        public IActionResult GetMaterialRequisitionNoteAssignmentList()
        {
            try
            {
                var materielassgnmntList = CommonHelper.GetMrnnoAssignment();
                if (materielassgnmntList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.materielassgnmntList = materielassgnmntList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMaterialRequisitionNoteAssignment")]
        public IActionResult UpdateMaterialRequisitionNoteAssignment([FromBody] TblMrnnoAssignment assgnmnt)
        {
            if (assgnmnt == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(assgnmnt)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _materialNoAssignmentRepository.Update(assgnmnt);
                if (_materialNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assgnmnt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "MRN already Exist, Please use another key " + " " + (assgnmnt.Mrnseries) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialRequisitionNoteAssignment/{code}")]
        public IActionResult DeleteMaterialRequisitionNoteAssignmentbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _materialNoAssignmentRepository.GetSingleOrDefault(x => x.Mrnseries.Equals(code));
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
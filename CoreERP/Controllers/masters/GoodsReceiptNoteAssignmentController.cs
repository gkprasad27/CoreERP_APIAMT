using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/GoodsReceiptNoteAssignment")]
    public class GoodsReceiptNoteAssignmentController : ControllerBase
    {
        private readonly IRepository<TblGrnassignment> _grnassignmentRepository;
        public GoodsReceiptNoteAssignmentController(IRepository<TblGrnassignment> grnassignmentRepository)
        {
            _grnassignmentRepository = grnassignmentRepository;
        }

        [HttpPost("RegisterGoodsReceiptNoteAssignment")]
        public IActionResult RegisterGoodsReceiptNoteAssignment([FromBody]TblGrnassignment assgnmnt)
        {
            if (assgnmnt == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _grnassignmentRepository.Add(assgnmnt);
                if (_grnassignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assgnmnt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGoodsReceiptNoteAssignmentList")]
        public IActionResult GetGoodsReceiptNoteAssignmentList()
        {
            try
            {
                var grnoassgnmtList = _grnassignmentRepository.GetAll();
                if (grnoassgnmtList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.grnoassgnmtList = grnoassgnmtList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateGoodsReceiptNoteAssignment")]
        public IActionResult UpdateGoodsReceiptNoteAssignment([FromBody] TblGrnassignment assgnmnt)
        {
            if (assgnmnt == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(assgnmnt)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _grnassignmentRepository.Update(assgnmnt);
                if (_grnassignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assgnmnt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteGoodsReceiptNoteAssignment/{code}")]
        public IActionResult DeleteGoodsReceiptNoteAssignmentbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _grnassignmentRepository.GetSingleOrDefault(x => x.Grnseries.Equals(code));
                _grnassignmentRepository.Remove(record);
                if (_grnassignmentRepository.SaveChanges() > 0)
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
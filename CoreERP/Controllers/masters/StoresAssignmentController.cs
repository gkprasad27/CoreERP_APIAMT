using System;
using System.Collections.Generic;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/StoresAssignment")]
    public class StoresAssignmentController : ControllerBase
    {
        private readonly IRepository<TblLotAssignment> _lotAssignmentRepository;
        public StoresAssignmentController(IRepository<TblLotAssignment> lotAssignmentRepository)
        {
            _lotAssignmentRepository = lotAssignmentRepository;
        }

        [HttpPost("RegisterStoresAssignment")]
        public IActionResult RegisterStoresAssignment([FromBody]TblLotAssignment assgnmnt)
        {
            if (assgnmnt == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _lotAssignmentRepository.Add(assgnmnt);
                if (_lotAssignmentRepository.SaveChanges() > 0)
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

        [HttpGet("GetStoresAssignmentList")]
        public IActionResult GetStoresAssignmentList()
        {
            try
            {
                var storeasnList = _lotAssignmentRepository.GetAll();
                if (storeasnList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.storeasnList = storeasnList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateStoresAssignment")]
        public IActionResult UpdateStoresAssignment([FromBody] TblLotAssignment assnmnt)
        {
            if (assnmnt == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(assnmnt)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _lotAssignmentRepository.Update(assnmnt);
                if (_lotAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assnmnt };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteStoresAssignment/{code}")]
        public IActionResult DeleteStoresAssignmentbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _lotAssignmentRepository.GetSingleOrDefault(x => x.LotSeries.Equals(code));
                _lotAssignmentRepository.Remove(record);
                if (_lotAssignmentRepository.SaveChanges() > 0)
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
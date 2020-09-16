using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/PurchaseOrderAssignment")]
    public class PurchaseOrderAssignmentController : ControllerBase
    {
        private readonly IRepository<TblPurchaseOrderNoAssignment> _purchaseOrderNoAssignmentRepository;
        public PurchaseOrderAssignmentController(IRepository<TblPurchaseOrderNoAssignment> purchaseOrderNoAssignmentRepository)
        {
            _purchaseOrderNoAssignmentRepository = purchaseOrderNoAssignmentRepository;
        }

        [HttpPost("RegisterPurchaseOrderAssignment")]
        public IActionResult RegisterPurchaseOrderAssignment([FromBody]TblPurchaseOrderNoAssignment assgnmnt)
        {
            if (assgnmnt == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _purchaseOrderNoAssignmentRepository.Add(assgnmnt);
                if (_purchaseOrderNoAssignmentRepository.SaveChanges() > 0)
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

        [HttpGet("GetPurchaseOrderAssignmentList")]
        public IActionResult GetPurchaseOrderAssignmentList()
        {
            try
            {
                var poassnList = _purchaseOrderNoAssignmentRepository.GetAll();
                if (poassnList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.poassnList = poassnList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePurchaseOrderAssignment")]
        public IActionResult UpdatePurchaseOrderAssignment([FromBody] TblPurchaseOrderNoAssignment assgnmnt)
        {
            if (assgnmnt == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(assgnmnt)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _purchaseOrderNoAssignmentRepository.Update(assgnmnt);
                if (_purchaseOrderNoAssignmentRepository.SaveChanges() > 0)
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

        [HttpDelete("DeletePurchaseOrderAssignment/{code}")]
        public IActionResult DeletePurchaseOrderAssignmentbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _purchaseOrderNoAssignmentRepository.GetSingleOrDefault(x => x.NumberRange.Equals(code));
                _purchaseOrderNoAssignmentRepository.Remove(record);
                if (_purchaseOrderNoAssignmentRepository.SaveChanges() > 0)
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
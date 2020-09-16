using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;


namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/RequisitionNumberRange")]
    public class RequisitionNumberRangeController : ControllerBase
    {
        private readonly IRepository<TblRequisitionNoRange> _requisitionNumberRangeRepository;
        public RequisitionNumberRangeController(IRepository<TblRequisitionNoRange> requisitionNumberRangeRepository)
        {
            _requisitionNumberRangeRepository = requisitionNumberRangeRepository;
        }

        [HttpPost("RegisterRequisitionNumberRange")]
        public IActionResult RegisterRequisitionNumberRange([FromBody]TblRequisitionNoRange reqno)
        {
            if (reqno == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _requisitionNumberRangeRepository.Add(reqno);
                if (_requisitionNumberRangeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = reqno };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetRequisitionNumberRangeList")]
        public IActionResult GetRequisitionNumberRangeList()
        {
            try
            {
                var reqnorangeList = _requisitionNumberRangeRepository.GetAll();
                if (reqnorangeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.reqnorangeList = reqnorangeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateRequisitionNumberRange")]
        public IActionResult UpdateRequisitionNumberRange([FromBody] TblRequisitionNoRange reqno)
        {
            if (reqno == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(reqno)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _requisitionNumberRangeRepository.Update(reqno);
                if (_requisitionNumberRangeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = reqno };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteRequisitionNumberRange/{code}")]
        public IActionResult DeleteRequisitionNumberRangebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _requisitionNumberRangeRepository.GetSingleOrDefault(x => x.NumberRange.Equals(code));
                _requisitionNumberRangeRepository.Remove(record);
                if (_requisitionNumberRangeRepository.SaveChanges() > 0)
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
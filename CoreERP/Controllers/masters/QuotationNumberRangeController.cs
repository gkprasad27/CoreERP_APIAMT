using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/QuotationNumberRange")]
    public class QuotationNumberRangeController : ControllerBase
    {
        private readonly IRepository<TblQuotationNoRange> _quotationNoAssignmentRepository;
        public QuotationNumberRangeController(IRepository<TblQuotationNoRange> quotationNoAssignmentRepository)
        {
            _quotationNoAssignmentRepository = quotationNoAssignmentRepository;
        }

        [HttpPost("RegisterQuotationNumberRange")]
        public IActionResult RegisterQuotationNumberRange([FromBody]TblQuotationNoRange qtnorange)
        {
            if (qtnorange == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _quotationNoAssignmentRepository.Add(qtnorange);
                if (_quotationNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = qtnorange };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetQuotationNumberRangeList")]
        public IActionResult GetQuotationNumberRangeList()
        {
            try
            {
                var qtnnorangeList = _quotationNoAssignmentRepository.GetAll();
                if (qtnnorangeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.qtnnorangeList = qtnnorangeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateQuotationNumberRange")]
        public IActionResult UpdateQuotationNumberRange([FromBody] TblQuotationNoRange qtnorange)
        {
            if (qtnorange == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(qtnorange)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _quotationNoAssignmentRepository.Update(qtnorange);
                if (_quotationNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = qtnorange };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteQuotationNumberRange/{code}")]
        public IActionResult DeleteQuotationNumberRangebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _quotationNoAssignmentRepository.GetSingleOrDefault(x => x.NumberRange.Equals(code));
                _quotationNoAssignmentRepository.Remove(record);
                if (_quotationNoAssignmentRepository.SaveChanges() > 0)
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
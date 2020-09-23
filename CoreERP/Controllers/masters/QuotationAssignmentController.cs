using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/QuotationAssignment")]
    public class QuotationAssignmentController : ControllerBase
    {
        private readonly IRepository<TblQuotationNoAssignment> _quotationNoAssignmentRepository;
        public QuotationAssignmentController(IRepository<TblQuotationNoAssignment> quotationNoAssignmentRepository)
        {
            _quotationNoAssignmentRepository = quotationNoAssignmentRepository;
        }

        [HttpPost("RegisterQuotationAssignment")]
        public IActionResult RegisterQuotationAssignment([FromBody]TblQuotationNoAssignment qtnoassn)
        {
            if (qtnoassn == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _quotationNoAssignmentRepository.Add(qtnoassn);
                if (_quotationNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = qtnoassn };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetQuotationAssignmentList")]
        public IActionResult GetQuotationAssignmentList()
        {
            try
            {
                var qtnnoassnList = CommonHelper.GetQuotationNoAssignment();
                if (qtnnoassnList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.qtnnoassnList = qtnnoassnList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateQuotationAssignment")]
        public IActionResult UpdateQuotationAssignment([FromBody] TblQuotationNoAssignment qtnoassn)
        {
            if (qtnoassn == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(qtnoassn)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _quotationNoAssignmentRepository.Update(qtnoassn);
                if (_quotationNoAssignmentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = qtnoassn };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteQuotationAssignment/{code}")]
        public IActionResult DeleteQuotationAssignmentbyId(string code)
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
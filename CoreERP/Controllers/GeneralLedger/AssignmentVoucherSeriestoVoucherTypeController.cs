using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GeneralLedger
{

    [ApiController]
    [Route("api/AssignmentVoucherSeriestoVoucherType")]
    public class AssignmentVoucherSeriestoVoucherTypeController : ControllerBase
    {
        private readonly IRepository<TblAssignmentVoucherSeriestoVoucherType> _vsvtRepository;
        public AssignmentVoucherSeriestoVoucherTypeController(IRepository<TblAssignmentVoucherSeriestoVoucherType> vsvtRepository)
        {
            _vsvtRepository = vsvtRepository;
        }

        [HttpPost("RegisterAssignmentVoucherSeriestoVoucherType")]
        public IActionResult RegisterAssignmentVoucherSeriestoVoucherType([FromBody]TblAssignmentVoucherSeriestoVoucherType avsvtype)
        {
            if (avsvtype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (assignmentvoucherseriestovouchertypeHelper.GetList(avsvtype.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"assignmentvoucherseriestovouchertype Code {nameof(avsvtype.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _vsvtRepository.Add(avsvtype);
                if (_vsvtRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = avsvtype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssignmentVoucherSeriestoVoucherTypeList")]
        public IActionResult GetAssignmentVoucherSeriestoVoucherTypeList()
        {
            try
            {
                var avsvList = CommonHelper.GetAssignVoucherseriesVoucherType();
                if (avsvList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.avsvsList = avsvList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAssignmentVoucherSeriestoVoucherType")]
        public IActionResult UpdateAssignmentVoucherSeriestoVoucherType([FromBody] TblAssignmentVoucherSeriestoVoucherType avsvtype)
        {
            if (avsvtype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(avsvtype)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _vsvtRepository.Update(avsvtype);
                if (_vsvtRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = avsvtype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssignmentVoucherSeriestoVoucherType/{code}")]
        public IActionResult DeleteAssignmentVoucherSeriestoVoucherTypeByID(int code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _vsvtRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _vsvtRepository.Remove(record);
                if (_vsvtRepository.SaveChanges() > 0)
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
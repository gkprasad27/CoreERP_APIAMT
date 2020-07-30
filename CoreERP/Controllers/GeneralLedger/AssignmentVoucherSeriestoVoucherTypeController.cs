﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.GeneralLedger
{

    [ApiController]
    [Route("api/AssignmentVoucherSeriestoVoucherType")]
    public class AssignmentVoucherSeriestoVoucherTypeController : ControllerBase
    {
        [HttpPost("RegisterAssignmentVoucherSeriestoVoucherType")]
        public IActionResult RegisterAssignmentVoucherSeriestoVoucherType([FromBody]TblAssignmentVoucherSeriestoVoucherType avsvtype)
        {
            if (avsvtype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (assignmentvoucherseriestovouchertypeHelper.GetList(avsvtype.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"assignmentvoucherseriestovouchertype Code {nameof(avsvtype.Code)} is already exists ,Please Use Different Code " });

                var result = assignmentvoucherseriestovouchertypeHelper.Register(avsvtype);
                APIResponse apiResponse;
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

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
                var avsvList = assignmentvoucherseriestovouchertypeHelper.GetList();
                if (avsvList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.avsvsList = avsvList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
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
                var rs = assignmentvoucherseriestovouchertypeHelper.Update(avsvtype);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteAssignmentVoucherSeriestoVoucherType/{code}")]
        public IActionResult DeleteAssignmentVoucherSeriestoVoucherTypeByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = assignmentvoucherseriestovouchertypeHelper.Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
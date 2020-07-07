using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.SelfserviceHelpers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.Selfservice
{
    [ApiController]
    [Route("api/Selfservice/ApprovalType")]
    public class ApprovalTypeController : ControllerBase
    {
        [HttpPost("RegisterApprovalType")]
        public IActionResult RegisterApprovalType([FromBody]ApprovalType aptype)
        {
            if (aptype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (ApprovalTypeHelper.GetList(aptype.ApprovalType1).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"ApprovalType Code {nameof(aptype.ApprovalType1)} is already exists ,Please Use Different Code " });

                var result = ApprovalTypeHelper.Register(aptype);
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

        [HttpGet("GetApprovalTypesList")]
        public IActionResult GetApprovalTypesList()
        {
            try
            {
                var approvalTypesListList = ApprovalTypeHelper.GetList();
                if (approvalTypesListList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.approvalTypeList = approvalTypesListList;
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

        [HttpPut("UpdateApprovalType")]
        public IActionResult UpdateApprovalType([FromBody] ApprovalType aptype)
        {
            if (aptype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(aptype)} cannot be null" });

            try
            {
                var rs = ApprovalTypeHelper.Update(aptype);
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


        [HttpDelete("DeleteApprovalType/{code}")]
        public IActionResult DeleteApprovalType(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = ApprovalTypeHelper.Delete(code);
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
        [HttpGet("GetEmployeesList")]
        public IActionResult GetEmployeesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.EmployeesList = ApprovalTypeHelper.GetListOfEmployees().Select(x => new { ID = x.EmployeeCode, TEXT = x.EmployeeName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
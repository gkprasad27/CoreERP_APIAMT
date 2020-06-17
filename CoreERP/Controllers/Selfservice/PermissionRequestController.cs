using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.SelfserviceHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.Selfservice
{
    [ApiController]
    [Route("api/Selfservice/PermissionRequest")]
    public class PermissionRequestController : ControllerBase
    {
        [HttpGet("GetEmployeesList")]
        public IActionResult GetEmployeesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.EmployeeList = LeaveRequestHelper.GetEmployeesList().Select(x => new { ID = x.EmployeeCode, TEXT = x.EmployeeName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPermissionApplDetailsList")]
        public IActionResult GetPermissionApplDetailsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.PermissionApplDetailsList = PermissionRequestHelper.GetPermissionApplDetailsList().ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterPermissionapplying")]
        public IActionResult RegisterPermissionapplying([FromBody]PermissionRequest permissionRequest)
        {
            if (permissionRequest == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                PermissionRequest result = PermissionRequestHelper.RegisterPermissionApplDetails(permissionRequest);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}

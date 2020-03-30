using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.SelfserviceHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.Selfservice
{
  [ApiController]
  [Route("api/Selfservice/PermissionApproval")]
  public class PermissionApprovalController : ControllerBase
  {
        [HttpGet("GetPermissionApprovalApplDetailsList")]
        public IActionResult GetPermissionApprovalDetailsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.PermissionApprovalApplDetailsList = PermissionApprovalHelper.GetApplyPermissionRequestDetailsList().ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}

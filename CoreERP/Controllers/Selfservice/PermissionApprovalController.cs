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
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.Selfservice
{
  [ApiController]
  [Route("api/Selfservice/PermissionApproval")]
  public class PermissionApprovalController : ControllerBase
  {
        [HttpGet("GetPermissionApprovalApplDetailsList/{code}")]
        public IActionResult GetPermissionApprovalDetailsList(string code)
        {
            
            try
            {
                dynamic expando = new ExpandoObject();
                expando.PermissionApprovalApplDetailsList = PermissionApprovalHelper.GetApplyPermissionRequestDetailsList(code).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPost("RegisterPermissionApprovalDetails")]
        public async Task<IActionResult> RegisterPermissionApprovalDetails([FromBody]JObject objData)
        {
            APIResponse apiResponse = null;
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var code = objData["code"].ToString();
                var _stockissueHdr = objData["StockissueHdr"].ToObject<ApplyOddata>();
                //ToObject<TblEmployee>();
                var _stockissueDtl = objData["StockissueDtl"].ToObject<PermissionRequest[]>();

                var result = new PermissionApprovalHelper().RegisterPermissionApprovalDetails(code, _stockissueHdr, _stockissueDtl.ToList());

                apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}

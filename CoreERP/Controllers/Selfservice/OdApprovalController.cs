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
    [Route("api/Selfservice/OdApproval")]
    public class OdApprovalController : ControllerBase
    {
        [HttpGet("GetOdApprovalApplDetailsList/{code}")]
        public async Task<IActionResult> GetOdApprovalApplDetailsList(string code)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.OdApprovalApplDetailsList = OdApprovalHelper.GetOdApplDetailsList(code).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpPost("RegisterOdApprovalDetails")]
        public async Task<IActionResult> RegisterOdApprovalDetails([FromBody]JObject objData)
        {
            APIResponse apiResponse = null;
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var code = objData["code"].ToString();
                var _stockissueHdr = objData["StockissueHdr"].ToObject<ApplyOddata>();
                //ToObject<TblEmployee>();
                var _stockissueDtl = objData["StockissueDtl"].ToObject<ApplyOddata[]>();

                var result = new OdApprovalHelper().RegisterLeaveApprovalDetails(code, _stockissueHdr, _stockissueDtl.ToList());

                apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                return Ok(apiResponse);
                //return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


    }
}

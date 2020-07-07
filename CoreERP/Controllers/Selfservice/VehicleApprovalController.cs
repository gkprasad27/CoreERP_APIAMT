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
    [Route("api/Selfservice/VehicleApproval")]
    public class VehicleApprovalController : ControllerBase
    {
        [HttpGet("GetVehicleApprovalApplDetailsList/{code}")]
        public async Task<IActionResult> GetVehicleApprovalApplDetailsList(string code)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.VehicleApprovalApplDetailsList = VehicleApprovalHelper.GetVehicleApprovalApplDetailsList(code).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterVehicleApprovalDetails")]
        public async Task<IActionResult> RegisterVehicleApprovalDetails([FromBody]JObject objData)
        {
            APIResponse apiResponse = null;
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var code = objData["code"].ToString();
                var _stockissueHdr = objData["StockissueHdr"].ToObject<ApplyOddata>();
                //ToObject<TblEmployee>();
                var _stockissueDtl = objData["StockissueDtl"].ToObject<VehicleRequisition[]>();

                var result = new VehicleApprovalHelper().RegisterVehicleApprovalDetails(code, _stockissueHdr, _stockissueDtl.ToList());

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
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.transactionsHelpers;
using CoreERP.BussinessLogic.TransactionsHelpers;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.Transactions
{
    [Route("api/Transactions/PurchaseRequisitionApproval")]
    [ApiController]
    public class PurchaseRequisitionApprovalController : ControllerBase
    {
        
        [HttpPost("RegisterPurchaseRequisitionApproval")]
        public async Task<IActionResult> RegisterPurchaserequisition([FromBody]JObject objData)
        {
            APIResponse apiResponse = null;
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var _stockissueHdr = objData["PurreqHdr"].ToObject<PurchaseRequisitionMaster>();
                var _stockissueDtl = objData["PurreqDetail"].ToObject<PurchaseRequisitiondetails[]>();

                var result = new PurchaseRequisitionApproval().RegisterPurchaserequisition(_stockissueHdr, _stockissueDtl.ToList());

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
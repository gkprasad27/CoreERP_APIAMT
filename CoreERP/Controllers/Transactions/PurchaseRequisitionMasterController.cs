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
    [Route("api/Transactions/PurchaseRequisitionMaster")]
    [ApiController]
    public class PurchaseRequisitionMasterController : ControllerBase
    {
       
        [HttpGet("GetStackissueNo/{branchCode}")]
        public async Task<IActionResult> GetStackissueNo(string branchCode)
        {
            if (string.IsNullOrEmpty(branchCode))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

            try
            {
                string errorMessage = string.Empty;
                dynamic expando = new ExpandoObject();
                expando.StackissueNo = new PurchaseRequesitionMasterHelpercs().GetStackissueNo(branchCode, out errorMessage);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetProductLists/{productCode}/{branchCode}")]
        public async Task<IActionResult> GetPurchaserqDetailsection(string productcode, string branchCode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.productsList = new PurchaseRequesitionMasterHelpercs().GetOpStockIssuesDetailsection(productcode, branchCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterPurchaserequisition")]
        public async Task<IActionResult> RegisterPurchaserequisition([FromBody]JObject objData)
        {
            APIResponse apiResponse = null;
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var _stockissueHdr = objData["PurreqHdr"].ToObject<PurchaseRequisitionMaster>();
                var _stockissueDtl = objData["PurreqDetail"].ToObject<PurchaseRequisitiondetails[]>();

                var result = new PurchaseRequesitionMasterHelpercs().RegisterPurchaserequisition(_stockissueHdr, _stockissueDtl.ToList());

                apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                return Ok(apiResponse);
                //return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("GetPurchaseRequisitionList/{branchCode}")]
        public async Task<IActionResult> GetPurchaseRequisitionList(string branchCode, [FromBody]VoucherNoSearchCriteria searchCriteria)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var PurchaseRequisitionList = new PurchaseRequesitionMasterHelpercs().GetStockissuesMasters(searchCriteria, branchCode);
                if (PurchaseRequisitionList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.PurchaseRequisitionList = PurchaseRequisitionList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No purchase req record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpGet("GetPrreqDeatilList/{issueNo}")]
        public async Task<IActionResult> GetPrreqDeatilList(string issueNo)
        {

            if (string.IsNullOrEmpty(issueNo))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var GetPrreqDeatilList = new PurchaseRequesitionMasterHelpercs().PurchaseRequisitionDeatils(issueNo);
                if (GetPrreqDeatilList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.PrreqDeatilList = GetPrreqDeatilList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No prreq record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        ////to get the invoice Master data while page load
        [HttpPost("GetPurchaseequisitionDetails/{branchCode}")]
        public IActionResult GetPurchaseequisitionDetails([FromBody]SearchCriteria searchCriteria, string branchCode)
        {
            try
            {
                var PurchaseequisitionDetails = new PurchaseRequesitionMasterHelpercs().GetPurchaseRequesitionList(searchCriteria.Role, branchCode);
                if (PurchaseequisitionDetails.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.PurchaseequisitionDetailslist = PurchaseequisitionDetails;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "prreq records not found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
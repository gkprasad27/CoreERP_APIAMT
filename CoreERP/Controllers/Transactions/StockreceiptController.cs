using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.TransactionsHelpers;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.Transactions
{
    [Route("api/Transactions/Stockreceipt")]
    [ApiController]
    public class StockreceiptController : ControllerBase
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesListforStockreceipt()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = new StockreceiptHelpers().GetBranchesListforStockreceipt().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetProductLists/{productCode}/{branchCode}")]
        public async Task<IActionResult> GetOpStockreceiptDetailsection1(string productcode, string branchCode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.productsList = new StockreceiptHelpers().GetOpStockIssuesDetailsection(productcode, branchCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetToBranchesList")]
        public async Task<IActionResult> GetToBranchesList()
        {

            try
            {
                dynamic expando = new ExpandoObject();
                expando.branch = new StockissuesHelper().GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GettobranchesList/{branchcode}")]
        public async Task<IActionResult> GetbranchcodeList(string branchcode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.branch = new StockreceiptHelpers().Getbranchcodes(branchcode);
                //expando.branch = new StockreceiptHelpers().Getbranchcodes(branchcode).Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //GetReceiptNo
        [HttpGet("GetReceiptNo/{branchCode}")]
        public async Task<IActionResult> GetReceiptNo(string branchCode)
        {
            if (string.IsNullOrEmpty(branchCode))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

            try
            {
                string errorMessage = string.Empty;
                dynamic expando = new ExpandoObject();
                expando.ReceiptNo = new StockreceiptHelpers().GenerateInvoiceNo(branchCode,out errorMessage);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterStockreceipts")]
        public async Task<IActionResult> RegisterStockreceipts([FromBody]JObject objData)
        {
            APIResponse apiResponse = null;
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var _stockreceiptHdr = objData["StackreceiptsHdr"].ToObject<TblOperatorStockReceipt>();
                var _stockreceiptDtl = objData["StackreceiptsDetail"].ToObject<TblOperatorStockReceiptDetail[]>();

                var result = new StockreceiptHelpers().RegisterStockreceipts(_stockreceiptHdr, _stockreceiptDtl.ToList());
                apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPost("GetStockreceiptsList/{branchCode}")]
        //[HttpPost("GetStockreceiptsList")]
        public async Task<IActionResult> GetStockreceiptsList(string branchCode, [FromBody]VoucherNoSearchCriteria searchCriteria)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var stockreceiptMasterList = new StockreceiptHelpers().GetStockissuesMasters(searchCriteria, branchCode);
                if (stockreceiptMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.StockreceiptList = stockreceiptMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No StockreceiptsList record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetStockreceiptDeatilList/{issueNo}")]
        public async Task<IActionResult> GetStockreceiptDeatilList(decimal issueNo)
        {

            if (issueNo == 0)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var StockreceiptDeatilList = new StockreceiptHelpers().StockreceiptDeatils(issueNo);
                if (StockreceiptDeatilList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.StockreceiptDeatilList = StockreceiptDeatilList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        ////to get the invoice Master data while page load
        [HttpPost("GetInvoiceDetails/{branchCode}")]
        public IActionResult GetInvoiceDetails([FromBody]SearchCriteria searchCriteria, string branchCode)
        {
            try
            {
                var InvoiceDetails = new StockreceiptHelpers().GetInvoiceList(searchCriteria.Role, branchCode);
                if (InvoiceDetails.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.StockreceiptList = InvoiceDetails;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Stockreceipt records not found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


    }
}
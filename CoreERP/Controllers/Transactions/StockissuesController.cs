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
    [Route("api/Transactions/Stockissues")]
    [ApiController]
    public class StockissuesController : ControllerBase
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new StockissuesHelper().GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
        [HttpGet("GetToBranchesList")]
        public async Task<IActionResult> GetToBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.branch = new StockissuesHelper().GettoBranches().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
        [HttpGet("GettobranchesList/{branchcode}")]
        public async Task<IActionResult> GetbranchcodeList(string branchcode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.branch = new StockissuesHelper().Getbranchcodes(branchcode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        //stackissue no
        [HttpGet("GetStackissueNo/{branchCode}")]
        public async Task<IActionResult> GetStackissueNo(string branchCode)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(branchCode))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.StackissueNo = new StockissuesHelper().GetStackissueNo(branchCode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetProductLists/{productCode}/{branchCode}")]
        public async Task<IActionResult> GetOpStockIssuesDetailsection1(string productcode, string branchCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.productsList = new StockissuesHelper().GetOpStockIssuesDetailsection(productcode, branchCode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterStockissues")]
        public async Task<IActionResult> RegisterStockissues([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (objData == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var _stockissueHdr = objData["StockissueHdr"].ToObject<TblOperatorStockIssues>();
                    var _stockissueDtl = objData["StockissueDtl"].ToObject<TblOperatorStockIssuesDetail[]>();

                    var result = new StockissuesHelper().RegisterStockissues(_stockissueHdr, _stockissueDtl.ToList());

                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    return Ok(apiResponse);
                    //return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("GetStockissuesList/{branchCode}")]
        public async Task<IActionResult> GetStockissuesList(string branchCode,[FromBody]VoucherNoSearchCriteria searchCriteria)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var stockissueMasterList = new StockissuesHelper().GetStockissuesMasters(searchCriteria,branchCode);
                    if (stockissueMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.StockIssueList = stockissueMasterList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No stockissues record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }


        [HttpGet("GetStockissuesDeatilList/{issueNo}")]
        public async Task<IActionResult> GetStockissuesDeatilList(string issueNo)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(issueNo))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var StockissuesDeatilList = new StockissuesHelper().StockissuesDeatils(issueNo);
                    if (StockissuesDeatilList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.StockissuesDeatilList = StockissuesDeatilList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Stockisue record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
        [HttpPost("GetInvoiceDetails/{branchCode}")]
        public IActionResult GetInvoiceDetails([FromBody]SearchCriteria searchCriteria, string branchCode)
        {
            try
            {
                var InvoiceDetails = new StockissuesHelper().GetInvoiceList(searchCriteria.Role, branchCode);
                if (InvoiceDetails.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.StockIssueList = InvoiceDetails;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Invoice records not found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
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
        }
        [HttpGet("GetToBranchesList")]
        public async Task<IActionResult> GetToBranchesList()
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
        }
        [HttpGet("GettobranchesList/{branchcode}")]
        public async Task<IActionResult> GetbranchcodeList(string branchcode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.branch =new StockissuesHelper().Getbranchcodes(branchcode).Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //stackissue no
        [HttpGet("GetStackissueNo/{branchCode}")]
        public async Task<IActionResult> GetStackissueNo(string branchCode)
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
        }

        [HttpGet("GetProductLists/{productCode}/{branchCode}")]
        public async Task<IActionResult> GetOpStockIssuesDetailsection1(string productcode, string branchCode)
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
        }

        [HttpPost("RegisterStockissues")]
        public async Task<IActionResult> RegisterStockissues([FromBody]JObject objData)
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
        }

        //[HttpPost("GetStockissuesList/{branchCode}")]
        //public async Task<IActionResult> GetStockissuesList(string branchCode, [FromBody]SearchCriteria searchCriteria)
        //{

        //    if (searchCriteria == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
        //    try
        //    {
        //        var stockissueMasterList = new StockissuesHelper().GetStockissuesMasters(searchCriteria);
        //        if (stockissueMasterList.Count > 0)
        //        {
        //            dynamic expando = new ExpandoObject();
        //            expando.StockIssueList = stockissueMasterList;
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //        }

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No stockissues record found." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}


        [HttpPost("GetStockissuesList")]
        public async Task<IActionResult> GetStockissuesList([FromBody]SearchCriteria searchCriteria)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var stockissueMasterList = new StockissuesHelper().GetStockissuesMasters(searchCriteria);
                if (stockissueMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.StockIssueList = stockissueMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No StockIssueList record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStockissuesDeatilList/{issueNo}")]
        public async Task<IActionResult> GetStockissuesDeatilList(string issueNo)
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
        }
    }
}
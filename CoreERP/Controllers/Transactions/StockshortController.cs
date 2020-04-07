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
    [Route("api/Transactions/Stockshort")]
    [ApiController]
    public class StockshortController : ControllerBase
    {
        
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new StockshortHelpers().GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
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
        public async Task<IActionResult> GetOpStockShortDetailsection1(string productcode, string branchCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.productsList = new StockshortHelpers().GetOpStockShortDetailsection(productcode, branchCode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        //stackshort vocherno

        [HttpGet("GetstockshortVoucherNo/{branchCode}")]
        public async Task<IActionResult> GetstockshortVoucherNo(string branchCode)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(branchCode))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.stockshortVoucherNo = new StockshortHelpers().GetstockshortVoucherNo(branchCode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterStockshort")]
        public async Task<IActionResult> RegisterStockshort([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                if (objData == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var _stockrshortHdr = objData["StockshortHdr"].ToObject<TblStockshortMaster>();
                    var _stockshortDtl = objData["StockshortDtl"].ToObject<TblStockshortDetails[]>();

                    var result = new StockshortHelpers().RegisterStockshort(_stockrshortHdr, _stockshortDtl.ToList());
                    APIResponse apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }


        [HttpPost("GetStockshortsList/{branchCode}")]
        public async Task<IActionResult> GetStockshortsList(string branchCode, [FromBody]VoucherNoSearchCriteria searchCriteria)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var stockshortsListMasterList = new StockshortHelpers().GetStockshortsList(searchCriteria,branchCode);
                    if (stockshortsListMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.StockshortsList = stockshortsListMasterList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No StockreceiptsList record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }



        [HttpGet("GetCostCentersList")]
        public async Task<IActionResult> GetCostCentersList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.CostCentersList = new StockshortHelpers().GetCostCenters().Select(x => new { ID = x.Code, TEXT = x.Name });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetStockshortsDeatilList/{issueNo}")]
        public async Task<IActionResult> GetStockshortsDeatilList(string issueNo)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(issueNo))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var StockshortsDeatilList = new StockshortHelpers().StockshortsDeatilList(issueNo);
                    if (StockshortsDeatilList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.StockshortsDeatilList = StockshortsDeatilList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No StockshortsDeatilList record found." });
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
                var StockshortsDetails = new StockshortHelpers().GetInvoiceList(searchCriteria.Role, branchCode);
                if (StockshortsDetails.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.StockshortsList = StockshortsDetails;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Stockshrt records not found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
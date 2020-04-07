using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.transactionsHelpers;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.Transactions
{
    [ApiController]
    [Route("api/transactions/StockExcess")]
    public class StockExcessController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new StockExcessHelper().GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
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
                    expando.CostCentersList = new StockExcessHelper().GetCostCentersList().Select(x => new { ID = x.Name, TEXT = x.Name });
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
                    expando.productsList = new StockExcessHelper().GetOpStockShortDetailsection(productcode, branchCode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetstockexcessNo/{branchCode}")]
        public async Task<IActionResult> GetstockexcessNo(string branchCode)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(branchCode))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.stockexcessNo = new StockExcessHelper().GetVoucherNo(branchCode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterStockexcess")]
        public async Task<IActionResult> RegisterStockexcess([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (objData == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var _stockrexcessHdr = objData["StockexcessHdr"].ToObject<TblStockExcessMaster>();
                    var _stockexcessDtl = objData["StockexcessDtl"].ToObject<TblStockExcessDetails[]>();

                    var result = new StockExcessHelper().RegisterStocksexcess(_stockrexcessHdr, _stockexcessDtl.ToList());
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetStockExcessDetailsList/{id}")]
        public async Task<IActionResult> GetStockExcessDetailsList(decimal id)
        {
            var result = await Task.Run(() =>
            {
                if (id == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var stockExcessDetailsList = new StockExcessHelper().StockexcessDeatilList(id);
                    if (stockExcessDetailsList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.StockExcessDetails = stockExcessDetailsList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("GetStockexcessList/{branchCode}")]
        public async Task<IActionResult> GetStockexcessList( [FromBody]VoucherNoSearchCriteria searchCriteria, string branchCode)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var stockexcessListMasterList = new StockExcessHelper().GetStockexcessList(searchCriteria,branchCode);
                    if (stockexcessListMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.StockexcessList = stockexcessListMasterList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No StockExcess record found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

    }
}
﻿using System;
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
        }

        [HttpGet("GetProductLists/{productCode}/{branchCode}")]
        public async Task<IActionResult> GetOpStockShortDetailsection1(string productcode, string branchCode)
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
        }

        //stackshort vocherno

        [HttpGet("GetstockshortVoucherNo/{branchCode}")]
        public async Task<IActionResult> GetstockshortVoucherNo(string branchCode)
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
        }

        [HttpPost("RegisterStockshort")]
        public async Task<IActionResult> RegisterStockshort([FromBody]JObject objData)
        {
            APIResponse apiResponse = null;
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var _stockrshortHdr = objData["StockshortHdr"].ToObject<TblStockshortMaster>();
                var _stockshortDtl = objData["StockshortDtl"].ToObject<TblStockshortDetails[]>();

                var result = new StockshortHelpers().RegisterStockshort(_stockrshortHdr, _stockshortDtl.ToList());
                apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPost("GetStockshortsList/{branchCode}")]
        public async Task<IActionResult> GetStockshortsList(string branchCode, [FromBody]VoucherNoSearchCriteria searchCriteria)
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

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No StockshortList record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpGet("GetCostCentersList")]
        public async Task<IActionResult> GetCostCentersList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                 expando.CostCentersList =new StockshortHelpers().GetCostCenters().Select(x => new { ID = x.Code, TEXT = x.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStockshortsDeatilList/{issueNo}")]
        public async Task<IActionResult> GetStockshortsDeatilList(string issueNo)
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
        }

        ////to get the invoice Master data while page load
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
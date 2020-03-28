using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.Sales
{
    [Route("api/transaction/StockTransfer")]
    [ApiController]
    public class StockTransferController : ControllerBase
    {
        [HttpGet("GenerateStockTranfNo/{branchCode}")]
        public async Task<IActionResult> GetSateteList(string branchCode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.SateteList = new StockTransferHelper().GenerateStockTranfNo(branchCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                string message = string.Empty;

                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
            }
        }

        [HttpGet("GetStockTransferDetailsSection/{branchCode}/{productCode}")]
        public async Task<IActionResult> GetStockTransferDetailsSection(string branchCode,string productCode)
        {
            if (string.IsNullOrEmpty(branchCode) || string.IsNullOrEmpty(branchCode))
            {
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Query string paramter missing." });
            }
            try
            {
                var result = new StockTransferHelper().GetStockTransferDetailsSection(branchCode, productCode);
                if (result != null)
                {
                    dynamic expando = new ExpandoObject();
                    expando.SateteList = new StockTransferHelper().GetStockTransferDetailsSection(branchCode, productCode);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No product found for product code. +"+ productCode });
            }
            catch (Exception ex)
            {
                string message = string.Empty;

                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
            }
        }

        [HttpPost("GetStockTransferList/{branchCode}")]
        public async Task<IActionResult> GetStockTransferList(string branchCode,[FromBody]SearchCriteria searchCriteria)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var invoiceMasterList = new StockTransferHelper().GetStockTransferMasters(branchCode,searchCriteria);
                if (invoiceMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.InvoiceList = invoiceMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStockTransferDetilsaRecords/{stockTransferMasterId}")]
        public async Task<IActionResult> GetStockTransferList(string stockTransferMasterId)
        {

            if (stockTransferMasterId == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var invoiceMasterList = new StockTransferHelper().GetStockTransferDetailRecords(stockTransferMasterId);
                if (invoiceMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.InvoiceList = invoiceMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterStockTransfer")]
        public async Task<IActionResult> RegisterStockTransfer([FromBody]JObject objData)
        {
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var _stockTransferMaster = objData["stockTransferMaster"].ToObject<TblStockTransferMaster>();
                var _stockTransferDetail = objData["stockTransferDetail"].ToObject<TblStockTransferDetail[]>();

                var result = new StockTransferHelper().AddStockTransfer(_stockTransferMaster, _stockTransferDetail.ToList());
                if (result)
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = _stockTransferMaster });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
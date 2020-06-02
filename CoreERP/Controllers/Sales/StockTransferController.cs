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
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                try
                {
                    var _stockNo = new StockTransferHelper().GenerateStockTranfNo(branchCode, out errorMessage);
                    if (string.IsNullOrEmpty(_stockNo))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
                    }

                    dynamic expando = new ExpandoObject();
                    expando.SateteList = _stockNo;
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
            });
            return result;
        }

        [HttpPost("GetStockTransferDetailsSection")]
        public async Task<IActionResult> GetStockTransferDetailsSection([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                if (objData == null)
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Rquest is empty." });
                }
                try
                {
                    string branchCode = objData["branchCode"].ToString();
                    string productCode = objData["productCode"].ToString();

                    var result = new StockTransferHelper().GetStockTransferDetailsSection(branchCode, productCode);
                    if (result != null)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.SateteList = new StockTransferHelper().GetStockTransferDetailsSection(branchCode, productCode);
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No product found for product code. +" + productCode });
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
            });
            return result;
        }

        [HttpPost("GetStockTransferList/{branchCode}")]
        public async Task<IActionResult> GetStockTransferList(string branchCode,[FromBody]SearchCriteria searchCriteria)
        {
            var result = await Task.Run(() =>
            {
                if (searchCriteria == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var invoiceMasterList = new StockTransferHelper().GetStockTransferMasters(branchCode, searchCriteria);
                    if (invoiceMasterList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.InvoiceList = invoiceMasterList.OrderByDescending(x => x.ServerDateTime);
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

        [HttpGet("GetStockTransferDetilsaRecords/{stockTransferMasterId}")]
        public async Task<IActionResult> GetStockTransferList(string stockTransferMasterId)
        {
            var result = await Task.Run(() =>
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
            });
            return result;
        }

        [HttpPost("RegisterStockTransfer")]
        public async Task<IActionResult> RegisterStockTransfer([FromBody]JObject objData)
        {
            var result = await Task.Run(() =>
            {
                if (objData == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
                try
                {
                    var _stockTransferMaster = objData["stockTransferMaster"].ToObject<TblStockTransferMaster>();
                    var _stockTransferDetail = objData["stockTransferDetail"].ToObject<TblStockTransferDetail[]>();

                    if (_stockTransferMaster == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No request records found to Save" });
                    }

                    if (_stockTransferDetail == null || _stockTransferDetail.Count() == 0)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "In request no product found in to save" });
                    }

                    if (string.IsNullOrEmpty(_stockTransferMaster.StockTransferNo))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Stock transfer no canontbe null/empty." });
                    }
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
            });
            return result;
        }
    }
}
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
    [Route("api/Transactions/Oilconversion")]
    [ApiController]
    public class OilconversionController : ControllerBase
    {


        [HttpGet("GetProductLists/{productCode}/{branchCode}")]
        public async Task<IActionResult> GetOpStockShortDetailsection1(string productcode, string branchCode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.productsList = new OilconversionHelper().GetoilconversionDetailsection(productcode, branchCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        //oilconversionVoucherNo
        [HttpGet("GetoilconversionVoucherNo/{branchCode}")]
        public async Task<IActionResult> GetoilconversionVoucherNo(string branchCode)
        {
            if (string.IsNullOrEmpty(branchCode))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

            try
            {
                dynamic expando = new ExpandoObject();
                expando.oilconversionVoucherNo = new OilconversionHelper().GetoilconversionVoucherNo(branchCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterOilconversion")]
        public async Task<IActionResult> RegisterOilconversion([FromBody]JObject objData)
        {
            APIResponse apiResponse = null;
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var _oilcovrsnHdr = objData["OilcnvsHdr"].ToObject<TblOilConversionMaster>();
                var _oilcovrsnDtl = objData["OilcnvsDtl"].ToObject<TblOilConversionDetails[]>();

                var result = new OilconversionHelper().RegisterBill(_oilcovrsnHdr, _oilcovrsnDtl.ToList());

                apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("GetOilconversionList")]
        public async Task<IActionResult> GetOilconversionList([FromBody]SearchCriteria searchCriteria)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var oilconversionList = new OilconversionHelper().GetOilConversionMasters(searchCriteria);
                if (oilconversionList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.oilconversionsList = oilconversionList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No StockreceiptsList record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetOilconversionsDeatilList/{issueNo}")]
        public async Task<IActionResult> GetOilconversionsDeatilList(string issueNo)
        {

            if (string.IsNullOrEmpty(issueNo))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var OilconversionsDeatilList = new OilconversionHelper().OilconversionsDeatilList(issueNo);
                if (OilconversionsDeatilList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.OilconversionsDeatilList = OilconversionsDeatilList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No StockshortsDeatilList record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
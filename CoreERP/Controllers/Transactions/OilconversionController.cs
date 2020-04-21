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
                string errorMessage = string.Empty;
                dynamic expando = new ExpandoObject();
                expando.oilconversionVoucherNo = new OilconversionHelper().GetoilconversionVoucherNo(branchCode, out errorMessage);
                if(expando.oilconversionVoucherNo != null)
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "oilconversionVoucherNo Empty." });


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

        [HttpPost("GetOilconversionList/{branchCode}")]
        public async Task<IActionResult> GetOilconversionList(string branchCode, [FromBody]VoucherNoSearchCriteria searchCriteria)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var oilconversionList = new OilconversionHelper().GetOilConversionMasters(searchCriteria,branchCode);
                if (oilconversionList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.oilconversionsList = oilconversionList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No oilconversionList record found." });
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

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No oilconversionList record found." });
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
                var oilcnvsnDetails = new OilconversionHelper().GetInvoiceList(searchCriteria.Role, branchCode);
                if (oilcnvsnDetails.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.OilconversionsDeatilList = oilcnvsnDetails;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "oilconversionList records not found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [Route("api/BillOfMaterial")]
    [ApiController]
    public class BillOfMaterialController : ControllerBase
    {
        [HttpPost("GetBOMMasters")]
        public IActionResult GetBOMMasters([FromBody] SearchCriteria searchCriteria)
        {
            try
            {
                var bomMasters = new TransactionsHelper().GetBOMMasters(searchCriteria);
                if (!bomMasters.Any())
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for cash bank." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.bomMasters = bomMasters;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBomDetail/{bomNumber}")]
        public IActionResult GetBomDetail(string bomNumber)
        {
            try
            {
                var transactions = new TransactionsHelper();
                var bomMasters = transactions.GetBommasterById(bomNumber);
                if (bomMasters == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.bomMasters = bomMasters;
                expdoObj.bomDetail = new TransactionsHelper().GetlBomDetails(bomNumber);
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("AddBOM")]
        public IActionResult AddBOM([FromBody] JObject obj)
        {
            try
            {
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                var bomMaster = obj["bomHdr"].ToObject<TbBommaster>();
                var bomDetails = obj["bomDtl"].ToObject<List<TblBomDetails>>();

                if (!new TransactionsHelper().AddBOM(bomMaster, bomDetails))
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.bomMaster = bomMaster;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("ReturnBOM/{bomNumber}")]
        public IActionResult ReturnBOM(string bomNumber)
        {
            try
            {
                var result = new TransactionsHelper().ReturnBommaster(bomNumber);
                if (result)
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = "Return Successfully..." });

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "error while returning cash bank.." });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
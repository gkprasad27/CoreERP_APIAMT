using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/CardType")]
    public class CardTypeController : ControllerBase
    {

        [HttpGet("GetcardtypeList")]
        public IActionResult GetcardtypeList()
        {
            try
            {
                var cardTypeList = BillingHelpers.GetCardTypeList();
                if (cardTypeList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.cardtype = BillingHelpers.GetCardTypeList();
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLAccountsList/{accountType}")]
        public IActionResult GetGLAccountsList(string accountType)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.accounts = BillingHelpers.GetGlAccountsDRCR(accountType).Select(gl => new { ID = gl.Glcode, Text = gl.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTypeList")]
        public IActionResult GetTypeList(string accountType)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.typeList = BillingHelpers.GetTypesList().Select(x => new { ID = x, Text = x });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterCardType")]
        public IActionResult RegisterCardType([FromBody]CardType cardType)
        {

            if (cardType == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(cardType)} cannot be null" });
            try
            {
                var reponse = BillingHelpers.RegisterCardType(cardType);
                if (reponse != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = reponse });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateCardType")]
        public IActionResult UpdateCardType([FromBody] CardType cardtype)
        {
            if (cardtype == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(cardtype)} cannot be null" });
            try
            {
                var response = BillingHelpers.UpdateCardType(cardtype);
                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCardType/{code}")]
        [Produces(typeof(CardType))]
        public IActionResult DeleteCardType(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });
            try
            {
                var response = BillingHelpers.DeleteCardType(code);
                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
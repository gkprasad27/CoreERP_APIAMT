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
        public async Task<IActionResult> GetcardtypeList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.cardtype = BillingHelpers.GetCardTypeList();

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch(Exception ex)
            {

            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load Card Types." });

        }

        [HttpGet("GetGLAccountsList")]
        public async Task<IActionResult> GetGLAccountsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.accounts = BillingHelpers.GetGlAccountsDRCR();

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex) { }

            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load GL Accounts." });
        }

        [HttpPost("RegisterCardType")]
        public async Task<IActionResult> RegisterCardType([FromBody]CardType cardType)
        {

            if (cardType == null)
                return BadRequest($"{nameof(cardType)} cannot be null");
            try
            {
                var reponse = BillingHelpers.RegisterCardType(cardType);
                if (reponse != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = reponse });
            }
            catch (Exception ex) { }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
        }

        [HttpPut("UpdateCardType")]
        public async Task<IActionResult> UpdateCardType([FromBody] CardType cardtype)
        {
            if (cardtype == null)
                return BadRequest($"{nameof(cardtype)} cannot be null");

            try
            {
                var response = BillingHelpers.UpdateCardType(cardtype);
                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch (Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
        }

        [HttpDelete("DeleteCardType/{code}")]
        [Produces(typeof(CardType))]
        public async Task<IActionResult> DeleteCardType(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                var cardtype = BillingHelpers.GetCardTypeList(code);
                cardtype.Active = "N";
                var response = BillingHelpers.UpdateCardType(cardtype);
                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch (Exception ex)
            {
            }

            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
        }
    }
}
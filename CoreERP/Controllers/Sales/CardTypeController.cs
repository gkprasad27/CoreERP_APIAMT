using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/CardType")]
    public class CardTypeController : ControllerBase
    {

        [HttpGet("GetcardtypeList")]
        public async Task<IActionResult> GetcardtypeList()
        {
            return Ok(new { cardtype = BillingHelpers.GetCardTypeList() });

        }

        [HttpGet("GetGLAccountsList")]
        public async Task<IActionResult> GetGLAccountsList()
        {
            return Ok(new { accounts = BillingHelpers.GetGlAccountsDRCR() });
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
                    return Ok(reponse);
            }
            catch (Exception ex) { }
            return BadRequest("Registration Failed");
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
                    return Ok(response);


                return BadRequest("Updation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Updation Failed");
            }
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
                var response = BillingHelpers.UpdateCardType(cardtype);
                if (response != null)
                    return Ok(response);
                return Ok(cardtype);

            }
            catch (Exception ex)
            {
                return BadRequest($"Delete Operation Failed");
            }
        }
    }
}
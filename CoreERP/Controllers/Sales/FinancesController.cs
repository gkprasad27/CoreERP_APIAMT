using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/Finances")]
    public class FinancesController : ControllerBase
    {
        
        [HttpGet("GetFinanceList")]
        public async Task<IActionResult> GetFinanceList()
        {
            return Ok(new {financeslist =BillingHelpers.GetFinances()}); 
        }

        [HttpGet("GetFinancesCutomerGLAccounts")]
        public async Task<IActionResult> GetFinancesCutomerGLAccounts()
        {
            try { return Ok(new { glacccts = BillingHelpers.GetFinancesCutomerGLAccounts() }); }
            catch { }
            return NoContent();
        }

        [HttpGet("GetBrandList")]
        public async Task<IActionResult> GetBrandList()
        {
            try { return Ok(new { brandList = BillingHelpers.GetBrandList() }); }
            catch { }
            return NoContent();
        }

        [HttpGet("GetBrandModelList")]
        public async Task<IActionResult> GetBrandModelList()
        {
            try { return Ok(new { brandModelList = BillingHelpers.GetBrandModelList() }); }
            catch { }
            return NoContent();
        }




        [HttpPost("RegisterFiances")]
        public async Task<IActionResult> RegisterFiances([FromBody]Finance finances)
        {

            if (finances == null)
                return BadRequest($"{nameof(finances)} cannot be null");
            try
            {
                var response = BillingHelpers.RegisterFiances(finances);

                if (response != null)
                    return Ok(finances);

                return BadRequest("Registration Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Registration Failed");
            }
        }



        [HttpPut("UpdateFinance")]
        public async Task<IActionResult> UpdateFinance([FromBody] Finance finances)
        {
            if (finances == null)
                return BadRequest($"{nameof(finances)} cannot be null");

            try
            {
                var response = BillingHelpers.UpdateFinance(finances);
                if (response != null)
                    return Ok(response);

                return BadRequest("Updation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Updation Failed");
            }
        }



        [HttpDelete("DeleteFinance/{code}")]
        [Produces(typeof(Finance))]
        public async Task<IActionResult> DeleteFinance(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                var financeEntity = BillingHelpers.GetFinances(code);
                financeEntity.Active = "N";
                var reposne = BillingHelpers.UpdateFinance(financeEntity);
                if (reposne != null)
                    return Ok(reposne);
                return BadRequest($"Delete Operation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Delete Operation Failed");
            }

        }
    }
}


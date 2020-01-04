using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/Finances")]
    public class FinancesController : ControllerBase
    {
        
        [HttpGet("GetFinanceList")]
        public async Task<IActionResult> GetFinanceList()
        {
            APIResponse apiResponse = null;
            try
            {
                dynamic expando = new ExpandoObject();
                expando.financeslist = BillingHelpers.GetFinances();

                return Ok(apiResponse = new APIResponse() { status = APIStatus.PASS.ToString() ,response= expando });
            }
            catch(Exception ex)
            {
                return Ok(apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load finance list." });
            }
        }

        [HttpGet("GetFinancesCutomerGLAccounts")]
        public async Task<IActionResult> GetFinancesCutomerGLAccounts()
        {
           
            try
            {
                APIResponse apiResponse = null;
                dynamic expando = new ExpandoObject();
                expando.glaccts = BillingHelpers.GetFinancesCutomerGLAccounts();

                return Ok(apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch { }
            return  Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load finance GL Accounts list." });
        }

        [HttpGet("GetBrandList")]
        public async Task<IActionResult> GetBrandList()
        {
            try 
            {
                dynamic expando = new ExpandoObject();
                expando.brandList = BillingHelpers.GetBrandList();

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch { }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load Brand list." });
        }

        [HttpGet("GetBrandModelList")]
        public async Task<IActionResult> GetBrandModelList()
        {
            try 
            {
                dynamic expando = new ExpandoObject();
                expando.brandModelList = BillingHelpers.GetBrandModelList();
             
                return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= expando }); 
            }
            catch { }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load Brand model list." });
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
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch (Exception ex)
            {
            }

            return Ok( new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
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
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch (Exception ex)
            {
            }

            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
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
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = reposne });
            }
            catch (Exception ex)
            {
            }

            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
        }
    }
}


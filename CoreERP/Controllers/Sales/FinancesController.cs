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
        public IActionResult GetFinanceList()
        {
            APIResponse apiResponse;
            try
            {
                var financeList = BillingHelpers.GetFinances();
                if (financeList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.financeslist = financeList;
                    return Ok(apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetFinancesCutomerGLAccounts")]
        public IActionResult GetFinancesCutomerGLAccounts()
        {

            try
            {
                dynamic expando = new ExpandoObject();
                expando.glaccts = BillingHelpers.GetFinancesCutomerGLAccounts();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBrandList")]
        public IActionResult GetBrandList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.brandList = BillingHelpers.GetBrandList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        //[HttpGet("GetBrandModelList")]
        //public async Task<IActionResult> GetBrandModelList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.brandModelList = BillingHelpers.GetBrandModelList();
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpPost("RegisterFiances")]
        public IActionResult RegisterFiances([FromBody]Finance finances)
        {
            if (finances == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(finances)} cannot be null" });
            try
            {
                var response = BillingHelpers.RegisterFiances(finances);

                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateFinance")]
        public IActionResult UpdateFinance([FromBody] Finance finances)
        {
            if (finances == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(finances)} cannot be null" });

            try
            {
                var response = BillingHelpers.UpdateFinance(finances);
                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch (Exception )
            {
            }

            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
        }

        [HttpDelete("DeleteFinance/{code}")]
        [Produces(typeof(Finance))]
        public IActionResult DeleteFinance(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                var reposne = BillingHelpers.DeleteFinance(code);
                if (reposne != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = reposne });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }
    }
}


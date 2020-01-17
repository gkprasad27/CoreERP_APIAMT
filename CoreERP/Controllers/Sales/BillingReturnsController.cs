using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/BillingReturns")]
    public class BillingReturnsController : ControllerBase
    {

        [HttpGet("GetBill/{id}")]
        public async Task<IActionResult> GetBill(string id)
        {
            try
            {
                var isBillReturn = BillingHelpers.IsBillExistsInBillReturns(id);
                if (isBillReturn)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Bill no {id} Already return." });

                dynamic expando = new ExpandoObject();
                expando.billings = BillingHelpers.GetBilling(id);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpPost("RegisterBillingReturn")]
        public async Task<IActionResult> RegisterBillingReturn([FromBody]BillingReturns[] billing)
        {

            if (billing == null || billing?.Count() == 0)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(billing)}object can not be null." });
            try
            {
                var result = BillingHelpers.RegisterBillingReturns(billing);

                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Bills returns Failed to return." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}
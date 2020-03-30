using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.transactionsHelpers;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.Transactions
{
    [ApiController]
    [Route("api/transactions/StockExcess")]
    public class StockExcessController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new StockExcessHelper().GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetCostCentersList")]
        public async Task<IActionResult> GetCostCentersList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.CostCentersList = new StockExcessHelper().GetCostCentersList().Select(x => new { ID = x.Name, TEXT = x.Name });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

    }
}
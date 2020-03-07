using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.TransactionsHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.Transactions
{
    [Route("api/Transactions/Stockreceipt")]
    [ApiController]
    public class StockreceiptController : ControllerBase
    {
        [HttpGet("GetStockreceiptList")]
        public async Task<IActionResult> GetStockreceiptList()
        {
            try
            {
                var stockreceiptList = new StockreceiptHelpers().GetStockreceiptList();
                if (stockreceiptList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.stockreceiptList = stockreceiptList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetbranchcodeList/{branchcode}")]
        public async Task<IActionResult> GetbranchcodeList(string branchcode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.branch =new StockreceiptHelpers().Getbranchcodes(branchcode).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetReceiptNo/{branchcode}")]
        public async Task<IActionResult> GetReceiptNo(string branchcode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                var vocherno =new StockreceiptHelpers().GetReceiptNo(branchcode);
                expando.vochernos = vocherno;
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
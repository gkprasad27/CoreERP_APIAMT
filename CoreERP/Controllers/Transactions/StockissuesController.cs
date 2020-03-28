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
    [Route("api/Transactions/Stockissues")]
    [ApiController]
    public class StockissuesController : ControllerBase
    {
        [HttpGet("GetStockissuesList")]
        public async Task<IActionResult> GetStockissuesList()
        {
            try
            {
                var stockissuesList =new StockissuesHelper().GetStockissuesList();
                if (stockissuesList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.stockissuesList = stockissuesList;
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
                expando.branch =new StockissuesHelper().Getbranchcodes(branchcode).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetIssueNo/{branchcode}")]
        //public async Task<IActionResult> GetIssueNo(string branchcode)
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        var vocherno =new StockissuesHelper().GetIssueNo(branchcode);
        //        expando.vochernos = vocherno;
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}
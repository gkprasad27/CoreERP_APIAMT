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
    [Route("api/Transactions/Stockshort")]
    [ApiController]
    public class StockshortController : ControllerBase
    {
        [HttpGet("GetStockshortsList")]
        public async Task<IActionResult> GetStockshortsList()
        {
            try
            {
                var stockList =new StockshortHelpers().GetStockshortsList();
                if (stockList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.stockshortList = stockList;
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
                expando.branch =new StockshortHelpers().Getbranchcodes(branchcode).Select(bc => new { ID = bc.BranchCode });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGetVoucherNo/{branchcode}")]
        public async Task<IActionResult> GetGetVoucherNo(string branchcode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                var vocherno =new StockshortHelpers().GetVoucherNo(branchcode);
                expando.vochernos = vocherno;
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCostCentersList")]
        public async Task<IActionResult> GetCostCentersList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CostCentersList =new StockshortHelpers().GetCostCenters().Select(x => new { ID = x.Code, TEXT = x.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


    }
}
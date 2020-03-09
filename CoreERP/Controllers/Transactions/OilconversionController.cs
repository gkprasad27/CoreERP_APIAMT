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
    [Route("api/Transactions/Oilconversion")]
    [ApiController]
    public class OilconversionController : ControllerBase
    {
        [HttpGet("GetOilconversionList")]
        public async Task<IActionResult> GetOilconversionList()
        {
            try
            {
                var oilconvrsionList =new OilconversionHelper().GetOilconversionList();
                if (oilconvrsionList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.oilconvrsionList = oilconvrsionList;
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
                expando.branch =new OilconversionHelper().Getbranchcodes(branchcode).Select(bc => new { ID = bc.BranchCode });
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
                var vocherno =new OilconversionHelper().GetVoucherNo(branchcode);
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
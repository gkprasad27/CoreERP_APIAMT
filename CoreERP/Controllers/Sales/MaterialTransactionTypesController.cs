using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.SalesHelper;
using System.Dynamic;
using CoreERP.DataAccess;
using CoreERP.Models;
using System.Linq;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/MaterialTransTypes")]
    public class MaterialTransactionTypesController : ControllerBase
    {
        [HttpGet("GetMatTranTypesList")]
        public IActionResult GetMatTranTypesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.materialtratypes = BillingHelpers.GetMatTranTypesList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBranchesList")]
        public IActionResult GetBranchesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.branchesList = BillingHelpers.GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTransTypesList")]
        public IActionResult GetTransTypesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.branchesList = BillingHelpers.GetTransTypesList().Select(x => new { ID = x, TEXT = x });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterMatTransType")]
        public IActionResult RegisterMatTransType([FromBody]MatTranTypes mattrantypes)
        {

            if (mattrantypes == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(mattrantypes)} cannot be null" });
            try
            {

                var response = BillingHelpers.RegisterMatTransType(mattrantypes);
                if (response != null)
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMatTranTypes")]
        public IActionResult UpdateMatTranTypes([FromBody] MatTranTypes mattrantype)
        {
            if (mattrantype == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(mattrantype)} cannot be null" });
            try
            {
                var result = BillingHelpers.UpdateMatTransType(mattrantype);
                if (result != null)
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMatTranTypes/{seqid}")]
        [Produces(typeof(BillingNoSeries))]
        public IActionResult DeleteMatTranTypes(string seqid)
        {
            if (seqid == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(seqid)}can not be null" });
            try
            {
                var result = BillingHelpers.DeleteMatTransType(Convert.ToInt32(seqid));
                if (result != null)
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
                }
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Deletion Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = ex.Message });
            }
        }
    }
}